using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class VictorStack<T>
    {
        private LinkedList<T> _list = new LinkedList<T>();

        public T Pop()
        {
           
            if (this._list.Count == 0) throw new IndexOutOfRangeException();
            
            var temp = _list.First.Value;
            
            _list.RemoveFirst();

            return temp;
        }
        public void Push(T item) => _list.AddFirst(item);
        public void Clear() { _list.Clear(); }
        public int Count => _list.Count;
        public T? Peek() => _list.First!=null? _list.First.Value : default;
    }
}
