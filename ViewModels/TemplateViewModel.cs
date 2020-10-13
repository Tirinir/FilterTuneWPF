using System;
using System.Collections.Generic;
using System.Text;

namespace FilterTuneWPF
{
    class TemplateViewModel : Notifier
    {
        public TemplateViewModel(string selectors, string parameters, string templateName = "New template")
        {
            Selectors = selectors;
            Parameters = parameters;
            TemplateName = templateName;
        }
        public bool Active { get; set; }
        public string TemplateName { get; set; }
        public string Selectors { get; set; }
        public string Parameters { get; set; }
    }
}
