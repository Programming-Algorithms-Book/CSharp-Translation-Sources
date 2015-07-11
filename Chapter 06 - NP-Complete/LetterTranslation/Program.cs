namespace LetterTranslation
{
    using System;
    using System.Text;

    public class Program
    {
        /* Максимален брой съответствия между букви */
        private const int MaxN = 40;
        /* Максимална дължина на дума за превод */
        private const int MaxTranslation = 200;
        /* Брой съответствия */
        private const uint N = 38;

        private static readonly TranslationType[] Transf = new TranslationType[MaxN];

        private static readonly uint[] Translation = new uint[MaxTranslation];

        /* Дума за превод */
        private static string str1 = "101001010";
        private static uint pN;
        private static uint total = 0;

        internal static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Списък от всички възможни преводи: ");
            InitLanguage();
            pN = 0;
            NextLetter(0);
            Console.WriteLine("Общ брой различни преводи: {0} ", total);
        }

        /* В примера се използва Морзовата азбука: 0 е точка, а 1-та е тире */
        private static void InitLanguage()
        {
            Transf[0] = new TranslationType("А", "01");
            Transf[1] = new TranslationType("Б", "1000");
            Transf[2] = new TranslationType("В", "011");
            Transf[3] = new TranslationType("Г", "110");
            Transf[4] = new TranslationType("Д", "100");
            Transf[5] = new TranslationType("Е", "0");
            Transf[6] = new TranslationType("Ж", "0001");
            Transf[7] = new TranslationType("З", "1100");
            Transf[8] = new TranslationType("И", "00");
            Transf[9] = new TranslationType("Й", "0111");
            Transf[10] = new TranslationType("K", "101");
            Transf[11] = new TranslationType("Л", "0100");
            Transf[12] = new TranslationType("М", "11");
            Transf[13] = new TranslationType("Н", "10");
            Transf[14] = new TranslationType("О", "111");
            Transf[15] = new TranslationType("П", "0110");
            Transf[16] = new TranslationType("Р", "010");
            Transf[17] = new TranslationType("С", "000");
            Transf[18] = new TranslationType("Т", "1");
            Transf[19] = new TranslationType("У", "001");
            Transf[20] = new TranslationType("Ф", "0010");
            Transf[21] = new TranslationType("Х", "0000");
            Transf[22] = new TranslationType("Ц", "1010");
            Transf[23] = new TranslationType("Ч", "1110");
            Transf[24] = new TranslationType("Ш", "1111");
            Transf[25] = new TranslationType("Щ", "1101");
            Transf[26] = new TranslationType("Ю", "0011");
            Transf[27] = new TranslationType("Я", "0101");
            Transf[28] = new TranslationType("1", "01111");
            Transf[29] = new TranslationType("2", "00111");
            Transf[30] = new TranslationType("3", "00011");
            Transf[31] = new TranslationType("4", "00001");
            Transf[32] = new TranslationType("5", "00000");
            Transf[33] = new TranslationType("6", "10000");
            Transf[34] = new TranslationType("7", "11000");
            Transf[35] = new TranslationType("8", "11100");
            Transf[36] = new TranslationType("9", "11110");
            Transf[37] = new TranslationType("0", "11111");
        }

        /* Отпечатва превод */
        private static void PrintTranslation()
        {
            total++;
            for (int i = 0; i < pN; i++)
            {
                Console.Write("{0}", Transf[Translation[i]].FirstString);
            }

            Console.WriteLine();
        }

        /* Намира следваща буква */
        private static void NextLetter(int count)
        {
            if (count == str1.Length)
            {
                PrintTranslation();
                return;
            }

            for (uint k = 0; k < N; k++)
            {
                uint len = (uint)Transf[k].SecondString.Length;
                uint i;
                for (i = 0; i < len; i++)
                {
                    if ((int)i >= Transf[k].SecondString.Length
                        || (int)(i + count) >= str1.Length
                        || str1[(int)(i + count)] != Transf[k].SecondString[(int)i])
                    {
                        break;
                    }
                }

                if (i == len)
                {
                    Translation[pN++] = k;
                    NextLetter(count + Transf[k].SecondString.Length);
                    pN--;
                }
            }
        }
    }
}