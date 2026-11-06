namespace MiniSql.REPL;

public partial class Core
{
    static Core()
    {
        // Do nothing
    }

    public void Initialize(Library.Core.CommandProcessor commandProcessor)
    {
        Console.WriteLine(Resource.Misc.WelcomeMessage);
        Console.WriteLine(Resource.Misc.Subtitle);

        while (!IsExitRequested())
        {
            Console.Write(Resource.Symbols.Input);
            Console.Write(" ");
            string command = Console.ReadLine() ?? string.Empty;
            string output = string.Empty;
            commandProcessor.Process(command, ref output);
            Console.WriteLine();
            Console.Write(output);
        }

        Console.WriteLine(Resource.Misc.FinishingUp);
        Communicator.Common.RequestShutdown();
        Console.WriteLine(Resource.Misc.EndMessage);
    }

    private bool IsExitRequested()
    {
        if (Communicator.Common.IsExitRequested)
        {
            Communicator.Common.IsExitRequested = false;
            return true;
        }
        return false;
    }
}

internal static class Resource
{
    public static class Misc
    {
        public static string WelcomeMessage = "Welcome to MiniSQL REPL";
        public static string Subtitle = @"
            Made by Dev Sirohi";
        public static string EndMessage = "Fuck off";
        public static string FinishingUp = "Finishing up...";
    }

    public static class Symbols
    {
        public static string Input = ">>>";
    }
}