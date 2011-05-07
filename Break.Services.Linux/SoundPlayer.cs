using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Break.Core;
using System.Media;

namespace Break.Services
{
    // TODO: Consider http://gstreamer.freedesktop.org/src/gstreamer-sharp/ http://gstreamer.freedesktop.org/ (see above)

    // TODO: Note that linux version will not allow playing multiple times with this as we don't have any feedback about sound finishing.
    public class SoundPlayer : ISoundPlayer
    {
        // Private Variables
        //
        private System.Media.SoundPlayer _player;
        private Uri _soundfile;

        private bool _isPlaybackEnded = true;


        // Events
        //

        // TODO: Note that this is useless on
        public event SoundPlaybackEnded SoundPlaybackEnded;

        private void InternalSoundPlaybackEnded( object sender, EventArgs e ) {
            OnSoundPlaybackEnded();
        }

        protected void OnSoundPlaybackEnded() {
            this.IsPlaybackEnded = true;

            if ( SoundPlaybackEnded != null )
                SoundPlaybackEnded( this, EventArgs.Empty );
        }


        // Constructors
        //

        public SoundPlayer() {
            try {
                _player = new System.Media.SoundPlayer();
            } catch {
                throw;
            }
        }


        // Properties
        //

        public string FileFilter {
            get {
                return
                    "Wav (*.wav)|*.wav| MP3 (*.mp3)|*.mp3";
            }
        }

        public bool IsPlaybackEnded {
            get {
                return _isPlaybackEnded;
            }
            private set {
                _isPlaybackEnded = value;
            }
        }

        public Uri SoundFile {
            get {
                return _soundfile;
            }
            set {
                _soundfile = value;
            }
        }


        // Public Methods
        //

        public void Play() {
            Play( 1 );
        }

        // TODO: Note that this method is useless on Mono :(
        public void Play( int noOfTimes ) {
            _player.SoundLocation = this.SoundFile.ToString();

            Play_Internal();
        }

        public void Stop() {
            _player.Stop();

            OnSoundPlaybackEnded();
        }


        // Private Methods
        //

        private void Play_Internal() {
            this.IsPlaybackEnded = false;

            _player.Play();
        }

    }
}
