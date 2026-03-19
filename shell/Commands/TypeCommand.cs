using shell.Exceptions;

namespace shell.Commands;

public class TypeCommand : ICommand
{
    public string Name => "type";

    public string Description => "type is a shell builtin";

    public void Execute(string[] args)
    {
        var commandName = args[0];
        if (!CommandRegistry.TryGet(commandName, out var command))
        {
            throw new CommandNotFoundException(commandName);
        }
        Console.WriteLine(command.Description);
    }

    public bool Validate(string[] args)
    {
        return args.Length == 1;
    }
}
