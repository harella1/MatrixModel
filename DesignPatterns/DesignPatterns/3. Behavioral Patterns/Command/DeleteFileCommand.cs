namespace DesignPatterns.Command
{
    public class DeleteFileCommand : ICommand
    {
        private readonly string m_FileName;
        private readonly IFileOperator m_Receiver;

        public DeleteFileCommand(IFileOperator receiver, string fileName)
        {
            m_Receiver = receiver;
            m_FileName = fileName;
        }

        public void Execute()
        {
            m_Receiver.Delete(m_FileName);
        }
    }
}