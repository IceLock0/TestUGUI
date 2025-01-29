using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace _Project.Scripts.Services.LoadSave
{
    public class SaveLoadService : ISaveLoadService
    {
        public void Save(string key, object data)
        {
            var path = GetPath(key);

            if (!File.Exists(path))
                File.Create(path).Close();

            var setting = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Objects };
            
            var json = JsonConvert.SerializeObject(data, Formatting.Indented, setting);
            
            File.WriteAllText(path, json);
        }

        public T Load<T>(string key)
        {
            var path = GetPath(key);

            if (!File.Exists(path))
            {
                File.Create(path).Close();
                return default;
            }

            var data = File.ReadAllText(path);
            
            var setting = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Objects };
            
            return JsonConvert.DeserializeObject<T>(data, setting);
        }

        public void Clean(string key)
        {
            var path = GetPath(key);
            
            if (!File.Exists(path))
                return;
            
            File.Delete(path);
        }

        private string GetPath(string key) => Path.Combine(Application.persistentDataPath, key);
    }
}