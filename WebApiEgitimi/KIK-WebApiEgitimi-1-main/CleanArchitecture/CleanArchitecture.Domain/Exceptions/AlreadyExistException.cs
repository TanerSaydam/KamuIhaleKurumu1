namespace CleanArchitecture.Domain.Exceptions;

public sealed class AlreadyExistException : Exception
{
    const string message = "Bu kayıt daha önce yapılmış!";
    public AlreadyExistException() : base(message)
    {
        
    }
}
