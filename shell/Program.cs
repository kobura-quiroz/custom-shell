using shell.Commands;
using shell.Exceptions;

namespace shell;

class Program
{
    static void Main()
    {
        CommandRegistry.Setup();

        while (true)
        {
            try
            {
                Console.Write("$ ");
                var input = Console.ReadLine();

                if (CommandValidator.Validate(input, out var command, out var args))
                {
                    command.Execute(args);
                }
            }
            catch (InvalidCommandException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
