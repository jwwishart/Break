﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.IO;
using Break.Core;

namespace Break
{
    public partial class Preferences : Form
    {
        // Private Members
        //

        private ISoundPlayer _soundPlayer = null;


        // Constructors
        //

        public Preferences() {
            InitializeComponent();
        }
        

        // Form Events
        //

        private void Preferences_Load( object sender, EventArgs e ) {
            this.Icon = Break.Properties.Resources.Break_Icon;

            this.ofdBreakSound.InitialDirectory = Environment.GetFolderPath( Environment.SpecialFolder.MyMusic );
            this.ofdBreakSound.Filter = ServiceLocator.GetSoundPlayer().FileFilter;

            LoadSettings();
        }

        private void lnkPlaySound_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e ) {
            // TODO: Test for file existence
            // TODO: Test for exceptions
            // TODO: Run sound playing in a different thread
            // TODO: Provider way to stop the sound from playing.
            // TODO: Avoid issue where person presses play button and causes io exception as another process is using the wav file.

            if ( _soundPlayer == null ) {
                _soundPlayer = ServiceLocator.GetSoundPlayer();
                _soundPlayer.SoundPlaybackEnded += new SoundPlaybackEnded( SoundPlayer_PlaybackEnded );
            }

            if ( _soundPlayer.IsPlaybackEnded ) {    
                if ( cbUseCustomSound.Checked ) {
                    _soundPlayer.SoundFile =
                        new Uri( new FileInfo( txtBreakSound.Text ).FullName );
                } else {
                    // Kudos: DefaultSound  http://www.freesound.org/samplesViewSingle.php?id=118648
                    _soundPlayer.SoundFile =
                        new Uri( new FileInfo( "DefaultSound.wav" ).FullName );
                }

                _soundPlayer.Play();
                lnkPlaySound.Text = "Stop Sound";
            } else {
                StopPlayingSound();
            }
        }

        void SoundPlayer_PlaybackEnded( object sender, EventArgs e ) {
            lnkPlaySound.Text = "Play Sound";
        }

        private void txtBreakSound_TextChanged( object sender, EventArgs e ) {
            if ( File.Exists( txtBreakSound.Text ) ) {
                txtBreakSound.BackColor = Color.LightGreen;
            } else {
                txtBreakSound.BackColor = Color.Pink;
            }
        }

        private void cbUseCustomSound_CheckedChanged( object sender, EventArgs e ) {
            SetupSoundSelection();
        }

        private void btnBrowse_Sound_Click( object sender, EventArgs e ) {
            DialogResult result = ofdBreakSound.ShowDialog();

            if ( result == System.Windows.Forms.DialogResult.OK ) {
                txtBreakSound.Text = ofdBreakSound.FileName;
            }
        }

        private void btnCancel_Click( object sender, EventArgs e ) {
            StopPlayingSound();
        }

        private void btnOk_Click( object sender, EventArgs e ) {
            // TODO: Validate that the sound file exists
            StopPlayingSound();
            SaveSettings();
            this.Close();
        }


        // Private Methods
        //

        private void StopPlayingSound() {
            if (_soundPlayer != null)
                _soundPlayer.Stop();
            lnkPlaySound.Text = "Play Sound";
        }

        private void SetupSoundSelection( ) {
            txtBreakSound.Enabled = cbUseCustomSound.Checked;
            btnBrowse_Sound.Enabled = cbUseCustomSound.Checked;
        }

        private void SaveSettings() {
            // Break Sound
            Properties.Settings.Default.UseCustomSound = cbUseCustomSound.Checked;

            if ( cbUseCustomSound.Checked )
                Properties.Settings.Default.BreakSoundFile =
                    txtBreakSound.Text;

            // Work Duration
            Properties.Settings.Default.WorkDurationMinutes =
                nudWorkDuration.Value;

            // Break Duration
            Properties.Settings.Default.BreakDurationMinutes =
                nudBreakDuration.Value;

            Properties.Settings.Default.Save();
        }

        private void LoadSettings() {
            // Break Sound
            cbUseCustomSound.Checked = Properties.Settings.Default.UseCustomSound;

            SetupSoundSelection();

            if ( cbUseCustomSound.Checked )
                txtBreakSound.Text = Properties.Settings.Default.BreakSoundFile;

            // Work Duration
            nudWorkDuration.Value
                = Properties.Settings.Default.WorkDurationMinutes;

            // Break Duration
            nudBreakDuration.Value
                = Properties.Settings.Default.BreakDurationMinutes;
        }

    }
}
