namespace LetterTranslation
{
    using System;

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
            Console.WriteLine("Списък от всички възможни преводи: ");
            InitLanguage();
            pN = 0;
            NextLetter(0);
            Console.WriteLine("Общ брой различни преводи: {0} ", total);
        }

        /* В примера се използва Морзовата азбука: 0 е точка, а 1-та е тире */
        private static void InitLanguage()
        {
            Transf[0].FirstString = "А";
            Transf[0].SecondString = "01";
            Transf[1].FirstString = "Б";
            Transf[1].SecondString = "1000";
            Transf[2].FirstString = "В";
            Transf[2].SecondString = "011";
            Transf[3].FirstString = "Г";
            Transf[3].SecondString = "110";
            Transf[4].FirstString = "Д";
            Transf[4].SecondString = "100";
            Transf[5].FirstString = "Е";
            Transf[5].SecondString = "0";
            Transf[6].FirstString = "Ж";
            Transf[6].SecondString = "0001";
            Transf[7].FirstString = "З";
            Transf[7].SecondString = "1100";
            Transf[8].FirstString = "И";
            Transf[8].SecondString = "00";
            Transf[9].FirstString = "Й";
            Transf[9].SecondString = "0111";
            Transf[10].FirstString = "К";
            Transf[10].SecondString = "101";
            Transf[11].FirstString = "Л";
            Transf[11].SecondString = "0100";
            Transf[12].FirstString = "М";
            Transf[12].SecondString = "11";
            Transf[13].FirstString = "Н";
            Transf[13].SecondString = "10";
            Transf[14].FirstString = "О";
            Transf[14].SecondString = "111";
            Transf[15].FirstString = "П";
            Transf[15].SecondString = "0110";
            Transf[16].FirstString = "Р";
            Transf[16].SecondString = "010";
            Transf[17].FirstString = "С";
            Transf[17].SecondString = "000";
            Transf[18].FirstString = "Т";
            Transf[18].SecondString = "1";
            Transf[19].FirstString = "У";
            Transf[19].SecondString = "001";
            Transf[20].FirstString = "Ф";
            Transf[20].SecondString = "0010";
            Transf[21].FirstString = "Х";
            Transf[21].SecondString = "0000";
            Transf[22].FirstString = "Ц";
            Transf[22].SecondString = "1010";
            Transf[23].FirstString = "Ч";
            Transf[23].SecondString = "1110";
            Transf[24].FirstString = "Ш";
            Transf[24].SecondString = "1111";
            Transf[25].FirstString = "Щ";
            Transf[25].SecondString = "1101";
            Transf[26].FirstString = "Ю";
            Transf[26].SecondString = "0011";
            Transf[27].FirstString = "Я";
            Transf[27].SecondString = "0101";
            Transf[28].FirstString = "1";
            Transf[28].SecondString = "01111";
            Transf[29].FirstString = "2";
            Transf[29].SecondString = "00111";
            Transf[30].FirstString = "3";
            Transf[30].SecondString = "00011";
            Transf[31].FirstString = "4";
            Transf[31].SecondString = "00001";
            Transf[32].FirstString = "5";
            Transf[32].SecondString = "00000";
            Transf[33].FirstString = "6";
            Transf[33].SecondString = "10000";
            Transf[34].FirstString = "7";
            Transf[34].SecondString = "11000";
            Transf[35].FirstString = "8";
            Transf[35].SecondString = "11100";
            Transf[36].FirstString = "9";
            Transf[36].SecondString = "11110";
            Transf[37].FirstString = "0";
            Transf[37].SecondString = "11111";
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

            for (int k = 0; k < N; k++)
            {
                uint len = (uint)Transf[k].SecondString.Length;
                for (int i = 0; i < len; i++)
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