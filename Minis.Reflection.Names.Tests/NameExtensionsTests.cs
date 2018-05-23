using System;
using System.Collections.Generic;

using NUnit.Framework;

// ReSharper disable AssignNullToNotNullAttribute

namespace Minis.Reflection.Names.Tests
{
    [TestFixture]
    public class NameExtensionsTests
    {
        public static IEnumerable<TestCaseData> ShortNameOf_Type_TestCases()
        {
            yield return new TestCaseData(typeof(char), "char");
            yield return new TestCaseData(typeof(string), "string");

            yield return new TestCaseData(typeof(byte), "byte");
            yield return new TestCaseData(typeof(sbyte), "sbyte");
            
            yield return new TestCaseData(typeof(short), "short");
            yield return new TestCaseData(typeof(ushort), "ushort");
            
            yield return new TestCaseData(typeof(int), "int");
            yield return new TestCaseData(typeof(uint), "uint");
            
            yield return new TestCaseData(typeof(long), "long");
            yield return new TestCaseData(typeof(ulong), "ulong");
            
            yield return new TestCaseData(typeof(float), "float");
            yield return new TestCaseData(typeof(double), "double");
            yield return new TestCaseData(typeof(decimal), "decimal");
            
            yield return new TestCaseData(typeof(bool), "bool");

            yield return new TestCaseData(typeof(DateTime), "DateTime");
            yield return new TestCaseData(typeof(TimeSpan), "TimeSpan");

            yield return new TestCaseData(typeof(IEnumerable<int>), "IEnumerable<int>");
        }

        [Test]
        [TestCaseSource(nameof(ShortNameOf_Type_TestCases))]
        public void ShortNameOf_Type_WithTestCases(Type type, string expected)
        {
            var name = type.ShortNameOf();

            Assert.That(name, Is.EqualTo(expected));
        }

        public static IEnumerable<TestCaseData> FullNameOf_Type_TestCases()
        {
            yield return new TestCaseData(typeof(char), "System.Char");
            yield return new TestCaseData(typeof(string), "System.String");

            yield return new TestCaseData(typeof(byte), "System.Byte");
            yield return new TestCaseData(typeof(sbyte), "System.SByte");
            
            yield return new TestCaseData(typeof(short), "System.Int16");
            yield return new TestCaseData(typeof(ushort), "System.UInt16");
            
            yield return new TestCaseData(typeof(int), "System.Int32");
            yield return new TestCaseData(typeof(uint), "System.UInt32");
            
            yield return new TestCaseData(typeof(long), "System.Int64");
            yield return new TestCaseData(typeof(ulong), "System.UInt64");
            
            yield return new TestCaseData(typeof(float), "System.Single");
            yield return new TestCaseData(typeof(double), "System.Double");
            yield return new TestCaseData(typeof(decimal), "System.Decimal");
            
            yield return new TestCaseData(typeof(bool), "System.Boolean");

            yield return new TestCaseData(typeof(DateTime), "System.DateTime");
            yield return new TestCaseData(typeof(TimeSpan), "System.TimeSpan");

            yield return new TestCaseData(typeof(IEnumerable<int>), "System.Collections.Generic.IEnumerable<System.Int32>");
        }

        [Test]
        [TestCaseSource(nameof(FullNameOf_Type_TestCases))]
        public void FullNameOf_Type_WithTestCases(Type type, string expected)
        {
            var name = type.FullNameOf();

            Assert.That(name, Is.EqualTo(expected));
        }
    }
}
