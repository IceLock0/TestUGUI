namespace _Project.Scripts.Services.LoadSave
{
    public interface ISaveLoadService
    {
        public void Save(string key, object data);
        public T Load<T>(string key);
        public void Clean(string key);
    }
}