using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

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
            _timer.Interval = Properties.Settings.Default.TimerInterval;
            _timer.Tick += new EventHandler( Timer_Ticked );
            _timer.Start();
        }

        void Timer_Ticked( object sender, EventArgs e ) {
            var useService = ServiceLocator.GetSystemUseService();
            var systemTicks = useService.IdleInformation.SystemUptimeTicks;

            if ( track_startTime == 0 )
                track_startTime = systemTicks; 

            /*
             * track_startTime : ticks that the user started the program
             *    or when the system was reset
             * track_workDurationCompletedCount : counts the number of
             *    times that the use has completed a full hour(for example)
             *    without having a break. If they do two hours then this
             *    number would equal 2
             *    
             * Every Timer Ticked: 
             *   1. Check whether user has gone over their work 
             *      duration. Increment track_workDurationCompletedCount 
             *      and play sound that many times
             *   2. Check whether the user has been idle for the
             *      specified break duration (ex 5 mins) and if they h
             *      have then reset ALL 3 settings above.
             * 
             * We need to track the following:
             * 1. How long the user has been using the system for
             *    If this goes over BreakMintues then sound dong (increment
             *    number of times over BreakMinutes)
             *    if user has been gone for over BreakConsideredDuration
             *    then reset all counts!
             * 2. How long the user has NOT been using the system for
             * 
             * 
             */

            ////var useService = ServiceLocator.GetSystemUseService();
            //if ( (useService.IdleInformation.IdleTimeTicks / 1000 / 60)
            //    >= (int)Properties.Settings.Default.BreakMinutes ) {
            //        PlaySound();
            //}

            var info = useService.IdleInformation;

            // NOTE: Below is Statistics Code for Testing - DONT REMOVE
            //Console.WriteLine( "       Idle Minutes: {0} mins", (info.IdleTimeTicks / 1000 / 60) );
            //Console.WriteLine( "System Uptime Ticks: {0} ticks", info.SystemUptimeTicks );
            //Console.WriteLine( "   Last Input Ticks: {0} ticks", info.LastInputTicks);
            //Console.WriteLine( "    Idle Time Ticks: {0} ticks", info.IdleTimeTicks);
            //Console.WriteLine( " --- " );
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
            soundService.Play();
        }

    }
}
