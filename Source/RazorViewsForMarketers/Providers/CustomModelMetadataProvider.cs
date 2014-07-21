using System;
using System.Collections.Generic;
using System.Web.Mvc;
using RazorViewsForMarketers.Models.Fields;

namespace RazorViewsForMarketers.Providers
{
    public class CustomModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        public const string DynamicContainerKey = "DynamicContainer";
        private object _lastDynamicMetadataModel;

        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            var ret = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
            var model = modelAccessor != null ? modelAccessor.Invoke() : null;
            if (model is WffmField)
            {
                _lastDynamicMetadataModel = model;
            }

            // this is a hack to work around the problem of not having the container in ModelValidator.GetClientValidationRules
            if (typeof(WffmField).IsAssignableFrom(containerType))
                ret.AdditionalValues.Add(DynamicContainerKey, _lastDynamicMetadataModel);
            return ret;
        }
    }
}