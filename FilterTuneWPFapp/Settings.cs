using System;
using System.Collections.Generic;
using System.Text;

namespace FilterTuneWPF
{
    public class Settings
    {
        public Settings(string filterPathSource, string filterPathTarget, string filterFileSource, string filterFileTarget)
        {
            FilterPathSource = filterPathSource;
            FilterPathTarget = filterPathTarget;
            FilterFileSource = filterFileSource;
            FilterFileTarget = filterFileTarget;
        }
        public Settings()
        {
            FilterPathSource = String.Empty;
            FilterPathTarget = String.Empty;
            FilterFileSource = String.Empty;
            FilterFileTarget = String.Empty;
        }
        public string FilterPathSource { get; set; }
        public string FilterPathTarget { get; set; }
        public string FilterFileSource { get; set; }
        public string FilterFileTarget { get; set; }
    }
}
