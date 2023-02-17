using _LitgTest.Scripts.GameLogic.Models.DataModels;
using UnityEngine;

namespace _LitgTest.Scripts.GameLogic.DataServices
{
    public static class PersistentDataService
    {
        public static void SaveElement<T>(DataModels key, T value)
        {
            var serializedValue = SerializeData(value);

            PlayerPrefs.SetString(key.ToString(), serializedValue);
            PlayerPrefs.Save();
        }

        public static T GetElement<T>(DataModels key)
        {
            var value = JsonUtility.FromJson<T>(PlayerPrefs.GetString(key.ToString()));
            return value;
        }

        public static string SerializeData<T>(T obj)
        {
            return JsonUtility.ToJson(obj);
        }
    }
}