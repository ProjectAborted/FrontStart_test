namespace Library.Application.Exceptions
{
    // Thrown when a requested resource does not exist → 404 Not Found
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }

    // Thrown when a business rule is violated (e.g. no copies left) → 400 Bad Request
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message) { }
    }

    // Thrown when a uniqueness constraint is violated (e.g. duplicate email) → 409 Conflict
    public class ConflictException : Exception
    {
        public ConflictException(string message) : base(message) { }
    }
}