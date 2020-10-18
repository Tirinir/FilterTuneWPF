using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Serialization;

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
        public ICommand RemoveTemplateCommand { get; set; }
        public ICommand FilterPathSourceCommand { get; set; }
        private ObservableCollection<TemplateViewModel> LoadTemplates(int numberOfTemplates)
        {
            var templates = new ObservableCollection<TemplateViewModel>();
            for (int i = 0; i < numberOfTemplates; i++)
            {
                templates.Add(new TemplateViewModel($"This is the {i}th selector", $"This is the {i}th parameter", $"Template {i}"));
            }
            return (templates);
        }
        private void SaveFilter()
        {
            NewFilterName = "Black";
            NotifyPropertyChanged("NewFilterName");
        }
        private ObservableCollection<TemplateViewModel> MockSavedTemplates { get; set; }
        public void SaveTemplate() //update Templates with NewTemplateName value of chosenTemplate
        {
            Templates.Add(new TemplateViewModel(chosenTemplate.Selectors, chosenTemplate.Parameters, chosenTemplate.NewTemplateName));//TODO check if it's an old template; provide the choice to overwrite or add new
        }
        public void RemoveTemplate() 
        {
            var result = MessageBox.Show($"Are you sure you want to delete {ChosenTemplate.TemplateName}?", "Deletion confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes) 
            {
                Templates.Remove(ChosenTemplate);
            }           
        }
        Settings FTSettings;
        private string OpenFilterDialogue()
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Filter";
            dlg.DefaultExt = ".filter";
            dlg.Filter = "PoE filter (.filter)|*.filter";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                return (dlg.FileName);
            }
            else
            {
                return "";
            }
        }

        private void RefreshFilterList()
        {
            //uses FTSettings to refresh ViewFilters
            if (Directory.Exists(FTSettings.FilterPathSource))
            {
                string[] getFilters = Directory.GetFiles(FTSettings.FilterPathSource, "*.filter");
                for(int i=0; i<getFilters.Length; i++)
                {
                    getFilters[i] = Path.GetFileNameWithoutExtension(getFilters[i]);
                }
                string selectedFilter = getFilters.Contains(FTSettings.FilterFileSource) ? FTSettings.FilterFileSource : getFilters[0];
                ViewFilters = new SourceFilters(getFilters, selectedFilter);
                NotifyPropertyChanged("ViewFilters");
            }
        }
        private void GetFilterPathSource()
        {
            var getFile = OpenFilterDialogue();
            FTSettings.FilterPathSource = Path.GetDirectoryName(getFile);
            FTSettings.FilterFileSource = Path.GetFileNameWithoutExtension(getFile);
            RefreshFilterList();
            SaveSettings();
        }
        private void GetFilterPathTarget()
        {
            var getFile = OpenFilterDialogue();
            FTSettings.FilterPathTarget = Path.GetDirectoryName(getFile);
            FTSettings.FilterFileTarget = Path.GetFileNameWithoutExtension(getFile);
            SaveSettings();
        }
        private void LoadSettings()
        {
            var XMLSerializer = new XmlSerializer(typeof(Settings));
            using (var fs = File.Open("Settings.xml", FileMode.Open))
            {
                FTSettings=(Settings)XMLSerializer.Deserialize(fs);
            }
            return;
        }
        private void SaveSettings()
        {
            var XMLSerializer = new XmlSerializer(typeof(Settings));
            using (var fs = File.Open("Settings.xml", FileMode.Create))
            {
                XMLSerializer.Serialize(fs, FTSettings);
            }

        }
        public MainScreenViewModel() //Initializing variables for main screen
        {
            FTSettings = new Settings("", "", "", "");
            SaveFilterCommand = new GenericCommand(x => SaveFilter());
            RemoveTemplateCommand = new GenericCommand(x => RemoveTemplate());
            Templates = LoadTemplates(5);
            ChosenTemplate = Templates.FirstOrDefault();
            MockSavedTemplates = LoadTemplates(5);
            ViewFilters = new SourceFilters(new String[0], String.Empty);           
            SaveTemplateCommand = new GenericCommand(x => SaveTemplate());
            FilterPathSourceCommand = new GenericCommand(x => GetFilterPathSource());
            LoadSettings();
            RefreshFilterList();
        }
    }
}
