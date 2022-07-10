namespace Kurs_Project
{
    public struct Table1
    {
        public string Login { set; get; }
        public int CountOfSell{ set; get; }
        public double Rating { set; get; }

        public static bool operator ==(Table1 obj1, Table1 obj2)
        {
            return (obj1.Login == obj2.Login && obj1.Rating == obj2.Rating && obj1.CountOfSell == obj2.CountOfSell);
        }

        public static bool operator !=(Table1 obj1, Table1 obj2)
        {
            return (!(obj1 == obj2));
        }
        
    }

    public struct Table2
    {
        public string Login { set; get; }  
        public string Naming { set; get; }
        public string Category { set; get; }
        public double Price { set; get; }
        public override string ToString()
        {
            return Login + " " + Naming + " " + Price + " " + Category + "\r\n";
        }
        public static bool operator ==(Table2 obj1, Table2 obj2)
        {
            return (obj1.Login == obj2.Login && obj1.Naming == obj2.Naming && obj1.Category == obj2.Category && obj1.Price == obj2.Price);
        }

        public static bool operator !=(Table2 obj1, Table2 obj2)
        {
            return !(obj1 == obj2);
        }
        
    }
    public struct ReportStruct
    {
        public string Login { set; get; }
        public double CountOfSell{ set; get; }
        public double Rating { set; get; }
        
        public string Naming { set; get; }
        public string Category { set; get; }
        public double Price { set; get; }
        public override string ToString()
        {
            return Login + " " + Rating + " " + CountOfSell + " " + Naming + " " + Price + " " + Category + "\r\n";
        }
        
    }

    public struct HashTableItem
    {
        public int Status;
        public Table1 Value;
        public int CountOf2;
        public override string ToString()
        {
            return Value.Login + " " + Value.CountOfSell + " " + Value.Rating + " Статус - " + Status + " Связанных записей - " + CountOf2;
        }
    };

    public class Inits
    {
        public static Table1 InitTable1(string login, int countOfSell, double rating)
        {
            Table1 temp = new Table1();
            temp.Login = login;
            temp.Rating = rating;
            temp.CountOfSell = countOfSell;
            return temp;
        }
        public static Table2 InitTable2(string login, string naming, double price, string category)
        {
            Table2 temp = default;
            temp.Login = login;
            temp.Category = category;
            temp.Naming = naming;
            temp.Price = price;
            return temp;
        }
    }
    
}