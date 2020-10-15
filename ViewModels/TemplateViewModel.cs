﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FilterTuneWPF
{
    class TemplateViewModel : Notifier // Templates and their metadata for presentation to the user
    {
        public TemplateViewModel(string selectors, string parameters, string templateName = "New template")
        {
            Selectors = selectors;
            Parameters = parameters;
            TemplateName = templateName;
            NewTemplateName = templateName;
        }
        public bool Active { get; set; }
        public string TemplateName { get; set; }
        public string Selectors { get; set; }
        public string Parameters { get; set; }
        public string NewTemplateName { get; set; }
    }
}
