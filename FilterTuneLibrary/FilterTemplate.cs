﻿using System;
using System.Collections.Generic;


namespace FilterTuneWPF_dll
{
    /// <summary>
    /// Contains template functionality that searches for specific text and makes changes to specific lines
    /// </summary>
    public class FilterTemplate
    {
        public string Name { get; set; }
        public List<StringPair> Selectors { get; set; }
        public List<StringPair> Parameters { get; set; }

        /// <summary>
        /// Creates default FilterTemplate
        /// </summary>
        public FilterTemplate()
        {
            this.Name = "Default";
            this.Selectors = new List<StringPair>();
            this.Parameters = new List<StringPair>();
        }

        /// <summary>
        /// Creates FilterTemplate instance with a name
        /// </summary>
        /// <param name="name"></param>
        public FilterTemplate(string name)
        {
            this.Name = name;
            this.Selectors = new List<StringPair>();
            this.Parameters = new List<StringPair>();
        }

        /// <summary>
        /// Creates FilterTemplate instance with default name 
        /// </summary>
        /// <param name="select"></param>
        /// <param name="param"></param>
        public FilterTemplate(List<StringPair> select, List<StringPair> param)
        {
            this.Name = $"Default template {select.Count}, {param.Count}";
            this.Selectors = new List<StringPair>(select);
            this.Parameters = new List<StringPair>(param);
        }

        /// <summary>
        /// Creates FilterTemplate instance
        /// </summary>
        /// <param name="name"></param>
        /// <param name="select"></param>
        /// <param name="param"></param>
        public FilterTemplate(string name, List<StringPair> select, List<StringPair> param)
        {
            this.Name = name;
            this.Selectors = new List<StringPair>(select);
            this.Parameters = new List<StringPair>(param);
        }

        /// <summary>
        /// Adds one selector, obtained from textLine
        /// </summary>
        /// <param name="textLine"></param>
        public void AddSelector(string textLine)
        {
            Selectors.Add(new StringPair(textLine));
        }


        /// <summary>
        /// Adds one parameter, obtained from textLine
        /// </summary>
        /// <param name="textLine"></param>
        public void AddParameter(string textLine)
        {
            Parameters.Add(new StringPair(textLine));
        }

        /// <summary>
        /// Adds multiple selectors, obtained from textLines
        /// </summary>
        /// <param name="textLines"></param>
        public void AddSelectors(string textLines)
        {
            string[] tempLines = textLines.Split('\n');
            foreach(string line in tempLines)
            {
                Selectors.Add(new StringPair(line)); 
            }
        }

        /// <summary>
        /// Adds multiple parameters, obtained from textLines
        /// </summary>
        /// <param name="textLines"></param>
        public void AddParameters(string textLines)
        {
            string[] tempLines = textLines.Split('\n');
            foreach (string line in tempLines)
            {
                Parameters.Add(new StringPair(line));
            }
        }

        /// <summary>
        /// Searches file for selector lines and makes changes in found parameters values
        /// </summary>
        public void ApplyTemplate(FilterFile file)
        {
            file.ApplyTemplate(this);
        }
    }
}
