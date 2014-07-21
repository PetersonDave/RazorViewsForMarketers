using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RazorViewsForMarketers.ModelBinding
{
    public class WffmFieldModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            Type type = modelType;
            if (modelType.IsGenericType)
            {
                Type genericTypeDefinition = modelType.GetGenericTypeDefinition();
                if (((genericTypeDefinition == typeof(IEnumerable<>)) || (genericTypeDefinition == typeof(ICollection<>))) || (genericTypeDefinition == typeof(IList<>)))
                {
                    type = typeof(List<>).MakeGenericType(modelType.GetGenericArguments());
                }
                return Activator.CreateInstance(type);
            }

            if (modelType.IsAbstract)
            {
                string concreteTypeName = bindingContext.ModelName + ".ModelType";          // ModelType property on SurveyControl Model
                var concreteTypeResult = bindingContext.ValueProvider.GetValue(concreteTypeName);
                if (concreteTypeResult == null)
                {
                    throw new Exception("Concrete type for abstract class not specified");
                }

                type = Type.GetType(concreteTypeResult.AttemptedValue, true);
                if (type == null)
                {
                    throw new Exception(String.Format("Concrete model type {0} not found", concreteTypeResult.AttemptedValue));
                }

                var instance = Activator.CreateInstance(type);
                bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => instance, type);
                return instance;
            }

            // fallback
            return Activator.CreateInstance(modelType);
        }
    }
}