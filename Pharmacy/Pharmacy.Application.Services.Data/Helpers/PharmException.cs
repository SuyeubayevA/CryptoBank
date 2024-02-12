namespace Pharmacy.Infrastructure.Data.Helpers
{
    public class PharmException : Exception
    {
        public PharmException() : base() { }
        public PharmException(string message) : base(message) { }
    }
}
