using System.IO;

namespace Kurs_Project
{
    public class saveElements
    {
        public static void AvlToFile(Avl tree, string FileOfTable2)
        {
            StreamWriter writer = new StreamWriter(FileOfTable2);
            LinkedList<Table2> obj = new LinkedList<Table2>();
            obj = tree.AvlToList();
            foreach (var i in obj)
            {
                writer.WriteLine($"{i.Login};{i.Naming};{i.Price};{i.Category}");
            }
            writer.Close();
        }

        public static void HashToFile(Hash hashTable, string FileOfTable1)
        {
            StreamWriter writer = new StreamWriter(FileOfTable1);
            Table1[] tempTable = hashTable.Getter();
            for (int i = 0; i < hashTable.Capacity; i++)
            {
                writer.WriteLine($"{tempTable[i].Login};{tempTable[i].CountOfSell};{tempTable[i].Rating}");
            }
            writer.Close();
        }

        public static void ReportToFile(LinkedList<ReportStruct> reportStruct, string FileOfTable3)
        {
            StreamWriter writer = new StreamWriter(FileOfTable3);
            foreach (var i in reportStruct)
            {
                writer.Write($"Логин - {i.Login}, Рейтинг продавца - {i.Rating}, Количество продаж - {i.CountOfSell}, ");
                writer.WriteLine($"Наименование товара - {i.Naming}, Цена - {i.Price}, Категория - {i.Category}");
            }
            writer.Close();
        }
    }
}
