using XamarinStarter.Abstractions;
using XamarinStarter.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinStarter.Helpers
{
    public class PersistantKeyData : IPersistantKeyData
    {
        public string GetValueFromKey(PersistantKeyDataEnum key)
        {
            return ContainsKey(key) ? Application.Current.Properties[key.ToString()].ToString() : null;
        }

        public void AddKey(PersistantKeyDataEnum key, string value)
        {
            Application.Current.Properties.Add(key.ToString(), value);
        }

        public bool ContainsKey(PersistantKeyDataEnum key)
        {
            return Application.Current.Properties.ContainsKey(key.ToString());
        }

        public bool RemoveKey(PersistantKeyDataEnum key)
        {
            return Application.Current.Properties.Remove(key.ToString());
        }

        public void UpdateKey(PersistantKeyDataEnum key, string value)
        {
            if (ContainsKey(key))
                RemoveKey(key);
            Application.Current.Properties.Add(key.ToString(), value);
        }

        public void RemoveAllKeys()
        {
            foreach (PersistantKeyDataEnum key in Enum.GetValues(typeof(PersistantKeyDataEnum)))
            {
                if (ContainsKey(key))
                    RemoveKey(key);
            }
        }
    }
}
