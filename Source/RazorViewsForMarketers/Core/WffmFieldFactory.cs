﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RazorViewsForMarketers.Configuration;
using RazorViewsForMarketers.Core.Validators;
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
            wffmField.Id = field.ID.Guid;

            return wffmField;
        }

        public static IEnumerable<IValidator> GetValidators(Item field)
        {
            var validators = new List<IValidator>();

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

        public static IValidator GetValidator(string validatorId)
        {
            ID id;
            bool isValid = ID.TryParse(validatorId, out id);
            if (!isValid) return null;

            return GetValidator(id);
        }

        public static IValidator GetValidator(Guid validatorId)
        {
            ID id;
            bool isValid = ID.TryParse(validatorId, out id);
            if (!isValid) return null;

            return GetValidator(id);
        }

        public static IValidator GetValidator(ID validatorId)
        {
            var validatorItem = Sitecore.Context.Database.Items[validatorId];
            if (validatorItem == null) return null;

            if (!ValidatorResolver.Current.ContainsKey(validatorItem.Name)) throw new Exception(string.Format("Validator name {0} does not exist in validator config", validatorItem.Name));

            var definition = ValidatorResolver.Current[validatorItem.Name];

            Type fieldType = definition.ValidatorInitializer;
            if (fieldType == null) return null;

            var wffmFieldInitializer = Activator.CreateInstance(fieldType, validatorItem);
            if (wffmFieldInitializer == null) return null;

            PropertyInfo genericFieldProperty = wffmFieldInitializer.GetType().GetProperty("Validator");
            var wffmValidator = genericFieldProperty.GetValue(wffmFieldInitializer, null) as Validator;

            Type validatorType = definition.Validator;
            if (validatorType == null) return null;

            var varlidator = Activator.CreateInstance(validatorType, wffmValidator) as IValidator;
            if (varlidator == null) return null;

            return varlidator;
        }
    }
}