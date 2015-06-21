namespace BinarySearch.UsingBitwiseOperations
{
    public class Element<T>
    {
        public Element(int key, T value)
        {
            this.Key = key;
            this.Value = value;
        }

        public int Key { get; set; }

        public T Value { get; set; }
    }
}