using System;

namespace Minis.Reflection.Names
{
    [Flags]
    public enum NameOfTypeOptions
    {
        None = 0,

        CSharpKeywords = 1,
        IncludeSystemNamespace = 2,
        IncludeCollectionNamespaces = 4,

        Short = CSharpKeywords,
        Full = IncludeSystemNamespace | IncludeCollectionNamespaces,

        Default = Short
    }
}