using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TopRepeatedNumber.UnitTests
{
    [TestClass]
    public class FindInTests
    {
        [TestMethod]
        public void WhenNumbersIsNull_ThrowsArgumntNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => TopRepeatedNumber.FindIn(null));
        }

        [TestMethod]
        public void WhenNumbersIsEmpty_ThrowsArgumntNullException()
        {
            Assert.ThrowsException<ArgumentException>(() => TopRepeatedNumber.FindIn(Enumerable.Empty<int>()));
        }

        [TestMethod]
        public void WhenNumbersContainsOneItem_ItemIsReturned_AndCountIsOne()
        {
            var numbers = new List<int> { 2 };

            var result = TopRepeatedNumber.FindIn(numbers);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Number);
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void WhenNumbersContainsMoreThanItem_AndOneItemIsTop_ReturnsItem_AndCount()
        {
            var numbers = new List<int> { 3, 2, 3 };

            var result = TopRepeatedNumber.FindIn(numbers);

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Number);
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void WhenNumbersContainsMoreThanItem_AndMoreThanOneItemIsTop_ReturnsFirstItem_AndCount()
        {
            var numbers = new List<int> { 5, 7, 5, 4, 7, 7, 5 };

            var result = TopRepeatedNumber.FindIn(numbers);

            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Number);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void WhenNumbersContainsMoreThanItem_AndNoItemsAreTop_ReturnsFirstItem_AndCount()
        {
            var numbers = new List<int> { 8, 7, 8, 4, 7 };

            var result = TopRepeatedNumber.FindIn(numbers);

            Assert.IsNotNull(result);
            Assert.AreEqual(8, result.Number);
            Assert.AreEqual(2, result.Count);
        }
    }
}
