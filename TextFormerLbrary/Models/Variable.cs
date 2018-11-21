using System;
using System.Collections.Generic;
using System.Text;

namespace TextFormerLbrary.Models
{
    public class Variable
    {
        #region Enums
        public enum ValueFunctionEnum
        {
            NONE = 0,
        }
        #endregion
        #region Static methods

        #endregion
        #region Private Fields
        #endregion
        #region Public Properties
        public string ReplacementText { get; set; } = "";
        public string Key { get; set; } = "";
        public int Index { get; set; } = 0;
        public ValueFunctionEnum ValueFunction { get; set; } = ValueFunctionEnum.NONE;
        public string Value { get; set; } = "";
        #endregion
        #region Constructor
        public Variable(string pReplacementText)
        {
            ReplacementText = pReplacementText;
        }
        #endregion
        #region Methods
        public void SetValueFunction(string functionName)
        {
            var v = ValueFunctionEnum.NONE;
            Enum.TryParse<ValueFunctionEnum>(functionName, out v);
            ValueFunction = v;
        }
        #endregion
    }
}
