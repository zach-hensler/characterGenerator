using System.Data;

namespace plugins;

public interface IPlugin {
    public string Generate();
    public List<string> GenerateMultiple(int count);
}
