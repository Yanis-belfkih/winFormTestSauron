namespace winFormTestSauron.Interfaces
{
    public interface IPlugin
    {
        string Name { get; }
        void Initialize();
        Task<string> ExecuteCallAsync(string inputMessage);
    }
}