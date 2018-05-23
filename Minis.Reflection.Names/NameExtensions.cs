using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

using JetBrains.Annotations;

using static Minis.Ensurances.ReSharperHelpers;

namespace Minis.Reflection.Names
{
    public static class NameExtensions
    {
        private static bool IsCollectionNamespace([NotNull] string ns)
        {
            switch (ns)
            {
                case "System.Collections":
                case "System.Collections.Generic":
                case "System.Collections.Specialized":
                    return true;

                default:
                    return false;
            }
        }

        [NotNull]
        private static readonly Dictionary<Type, string> _CSharpKeywords = new Dictionary<Type, string>
                                                                           {
                                                                               [typeof(char)] = "char",
                                                                               [typeof(string)] = "string",

                                                                               [typeof(byte)] = "byte",
                                                                               [typeof(sbyte)] = "sbyte",

                                                                               [typeof(short)] = "short",
                                                                               [typeof(ushort)] = "ushort",

                                                                               [typeof(int)] = "int",
                                                                               [typeof(uint)] = "uint",

                                                                               [typeof(long)] = "long",
                                                                               [typeof(ulong)] = "ulong",

                                                                               [typeof(float)] = "float",
                                                                               [typeof(double)] = "double",
                                                                               [typeof(decimal)] = "decimal",

                                                                               [typeof(bool)] = "bool",
                                                                           };

        [NotNull]
        public static string NameOf([NotNull] this Type type, NameOfTypeOptions options = NameOfTypeOptions.Default)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if ((options & NameOfTypeOptions.CSharpKeywords) != 0)
                if (_CSharpKeywords.TryGetValue(type, out string name))
                    return name;

            string namespacePrefix = string.Empty;
            if (type.Namespace == "System")
            {
                if ((options & NameOfTypeOptions.IncludeSystemNamespace) != 0)
                    namespacePrefix = "System.";
            }
            else if (IsCollectionNamespace(type.Namespace))
            {
                if ((options & NameOfTypeOptions.IncludeCollectionNamespaces) != 0)
                    namespacePrefix = type.Namespace + ".";
            }
            else
                namespacePrefix = type.Namespace + ".";

            var typeInfo = type.GetTypeInfo();
            assume(typeInfo != null);
            if (typeInfo.IsGenericType)
            {
                var name = type.Name.Substring(0, type.Name.IndexOf('`'));
                var builder = new StringBuilder();
                builder.Append(namespacePrefix);
                builder.Append(name).Append('<');

                var genericParameters = type.IsConstructedGenericType
                                            ? typeInfo.GenericTypeArguments
                                            : typeInfo.GenericTypeParameters;

                builder.Append(string.Join(",", genericParameters.Select(gtp => NameOf(gtp, options))));

                builder.Append('>');
                return builder.ToString();
            }

            return namespacePrefix + type.Name;
        }

        [NotNull]
        public static string ShortNameOf([NotNull] this Type type) => NameOf(type, NameOfTypeOptions.Short);

        [NotNull]
        public static string FullNameOf([NotNull] this Type type) => NameOf(type, NameOfTypeOptions.Full);
    }
}