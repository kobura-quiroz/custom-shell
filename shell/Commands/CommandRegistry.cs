using System.Reflection;

namespace shell.Commands;

public static class CommandRegistry
{
    private static readonly Dictionary<string, ICommand> _commands = new();

    public static void Setup()
    {
        var commands = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(ICommand).IsAssignableFrom(t) && !t.IsInterface);

        foreach (var command in commands)
        {
            var cmd = (ICommand)Activator.CreateInstance(command);
            Register(cmd);
        }
    }

    public static void Register(ICommand command)
    {
        _commands[command.Name] = command;
    }

    public static bool TryGet(string name, out ICommand command)
    {
        return _commands.TryGetValue(name, out command);
    }
}
