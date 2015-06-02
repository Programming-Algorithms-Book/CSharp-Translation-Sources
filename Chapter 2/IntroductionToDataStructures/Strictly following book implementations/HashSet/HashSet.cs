using System;

class Program
{
    private const int Step = 107; // Стъпка на увеличаване при колизия
    private const double MaxFillLevel = 0.8; // Максимално ниво на запълване
    private static ulong n = 32; //Начален размер на хеш-таблицата
    private static ulong count = 0;
    private static SingleWord[] hashTable = new SingleWord[n];

    struct SingleWord
    {
        public string Word { get; set; } // Ключ - символен низ
        public ulong Frequency { get; set; } // Честота на срещане на думата
    }

    // Хеш-функция за символен низ 
    static ulong HashFunction(string key)
    {
        ulong result = 0;

        for (int i = 0; i < key.Length; i++)
        {
            result += result + key[i];
        }

        return result & (n - 1);
    }

    // Търсене в хеш-таблицата: връща 1 при успех, и 0 – иначе
    // При успех: index съдържа индекса на намерения елемент
    // При неуспех: свободна позиция, където може да бъде вмъкнат
    static int Get(string key, out ulong index)
    {
        index = HashFunction(key);
        ulong k = index;

        do
        {
            if (hashTable[index].Word == null)
            {
                return 0;
            }
            if (key == hashTable[index].Word)
            {
                return 1;
            }
            index = (index + Step) & (n - 1);
        } while (index != k);

        return 0;
    }

    // Разширяване на хеш-таблицата
    static void Resize()
    {
        ulong hashIndex = 0;

        // 1. Запазване на старата хеш-таблица
        SingleWord[] oldHashTable = hashTable;

        // 2. Двойно разширяване
        n <<= 1;

        //3. Заделяне на памет за новата хеш-таблица
        hashTable = new SingleWord[n];

        //4. Преместване на записите в новата хеш-таблица
        for (ulong i = 0; i < (n >> 1); i++)
        {
            if (oldHashTable[i].Word != null)
            {
                // Премества записа на новото място
                if (Get(oldHashTable[i].Word, out hashIndex) == 0)
                {
                    hashTable[hashIndex] = oldHashTable[i];
                }
                else
                {
                    throw new InvalidOperationException("Грешка при разширяване на хеш-таблицата!");
                }
            }
        }
    }

    // Добавяне на елемент в хеш-таблицата
    static void Put(string key)
    {
        ulong index = 0;

        if (Get(key, out index) == 0) // Думата не е в хеш-таблицата
        {
            hashTable[index].Word = key;
            hashTable[index].Frequency = 1;

            count++;

            if (count > n * MaxFillLevel)
            {
                Resize();
            }
        }
        else
        {
            hashTable[index].Frequency++;
        }
    }

    // Отпечатване на хеш-таблицата
    static void PrintAll()
    {
        for (ulong i = 0; i < n; i++)
        {
            if (hashTable[i].Word != null)
            {
                Console.WriteLine("{0} {1}", hashTable[i].Word, hashTable[i].Frequency);
            }
        }
    }

    static void Main()
    {
        Put("reload");
        Put("crush tour");
        Put("room service");
        Put("load");
        Put("reload");
        Put("reload");

        PrintAll();

        ulong find = 0;
        if (Get("reload", out find) != 0)
        {
            Console.WriteLine("Честота на думата 'reload': {0}", hashTable[find].Frequency);
        }
        else
        {
            Console.WriteLine("Думата 'reload' липсва!");
        }

        if (Get("download", out find) != 0)
        {
            Console.WriteLine("Честота на думата 'download': {0}", hashTable[find].Frequency);
        }
        else
        {
            Console.WriteLine("Думата 'download' липсва!");
        }
    }
}
