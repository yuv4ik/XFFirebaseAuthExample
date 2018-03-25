namespace XFFirebaseAuthExample
{
    public interface IValidationRule<T>
    {
        string Description { get; }
        bool Validate(T value);
    }
}
