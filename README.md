# OptionalDotNet
A simple reinterpretation of the `java.util.Optional<?>` Class from Java in C#.

## Usage

```csharp
Optional<ExampleObject> optionalExample = Optional.of(new ExampleObject(1));

// Invoke action if the optional is present
optionalExample.IfPresent(example => Console.WriteLine(example.Value));
optionalExample.IfPresentOrElse(example => Console.WriteLine(example.Value), () => Console.WriteLine("No Value"));

if (optionalExample.IsPresent)
{
    Console.WriteLine(optionalExample.Value);
}

if (optionalExample.IsEmpty)
{
    Console.WriteLine("No Value");
}

// Provide a fallback value
ExampleObject example = optionalExample.OrElseGet(() => new ExampleObject(2));
ExampleObject example = optionalExample.OrElse(new ExampleObject(2));

// Throw an exception if the optional is empty
ExampleObject example = optionalExample.OrElseThrow(() => new NullReferenceException());
ExampleObject example = optionalExample.OrElseThrow();
```
