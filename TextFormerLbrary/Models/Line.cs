using System;
using System.Collections.Generic;
using System.Text;

namespace TextFormerLbrary.Models
{
    public class Line
    {
        #region Enumeration
        public enum LineTypeEnum
        {
            TEXT,
            SECTION_BEGIN_MARKER,
            SECTION_END_MARKER,
            COMMAND_IMPORT_MARKER,
            COMMAND_FOR_ALL_MARKER,
            COMMAND_FOR_MARKER,
            COMMAND_LOOKUP_MARKER,
            COMMAND_VARIABLE_MARKER,
            COMMENT_MARKER            
        }
        #endregion
        #region Static Methods
        #endregion
        #region Private Fields
        #endregion
        #region Public Properties
        public Section Parent { get; set; } = null;
        public string Text { get; set; } = "";

        public LineTypeEnum LineType { get => GetLineType();  }
        #endregion
        #region Constructor
        public Line(string pText, Section pParent)
        {
            Text = pText;
            Parent = pParent;
        }
        #endregion
        #region Methods
        #region Property Methods
        private LineTypeEnum GetLineType()
        {

            if (Text.Trim().StartsWith("@SECTION")) return LineTypeEnum.SECTION_BEGIN_MARKER;
            if (Text.Trim().StartsWith("@END_OF_SECTION")) return LineTypeEnum.SECTION_END_MARKER;

            if (Text.Trim().StartsWith("!IMPORT")) return LineTypeEnum.COMMAND_IMPORT_MARKER;
            if (Text.Trim().StartsWith("!FOR_ALL")) return LineTypeEnum.COMMAND_FOR_ALL_MARKER;
            if (Text.Trim().StartsWith("!FOR")) return LineTypeEnum.COMMAND_FOR_MARKER;
            if (Text.Trim().StartsWith("!LOOK_UP")) return LineTypeEnum.COMMAND_LOOKUP_MARKER;
            if (Text.Trim().StartsWith("!VAR")) return LineTypeEnum.COMMAND_VARIABLE_MARKER;

            if (Text.Trim().StartsWith("#") && !Text.Trim().StartsWith("\\#") ) return LineTypeEnum.COMMENT_MARKER;

            return LineTypeEnum.TEXT;
        }
        #endregion
        public override string ToString()
        {
            return Text;
        }
        #endregion
    }
}
