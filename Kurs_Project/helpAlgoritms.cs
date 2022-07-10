namespace Kurs_Project
{
    public class helpAlgoritms
    {
        public static bool mask(string key, int table)
        {
            if (key.Length > 11)
            {
                char[] templ = { key[0], key[1], key[2], key[3], key[4], key[5] , key[6]};
                string tempLeft = new string(templ);
                char[] tempr = { key[key.Length - 4], key[key.Length - 3], key[key.Length - 2], key[key.Length - 1] };
                string tempRight = new string(tempr);
                if (table == 1)
                {
                    if (tempLeft == "table1_" && tempRight == ".txt")
                    {
                        return true;
                    }
                }
                else if (table == 2)
                {
                    if (tempLeft == "table2_" && tempRight == ".txt")
                    {
                        return true;
                    }
                }
                else if (table == 3)
                {
                    if (tempLeft == "report_" && tempRight == ".txt")
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }
    }
}