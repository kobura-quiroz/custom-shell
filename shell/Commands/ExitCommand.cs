using shell.Exceptions;

namespace shell.Commands;

public class ExitCommand : ICommand
{
    public string Name => "exit";

    public void Execute(string[] args)
    {
        Environment.Exit(0);
    }

    public bool Validate(string[] args)
    {
        return true;
    }
}
