using System.Collections.Generic;
using System.Security.Policy;

namespace Kurs_Project
{
    public class Report
    {
        public static List<ReportStruct> MakeReport(Hash T1, Avl T2, string keyAvl, double raiting1, double raiting2)
        {
            List<ReportStruct> repList = new List<ReportStruct>();
            List<Table2> nodeAvl = T2.Find(keyAvl);
            Table1 tempTable1;
            ReportStruct temp = new ReportStruct();
            for (int i = 0; i < nodeAvl.Count; i++)
            {
                tempTable1 = T1.Searching(nodeAvl[i].Login);
                if (tempTable1.Rating <= raiting2 && tempTable1.Rating >= raiting1)
                {
                    temp.Login = tempTable1.Login;
                    temp.Category = nodeAvl[i].Category;
                    temp.Naming = nodeAvl[i].Naming;
                    temp.Price = nodeAvl[i].Price;
                    temp.Rating = tempTable1.Rating;
                    temp.CountOfSell = tempTable1.CountOfSell;
                    repList.AddFirst(temp);
                }
            }
            return repList;
        }
    }
}