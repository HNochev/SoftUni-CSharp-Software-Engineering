namespace Exercise_6___SOLID.Models.Contracts
{
    public interface IFile
    {
        string Path { get; }

        ulong Size { get; }

        string Write(ILayout layout, IError error);
    }
}