using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Break.Core;
using System.Runtime.InteropServices;

namespace Break.Services
{
    // Kudos: http://www.geekpedia.com/tutorial210_Retrieving-the-Operating-System-Idle-Time-Uptime-and-Last-Input-Time.html
    public class SystemUseService : ISystemUseService
    {
        // Interface Implementation
        //

        public LastInputInfo IdleInformation {
            get {
                // TODO: We need to figure out whether this is upset by things like media centre?
                LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
                lastInputInfo.cbSize = (uint)Marshal.SizeOf( lastInputInfo );
                lastInputInfo.dwTime = 0;

                if ( GetLastInputInfo( ref lastInputInfo ) ) {
                    LastInputInfo info = new LastInputInfo();
                    info.SystemUptimeTicks = Environment.TickCount;
                    info.LastInputTicks = (int)lastInputInfo.dwTime;
                    return info;
                }

                // TODO: Consider a better error :)
                throw new SystemException( "WOOPS. Can't get LastInputTime" );
            }
        }


        // External Methods
        //

        // TODO: Limits to Windows 2000 Professional as the oldest version of windows that this program will run on.
        [DllImport( "User32.dll" )]
        private static extern bool
            GetLastInputInfo( ref LASTINPUTINFO plii );


        // Structures
        //

        internal struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

    }
}



