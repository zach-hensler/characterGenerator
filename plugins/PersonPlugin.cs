namespace plugins;

public class PersonPlugin : IPlugin {
    private static readonly string[] firstNames = {
        "John",
        "Jane",
        "Jake",
        "James",
        "Jimothy",
        "Joe",
        "Jared",
        "Johnny",
        "Jennifer",
        "Jaskier"
    };

    private static readonly string[] lastNames = {
        "Smith",
        "Scott",
        "Stewart",
        "Sullivan",
        "Sanders",
        "Stevens",
        "Snyder",
        "Simmons"
    };

    private Random _random = new();
    private string GetRandFirst() {
        return firstNames[_random.Next(0, firstNames.Length)];
    }

    private string GetRandLast() {
        return lastNames[_random.Next(0, lastNames.Length)];
    }
    public string Generate() {
        return $"{GetRandFirst()} {GetRandLast()}";
    }

    public List<string> GenerateMultiple(int count) {
        var names = new List<string>();
        for (var i = 0; i < count; i++) {
            names.Add(Generate());
        }
        
        return names;
    }
}