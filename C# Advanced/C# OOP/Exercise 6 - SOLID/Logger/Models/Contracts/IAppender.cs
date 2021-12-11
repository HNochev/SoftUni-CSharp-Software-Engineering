namespace Exercise_6___SOLID.Models.Contracts
{
    using Enumerations;

    public interface IAppender
    {
        ILayout Layout { get; }

        Level Level { get; }

        void Append(IError error);
    }
}