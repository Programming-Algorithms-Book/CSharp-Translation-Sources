namespace ProductOfArrayElements
{
    using System;

    public class ProductOfArrayElements
    {
        internal static void Main()
        {
            int[] elements = new int[] { -5, 8, 22, 25, -158, 73 };
            long product = GetProduct(elements);

            Console.WriteLine(
                "Сумата на масива с елементи {0} е {1}",             
                string.Join(", ", elements), 
                product);
        }

        private static long GetProduct(int[] elements)
        {
            long product = 1L;
            for (int i = 0; i < elements.Length; i++)
            {
                product *= elements[i];
            }

            return product;
        }
    }
}
