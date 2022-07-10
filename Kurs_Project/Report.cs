using System.Collections.Generic;
using System.Security.Policy;

namespace Kurs_Project
{
    public class Report
    {
        public static LinkedList<ReportStruct> MakeReport(Hash T1, Avl T2, string keyAvl, double raiting1, double raiting2)
        {
            LinkedList<ReportStruct> repList = new LinkedList<ReportStruct>();
            LinkedList<Table2> nodeAvl = T2.Find(keyAvl);
            Table1 tempTable1;
            ReportStruct temp = new ReportStruct();
            foreach (var i in nodeAvl)
            {
                tempTable1 = T1.Searching(i.Login);
                if (tempTable1.Rating <= raiting2 && tempTable1.Rating >= raiting1)
                {
                    temp.Login = tempTable1.Login;
                    temp.Category = i.Category;
                    temp.Naming = i.Naming;
                    temp.Price = i.Price;
                    temp.Rating = tempTable1.Rating;
                    temp.CountOfSell = tempTable1.CountOfSell;
                    repList.Add(temp);
                }
            }
            return repList;
        }
    }
}