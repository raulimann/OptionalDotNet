namespace OptionalDotNet;

public class Optional
{
    protected static readonly Optional EmptyNonGeneric = new(null);
    
    protected object? ValueNonGeneric { get; }
    
    protected Optional(object? value) => this.ValueNonGeneric = value;
}
