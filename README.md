# EvoAssembly [Beta]
EvoAssembly converts compiled .NET assemblies, or select types, to collectible assemblies.

## Examples
The following examples demonstrate how to convert type and assemblies into their convertible counterparts.

```csharp
using Root.Code.PI.E01D; // Programmer Interface
```

```csharp
// Example1: Convert a type
var convertedType = EvoAssembly.QuickConvert(inputType);

// Example2: Convert an assembly
var convertedAssembly = EvoAssembly.QuickConvert(inputAssembly);

// Example3: Convert an array of types
var convertedTypes = EvoAssembly.QuickConvert(new []{inputType1, inputType2});

// Example4: Convert an array of assemblies
var convertedAssemblies = EvoAssembly.QuickConvert(new []{inputAssembly1, inputAssembly2});
      


```

## Known Issues / To-Do List

* calli instruction not implemented yet
* unsafe code not tested, though pointers types should be supported.
* no p-invoke support
* assembly and module attributes not supported
* modifiers not supported

## Limitations

* It is not possible to create some recursively defined types, nor is it possible to create some nested type relationships, due to .NET runtime emit API limitations.  


*Last Updated:* August 13th, 2018
