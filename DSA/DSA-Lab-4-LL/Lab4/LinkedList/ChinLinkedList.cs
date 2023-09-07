using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class ChinLinkedList<T> : ILinkedList<T>
    {
       

        public ChinLinkedList()
        {
            this.Count = 0;
        }

        public ChinLinkedList(ChinNode<T>? initialNode)
        {
          this.Head = initialNode;
          
          this.Count++;
        }

        public int Count { get; private set; }

        public INode<T>? Head { get; private set; }

        public INode<T>? Tail
        {
            get
            {
                INode<T>? node = Head;
                while (node?.Next() != null) {
                    node = node.Next();
                }
                return node;
            }

         }

        public IEnumerable<INode<T>> Nodes
        {
            get { 
                INode<T> node= Head;
                yield return Head;
                while (node?.Next() != null) {  
                    node = node.Next();
                    yield return node;
                }
            }
        }

        public void AddFirst(INode<T> value)
        {
            if (this.Head != null)
            { value.LinkNext(this.Head); }

            this.Head = value;
            Count++;
        }

        public void AddLast(INode<T> value)
        {
            this.Tail.LinkNext(value);
            Count++;
        }

        public void Clear()
        {
            Count = 0;
            Head = null;
        }

        public INode<T>[] FindAll(T value)
        {
            INode<T>[] result = new INode<T>[0];
            int resultCount = 0;
            foreach (INode<T> node in this.Nodes) { 
                if (EqualityComparer<T>.Default.Equals(node.Content, value)) {
                Array.Resize(ref result, resultCount+1);
                result[resultCount++] = node;
                }
            }
            return result;
        }

        public INode<T>? FindFirst(T value)
        {
            INode<T>[] result = FindAll(value);//shame...shame...
            if (result.Length>0) { return result[0]; }
            else { return null; }
            
        }

        public void InsertAfterNodeIndex(INode<T> value, int position)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int IndexPosition)
        {
            if (Head == null || Count == 0) throw new InvalidOperationException();
        }

        public void RemoveFirst()
        {
            if (Head == null || Count==0) throw new InvalidOperationException();

            this.Head = Head.Next();
            Count--;

        }

        public void RemoveLast()
        {
            if (Head == null || Count == 0) throw new InvalidOperationException();
        }
    }
}
