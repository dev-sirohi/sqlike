using MiniSql.REPL;
using MiniSql.Library;

var commandProcessor = new MiniSql.Library.Core.CommandProcessor();
new MiniSql.REPL.Core().Initialize(commandProcessor);