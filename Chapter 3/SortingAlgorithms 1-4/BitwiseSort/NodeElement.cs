namespace BitwiseSort
{
    public class NodeElement
    {
        public NodeElement()
        {
            this.Data = new Element();
        }

        public Element Data { get; set; }

        public NodeElement Next { get; set; }

        public override string ToString()
        {
            return this.Data.Key.ToString();
        }
    }
}