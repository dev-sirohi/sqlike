namespace MiniSql.Library;

public partial class Core
{
    internal static class Utilities
    {
        internal enum ReservedKeywords
        {
            CREATE,
            READ,
            UPDATE,
            DELETE,
            SCHEMA,
            DB,
            SESSION,
            TABLE,
            RECORD,
            DATE,
            DATETIME,
            WHERE,
            TYPE,
            NAME,
            AS,
            RETURN,
            VALUES,
            ADD,
            REMOVE,
            COMMIT,
            ROLLBACK,
        }

        public static HashSet<string> ReservedKeywordsSet = new();

        static Utilities()
        {
            foreach (var keyword in Enum.GetNames<ReservedKeywords>())
            {
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    continue;
                }
                ReservedKeywordsSet.Add(keyword.ToUpper());
                ReservedKeywordsSet.Add(keyword.ToLower());
            }
        }
    }
}