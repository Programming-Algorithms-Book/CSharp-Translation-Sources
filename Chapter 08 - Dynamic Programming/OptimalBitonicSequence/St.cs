namespace OptimalBitonicSequence
{
    public struct St
    {
        public int Len { get; set; } /* Дължина на максималната ненамаляваща подредица, завършваща в i */

        public int Back { get; set; } /* Индекс на предишния елемент в макс. редица */

        public long Sum { get; set; } /* Сума на елементите на максималната редица */
    }
}