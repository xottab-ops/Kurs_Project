using System.IO;

namespace Kurs_Project
{
    public class saveElements
    {
        public static void AvlToFile(Avl tree, string FileOfTable2)
        {
            StreamWriter writer = new StreamWriter(FileOfTable2);
            List<Table2> obj = new List<Table2>();
            Avl.AvlToList(tree.Root, obj);
            for (int i = 0; i < obj.Count; i++)
            {
                writer.WriteLine($"{obj[i].Login};{obj[i].Naming};{obj[i].Price};{obj[i].Category}");
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

        public static void ReportToFile(List<ReportStruct> reportStruct, string FileOfTable3)
        {
            StreamWriter writer = new StreamWriter(FileOfTable3);
            for (int i = 0; i < reportStruct.Count; i++)
            {
                writer.Write($"Логин - {reportStruct[i].Login}, Рейтинг продавца - {reportStruct[i].Rating}, Количество продаж - {reportStruct[i].CountOfSell}, ");
                writer.WriteLine($"Наименование товара - {reportStruct[i].Naming}, Цена - {reportStruct[i].Price}, Категория - {reportStruct[i].Category}");
            }
            writer.Close();
        }
    }
}
