namespace MergesortLinkedListDoubleStep
{
    public class Node
    {
        static Node()
        {
            Z = new Node { Value = int.MaxValue };
            Z.Next = Z;
        }

        public static Node Z { get; private set; }

        public int Value { get; set; }

        public Node Next { get; set; }
    }
}