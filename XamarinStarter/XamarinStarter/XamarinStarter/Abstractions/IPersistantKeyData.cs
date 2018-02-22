using XamarinStarter.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinStarter.Abstractions
{
    public interface IPersistantKeyData
    {
        string GetValueFromKey(PersistantKeyDataEnum key);
        bool ContainsKey(PersistantKeyDataEnum key);
        bool RemoveKey(PersistantKeyDataEnum key);
        void AddKey(PersistantKeyDataEnum key, string value);
        void UpdateKey(PersistantKeyDataEnum key, string value);
        void RemoveAllKeys();
    }
}
