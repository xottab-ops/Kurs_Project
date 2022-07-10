using System;
using System.IO;

namespace Kurs_Project
{
    public class initFiles
    {
        public static Table1[] FileToHash(string fileOfTable1)
        {
            if (!File.Exists(fileOfTable1))
            {
                return Array.Empty<Table1>();
            }
            string[] table1Strings = File.ReadAllLines(fileOfTable1);
            if (table1Strings != null)
            {
                string[] temp;
                Table1 tempTable1;
                Table1[] tempHash = new Table1[table1Strings.Length];
                for (int i = 0; i < table1Strings.Length; i++)
                {
                    temp = table1Strings[i].Split(new char[] { ';' });
                    tempTable1 = Inits.InitTable1(temp[0], Convert.ToInt32(temp[1]), Convert.ToDouble(temp[2]));
                    tempHash[i] = tempTable1;
                }
                return tempHash;
            }
            else
            {
                return Array.Empty<Table1>();
            }
        }

        public static Table2[] FileToAvl(string FileOfTable2)
        {
            if (!File.Exists(FileOfTable2))
            {
                return Array.Empty<Table2>();
            }
            string[] table2Strings = File.ReadAllLines(FileOfTable2);
            if (table2Strings != null)
            {
                string[] temp;
                Table2 tempTable2;
                Table2[] tempList = new Table2[table2Strings.Length];
                for (int i = 0; i < table2Strings.Length; i++)
                {
                    temp = table2Strings[i].Split(new char[] { ';' });
                    tempTable2 = Inits.InitTable2(temp[0], temp[1], Convert.ToDouble(temp[2]), temp[3]);
                    tempList[i] = tempTable2;
                }
                return tempList;
            }
            else
            {
                return Array.Empty<Table2>();
            }
        }
    }
}