using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace TextFormerLbrary.Models
{
    /// <summary>
    /// This class will allow me to setup pre-configured settings so no arguments are required to run TextFormer.
    /// </summary>
    public class Settings
    {
        #region Static Methods
        static public Settings FromJSON(string data)
        {
            return JsonConvert.DeserializeObject<Settings>(data);
        }

        static public Settings FromFile(string FileName)
        {
            if (File.Exists(FileName) == false) throw new FileNotFoundException();
            var str = File.ReadAllText(FileName);
            return FromJSON(str);
        }
        #endregion
        #region Private Fields
        #endregion
        #region Public Properties
        /// <summary>
        /// This is a CSV file that contains the records for Transformation
        /// Format is
        /// Line 01: Headers
        /// Line 02+ Data
        /// Headers are used as the variables within the Text Transform
        /// </summary>
        public string DataFile { get; set; } = "";
        /// <summary>
        /// This is the Text Transform Template File.  This file is used to build the output File
        /// </summary>
        public string TemplateFile { get; set; } = "";
        /// <summary>
        /// This is the Dictionary File.  This contains replacement values for Data File Values Depending on a Key
        /// Format
        /// Lookup Function Name, Lookup Text Value, Replacement Value
        /// Example:
        /// SQL, VARCHAR40, varchar(40)
        /// </summary>
        public string DictionaryFile { get; set; } = "";
        /// <summary>
        /// The output file for the text traform.
        /// </summary>
        public string OutputFile { get; set; } = "";
        /// <summary>
        /// If this is true, when the console applicatoin starts up, it won't qick until control-c and will update the output file every time the DataFile, TemplateFile, or DictionaryFile is modified.
        /// </summary>
        public bool LiveConvert { get; set; } = false;

        #endregion
        #region Constructor
        #endregion
        #region Methods
        public string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }

        public void ToFile(string FileName)
        {
            if (File.Exists(FileName)) File.Delete(FileName);
            File.WriteAllText(FileName, ToJSON());
        }
        #endregion
    }
}
