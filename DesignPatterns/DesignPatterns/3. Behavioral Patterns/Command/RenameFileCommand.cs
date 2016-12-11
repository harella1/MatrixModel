namespace DesignPatterns.Command
{
    public class RenameFileCommand : ICommand
    {
        private readonly string m_NewName;
        private readonly string m_OldName;
        private readonly IFileOperator m_Receiver;

        public RenameFileCommand(IFileOperator receiver, string oldName, string newName)
        {
            m_Receiver = receiver;
            m_OldName = oldName;
            m_NewName = newName;
        }

        public void Execute()
        {
            m_Receiver.Rename(m_OldName, m_NewName);
        }
    }
}