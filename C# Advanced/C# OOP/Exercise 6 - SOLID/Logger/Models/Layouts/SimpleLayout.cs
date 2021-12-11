namespace Exercise_6___SOLID.Models.Layouts
{
    using Contracts;

    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
