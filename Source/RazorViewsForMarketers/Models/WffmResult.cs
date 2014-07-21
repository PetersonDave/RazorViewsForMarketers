using System;

namespace RazorViewsForMarketers.Models
{
    public class WffmResult
    {
        public Guid FieldId { get; set; }
        public string FieldName { get; set; }
        public string Value { get; set; }
        public string Parameters { get; set; }
    }
}