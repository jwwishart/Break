using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Break.Core;
using System.Windows.Media;

namespace Break.Services
{
    public class SoundPlayer : ISoundPlayer
    {
        // Private Variables
        //

        private MediaPlayer _player;
        private Uri _soundfile;

        private bool _isPlaybackEnded = true;
        private int _noOfTimesToPlay;


        // Events
        //

        public event SoundPlaybackEnded SoundPlaybackEnded;

        private void InternalSoundPlaybackEnded( object sender, EventArgs e ) {
            _noOfTimesToPlay -= 1;

            if ( _noOfTimesToPlay == 0 ) 
                OnSoundPlaybackEnded();
            else
                Play_Internal();
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
                _player = new MediaPlayer();
                _player.MediaEnded += new EventHandler( InternalSoundPlaybackEnded );
            } catch {
                this.Dispose( true );
                throw;
            }
        }


        // Properties
        //

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

        public void Play() {
            Play( 1 );
        }

        public void Play( int noOfTimes ) {
            _noOfTimesToPlay = noOfTimes;

            _player.Open( this.SoundFile );

            Play_Internal();
        }

        private void Play_Internal() {
            this.IsPlaybackEnded = false;

            _player.Play();
        }
        
        public void Stop() {
            _player.Stop();

            OnSoundPlaybackEnded();
        }

        public string FileFilter {
            get {
                return
                    "Wav (*.wav)|*.wav| MP3 (*.mp3)|*.mp3";
            }
        }

        #region "IDisposable"

        private bool _isDisposed;

        public void Dispose() {
            if ( !_isDisposed )
                Dispose( true );
            GC.SuppressFinalize( this );
        }

        private void Dispose( bool disposing ) {
            _isDisposed = true;

            if ( disposing ) {
                _isPlaybackEnded = true;

                _player.Stop();
                _player.MediaEnded -= new EventHandler( InternalSoundPlaybackEnded );
                _player.Close();
                _player = null;
            }
        }

        #endregion

    }
}
