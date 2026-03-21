using shell.Exceptions;

namespace shell.Commands;

public class TypeCommand : ICommand
{
    public string Name => "type";

    public string Description => "type is a shell builtin";

    public void Execute(string[] args)
    {
        var commandName = args[0];

        if (TryHandleRegisterCommand(commandName)) return;

        var fullPath = FindExecutableInPath(commandName);

        if (fullPath != null)
        {
            Console.WriteLine($"{commandName} is {fullPath}");
            return;
        }

        throw new CommandNotFoundException(commandName);
    }

    public bool Validate(string[] args)
    {
        return args.Length == 1;
    }

    private string? FindExecutableInPath(string commandName)
    {
        var pathEnv = Environment.GetEnvironmentVariable("PATH");
        if (string.IsNullOrWhiteSpace(pathEnv))
            return null;

        var isWindows = OperatingSystem.IsWindows();
        var extensions = isWindows
            ? (Environment.GetEnvironmentVariable("PATHEXT")?.Split(';')) ?? new[] { ".exe" }
            : new[] { "" };

        foreach (var dir in pathEnv.Split(Path.PathSeparator, StringSplitOptions.RemoveEmptyEntries))
        {
            foreach (var ext in extensions)
            {
                var fullPath = Path.Combine(dir, commandName + ext.ToLower());

                if (!File.Exists(fullPath))
                    continue;

                if (isWindows || HasUnixExecutePermission(fullPath))
                    return fullPath;
            }
        }

        return null;
    }

    private bool HasUnixExecutePermission(string path)
    {
        var mode = File.GetUnixFileMode(path);

        return (mode & (UnixFileMode.UserExecute |
                        UnixFileMode.GroupExecute |
                        UnixFileMode.OtherExecute)) != 0;
    }

    private bool TryHandleRegisterCommand(string commandName)
    {
        if (CommandRegistry.TryGet(commandName, out ICommand command))
        {
            Console.WriteLine(command.Description);
            return true;
        }
        return false;
    }
}
