namespace plugins;

public class ColorsPlugin: IPlugin {
    private readonly Random _random = new();
    private string GenerateColor() {
        return $"#{GenDigit()}{GenDigit()}{GenDigit()}" +
               $"{GenDigit()}{GenDigit()}{GenDigit()}";
        
        char GenDigit() {
            const string hexCharSpace = "0123456789ABCDEF";
            return hexCharSpace[_random.Next(0, hexCharSpace.Length)];
        }
    }
    public string Generate() {
        return GenerateColor();
    }

    public List<string> GenerateMultiple(int count) {
        var colors = new List<string>();
        for (var i = 0; i < count; i++) {
            colors.Add(Generate());
        }
        
        return colors;
    }
}