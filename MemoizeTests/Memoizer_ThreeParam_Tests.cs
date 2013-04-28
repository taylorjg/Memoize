using System;
using Memoize;
using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace MemoizeTests
{
    [TestFixture]
    internal class Memoizer_ThreeParam_Tests
    {
        private Func<string, char, int, string> _func;
        private Func<string, char, int, string> _memoizedFunc;
        private int _numRealCalls;

        private string StringTwiddle(string prefix, char c, int count)
        {
            _numRealCalls++;
            return prefix + "-" + new string(c, count);
        }

        [SetUp]
        public void SetUp()
        {
            _func = StringTwiddle;
            _memoizedFunc = Memoizer.Memoize(_func);
            _numRealCalls = 0;
        }

        [Test]
        public void Memoize_A_CallsTheRealFunctionOnce()
        {
            // Arrange, Act
            var result = _memoizedFunc("Hello", 'X', 5);

            // Assert
            Assert.That(result, Is.EqualTo("Hello-XXXXX"));
            Assert.That(_numRealCalls, Is.EqualTo(1));
        }

        [Test]
        public void Memoize_AA_CallsTheRealFunctionOnce()
        {
            // Arrange, Act
            var result1 = _memoizedFunc("Hello", 'X', 5);
            var result2 = _memoizedFunc("Hello", 'X', 5);

            // Assert
            Assert.That(result1, Is.EqualTo("Hello-XXXXX"));
            Assert.That(result2, Is.EqualTo("Hello-XXXXX"));
            Assert.That(_numRealCalls, Is.EqualTo(1));
        }

        [Test]
        public void Memoize_AAAAA_CallsTheRealFunctionOnce()
        {
            // Arrange, Act
            var result1 = _memoizedFunc("Hello", 'X', 5);
            var result2 = _memoizedFunc("Hello", 'X', 5);
            var result3 = _memoizedFunc("Hello", 'X', 5);
            var result4 = _memoizedFunc("Hello", 'X', 5);
            var result5 = _memoizedFunc("Hello", 'X', 5);

            // Assert
            Assert.That(result1, Is.EqualTo("Hello-XXXXX"));
            Assert.That(result2, Is.EqualTo("Hello-XXXXX"));
            Assert.That(result3, Is.EqualTo("Hello-XXXXX"));
            Assert.That(result4, Is.EqualTo("Hello-XXXXX"));
            Assert.That(result5, Is.EqualTo("Hello-XXXXX"));
            Assert.That(_numRealCalls, Is.EqualTo(1));
        }

        [Test]
        public void Memoize_AB_CallsTheRealFunctionTwice()
        {
            // Arrange, Act
            var result1 = _memoizedFunc("Hello", 'X', 5);
            var result2 = _memoizedFunc("Goodbye", 'Y', 3);

            // Assert
            Assert.That(result1, Is.EqualTo("Hello-XXXXX"));
            Assert.That(result2, Is.EqualTo("Goodbye-YYY"));
            Assert.That(_numRealCalls, Is.EqualTo(2));
        }

        [Test]
        public void Memoize_AABB_CallsTheRealFunctionTwice()
        {
            // Arrange, Act
            var result1 = _memoizedFunc("Hello", 'X', 5);
            var result2 = _memoizedFunc("Hello", 'X', 5);
            var result3 = _memoizedFunc("Goodbye", 'Y', 3);
            var result4 = _memoizedFunc("Goodbye", 'Y', 3);

            // Assert
            Assert.That(result1, Is.EqualTo("Hello-XXXXX"));
            Assert.That(result2, Is.EqualTo("Hello-XXXXX"));
            Assert.That(result3, Is.EqualTo("Goodbye-YYY"));
            Assert.That(result4, Is.EqualTo("Goodbye-YYY"));
            Assert.That(_numRealCalls, Is.EqualTo(2));
        }

        [Test]
        public void Memoize_ABAB_CallsTheRealFunctionTwice()
        {
            // Arrange, Act
            var result1 = _memoizedFunc("Hello", 'X', 5);
            var result2 = _memoizedFunc("Goodbye", 'Y', 3);
            var result3 = _memoizedFunc("Hello", 'X', 5);
            var result4 = _memoizedFunc("Goodbye", 'Y', 3);

            // Assert
            Assert.That(result1, Is.EqualTo("Hello-XXXXX"));
            Assert.That(result2, Is.EqualTo("Goodbye-YYY"));
            Assert.That(result3, Is.EqualTo("Hello-XXXXX"));
            Assert.That(result4, Is.EqualTo("Goodbye-YYY"));
            Assert.That(_numRealCalls, Is.EqualTo(2));
        }
    }
}
