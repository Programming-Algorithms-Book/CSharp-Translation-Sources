using System;

class Translat
{
    /* Максимален брой съответствия между букви */
    const int MAXN = 40;
    /* Максимална дължина на дума за превод */
    const int MAXTL = 200;
    /* Брой съответствия */ 
    const uint n = 38;
    /* Дума за превод */
    static string str1 = "101001010"; 

    struct transType {
    public string st1;
    public string st2;
    };
    static transType[] transf = new transType[MAXN];

    static uint[] translation = new uint[MAXTL];
    static uint pN, total = 0;

    /* В примера се използва Морзовата азбука: 0 е точка, а 1-та е тире */
    static void initLanguage()
    {
        transf[0].st1 = "А";
        transf[0].st2 = "01";
        transf[1].st1 = "Б";
        transf[1].st2 = "1000";
        transf[2].st1 = "В";
        transf[2].st2 = "011";
        transf[3].st1 = "Г";
        transf[3].st2 = "110";
        transf[4].st1 = "Д";
        transf[4].st2 = "100";
        transf[5].st1 = "Е";
        transf[5].st2 = "0";
        transf[6].st1 = "Ж";
        transf[6].st2 = "0001";
        transf[7].st1 = "З";
        transf[7].st2 = "1100";
        transf[8].st1 = "И";
        transf[8].st2 = "00";
        transf[9].st1 = "Й";
        transf[9].st2 = "0111";
        transf[10].st1 = "К";
        transf[10].st2 = "101";
        transf[11].st1 = "Л";
        transf[11].st2 = "0100";
        transf[12].st1 = "М";
        transf[12].st2 = "11";
        transf[13].st1 = "Н";
        transf[13].st2 = "10";
        transf[14].st1 = "О";
        transf[14].st2 = "111";
        transf[15].st1 = "П";
        transf[15].st2 = "0110";
        transf[16].st1 = "Р";
        transf[16].st2 = "010";
        transf[17].st1 = "С";
        transf[17].st2 = "000";
        transf[18].st1 = "Т";
        transf[18].st2 = "1";
        transf[19].st1 = "У";
        transf[19].st2 = "001";
        transf[20].st1 = "Ф";
        transf[20].st2 = "0010";
        transf[21].st1 = "Х";
        transf[21].st2 = "0000";
        transf[22].st1 = "Ц";
        transf[22].st2 = "1010";
        transf[23].st1 = "Ч";
        transf[23].st2 = "1110";
        transf[24].st1 = "Ш";
        transf[24].st2 = "1111";
        transf[25].st1 = "Щ";
        transf[25].st2 = "1101";
        transf[26].st1 = "Ю";
        transf[26].st2 = "0011";
        transf[27].st1 = "Я";
        transf[27].st2 = "0101";
        transf[28].st1 = "1";
        transf[28].st2 = "01111";
        transf[29].st1 = "2";
        transf[29].st2 = "00111";
        transf[30].st1 = "3";
        transf[30].st2 = "00011";
        transf[31].st1 = "4";
        transf[31].st2 = "00001";
        transf[32].st1 = "5";
        transf[32].st2 = "00000";
        transf[33].st1 = "6";
        transf[33].st2 = "10000";
        transf[34].st1 = "7";
        transf[34].st2 = "11000";
        transf[35].st1 = "8";
        transf[35].st2 = "11100";
        transf[36].st1 = "9";
        transf[36].st2 = "11110";
        transf[37].st1 = "0";
        transf[37].st2 = "11111";
    }

    /* Отпечатва превод */
    static void printTranslation()
    {
        uint i;
        total++;
        for (i = 0; i < pN; i++)
            Console.Write("{0}", transf[translation[i]].st1);
        Console.WriteLine();
    }

    /* Намира следваща буква */
    static void nextLetter(int count)
    {
        uint i, k;
        if (count == str1.Length)
        {
            printTranslation();
            return;
        }
        for (k = 0; k < n; k++)
        {
            uint len = (uint)transf[k].st2.Length;
            for (i = 0; i < len; i++)
                if ((int)i>=transf[k].st2.Length || (int)(i+count)>=str1.Length ||
                    str1[(int)(i + count)] != transf[k].st2[(int)i])
                    break;
            if (i == len)
            {
                translation[pN++] = k;
                nextLetter(count + transf[k].st2.Length);
                pN--;
            }
        }
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Списък от всички възможни преводи: ");
        initLanguage();
        pN = 0;
        nextLetter(0);
        Console.WriteLine("Общ брой различни преводи: {0} ", total);
        
    }
}