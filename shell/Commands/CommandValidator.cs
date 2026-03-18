using shell.Exceptions;

namespace shell.Commands;

public class CommandValidator
{
    public static bool Validate(string input, out ICommand command, out string[] args)
    {
        var tokens =  input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (tokens.Length == 0)
        {
            command = null;
            args = new string[0];
            return false;
        }

        var commandName = tokens[0];
        args = tokens.Skip(1).ToArray();

        if (!CommandRegistry.TryGet(commandName, out command))
        {
            throw new InvalidCommandException($"{commandName}: command not found");
        }

        return command.Validate(args);
    }
}
