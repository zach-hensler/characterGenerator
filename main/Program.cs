using plugins;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/random", () => Results.Ok(PluginMapper.ValidPlugins))
    .WithName("ListRandomTypes")
    .WithOpenApi();

app.MapGet("/random/{type}", (string type) => {
        var selectedPlugin = PluginMapper.GetPlugin(type);
        return selectedPlugin == null
            ? Results.BadRequest($"Type {type} not supported. Current types: {String.Join(", ", PluginMapper.ValidPlugins)}.")
            : Results.Ok(selectedPlugin.Generate());
    })
    .WithName("GetRandomSingle")
    .WithOpenApi();

app.MapGet("/random/{type}/{count}", (string type, int count) => {
        var selectedPlugin = PluginMapper.GetPlugin(type);
        return selectedPlugin == null
            ? Results.BadRequest($"Type {type} not supported. Current types: {String.Join(", ", PluginMapper.ValidPlugins)}.")
            : Results.Ok(selectedPlugin.GenerateMultiple(count));
    })
    .WithName("GetRandomMultiples")
    .WithOpenApi();

app.MapGet("/random/all", () => {
        Dictionary<string, string> values = new();
        foreach (var pluginName in PluginMapper.ValidPlugins) {
            var plugin = PluginMapper.GetPlugin(pluginName);
            if (plugin == null) {
                continue;
            }
            values[pluginName] = plugin.Generate();
        }

        return values;
    })
    .WithName("GetRandomAll")
    .WithOpenApi();

app.Run();
