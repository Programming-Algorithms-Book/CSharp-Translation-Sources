namespace LinkedList
{
    public class LinkedList<T, K>
    {
        public LinkedList()
        {
        }

        public LinkedList(K key, T data)
        {
            this.Key = key;
            this.Data = data;
        }

        public K Key { get; set; }

        public T Data { get; set; }

        public LinkedList<T, K> Next { get; set; }
    }
}