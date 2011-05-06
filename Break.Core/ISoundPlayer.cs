using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Break.Core
{
    public interface ISoundPlayer
    {
        // Events
        //

        event SoundPlaybackEnded SoundPlaybackEnded;


        // Properties
        //

        Uri SoundFile { get; set; }
        string FileFilter { get; }
        bool IsPlaybackEnded { get ;}
        

        // Methods
        //

        void Play();
        void Play( int noOfTimes );
        void Stop();
    }
}
