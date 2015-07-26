namespace BubbleSort.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class BubbleSortTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BubbleSortNullElementsShouldThrowException()
        {
            BubbleSortingAlgorithm.BubbleSort(null);
        }

        [Test]
        public void BubbleSortEmptyElementsShouldNotSort()
        {
            const int MaxValue = 0;

            Element[] elements = new Element[MaxValue];
            BubbleSortingAlgorithm.BubbleSort(elements);
            CheckSortingOrder(elements);
        }

        [Test]
        public void BubbleSortRandomElementsSholdSortCorrectly()
        {
            const int MaxValue = 100;
            const int TestsCount = 100;

            Element[] elements = new Element[MaxValue];
            for (int i = 0; i < TestsCount; i++)
            {
                BubbleSortingAlgorithm.Initialize(elements);
                BubbleSortingAlgorithm.BubbleSort(elements);
                CheckSortingOrder(elements);
            }
        }

        private static void CheckSortingOrder(Element[] elements)
        {
            for (int i = 0; i < elements.Length - 1; i++)
            {
                if (elements[i].Key > elements[i + 1].Key)
                {
                    throw new Exception("Масива не е сортиран правилно.");
                }
            }
        }
    }
}
