using System;
using System.Windows;

namespace Kurs_Project
{
    public partial class MainWindow
    {
        private Hash hashTable = new Hash(10);
        private Avl AvlTree = new Avl();
        private List<ReportStruct> _reportStruct = new List<ReportStruct>();
        public MainWindow()
        {
            InitializeComponent();
            /*this.Icon = ;*/
        }
        // РАБОТА С ХЭШ ТАБЛИЦЕЙ
        public void LoadTable1_Click(object sender, RoutedEventArgs e)
        {
            if (helpAlgoritms.mask(TextBlockFile1.Text, 1))
            {
                Table1[] tempHash = initFiles.FileToHash(TextBlockFile1.Text);
                if (tempHash.Length == 0)
                {
                    MessageBox.Show(errors.mistake11);
                    return;
                }
                for (int i = 0; i < tempHash.Length; i++)
                {
                    hashTable.Add(tempHash[i]);
                }
                MessageBox.Show(errors.completeLoad);
            }
            else MessageBox.Show(errors.mistake1);
        }

        public void SaveTable1_Click(object sender, RoutedEventArgs e)
        {
            if (helpAlgoritms.mask(TextBlockFile1.Text, 1))
            {
                saveElements.HashToFile(hashTable, TextBlockFile1.Text);
                MessageBox.Show(errors.completeSave);
            }
            else MessageBox.Show(errors.mistake1);
        }
        
        public void ButtonSearch1Sprav_Click(object sender, RoutedEventArgs e)
        {
            Table1[] tempTable = hashTable.Getter();
            SearchTable1.ItemsSource = tempTable;
        }

        public void AddingTo1_Click(object sender, RoutedEventArgs e)
        {
            int countOfSell;
            double raiting;
            if (int.TryParse(CountOfSell.Text,out countOfSell) == true && double.TryParse(Rating.Text,out raiting) == true)
            {
                if (LoginTo1.Text.Length is < 5 or > 25 || Char.IsDigit(LoginTo1.Text[0]))
                {
                    MessageBox.Show(errors.mistake2);
                    return;
                }
                if (countOfSell < 0 || raiting is < 0 or > 5)
                {
                    MessageBox.Show(errors.mistake2);
                    return;
                }
                if (hashTable.Search(LoginTo1.Text) != -1)
                {
                    MessageBox.Show(errors.mistake3);
                    return;
                }
                Table1 temp = Inits.InitTable1(LoginTo1.Text, countOfSell, raiting);
                hashTable.Add(temp);
                MessageBox.Show(errors.completeAdd);
            }
            else
            {
                MessageBox.Show(errors.mistake2);
            }
        }

        public void DeleteButton1_Click(object sender, RoutedEventArgs e)
        {
            if (hashTable.Search(DeleteFromTable1.Text) == -1)
            {
                MessageBox.Show(errors.mistake4);
                return;
            }

            if (hashTable.GetterPublic()[hashTable.Search(DeleteFromTable1.Text)].CountOf2 != 0)
            {
                MessageBox.Show(errors.mistake7);
                return;
            }
            hashTable.Delete(DeleteFromTable1.Text);
            MessageBox.Show(errors.completeDelete);
        }

        public void DebugHash_Click(object sender, RoutedEventArgs e)
        {
            DebugHashText.Text = "";
            HashTableItem[] temp = hashTable.GetterPublic();
            for (int i = 0; i < hashTable.GetterSize(); i++)
            {
                DebugHashText.Text += "Хеш = " + i + " " + temp[i].ToString()+"\r\n";
            }
        }
        // АВЛ ДЕРЕВО РАБОТА С ДЕРЕВОМ
        public void ButtonSearch2Sprav_Click(object sender, RoutedEventArgs e)
        {
            List<Table2> listAvl = new List<Table2>();
            Avl.AvlToList(AvlTree.Root, listAvl);
            Table2[] tab = listAvl.Getter();
            SearchTable2.ItemsSource = tab;
        }

        public void DebugAvl_Click(object sender, RoutedEventArgs e)
        {
            DebugAvlText.Text = "";
            List<string> DisplayString = new List<string>();;
            DisplayString = AvlTree.DisplayTree();
            for (int i = 0; i < DisplayString.Capacity; i++)
            {
                DebugAvlText.Text += DisplayString[i]+"\r\n";
            }
        }

        public void AddingTo2_Click(object sender, RoutedEventArgs e)
        {
            if (hashTable.Search(LoginTo2.Text) == -1)
            {
                MessageBox.Show(errors.mistake5);
                return;
            }
            double k;
            if (double.TryParse(PriceOfObject.Text, out k) == true)
            {
                if (k <= 0)
                {
                    MessageBox.Show(errors.mistake2);
                    return;
                }
                if (NamingOfObject.Text.Length is < 5 or > 100)
                {
                    MessageBox.Show(errors.mistake2);
                    return;
                }
                if (CategorySearchAdd.Text == "")
                {
                    MessageBox.Show(errors.mistake2);
                    return;
                }
                Table2 temp = Inits.InitTable2(LoginTo2.Text, NamingOfObject.Text, k, CategorySearchAdd.Text);
                AvlTree.Add(temp);
                hashTable.ChangeCounts(LoginTo2.Text, 1);
                MessageBox.Show(errors.completeAdd);
            }
            else
            {
                MessageBox.Show(errors.mistake3);
            }
        }

        public void RemoveTo2_Click(object sender, RoutedEventArgs e)
        {
            double prRemove;
            if (double.TryParse(PriceOfObjectRemove.Text, out prRemove) == true)
            {
                if (prRemove <= 0)
                {
                    MessageBox.Show(errors.mistake2);
                    return;
                }
                if (CategorySearchRemove.Text == "")
                {
                    MessageBox.Show(errors.mistake4);
                    return;
                }
                Table2 tempDel = Inits.InitTable2(LoginTo2Remove.Text, NamingOfObjectRemove.Text, prRemove, CategorySearchRemove.Text);
                List<Table2> tempTab = new List<Table2>();
                Avl.AvlToList(AvlTree.Root, tempTab);
                if (tempTab.IndexOf(tempDel) == -1)
                {
                    MessageBox.Show(errors.mistake6);
                    return;
                }
                AvlTree.Delete(tempDel);
                hashTable.ChangeCounts(LoginTo2.Text, -1);
                MessageBox.Show(errors.completeDelete);
                return;
            }
            else
            {
                MessageBox.Show(errors.mistake2);
                return;
            }
        }
        public void SaveTable2_Click(object sender, RoutedEventArgs e)
        {
            if (helpAlgoritms.mask(TextBlockFile2.Text, 2))
            {
                saveElements.AvlToFile(AvlTree, TextBlockFile2.Text);
                MessageBox.Show(errors.completeSave);
            }
            else MessageBox.Show(errors.mistake1);
        }
        public void LoadTable2_Click(object sender, RoutedEventArgs e)
        {
            if (helpAlgoritms.mask(TextBlockFile2.Text, 2))
            {
                Table2[] tempList = initFiles.FileToAvl(TextBlockFile2.Text);
                if (tempList.Length == 0)
                {
                    MessageBox.Show(errors.mistake11);
                    return;
                }
                for (int i = 0; i < tempList.Length; i++)
                {
                    if (hashTable.Search(tempList[i].Login) == -1)
                    {
                        MessageBox.Show(errors.mistake8);
                        return;
                    }
                    AvlTree.Add(tempList[i]);
                    hashTable.ChangeCounts(tempList[i].Login, 1);
                }
                MessageBox.Show(errors.completeLoad);
            }
            else MessageBox.Show(errors.mistake1);
        }
        //РАБОТА С ОТЧЕТОМ
        public void Search_Click(object sender, RoutedEventArgs e)
        {
            double raiting1, raiting2;
            if (double.TryParse(intervalMin.Text, out raiting1) == false ||
                double.TryParse(intervalMax.Text, out raiting2) == false || CategorySearch.Text == "")
            {
                MessageBox.Show(errors.mistake2);
                return;
            }

            if (raiting1 is < 0 or > 5 || raiting2 is < 0 or > 5 || raiting1 > raiting2)
            {
                MessageBox.Show(errors.mistake2);
                return;
            }
            if (AvlTree.Find(CategorySearch.Text, AvlTree.Root) == null)
            {
                MessageBox.Show(errors.mistake9);
                return;
            }
            _reportStruct = Report.MakeReport(hashTable, AvlTree, CategorySearch.Text, raiting1, raiting2);
            ReportStruct[] tempRep = new ReportStruct[_reportStruct.Capacity];
            for (int i = 0; i < _reportStruct.Count; i++)
            {
                tempRep[i] = _reportStruct[i];
            }
            mainSearchTable.ItemsSource = tempRep;
        }
        public void ReportToFile_Click(object sender, RoutedEventArgs e)
        {
            if (helpAlgoritms.mask(ReportTextFile.Text, 3) == false)
            {
                MessageBox.Show(errors.mistake1);
                return;
            }

            if (_reportStruct == null)
            {
                MessageBox.Show(errors.mistake10);
                return;
            }
            saveElements.ReportToFile(_reportStruct, ReportTextFile.Text);
            MessageBox.Show(errors.completeSave);
        }
        public void DebugTempStruct_Click(object sender, RoutedEventArgs e)
        {
            DebugTempStructText.Text = "";
            for (int i = 0; i < _reportStruct.Count; i++)
            {
                DebugTempStructText.Text += _reportStruct[i].ToString();
            }
        }
        
    }
}