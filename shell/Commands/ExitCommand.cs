using shell.Exceptions;

namespace shell.Commands;

public class ExitCommand : ICommand
{
    public string Name => "exit";

    public string Description => "exit is a shell builtin";

    public void Execute(string[] args)
    {
        Environment.Exit(0);
    }

    public bool Validate(string[] args)
    {
        return true;
    }
}
