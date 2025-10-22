using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace pr3
{
    internal class ListOfClasses
    {
        private List<AudioAndVideo> audioAndVideos;
        private Dictionary<int, AudioAndVideo> dAudioAndVideos;

        public ListOfClasses()
        {
            audioAndVideos = new List<AudioAndVideo>();
            dAudioAndVideos = new Dictionary<int, AudioAndVideo>();
        }

        public void WorkWithListOfClasses()
        {
            Console.WriteLine("\t\t\tРабота с коллекцией AudioAndVideo List\n\n");
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
                Console.WriteLine($"Найденная пара: ключ - {n}, значение - {dAudioAndVideos[n]}");
            }
            else
            {
                int price = int.Parse(Console.ReadLine());
                var res = dAudioAndVideos.Where(x => x.Value.Price == price);
                Console.WriteLine("Найденные значения");
                foreach (var item in res)
                {
                    Console.WriteLine($"\"{item}\"");
                }
            }

            Console.WriteLine("\t\t\tРабота с интерфейсами\n\n");
            ProccesInterfacesWork();
        }

        private void ProccesInterfacesWork()
        {
            AudioAndVideo l1 = new AudioAndVideo();
            AudioAndVideo l2 = (AudioAndVideo)l1.Clone();
            Console.WriteLine("Результат клонирования\n" + $"{l2}");
            Console.WriteLine("Результат сравнения первого и второго экземпляров: " + $"{l2.CompareTo(l1)}");

            AudioAndVideo l3 = new AudioAndVideo("Name", 123456);
            Console.WriteLine("Результат сравнения второго и третьего экземпляров: " + $"{l2.CompareTo(l3)}\n");
        }

        private void AddNumOfElementsToList(int n)
        {
            Random rndm = new Random();

            for (int i = 1; i <= n; i++)
            {
                string manufacturer = "Name" + i;
                int price = (int)rndm.Next(300, 7000000);
                AudioAndVideo tech = new(manufacturer, price);
                audioAndVideos.Add(tech);
            }
        }

        private void PrintCollectionOfList()
        {
            foreach (var item in audioAndVideos)
                Console.WriteLine(item.ToString()); 
            Console.WriteLine();
        }

        private void PrintCollectionOfDictionary()
        {
            foreach (var item in dAudioAndVideos)
                Console.WriteLine(item.ToString());
            Console.WriteLine();
        }

        private void DeleteNumOfItemsInList(int n)
        {
            for (int i = 0; i < n; i++)
                audioAndVideos.Remove(audioAndVideos[i]);
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
            for (int i = 0; i < audioAndVideos.Count(); i++)
            {
                var generatedKey = i + 1;
                dAudioAndVideos.Add(generatedKey, audioAndVideos[i]);
            }
        }
    }
}
