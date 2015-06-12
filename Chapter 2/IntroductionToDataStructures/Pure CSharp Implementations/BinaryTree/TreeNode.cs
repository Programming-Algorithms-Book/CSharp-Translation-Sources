namespace BinaryTree
{
    public class TreeNode<TKey, TValue>
    {
        public TreeNode(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
            this.Parent = null;
            this.LeftChild = null;
            this.RightChild = null;
        }

        public TKey Key { get; set; }

        public TValue Value { get; set; }

        public TreeNode<TKey, TValue> Parent { get; set; }

        public TreeNode<TKey, TValue> LeftChild { get; set; }

        public TreeNode<TKey, TValue> RightChild { get; set; }
    }
}