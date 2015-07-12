namespace KruskalAlgorithm
{
    using System;

    public struct Arc : IComparable<Arc>
    {
        public int Vertex1 { get; set; }

        public int Vertex2 { get; set; }

        public int Weight { get; set; }

        public int CompareTo(Arc other)
        {
            return this.Weight.CompareTo(other.Weight);
        }
    }
}