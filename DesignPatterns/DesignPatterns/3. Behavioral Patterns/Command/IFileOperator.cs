namespace DesignPatterns.Command
{
    public interface IFileOperator
    {
        void Create(string fileName);
        void Rename(string oldName, string newName);
        void Delete(string fileName);
    }
}