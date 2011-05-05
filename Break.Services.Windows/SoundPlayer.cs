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


        // Events
        //

        public event SoundPlaybackEnded SoundPlaybackEnded;

        private void InternalSoundPlaybackEnded( object sender, EventArgs e ) {
            _isPlaybackEnded = true;
            OnSoundPlaybackEnded();
        }

        protected void OnSoundPlaybackEnded() {
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
            _player.Open( this.SoundFile );

            _isPlaybackEnded = false;

            _player.Play();
        }
        
        public void Stop() {
            _player.Stop();

            _isPlaybackEnded = true;
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
