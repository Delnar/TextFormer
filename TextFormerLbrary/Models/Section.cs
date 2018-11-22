using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextFormerLbrary.Models
{
    public class Section
    {
        #region Static Methods
        #endregion
        #region Private Fields

        #endregion
        #region Public Properties
        public Section Parent { get; set; } = null;
        public List<Section> SubSections { get; set; } = new List<Section>();
        public List<Line> Lines { get; set; } = new List<Line>();

        public string UnformatedText { get => GetUnformatedText(); set => SetUnformatedText(value); }

        public string Text { get => GetText(); }
        #endregion
        #region Constructor
        #endregion
        #region Methods
        #region Property Methods
        private string GetUnformatedText()
        {
            return string.Join("\r\n", Lines.Select(x => x.Text).ToArray());
        }

        private void SetUnformatedText(string Value)
        {
            Lines = Value.Replace("\r\n", "\n").Split('\n').Select(x => new Line(x, this)).ToList();
        }

        private string GetText()
        {
            return string.Join("\r\n", Lines.Select(x => x.ToString()).ToArray());
        }
        #endregion

        public override string ToString()
        {
            return Text;
        }
        #endregion

    }
}
