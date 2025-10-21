using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

            for (int i = 0; i < 5; i++)
                uncommunicatedСollection.Add(rndm.Next(1, 100));

            string str = "DobavlennayaStroka";

            uncommunicatedСollection.Add(str);

            for (int i = 0; i < uncommunicatedСollection.Count; i++)
                Console.Write(uncommunicatedСollection[i] + " ");

            int del_ind = 0;
            Console.WriteLine("\nВыберите номер элемента для удаления: ");
            del_ind = int.Parse(Console.ReadLine()) - 1;

            uncommunicatedСollection.Remove(uncommunicatedСollection[del_ind]);
            Console.WriteLine("Кол-во элементов: " + uncommunicatedСollection.Count);
            Console.WriteLine("Коллекция:");

            for (int i = 0; i < uncommunicatedСollection.Count; i++)
                Console.Write(uncommunicatedСollection[i] + " ");
        }
    }
}
