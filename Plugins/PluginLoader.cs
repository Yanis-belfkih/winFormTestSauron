using winFormTestSauron.Interfaces;

public class PluginLoader
{
    private readonly List<IPlugin> _plugins = new List<IPlugin>();

    // permet d'enregistrer et d'initialiser les plugins
    public void Load(IPlugin plugin)
    {
        if (plugin == null) return;

        plugin.Initialize();
        _plugins.Add(plugin);
    }

    // permet d'appeler un plugin par son nom
    public IPlugin? Get(string name)
    {
        if (name == null) return null;
        foreach (var plugin in _plugins)
        {
            if (plugin.Name == name) 
            {
                return plugin;
            }
        }
        return null;
    }

    // liste les plugins disponibles
    public IEnumerable<string> ListPlugins()
    {
        return _plugins.Select(p => p.Name);
    }
}