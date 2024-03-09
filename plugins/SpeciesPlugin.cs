namespace plugins;

public class SpeciesPlugin: IPlugin {
    private static readonly string[] Races = [
        "human",
        "cat",
        "dog",
        "wolf",
        "lizard",
        "elf",
        "troll",
    ];

    private Random _random = new();
    public string Generate() {
        return Races[_random.Next(0, Races.Length)];
    }

    public List<string> GenerateMultiple(int count) {
        var species = new List<string>();
        for (var i = 0; i < count; i++) {
            species.Add(Generate());
        }
        
        return species;
    }
}