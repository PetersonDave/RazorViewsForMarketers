using System.Collections.Generic;
using Sitecore.Data;

namespace RazorViewsForMarketers.Models
{
    public class WffmForm
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public bool ShowTitle { get; set; }
        public string Introduction { get; set; }
        public bool ShowIntroduction { get; set; }
        public string Footer { get; set; }
        public bool ShowFooter { get; set; }
        public List<WffmSection> Sections { get; set; }
    }
}