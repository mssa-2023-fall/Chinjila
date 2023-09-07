using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class Class1<T> : ILinkedList<T>
    {
        public int Count => throw new NotImplementedException();

        public INode<T> Head => throw new NotImplementedException();

        public INode<T> Tail => throw new NotImplementedException();

        public IEnumerable<INode<T>> Nodes => throw new NotImplementedException();

        public void AddFirst(INode<T> value)
        {
            throw new NotImplementedException();
        }

        public void AddLast(INode<T> value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public INode<T>[] FindAll(T value)
        {
            throw new NotImplementedException();
        }

        public INode<T>? FindFirst(T value)
        {
            throw new NotImplementedException();
        }

        public void InsertAfterNodeIndex(INode<T> value, int position)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int IndexPosition)
        {
            throw new NotImplementedException();
        }

        public void RemoveFirst()
        {
            throw new NotImplementedException();
        }

        public void RemoveLast()
        {
            throw new NotImplementedException();
        }
    }
}
