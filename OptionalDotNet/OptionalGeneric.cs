namespace OptionalDotNet;


public class Optional<T> : Optional, IEquatable<Optional<T>>
{
    public static Optional<T> Empty => (Optional<T>)EmptyNonGeneric;
    
    public T Value => this.ValueNonGeneric == null ? throw new NullReferenceException("No optional value present!") : (T)this.ValueNonGeneric;
    
    public bool IsPresent => this.ValueNonGeneric != null;
    
    public bool IsEmpty => this.ValueNonGeneric == null;
    
    
    protected Optional(T value) : base(value) { }

    
    public void IfPresent(Action<T> action) 
    {
        if (this.IsPresent) 
        {
            action.Invoke(this.Value);
        }
    }

    public void IfPresentOrElse(Action<T> action, Action emptyAction) 
    {
        if (this.IsPresent) 
        {
            action.Invoke(this.Value);
        } 
        else 
        {
            emptyAction.Invoke();
        }
    }

    public T OrElse(T other) => this.IsPresent ? this.Value : other;
    
    public T OrElseGet(Func<T> supplier) => this.IsPresent ? this.Value : supplier.Invoke();
    
    public T OrElseThrow() => this.IsPresent ? this.Value : throw new NullReferenceException("No optional value present!");
    
    public T OrElseThrow<TException>(Func<TException> exceptionSupplier) where TException : Exception => this.IsPresent ? this.Value : throw exceptionSupplier.Invoke();
    
    public static Optional<T> Of(T value) => value == null ? Empty : new Optional<T>(value);
    
    
    public bool Equals(Optional<T>? other) => other != null && GetHashCode() == other.GetHashCode();
    
    public override bool Equals(object? obj) => Equals(obj as Optional<T>);
    
    public override int GetHashCode() => this.ValueNonGeneric == null ? 0 : this.ValueNonGeneric.GetHashCode();
}
