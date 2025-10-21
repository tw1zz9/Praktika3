using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace pr3
{
    public class ArList
    {
        public void WorkWithArrayLIst()
        {
            ArrayList uncommunicatedСollection = new ArrayList();

            Random rndm = new Random();

            // Заполнение случайными числами
            for (int i = 0; i < 5; i++)
                uncommunicatedСollection.Add(rndm.Next(1, 100));

            // Добавление строки
            string str = "DobavlennayaStroka";
            uncommunicatedСollection.Add(str);

            // Вывод элементов
            for (int i = 0; i < uncommunicatedСollection.Count; i++)
                Console.Write(uncommunicatedСollection[i] + " ");

            // Удаление по номеру
            int dInd = 0;
            Console.WriteLine("\nВыберите номер элемента для удаления: ");
            if (int.TryParse(Console.ReadLine(), out dInd) && dInd > 0)
                dInd -= 1;
            else dInd = 0;
            uncommunicatedСollection.Remove(uncommunicatedСollection[dInd]);

            // Вывод количества элементов и самой коллекции
            Console.WriteLine("Кол-во элементов: " + uncommunicatedСollection.Count);
            Console.WriteLine("Коллекция:");
            for (int i = 0; i < uncommunicatedСollection.Count; i++)
                Console.Write(uncommunicatedСollection[i] + " ");
            Console.WriteLine();

            // Нахождение элемента по значению
            Console.WriteLine("Введите значение, которое хотите получить из коллекции: ");
            var elem = Console.ReadLine();
            var condition = int.TryParse(elem, out var x);
            for (int i = 0; i < uncommunicatedСollection.Count; i++)
            {
                if (condition && uncommunicatedСollection[i].Equals(x))
                {
                    Console.WriteLine($"Выбранный элемент: {x} с типом {x.GetType()} и индексом {i}");
                }
                else if (!condition && uncommunicatedСollection[i].Equals(elem))
                {
                    Console.WriteLine($"Выбраный элемент: {elem} с типом {elem.GetType()} и индексом {i}");
                }
            }
        }
    }
}
