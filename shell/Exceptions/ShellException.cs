namespace shell.Exceptions;

public class ShellException : Exception
{
    public ShellException()
    {   
    }

    public ShellException(string? message) : base(message)
    {
    }
}
