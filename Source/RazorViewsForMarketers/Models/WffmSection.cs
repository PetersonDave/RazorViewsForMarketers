using System.Collections.Generic;
using RazorViewsForMarketers.Models.Fields;

namespace RazorViewsForMarketers.Models
{
    public class WffmSection
    {
        public string Title { get; set; }
        public List<WffmField> Fields { get; set; }
    }
}