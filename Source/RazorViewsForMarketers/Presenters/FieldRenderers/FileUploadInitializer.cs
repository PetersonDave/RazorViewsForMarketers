using System;
using System.Collections.Generic;
using RazorViewsForMarketers.Models.Fields;
using Sitecore.Collections;
using Sitecore.Data.Items;
using Sitecore.Form.Core.Utility;

namespace RazorViewsForMarketers.Presenters.FieldRenderers
{
    public class FileUploadInitializer : FieldInitializerBase<FileUploadField>
    {
        public FileUploadInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(FileUploadField field)
        {
            var parameters = field.Item.Fields["Parameters"];
            if (parameters.HasValue)
            {
                IEnumerable<Pair<string, string>> p = ParametersUtil.XmlToPairArray(parameters.Value, true);
                foreach (var pair in p)
                {
                    EFileUploadFieldParametersType fieldParametersType;
                    bool isKnownType = Enum.TryParse(pair.Part1, true, out fieldParametersType);
                    if (!isKnownType) continue;

                    switch (fieldParametersType)
                    {
                        case EFileUploadFieldParametersType.UploadTo:
                            field.UploadTo = pair.Part2;
                            break;
                    }
                }
            }
        }

        public override void PopulateLocalizedParameters(FileUploadField field)
        {

        }
    }
}