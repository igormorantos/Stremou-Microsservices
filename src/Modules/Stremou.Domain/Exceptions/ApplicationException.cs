
namespace Stremou.Modules.Domain.Exceptions
{
    public class ApplicationException : Exception
    {
        protected ApplicationException(string name, string message)
            : base(message) =>
            Name = name;

        public string Name { get; }
    }
}
