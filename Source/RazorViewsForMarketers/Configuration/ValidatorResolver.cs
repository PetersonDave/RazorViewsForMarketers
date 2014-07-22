using System;
using System.Collections.Generic;
using System.Xml;
using Sitecore.Configuration;

namespace RazorViewsForMarketers.Configuration
{
    public static class ValidatorResolver
    {
        public class ValidatorDefinition
        {
            public Type ValidatorInitializer { get; set; }
            public Type Validator { get; set; }
        }

        private static readonly object SyncRoot = new object();
        private static volatile Dictionary<string, ValidatorDefinition> _current;

        public static Dictionary<string, ValidatorDefinition> Current
        {
            get
            {
                if (_current == null)
                {
                    lock (SyncRoot)
                    {
                        if (_current == null)
                        {
                            _current = GetValidatorDictionaryFromConfig();
                        }
                    }
                }

                return _current;
            }
            set
            {
                lock (SyncRoot)
                {
                    _current = value;
                }
            }
        }

        private static Dictionary<string, ValidatorDefinition> GetValidatorDictionaryFromConfig()
        {
            var validatorDictionary = new Dictionary<string, ValidatorDefinition>();
            var nodes = Factory.GetConfigNodes("/sitecore/rvfm/validators/validator");

            foreach (XmlNode node in nodes)
            {
                if (node == null || node.Attributes == null) continue;

                var type = Type.GetType(node.Attributes["type"].Value);
                if (type == null) throw new Exception(string.Format("Type {0} cannot be resolved. Please verify your type definition.", node.Attributes["type"].Value));

                var validatorType = Type.GetType(node.Attributes["validator"].Value);
                if (validatorType == null) throw new Exception(string.Format("Validator type {0} cannot be resolved. Please verify your type definition.", node.Attributes["validatorType"].Value));

                var key = node.Attributes["name"].Value;

                if (validatorDictionary.ContainsKey(key))
                {
                    throw new Exception(string.Format("Field dictionary cannot caontain multuple fields of the same type: {0}", key));
                }

                var definition = new ValidatorDefinition() {ValidatorInitializer = type, Validator = validatorType};
                validatorDictionary.Add(key, definition);
            }

            return validatorDictionary;
        }
    }
}