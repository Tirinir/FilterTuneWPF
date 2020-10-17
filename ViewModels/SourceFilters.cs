using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FilterTuneWPF
{
    public class SourceFilters : Notifier
    {
        public ObservableCollection<String> Filters { get; set; }
        //{
        //    get => filters; set
        //    {
        //        filters = value;
        //        NotifyPropertyChanged("Filters");
        //    }
        //}
        //private String selected;
        public String Selected { get; set; }
        //{
        //    get => selected; 
        //    set
        //    {
        //        selected = value;
        //        NotifyPropertyChanged("Selected");
        //    } 
        //}
        private List<string> MockGetFilters()
        {
            List<string> Filters = new List<string>();
            Filters.Add("A filter");
            Filters.Add("Another filter");
            Filters.Add("Third filter");
            return Filters;
        }
        public SourceFilters()
        {
            Filters = new ObservableCollection<string>(MockGetFilters());
            Selected = Filters[0];
        }
    }
}
