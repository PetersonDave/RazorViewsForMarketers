using System;
using System.Collections.Generic;
using System.Xml;
using Sitecore.Configuration;

namespace RazorViewsForMarketers.Configuration
{
    public static class FieldResolver
    {
        private static readonly object SyncRoot = new object();
        private static volatile Dictionary<string, Type> _current;

        public static Dictionary<string, Type> Current
        {
            get
            {
                if (_current == null)
                {
                    lock (SyncRoot)
                    {
                        if (_current == null)
                        {
                            _current = GetFieldDictionaryFromConfig();
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

        private static Dictionary<string, Type> GetFieldDictionaryFromConfig()
        {
            var fieldDictionary = new Dictionary<string, Type>();
            var nodes = Factory.GetConfigNodes("/sitecore/rvfm/fields/field");

            foreach (XmlNode node in nodes)
            {
                if (node == null || node.Attributes == null) continue;

                var type = Type.GetType(node.Attributes["type"].Value);
                if (type == null) throw new Exception(string.Format("Type {0} cannot be resolved. Please verify your type definition.", node.Attributes["type"].Value));

                var key = node.Attributes["name"].Value;

                if (fieldDictionary.ContainsKey(key))
                {
                    throw new Exception(string.Format("Field dictionary cannot caontain multuple fields of the same type: {0}", key));
                }

                fieldDictionary.Add(key, type);
            }

            return fieldDictionary;
        }
    }
}