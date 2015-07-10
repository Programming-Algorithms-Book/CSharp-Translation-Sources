namespace OptimalBitonicSequence
{
    public struct St
    {
        /* Дължина на максималната ненамаляваща подредица, завършваща в i */
        public int Length { get; set; }

        /* Индекс на предишния елемент в макс. редица */
        public int Back { get; set; }

        /* Сума на елементите на максималната редица */
        public long Sum { get; set; }
    }
}