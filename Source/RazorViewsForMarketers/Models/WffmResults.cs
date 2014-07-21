//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Sitecore.Form.Core.Controls.Data;
//using Website.Model;

//namespace DartmouthWeb.Api.Models
//{
//    public class WffmResults
//    {
//        public Guid FormId { get; set; }
//        public List<DecoratedControlResult> Results { get; set; }

//        public WffmResults(RazordViewForMarketersFormModel model)
//        {
//            var results = new List<DecoratedControlResult>();

//            foreach (var section in model.Form.Sections)
//            {
//                foreach (var field in section.Fields)
//                {
//                    var result = new DecoratedControlResult(field.Item.ID, field.Item.Name, field.Response, string.Empty);
//                    results.Add(result);
//                }
//            }

//            Results = results;
//        }

//        public ControlResult[] GetControlResults()
//        {
//            bool hasResults = Results != null && Results.Any();
//            return !hasResults ? null : Results.ToList().Select(r => r.ControlResult).ToArray();
//        }
//    }
//}