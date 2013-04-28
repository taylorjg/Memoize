using System;
using Memoize;
using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace MemoizeTests
{
    [TestFixture]
    internal class Memoizer_TwoParam_Tests
    {
        private Func<int, int, int> _func;
        private Func<int, int, int> _memoizedFunc;
        private int _numRealCalls;

        private int Add(int x, int y)
        {
            _numRealCalls++;
            return x + y;
        }

        [SetUp]
        public void SetUp()
        {
            _func = Add;
            _memoizedFunc = Memoizer.Memoize(_func);
            _numRealCalls = 0;
        }

        [Test]
        public void Memoize_A_CallsTheRealFunctionOnce()
        {
            // Arrange, Act
            var result = _memoizedFunc(1, 2);

            // Assert
            Assert.That(result, Is.EqualTo(3));
            Assert.That(_numRealCalls, Is.EqualTo(1));
        }

        [Test]
        public void Memoize_AA_CallsTheRealFunctionOnce()
        {
            // Arrange, Act
            var result1 = _memoizedFunc(1, 2);
            var result2 = _memoizedFunc(1, 2);

            // Assert
            Assert.That(result1, Is.EqualTo(3));
            Assert.That(result2, Is.EqualTo(3));
            Assert.That(_numRealCalls, Is.EqualTo(1));
        }

        [Test]
        public void Memoize_AAAAA_CallsTheRealFunctionOnce()
        {
            // Arrange, Act
            var result1 = _memoizedFunc(1, 2);
            var result2 = _memoizedFunc(1, 2);
            var result3 = _memoizedFunc(1, 2);
            var result4 = _memoizedFunc(1, 2);
            var result5 = _memoizedFunc(1, 2);

            // Assert
            Assert.That(result1, Is.EqualTo(3));
            Assert.That(result2, Is.EqualTo(3));
            Assert.That(result3, Is.EqualTo(3));
            Assert.That(result4, Is.EqualTo(3));
            Assert.That(result5, Is.EqualTo(3));
            Assert.That(_numRealCalls, Is.EqualTo(1));
        }

        [Test]
        public void Memoize_AB_CallsTheRealFunctionTwice()
        {
            // Arrange, Act
            var result1 = _memoizedFunc(1, 2);
            var result2 = _memoizedFunc(3, 4);

            // Assert
            Assert.That(result1, Is.EqualTo(3));
            Assert.That(result2, Is.EqualTo(7));
            Assert.That(_numRealCalls, Is.EqualTo(2));
        }

        [Test]
        public void Memoize_AABB_CallsTheRealFunctionTwice()
        {
            // Arrange, Act
            var result1 = _memoizedFunc(1, 2);
            var result2 = _memoizedFunc(1, 2);
            var result3 = _memoizedFunc(3, 4);
            var result4 = _memoizedFunc(3, 4);

            // Assert
            Assert.That(result1, Is.EqualTo(3));
            Assert.That(result2, Is.EqualTo(3));
            Assert.That(result3, Is.EqualTo(7));
            Assert.That(result4, Is.EqualTo(7));
            Assert.That(_numRealCalls, Is.EqualTo(2));
        }

        [Test]
        public void Memoize_ABAB_CallsTheRealFunctionTwice()
        {
            // Arrange, Act
            var result1 = _memoizedFunc(1, 2);
            var result2 = _memoizedFunc(3, 4);
            var result3 = _memoizedFunc(1, 2);
            var result4 = _memoizedFunc(3, 4);

            // Assert
            Assert.That(result1, Is.EqualTo(3));
            Assert.That(result2, Is.EqualTo(7));
            Assert.That(result3, Is.EqualTo(3));
            Assert.That(result4, Is.EqualTo(7));
            Assert.That(_numRealCalls, Is.EqualTo(2));
        }
    }
}
