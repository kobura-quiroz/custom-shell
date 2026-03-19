namespace shell.Commands;

public class EchoCommand : ICommand
{
    public string Name => "echo";

    public string Description => "echo is a shell builtin";

    public void Execute(string[] args)
    {
        Console.WriteLine(string.Join(" ", args));
    }

    public bool Validate(string[] args)
    {
        return args.Length > 0;
    }
}
