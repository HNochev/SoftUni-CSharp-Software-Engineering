namespace P02._Identity_Before.Contracts
{
    using System.Collections.Generic;

    public interface IAccountRegistrationSettings
    {
        bool RequireUniqueEmail { get; }

        int MinRequiredPasswordLength { get; }

        int MaxRequiredPasswordLength { get; }
    }
}
