using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Break.Core
{
    /// <summary>
    /// Represents information about the systems last use by the current user and uptime of the system.
    /// </summary>
    public sealed class LastInputInfo
    {
        /// <summary>
        /// Gets or sets the number of ticks that the system has been up for
        /// </summary>
        /// <remarks>1 Tick is 1000ths of a second</remarks>
        public int SystemUptimeTicks { get; set; }

        /// <summary>
        /// Gets or sets the tick at which the system last had user input
        /// in the current users session
        /// </summary>
        /// <remarks>1 Tick is 1000th of a second and will be a number smaller than 
        /// the number of total system ticks given in SystemUptimeTicks.</remarks>
        public int LastInputTicks { get; set; }

        /// <summary>
        /// Gets the number of ticks since the last user input
        /// </summary>
        /// <remarks>This is SystemUptimeTicks - LastInputTicks. 1 Tick is 1000th of a second.</remarks>
        public int IdleTimeTicks {
            get {
                return SystemUptimeTicks - LastInputTicks;
            }
        }

        /// <summary>
        /// Gets a <see cref="TimeSpan"/> which represents the duration of time since the system last
        /// has input.
        /// </summary>
        public TimeSpan IdleTimeSpan {
            get {
                // Not a system tick is 1000th of a second, but TimeSpan ticks is
                // measured in 100 nano-seconds, thus we multiply the IdleTimeTicks
                // by 10000 to get TimeSpan style ticks
                return new TimeSpan( IdleTimeTicks * 10000 );
            }
        }

    }
}
