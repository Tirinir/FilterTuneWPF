using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Input;

namespace FilterTuneWPF
{
    class MainScreenViewModel : Notifier
    {
        private TemplateViewModel chosenTemplate;

        public List<TemplateViewModel> Templates { get; set; }
        public TemplateViewModel ChosenTemplate
        {
            get => chosenTemplate; set
            {
                chosenTemplate = value;
                NotifyPropertyChanged("ChosenTemplate");
            }
        }
        public string testString { get; set; }
        public ICommand TestCommand { get; set; }
        public MainScreenViewModel()
        {
            Templates = new List<TemplateViewModel>();
            for (int i = 0; i < 5; i++)
            {
                Templates.Add(new TemplateViewModel($"This is the {i}th selector", $"This is the {i}th parameter", $"Template {i}"));
            }

            TestCommand = new GenericCommand(x => Test());
        }
        private void Test()
        {
            object s = "Black";
            //System.Windows.Media.Color x = (System.Windows.Media.Color)s;
            testString = "Black";
            NotifyPropertyChanged("testString");
        }
    }
}
