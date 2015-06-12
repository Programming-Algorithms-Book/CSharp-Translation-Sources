namespace Huffman3
{
    using System.Collections.Generic;

    public class HeapForest
    {
        private readonly List<Tree> list = new List<Tree>();

        public int Count
        {
            get
            {
                return this.list.Count;
            }
        }

        public Tree GetMin()
        {
            var first = this.list[0];
            this.list[0] = this.list[this.list.Count - 1];
            this.list.RemoveAt(this.list.Count - 1);
            this.SiftDown(0);
            return first;
        }

        public void Add(Tree elem)
        {
            this.list.Add(elem);
            this.SiftUp(this.list.Count - 1);
        }

        private void SiftUp(int index)
        {
            int parent = (index / 2) - 1 + (index % 2);
            if (parent < 0)
            {
                return;
            }

            if (this.list[parent].Weight <= this.list[index].Weight)
            {
                return;
            }

            Tree temp = this.list[index];
            this.list[index] = this.list[parent];
            this.list[parent] = temp;
            this.SiftUp(parent);
        }

        private void SiftDown(int index)
        {
            int minChild = this.MinChild(index);
            if (minChild == -1)
            {
                return;
            }

            if (this.list[index].Weight <= this.list[minChild].Weight)
            {
                return;
            }

            Tree temp = this.list[index];
            this.list[index] = this.list[minChild];
            this.list[minChild] = temp;
            this.SiftDown(minChild);
        }

        private int MinChild(int index)
        {
            int left = (index * 2) + 1;
            if (left >= this.list.Count)
            {
                return -1;
            }

            if (left == this.list.Count - 1 ||
                this.list[left].Weight <= this.list[left + 1].Weight)
            {
                return left;
            }

            return left + 1;
        }
    }
}