using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Break.Core;
using System.Reflection;
using System.IO;

namespace Break
{
    internal class ServiceLocator
    {
        private static Assembly _soundSystem;

        internal static ISoundPlayer GetSoundPlayer() {
            string path = new FileInfo("Break.Services.Windows.dll").FullName;

            if (_soundSystem == null)
                _soundSystem = Assembly.LoadFile( path );

            return (ISoundPlayer)_soundSystem.CreateInstance( "Break.Services.SoundPlayer", true );
        }

        internal static ISystemUseService GetSystemUseService() {
            string path = new FileInfo( "Break.Services.Windows.dll" ).FullName;

            if ( _soundSystem == null )
                _soundSystem = Assembly.LoadFile( path );

            return (ISystemUseService)_soundSystem.CreateInstance( "Break.Services.SystemUseService", true );
        }
    }
}
