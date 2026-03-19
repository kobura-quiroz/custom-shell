namespace shell.Exceptions;

public class InvalidCommandException : ShellException
{
    public InvalidCommandException(string commandName) : base($"{commandName}: command not found")
    {
        
    }
}
