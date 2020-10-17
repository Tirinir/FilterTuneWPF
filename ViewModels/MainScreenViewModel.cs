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
        public SourceFilters ViewFilters { get; set; }
        public TemplateViewModel ChosenTemplate
        {
            get => chosenTemplate; set
            {
                chosenTemplate = value;
                NotifyPropertyChanged("ChosenTemplate");
            }
        }
        public string NewFilterName { get; set; }
        public ICommand SaveFilterCommand { get; set; }
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
        private void SaveFilter()
        {
            //System.Windows.Media.Color x = (System.Windows.Media.Color)s;
            NewFilterName = "Black";
            NotifyPropertyChanged("NewFilterName");
        }
        private ObservableCollection<TemplateViewModel> MockSavedTemplates { get; set; }
        public void SaveTemplate() //update Templates with NewTemplateName value of chosenTemplate
        {
            Templates.Add(new TemplateViewModel(chosenTemplate.Selectors, chosenTemplate.Parameters, chosenTemplate.NewTemplateName));//TODO check if it's an old template; provide the choice to overwrite or add new
        }
        public void RemoveTemplate(TemplateViewModel TemplateToRemove) 
        {
            Templates.Remove(TemplateToRemove);
        }
        public MainScreenViewModel() //Initializing variables for main screen
        {
            SaveFilterCommand = new GenericCommand(x => SaveFilter());
            Templates = LoadTemplates(5);
            ChosenTemplate = Templates[0];
            MockSavedTemplates = LoadTemplates(5);
            ViewFilters = new SourceFilters();
            SaveTemplateCommand = new GenericCommand(x => SaveTemplate());
        }
    }
}
