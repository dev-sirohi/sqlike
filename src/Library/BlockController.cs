namespace MiniSql.Library;

public partial class Core
{
    internal enum BlockType
    {
        DDC, // Data Definition Command
        DMC, // Data Manipulation Command
    }

    internal enum CommandResolution
    {
        Commit,
        Rollback,
    }

    internal class Block
    {
        public BlockType BlockType { get; private set; }
        // Set commandResolution at initialization only
        // Once query begins, the commandResolution remains whatever was saved first
        public CommandResolution CommandResolution
        {
            get;
            private set;
        } = Communicator.Configuration.AutoCommitEnabled ? CommandResolution.Commit : CommandResolution.Rollback;
    }

    internal class BlockBuilder
    {
        private string command = string.Empty;

        public BlockBuilder SetCommand(string command)
        {
            this.command = command;
            return this;
        }

        public void Build(ref Block block)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                return;
            }
        }
    }

    internal static class BlockExecutor
    {
        public static void Execute(ref Block block)
        {
            switch (block.BlockType)
            {
                case BlockType.DDC:
                    ExecuteDDL();
                    break;
                case BlockType.DMC:
                    ExecuteDML();
                    break;
            }

            if (block.CommandResolution == CommandResolution.Commit)
            {
                DataCache.Flush();
            }
        }

        private static void ExecuteDDL()
        {

        }

        private static void ExecuteDML()
        {

        }
    }
}