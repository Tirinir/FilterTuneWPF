using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace FilterTuneWPF
{
    class MainScreenViewModel : Notifier
    {
        private TemplateViewModel chosenTemplate;

        public ObservableCollection<TemplateViewModel> Templates { get; set; }
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
        public ICommand SaveTemplateCommand { get; set; }
        private ObservableCollection<TemplateViewModel> LoadTemplates(int numberOfTemplates)
        {
            Templates = new ObservableCollection<TemplateViewModel>();
            for (int i = 0; i < numberOfTemplates; i++)
            {
                Templates.Add(new TemplateViewModel($"This is the {i}th selector", $"This is the {i}th parameter", $"Template {i}"));
            }
            return (Templates);
        }
        private void Test()
        {
            //System.Windows.Media.Color x = (System.Windows.Media.Color)s;
            testString = "Black";
            NotifyPropertyChanged("testString");
        }
        private ObservableCollection<TemplateViewModel> MockSavedTemplates { get; set; }
        public void SaveTemplate() //update Templates with NewTemplateName value of chosenTemplate
        {
            Templates.Add(new TemplateViewModel(chosenTemplate.Selectors, chosenTemplate.Parameters, chosenTemplate.NewTemplateName));
            NotifyPropertyChanged("Templates");
        }
        
        public MainScreenViewModel() //Initializing variables for main screen
        {
            TestCommand = new GenericCommand(x => Test());
            Templates = LoadTemplates(5);
            MockSavedTemplates = LoadTemplates(5);
            SaveTemplateCommand = new GenericCommand(x => SaveTemplate());
        }
    }
}
