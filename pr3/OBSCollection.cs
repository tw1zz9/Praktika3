using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr3
{
    public class OBSCollection
    {
        private ObservableCollection<AudioAndVideo> collection;

        public OBSCollection()
        {
            collection = new ObservableCollection<AudioAndVideo>();
        }

        public void WorkWithOBSCollection()
        {
            collection.CollectionChanged += AUVCollectionUpdated;

            collection.Add(new AudioAndVideo("Name", 10000));
            collection.Add(new AudioAndVideo("SAMSUNG", 12345));
            collection.Add(new AudioAndVideo("Unknown", 20000));

            collection.Remove(collection[0]);
            collection[1] = new AudioAndVideo("BESTTECHEVER", 999999);
        }

        private static void AUVCollectionUpdated(object sender,
            NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        if (e.NewItems?[0] is AudioAndVideo item)
                            Console.WriteLine($"Добавлен элемент: {item}");
                        break;
                    }
                case NotifyCollectionChangedAction.Remove:
                    {
                        if (e.OldItems?[0] is AudioAndVideo item)
                            Console.WriteLine($"Удалённый элемент: {item}");
                        break;
                    }
                case NotifyCollectionChangedAction.Replace:
                    {
                        if (e.NewItems?[0] is AudioAndVideo itemN &&
                            e.OldItems?[0] is AudioAndVideo itemO)
                            Console.WriteLine($"Заменён элемент {itemO} на элемент {itemN}");
                        break;
                    }
            }
        }
    }
}
