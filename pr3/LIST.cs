using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr3
{
    public class LIST
    {
        private List<char> chars;
        private Dictionary<int, char> dChars;

        public LIST()
        {
            chars = new List<char>();
            dChars = new Dictionary<int, char>();
        }

        public void WorkWithList()
        {
            Console.WriteLine("\t\t\tРабота с коллекцией char List\n\n");
            Console.WriteLine("Из скольки элементов будет состоять коллекция (заполняется случайными числами):");
            var n = InputInt();
            AddNumOfElementsToList(n);
            
            // Вывод коллекции
            PrintCollectionOfList();

            // Удаление n-ого количества первых элементов
            Console.WriteLine("Введите число удаляемых элементов (от начала списка):");
            n = InputInt();
            DeleteNumOfItemsInList(n);

            // Новое добавление элементов
            Console.WriteLine("Введите количество новых элементов: ");
            n = InputInt();
            AddNumOfElementsToList(n);

            // Снова вывод коллекции
            PrintCollectionOfList();

            // Создаём словарь со значениями из List
            // Также генерируются значения для ключей под копируемые элементы List
            CreateDictionary();

            // Вывод второй коллекции на консоль
            PrintCollectionOfDictionary();

            Console.WriteLine("Каким образом хотите найти элемент словаря? \n(0 - по ключу, 1 - по значению)");
            bool take;
            var s = Console.ReadLine();
            if (s == "1") take = false;
            else take = true;

            Console.WriteLine("Введите нужное значение: ");
            if (take)
            {
                n = InputInt();
                Console.WriteLine($"Найденная пара: ключ - {n}, значение - {dChars[n]}");
            }
            else
            {
                char c = char.Parse(Console.ReadLine());
                var res = dChars.Where(x => x.Value == c);
                Console.WriteLine("Найденные значения");
                foreach (var item in res)
                {
                    Console.WriteLine($"\"{item}\"");
                }
            }
        }

        private void AddNumOfElementsToList(int n)
        {
            Random rndm = new Random();

            for (int i = 0; i < n; i++)
            {
                char s = (char)rndm.Next(0, 100);
                chars.Add(s);
            }
        }

        private void PrintCollectionOfList()
        {
            foreach (var item in chars)
                Console.Write("\"" + item + "\", ");
            Console.WriteLine();
        }

        private void PrintCollectionOfDictionary()
        {
            foreach(var item in dChars)
                Console.WriteLine("\"" + item + "\", ");
            Console.WriteLine();
        }

        private void DeleteNumOfItemsInList(int n)
        {
            for (int i = 0; i < n; i++)
                chars.Remove(chars[i]);
        }

        private int InputInt()
        {
            var n = 0;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out n) && n > 0)
                    return n;
                else Console.WriteLine($"Неверно введено число удаляемых элементов. Повторите: ");
            }
        }

        private void CreateDictionary()
        {
            for (int i = 0; i < chars.Count(); i++)
            {
                var generatedKey = i + 1;
                dChars.Add(generatedKey, chars[i]);
            }
        }


    }
}
