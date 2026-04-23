#region Using Directives
using System;
using System.Collections.Generic;
#endregion

namespace KeepAliveHD.Database
{
    public class DriveInfo
    {
        #region Members

        public int ID { get; set; }

        public string Drive { get; set; }

        public List<string> VolumeNames { get; set; }

        //public string VolumeName { get; set; }

        /// <summary>
        /// Operation type.
        /// </summary>
        public string Operation { get; set; }

        /// <summary>
        /// Time interval in minutes.
        /// </summary>
        public int TimeInterval { get; set; }

        /// <summary>
        /// Unit of time interval (second, minute, hour).
        /// </summary>
        public string TimeUnit { get; set; }

        /// <summary>
        /// Drive status.
        /// </summary>
        public int Status { get; set; }

        public bool Connected { get; set; }

        public DateTime? NextRunAt { get; set; }

        #endregion
    }
}