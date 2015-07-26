namespace CombSorter.Tests
{
    using System;

    using CombSort;

    using NUnit.Core;
    using NUnit.Framework;

    [TestFixture]
    public class CombSorterTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CombSortNullElementsShouldThrowException()
        {
            CombSorter.CombSort(null);
        }

        [Test]
        public void CombSortEmptyElementsShouldNotSort()
        {
            const int MaxValue = 0;

            Element[] elements = new Element[MaxValue];
            CombSorter.CombSort(elements);
            CheckSortingOrder(elements, elements);
        }

        [Test]
        public void CombRandomElementsSholdSortCorrectly()
        {
            const int MaxValue = 100;
            const int TestsCount = 100;

            for (int i = 0; i < TestsCount; i++)
            {
                Element[] elements = new Element[MaxValue];
                Element[] saveArray = new Element[MaxValue];
                CombSorter.Initialize(elements);
                Array.Copy(elements, saveArray, elements.Length);
                CombSorter.CombSort(elements);

                CheckSortingOrder(elements, saveArray);
            }
        }

        private static void CheckSortingOrder(Element[] sortedArray, Element[] originalArray)
        {
            /* 1. Проверка за наредба във възходящ ред */
            for (int i = 0; i < sortedArray.Length - 1; i++)
            {
                if (sortedArray[i].Key > sortedArray[i + 1].Key)
                {
                    throw new InvalidOperationException("Array is not sorted!");
                }
            }

            /* 2. Проверка за пермутация на изходните елементи */
            bool[] found = new bool[sortedArray.Length];
            for (int i = 0; i < sortedArray.Length; i++)
            {
                int j;
                for (j = 0; j < sortedArray.Length; j++)
                {
                    if (!found[j] && sortedArray[i].Equals(originalArray[j]))
                    {
                        found[j] = true;
                        break;
                    }
                }

                if (j >= sortedArray.Length)
                {
                    throw new InvalidOperationException("No element found");
                }
            }
        }
    }
}
