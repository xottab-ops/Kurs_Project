namespace Kurs_Project
{

        public class Hash
        {
        private int _k;
        public int Capacity;
        private int _sizeOfTable;
        private int _pop;
        private readonly int _mainSize;
        private HashTableItem[] _table;

        private int Prime(int index)
        {
            for (int i = 2; i < index; i++)
            {
                if (index % i != 0)
                {
                    return i;
                }
            }
            return -1;
        }
        private int HashFunction(string pat)
        {
            int temp = 0;
            foreach (var t in pat)
            {
                temp += (int)t;
            }
            return temp % _sizeOfTable;    
        }
        
        private int HashFunctuonTwo(int hash1, int j)
        {
            return (hash1 + j * _k) % _sizeOfTable;
        }
        
        public Hash(int size)
        {
            _k = Prime(size);
            _sizeOfTable = size;
            Capacity = 0;
            _table = Init(_sizeOfTable);
            _mainSize = size;
        }

        HashTableItem[] Init(int size)
        {
            HashTableItem[] temp = new HashTableItem[size];
            for (int i = 0; i < _sizeOfTable; i++) {
                temp[i].Status = 0;
                temp[i].CountOf2 = 0;
            }
            return temp;
        }

        public void Add(Table1 pat)
        {
            _pop = 0;
            if (_sizeOfTable * 0.75 <= Capacity) {
                Resize();
            }

            if (Search(pat.Login) != -1)
            {
                return;
            }
            int tempHash = HashFunction(pat.Login);
            if ((_table[tempHash].Status == 0) || (_table[tempHash].Status == 2)) {
                _table[tempHash].Status = 1;
                _table[tempHash].Value = pat;
                Capacity++;
            }
            else AddKolliz(pat, ++_pop, tempHash);
        }

        private void AddKolliz(Table1 pat, int pop, int hashKey)
        {
            int tempHash = (hashKey + pop * _k) % _sizeOfTable;
            if ((_table[tempHash].Status == 0) || (_table[tempHash].Status == 2)) {
                _table[tempHash].Status = 1;
                _table[tempHash].Value = pat;
                Capacity++;
            }
            else AddKolliz(pat, ++pop, hashKey);
        }

        private void Resize()
        {
            HashTableItem[] temptable = Init(_sizeOfTable);
            (temptable, _table) = (_table, temptable);
            _sizeOfTable *= 2;
            _table = Init(_sizeOfTable);
            Capacity = 0;
            for (int i = 0; i < _sizeOfTable / 2; i++) {
                if (temptable[i].Status == 1) {
                    Add(temptable[i].Value);
                    _table[Search(temptable[i].Value.Login)].CountOf2 = temptable[i].CountOf2;
                }
            }

            if (_sizeOfTable % _k == 0)
            {
                _k = Prime(_sizeOfTable);
            }
        }

        public void ChangeCounts(string login, int k)
        {
            if (k == 1)
            {
                _table[Search(login)].CountOf2++;
            }
            else if(k == -1)
            {
                _table[Search(login)].CountOf2--;
            }
        }
        private void Rehash()
        {
            HashTableItem[] temptable = Init(_sizeOfTable);
            (temptable, _table) = (_table, temptable);
            _sizeOfTable *= 2;
            _table = Init(_sizeOfTable);
            Capacity = 0;
            for (int i = 0; i < _sizeOfTable / 2; i++) {
                if (temptable[i].Status == 1) {
                    Add(temptable[i].Value);
                    _table[Search(temptable[i].Value.Login)].CountOf2 = temptable[i].CountOf2;
                }
            }
        }

        public Table1 Searching(string key)
        {
            int k = Search(key);
            if (k == -1)
            {
                return new Table1();
            }
            else return _table[Search(key)].Value;
        }
        
        public int Search(string pat)
        {
            int index = HashFunction(pat);
            int secondIndex = index;
            int i = 0, j = 0;
            do
            {
                j++;
                if (_table[secondIndex].Value.Login == pat && _table[secondIndex].Status == 1)
                {
                    return secondIndex;
                }
                secondIndex = HashFunctuonTwo(index, j);
                i++;
            } while (_table[secondIndex].Value.Login != pat && i < _sizeOfTable);

            if (i == _sizeOfTable)
            {
                return -1;
            }
            else return secondIndex;
        }
        

        public void Delete(string pat)
        {
            if (Capacity < _sizeOfTable * 0.25 && Capacity != _mainSize)
            {
                Rehash();
            }

            _k = Prime(_sizeOfTable);
            if (Capacity == 0)
            {
                return;
            }
            int i = Search(pat);
            if (i == -1)
            {
                /*WriteLine("Нет такого элемента");*/
            }
            else
            {
                _table[i].Status = 2;
            }
        }

        public int GetterSize()
        {
            return _sizeOfTable;
        }
        public Table1[] Getter()
        {
            int k = 0;
            Table1[] temp = new Table1[Capacity];
            for (int i = 0; i < _sizeOfTable; i++)
            {
                if (_table[i].Status == 1)
                {
                    temp[k] = _table[i].Value;
                    k++;
                }
            }
            return temp;
        }

        public HashTableItem[] GetterPublic()
        {
            HashTableItem[] temp = new HashTableItem[_sizeOfTable];
            for (int i = 0; i < _sizeOfTable; i++)
            {
                temp[i] = _table[i];
            }

            return temp;
        }
    }
}