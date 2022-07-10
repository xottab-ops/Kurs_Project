using System;

namespace Kurs_Project
{
    public class List<T> : IPrintable, ICloneableAs<List<T>>
     {
        private T[] _source;
 
    private void ThrowIfInvalid(int index)
    {
      if ((index < 0) || (index >= Count))
      {
        throw new IndexOutOfRangeException(nameof(index));
      }
    }
 
        private void TryResize()
        {
            Count++;
            if (_source.Length < Count)
            {
                Array.Resize(ref _source, _source.Length == 0 ? 1 : _source.Length + 1);
            }
        }
 
    private void Insert(int index, T x)
    {
      TryResize();
            for(var i = Count - 1; i > index; i--)
            {
                _source[i] = _source[i - 1];
            }
            _source[index] = x;
    }
 
    public T this[int i]
    {
      get
      {
        ThrowIfInvalid(i);
        return _source[i];
      }
      set
      {
        ThrowIfInvalid(i);
        _source[i] = value;
      }
    }
 
    public int Capacity => _source.Length;
    public int Count { get; private set; }
 
    public List()
    {
      _source = new T[1];
    }
 
        public string GetStringRepresentation()
        {
            string representation = "[";
            for(var i = 0; i < Count; i++)
            {
                representation += _source[i].ToString();
                if (i < Count - 1)
                {
                    representation += ", ";
                }
            }
            representation += "]";
            return representation;
        }
 
        
 
        public List<T> CloneAs()
        {
            List<T> list = new List<T>();
            for(var i = 0; i < Count; i++)
            {
                list.AddLast(_source[i]);
            }
            return list;
        }
 
        public object Clone() => CloneAs();
        

    public int IndexOf(T x)
    {
      int i = 0;
      while ((i < Count) && (!_source[i].Equals(x)))
      {
        i++;
      }
      if (i == Count)
      {
        return -1;
      }
      return i;
    }

    public void RemoveAt(int index)
    {
      ThrowIfInvalid(index);
            for(var i = index; i < Count - 1; i++)
            {
                _source[i] = _source[i + 1];
            }
            _source[Count - 1] = default(T);
            Count--;
    }

    public void AddListInList(List<T> target)
    {
        if (target.Capacity != 0)
        {
            for (int i = 0; i < target.Count; i++)
            {
                AddLast(target[i]);
            }
        }
        
    }

    public T[] Getter()
    {
        T[] temp = new T[Count];
        for (int i = 0; i < Count; i++)
        {
            temp[i] = _source[i];
        }
        return temp;
    }
    
    public void AddFirst(T x) => Insert(0, x);
    
    public void AddLast(T x) => Insert(Count, x);
    
    public void Remove(T x) => RemoveAt(IndexOf(x));
    
  }

  public interface IPrintable
  {
      string GetStringRepresentation();
  }
  public interface ICloneableAs<T> : ICloneable
  {
      T CloneAs();
  }
}