namespace shell.Commands;

public interface ICommand
{
    string Name { get; }
    bool Validate(string[] args);
    void Execute(string[] args);
}
