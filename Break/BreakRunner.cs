using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Break.Core;
using System.Diagnostics;

namespace Break
{
    public class BreakRunner
    {
        private static readonly BreakRunner _runner = new BreakRunner();
        private Preferences preferencesForm = null;
        private NotifyIcon _icon = null;
        private Timer _timer = new Timer();
        
        private int track_startTime = 0;
        private int track_workDurationCompletedCount = 0;


        public static BreakRunner GetInstance() {
            return _runner;
        }

        private BreakRunner() {
            // http://msdn.microsoft.com/en-us/library/system.windows.forms.notifyicon.aspx
            _icon = new NotifyIcon( );
            _icon.Icon = Break.Properties.Resources.Break_Icon;
            _icon.Visible = true;

            // Context Menu
            _icon.ContextMenu = new ContextMenu( new MenuItem [] {
                new MenuItem("Preferences", new EventHandler(Preferences_Click)),
                new MenuItem("Exit", new EventHandler(Exit_Application_Click)) // TODO: http://www.codeproject.com/KB/cs/NotifyChecker.aspx
            } );
        }

        void Preferences_Click( object sender, EventArgs e ) {
            if ( this.preferencesForm == null )
                this.preferencesForm = new Preferences();

            if ( this.preferencesForm.Visible == false )
                this.preferencesForm.ShowDialog();
        }

        void Exit_Application_Click( object sender, EventArgs e ) {
            _icon.Visible = false; // Instantly Removes the icon from the notification bar (http://www.codeproject.com/KB/cs/NotifyChecker.aspx comment "A little improvement"
            Application.Exit();
        }

        public void Start() {
            _timer.Enabled = true;
            _timer.Interval = Properties.Settings.Default.TimerIntervalMilliseconds;
            _timer.Tick += new EventHandler( Timer_Ticked );
            _timer.Start();
        }

        void Timer_Ticked( object sender, EventArgs e ) {
            var useService = ServiceLocator.GetSystemUseService();

            // Track Working Time
            //

            if ( track_startTime == 0 )
                track_startTime = useService.IdleInformation.SystemUptimeTicks;

            var ticksSinceStart = Environment.TickCount - track_startTime;
            var workedMinutes = (ticksSinceStart / 1000 / 60);

            if ( workedMinutes >= (int)Properties.Settings.Default
                .WorkDurationMinutes ) 
            {
                track_workDurationCompletedCount += 1;

                // Reset the ticksSinceStart
                track_startTime = useService.IdleInformation.SystemUptimeTicks;

                // Play sound N number of times
                PlaySound();
            }

            // Track Idle Time
            //

            if ( (int)Properties.Settings.Default.BreakDurationMinutes
                <= useService.IdleInformation.IdleTimeTicks / 1000 / 60 ) {
                    track_startTime = Environment.TickCount;
                    track_workDurationCompletedCount = 0;
            }

        
            // NOTE: Below is Statistics Code for Testing - DONT REMOVE
            var info = useService.IdleInformation;
            Console.WriteLine( "       Idle Minutes: {0} mins", (info.IdleTimeTicks / 1000 / 60) );
            Console.WriteLine( "System Uptime Ticks: {0} ticks", info.SystemUptimeTicks );
            Console.WriteLine( "   Last Input Ticks: {0} ticks", info.LastInputTicks);
            Console.WriteLine( "    Idle Time Ticks: {0} ticks", info.IdleTimeTicks);
            Console.WriteLine( "      Logging Start: {0} ticks", track_startTime );
            Console.WriteLine( "Work Duration Count: {0} ticks", track_workDurationCompletedCount );
            Console.WriteLine( " --- " );
        }

        public void Stop() {
            _timer.Stop();
            _timer.Enabled = false;
        }

        private void PlaySound() {
            var soundService = ServiceLocator.GetSoundPlayer();
            soundService.SoundFile = new Uri( new FileInfo( "DefaultSound.wav" ).FullName );
            // TODO: setup configuration of sound file above for different...
            // available options
            soundService.Play(track_workDurationCompletedCount);
        }

    }
}
