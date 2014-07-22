using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RazorViewsForMarketers.Configuration;
using RazorViewsForMarketers.Models.Fields;
using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Core
{
    public class WffmFieldFactory
    {
        public static WffmField GetField(Guid fieldId)
        {
            ID id;
            bool isValidId = ID.TryParse(fieldId, out id);
            if (!isValidId)
            {
                throw new Exception(string.Format("Field {0} is not a valid Sitecore Id", fieldId));
            }

            return GetField(id);
        }

        public static WffmField GetField(ID fieldId)
        {
            var fieldItem = Sitecore.Context.Database.Items[fieldId];
            return GetField(fieldItem);
        }

        public static WffmField GetField(Item field)
        {
            var fieldLink = field.Fields["Field Link"];
            if (fieldLink == null || !fieldLink.HasValue) throw new Exception(string.Format("Field {0} does not have a defined field type", field.Name));

            var item = Sitecore.Context.Database.Items[fieldLink.Value];

            if (!FieldResolver.Current.ContainsKey(item.Name)) throw new Exception(string.Format("Field name {0} does not exist in field config", item.Name));

            Type fieldType = FieldResolver.Current[item.Name];
            if (fieldType == null) return null;

            var wffmFieldInitializer = Activator.CreateInstance(fieldType, field);
            if (wffmFieldInitializer == null) return null;

            PropertyInfo genericFieldProperty = wffmFieldInitializer.GetType().GetProperty("Field");
            var wffmField = genericFieldProperty.GetValue(wffmFieldInitializer, null) as WffmField;

            if (wffmField == null) return null;

            wffmField.Validators = GetValidators(field);
            if (wffmField.Validators != null)
            {
                wffmField.ValidatorIds =  wffmField.Validators.Select(v => v.Item.ID.Guid.ToString()).Aggregate((i, j) => i + "|" + j);
            }

            return wffmField;
        }

        public static IEnumerable<Validator> GetValidators(Item field)
        {
            var validators = new List<Validator>();

            ReferenceField fieldLink = field.Fields["Field Link"];
            if (fieldLink == null || fieldLink.TargetItem == null) return null;

            MultilistField validation = fieldLink.TargetItem.Fields["Validation"];
            if (validation == null || !validation.TargetIDs.Any()) return null;

            foreach (var targetId in validation.TargetIDs)
            {
                var wffmValidator = GetValidator(targetId);
                validators.Add(wffmValidator);
            }

            return validators;
        }

        public static Validator GetValidator(string validatorId)
        {
            ID id;
            bool isValid = ID.TryParse(validatorId, out id);
            if (!isValid) return null;

            return GetValidator(id);
        }

        public static Validator GetValidator(Guid validatorId)
        {
            ID id;
            bool isValid = ID.TryParse(validatorId, out id);
            if (!isValid) return null;

            return GetValidator(id);
        }

        public static Validator GetValidator(ID validatorId)
        {
            var validatorItem = Sitecore.Context.Database.Items[validatorId];
            if (validatorItem == null) return null;

            if (!ValidatorResolver.Current.ContainsKey(validatorItem.Name)) throw new Exception(string.Format("Validator name {0} does not exist in validator config", validatorItem.Name));

            Type fieldType = ValidatorResolver.Current[validatorItem.Name];
            if (fieldType == null) return null;

            var wffmFieldInitializer = Activator.CreateInstance(fieldType, validatorItem);
            if (wffmFieldInitializer == null) return null;

            PropertyInfo genericFieldProperty = wffmFieldInitializer.GetType().GetProperty("Validator");
            var wffmValidator = genericFieldProperty.GetValue(wffmFieldInitializer, null) as Validator;

            return wffmValidator;
        }

        //private void PopulateValidators(Item fieldLinkItem, Validator wffmField)
        //{
        //    var validators = new List<Validator>();

        //    MultilistField validation = fieldLinkItem.Fields["validation"];
        //    if (validation == null || !validation.TargetIDs.Any()) return;

        //    foreach (var target in validation.TargetIDs)
        //    {
        //        var validatorItem = fieldLinkItem.Database.Items[target];
        //        if (validatorItem == null) continue;

        //        CheckboxField enableClientScript = validatorItem.Fields["Enable Client Script"];

        //        var validator = new Validator()
        //        {
        //            AnalyticsFieldEvent = validatorItem.Fields["Field Event"].Value,
        //            Assembly = validatorItem.Fields["Assembly"].Value,
        //            Class = validatorItem.Fields["Class"].Value,
        //            EnableClientScript = enableClientScript.Checked,
        //            ErrorMessage = validatorItem.Fields["Error Message"].Value,
        //            Text = validatorItem.Fields["Text"].Value,
        //            ValidationExpression = validatorItem.Fields["Validation Expression"].Value,
        //            ValidatorDisplay = validatorItem.Fields["Validator Display"].Value
        //        };

        //        validators.Add(validator);
        //    }

        //    wffmField.Validators = validators;
        //}

    }
}