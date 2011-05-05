using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Break.Core
{
    /// <summary>
    /// Represents a service used to get system information regarding
    /// the time of the last user input. This service is used to
    /// retrieve relevant information so that a notification can be 
    /// given to the user at the appropriate durations.
    /// </summary>
    public interface ISystemUseService
    {
        /// <summary>
        /// Gets information about the systems uptime and the last time the 
        /// user used the keyboard/mouse.
        /// </summary>
        LastInputInfo IdleInformation { get; }
    }
}
