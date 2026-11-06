namespace MiniSql.Library;

public partial class Core
{
    public class CommandProcessor
    {
        private Block block = new();
        private BlockBuilder blockBuilder = new();

        public void Process(string command, ref string output)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                return;
            }

            blockBuilder.SetCommand(command).Build(ref block);
            BlockExecutor.Execute(ref block);
        }
    }
}