namespace plugins;

public static class PluginMapper {
    public static readonly string[] ValidPlugins = [
        "person",
        "color",
        "species"
    ];
    public static IPlugin? GetPlugin(string pluginName) {
        if (ValidPlugins.All(p => p != pluginName)) {
            return null;
        }
        return pluginName switch {
            "person" => new PersonPlugin(),
            "color" => new ColorsPlugin(),
            "species" => new SpeciesPlugin(),
            _ => null
        };
    }
}