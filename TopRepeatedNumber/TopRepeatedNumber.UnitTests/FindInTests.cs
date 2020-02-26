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
        public void WhenNumbersIsNull_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => TopRepeatedNumber.FindIn(null));
        }

        [TestMethod]
        public void WhenNumbersIsEmpty_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentException>(() => TopRepeatedNumber.FindIn(Enumerable.Empty<int>()));
        }

        [TestMethod]
        public void WhenNumbersContainsOneItem_ItemIsReturned_AndCountIsOne()
        {
            var numbers = new List<int> { 2 };

            var result = TopRepeatedNumber.FindIn(numbers);

            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(new List<int> { 2 }, result.NumbersWithMaxCount.ToList());
            Assert.AreEqual(1, result.MaxCount);
        }

        [TestMethod]
        public void WhenNumbersContainsMoreThanItem_AndNoItemsAreTop_ReturnsAllItems_AndCount()
        {
            var numbers = new List<int> { 1, 2, 3 };

            var result = TopRepeatedNumber.FindIn(numbers);

            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3 }, result.NumbersWithMaxCount.ToList());
            Assert.AreEqual(1, result.MaxCount);
        }

        [TestMethod]
        public void WhenNumbersContainsMoreThanItem_AndOneItemIsTop_ReturnsItem_AndCount()
        {
            var numbers = new List<int> { 3, 2, 3 };

            var result = TopRepeatedNumber.FindIn(numbers);

            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(new List<int> { 3 }, result.NumbersWithMaxCount.ToList());
            Assert.AreEqual(2, result.MaxCount);
        }

        [TestMethod]
        public void WhenNumbersContainsMoreThanItem_AndMoreThanOneItemIsTop_ReturnsAllItems_AndCount()
        {
            var numbers = new List<int> { 7, 5, 7, 4, 5, 5, 7 };

            var result = TopRepeatedNumber.FindIn(numbers);

            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(new List<int> { 7, 5 }, result.NumbersWithMaxCount.ToList());
            Assert.AreEqual(3, result.MaxCount);
        }
    }
}
