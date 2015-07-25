namespace BitwiseSort.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class BitwiseSortTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BitwiseSortNullInputShouldThrowException()
        {
            BitwiseSortAlgorithm.BitwiseSort(null);
        }

        [Test]
        public void BitwiseSortRandomInputShouldBeSorted()
        {
            const int MaxValue = 100;

            NodeElement head = BitwiseSortAlgorithm.Initialize(MaxValue);
            head = BitwiseSortAlgorithm.BitwiseSort(head);
            CheckSortOrder(head);

            Assert.Pass("Collection is sorted");
        }

        private static void CheckSortOrder(NodeElement head)
        {
            for (; head.Next != null; head = head.Next)
            {
                if (head.Data.Key > head.Next.Data.Key)
                {
                    Assert.Fail("Collection is not sorted correctly! Wrong Order!");
                }
            }
        }
    }
}
