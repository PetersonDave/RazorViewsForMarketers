using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using RazorViewsForMarketers.Core.FieldRenderers.EnumerationTypes;
using RazorViewsForMarketers.Models.Fields;
using RazorViewsForMarketers.Presenters;
using Sitecore.Collections;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Form.Core.Utility;

namespace RazorViewsForMarketers.Core.FieldRenderers
{
    public class FileUploadInitializer : FieldInitializerBase<FileUploadField>
    {
        public FileUploadInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(Field field, FileUploadField model)
        {
            IEnumerable<Pair<string, string>> p = ParametersUtil.XmlToPairArray(field.Value, true);
            foreach (var pair in p)
            {
                EFileUploadFieldParametersType fieldParametersType;
                bool isKnownType = Enum.TryParse(pair.Part1, true, out fieldParametersType);
                if (!isKnownType) continue;

                switch (fieldParametersType)
                {
                    case EFileUploadFieldParametersType.UploadTo:
                        model.UploadTo = pair.Part2;
                        break;
                }
            }
        }

        public override void PopulateLocalizedParameters(Field field, FileUploadField model)
        {

        }
    }
}