using System;
using Sitecore.Data;
using Sitecore.Form.Core.Controls.Data;

namespace RazorViewsForMarketers.Models
{
    public class DecoratedControlResult
    {
        public ID FieldIdValue { get; set; }
        public ControlResult ControlResult { get; set; }

        public DecoratedControlResult(ID fieldIdValue, string fieldName, object value, string parameters)
        {
            if (ID.IsNullOrEmpty(fieldIdValue)) throw new ArgumentNullException("fieldIdValue");

            var controlResult = new ControlResult(fieldName, value, parameters);
            FieldIdValue = fieldIdValue;
            controlResult.FieldID = fieldIdValue.ToString();

            ControlResult = controlResult;
        }
    }
}