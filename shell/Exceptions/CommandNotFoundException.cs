namespace shell.Exceptions;

public class CommandNotFoundException : ShellException
{
    public CommandNotFoundException(string commandName) : base($"{commandName}: not found")
    {
    }
}
