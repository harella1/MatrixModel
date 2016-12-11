using System.IO;
using DesignPatterns.Command;

namespace DesignPatterns
{
    public partial class Program
    {
        public static void Command()
        {
            IFileOperator fileOperator = new FileSystemOperator(Path.GetTempPath());
            //IFileOperator fileOperator = new FtpFileOperator(new Uri("ftp://tepuri.org"));

            var invoker = new FileOperationInvoker();
            ICommand command;

            command = new CreateFileCommand(fileOperator, "HelloWorld.txt");
            invoker.Enqueue(command);

            command = new RenameFileCommand(fileOperator, "HelloWorld.txt", "GoodbyeWorld.txt");
            invoker.Enqueue(command);

            command = new DeleteFileCommand(fileOperator, "GoodbyeWorld.txt");
            invoker.Enqueue(command);

            invoker.InvokeAll();
        }
    }

    namespace Command
    {
    }
}