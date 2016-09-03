using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Validate.Tests
{
    [TestClass]
    public class ValidateTests
    {
        [TestMethod]
        public void IsTrue()
        {
            Validate.IsTrue(true, "failed");
        }

        [TestMethod]
        public void IsTrueThrowsException()
        {
            try
            {
                Validate.IsTrue(false, "failed");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("failed", e.Message);
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void NotNull()
        {
            Validate.NotNull(5);
        }

        [TestMethod]
        public void NotNullThrowsException()
        {
            try
            {
                Validate.NotNull(null, "failed");
            }
            catch (NullReferenceException e)
            {
                Assert.AreEqual("failed", e.Message);
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void NotEmptyArray()
        {
            Validate.NotEmpty(new[] { 1, 2, 3 });
        }

        [TestMethod]
        public void NotEmptyArrayThrowsException()
        {
            try
            {
                Validate.NotEmpty(new int[0], "failed");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("failed", e.Message);
                return;
            }

            Assert.Fail();
        }
        
        [TestMethod]
        public void NotEmptyCollection()
        {
            var ints = new List<int> {1};
            Validate.NotEmpty(ints);
        }

        [TestMethod]
        public void NotEmptyCollectionThrowsException()
        {
            try
            {
                Validate.NotEmpty(new List<int>(), "failed");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("failed", e.Message);
                return;
            }

            Assert.Fail();
        }
        
        [TestMethod]
        public void NotBlank()
        {
            Validate.NotBlank("hello");
        }

        [TestMethod]
        public void NotBlankThrowsException()
        {
            try
            {
                Validate.NotBlank("", "failed");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("failed", e.Message);
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void NoNullElementsArray()
        {
            Validate.NoNullElements(new[] { "1", "2", "3" });
        }

        [TestMethod]
        public void NoNullElementsArrayThrowsException()
        {
            try
            {
                Validate.NoNullElements(new string[] { null }, "failed");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("failed", e.Message);
                return;
            }

            Assert.Fail();
        }
        
        [TestMethod]
        public void NoNullElementsCollection()
        {
            var strings = new List<string> {"1"};
            Validate.NoNullElements(strings);
        }

        [TestMethod]
        public void NoNullElementsCollectionThrowsException()
        {
            try
            {
                Validate.NoNullElements(new List<string>() { null }, "failed");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("failed", e.Message);
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void ValidIndexArray()
        {
            Validate.IsTrue(true);
            Validate.ValidIndex(new[] { "1", "2", "3" }, 1);
        }

        [TestMethod]
        public void ValidIndexArrayThrowsException()
        {
            try
            {
                Validate.ValidIndex(new string[] { null }, 2, "failed");
            }
            catch (IndexOutOfRangeException e)
            {
                Assert.AreEqual("failed", e.Message);
                return;
            }

            Assert.Fail();
        }
        
        [TestMethod]
        public void ValidIndexCollection()
        {
            var strings = new List<string> {"1"};
            Validate.ValidIndex(strings, 0);
        }

        [TestMethod]
        public void ValidIndexCollectionThrowsException()
        {
            try
            {
                Validate.ValidIndex(new List<string>() { "1" }, 2, "failed");
            }
            catch (IndexOutOfRangeException e)
            {
                Assert.AreEqual("failed", e.Message);
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void ValidState()
        {
            Validate.ValidState(true, "failed");
        }

        [TestMethod]
        public void ValidStateThrowsException()
        {
            try
            {
                Validate.ValidState(false, "failed");
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual("failed", e.Message);
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void MatchesPattern()
        {
            Validate.MatchesPattern("123", "1", "failed");
        }

        [TestMethod]
        public void MatchesPatternThrowsException()
        {
            try
            {
                Validate.MatchesPattern("123", "4", "failed");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("failed", e.Message);
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void InclusiveBetween()
        {
            Validate.InclusiveBetween(0, 5, 3, "failed");
        }

        [TestMethod]
        public void InclusiveBetweenThrowsException()
        {
            try
            {
                Validate.InclusiveBetween(0, 5, 6, "failed");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("failed", e.Message);
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void ExclusiveBetween()
        {
            Validate.ExclusiveBetween(0, 5, 3, "failed");
        }

        [TestMethod]
        public void ExclusiveBetweenThrowsException()
        {
            try
            {
                Validate.ExclusiveBetween(0, 5, 5, "failed");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("failed", e.Message);
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void IsInstanceOf()
        {
            Validate.IsInstanceOf(typeof(int), 5, "failed");
        }

        [TestMethod]
        public void IsInstanceOfThrowsException()
        {
            try
            {
                Validate.IsInstanceOf(typeof(int), "a", "failed");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("failed", e.Message);
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void IsAssignableFrom()
        {
            Validate.IsAssignableFrom(typeof(ICollection<string>), typeof(IList<string>), "failed");
        }

        [TestMethod]
        public void IsAssignableFromThrowsException()
        {
            try
            {
                Validate.IsAssignableFrom(typeof(int), typeof(string), "failed");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("failed", e.Message);
                return;
            }

            Assert.Fail();
        }
    }
}
