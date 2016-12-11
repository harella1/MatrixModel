namespace DesignPatterns.Command
{
    public class CreateFileCommand : ICommand
    {
        private readonly string m_FileName;
        private readonly IFileOperator m_Receiver;

        public CreateFileCommand(IFileOperator receiver, string fileName)
        {
            m_Receiver = receiver;
            m_FileName = fileName;
        }

        public void Execute()
        {
            m_Receiver.Create(m_FileName);
        }
    }
}