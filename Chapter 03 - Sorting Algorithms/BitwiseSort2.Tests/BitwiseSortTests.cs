namespace BitwiseSort2.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class BitwiseSortTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BitwiseSortNullElementsShouldThrowException()
        {
            BitwiseSortAlgorithm.BitwiseSort(null, 0, 0, 0);
        }

        [Test]
        public void BitwiseSortEmptyElementsShouldNotSort()
        {
            const int MaxValue = 0;
            const uint BitMask = (uint)int.MaxValue + 1;

            Element[] elements = new Element[MaxValue];
            BitwiseSortAlgorithm.BitwiseSort(elements, 0, MaxValue - 1, BitMask);
            CheckSortingOrder(elements);
        }

        [Test]
        public void BitwiseSortRandomElementsSholdSortCorrectly()
        {
            const int MaxValue = 100;
            const int TestsCount = 100;
            const uint BitMask = (uint)int.MaxValue + 1;

            Element[] elements = new Element[MaxValue];
            for (int i = 0; i < TestsCount; i++)
            {
                BitwiseSortAlgorithm.Initialize(elements, MaxValue);
                BitwiseSortAlgorithm.BitwiseSort(elements, 0, MaxValue - 1, BitMask);
                CheckSortingOrder(elements);
            }
        }

        private static void CheckSortingOrder(Element[] elements)
        {
            for (int i = 0; i < elements.Length - 1; i++)
            {
                if (elements[i].Key > elements[i + 1].Key)
                {
                    Assert.Fail("Array is not sorted!");
                }
            }
        }
    }
}
