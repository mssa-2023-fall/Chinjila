using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class ChinNode<T> : INode<T>
    {

        public INode<T>? NextNode { get; private set; }

        public ChinNode(T content)
        {
            this.Content = content;
            NextNode = null;

        }

        public void LinkNext(INode<T> nextNode) {
            this.NextNode = nextNode;
        }
        public T Content { get ; set; }

        public INode<T>? Next()
        {
            return NextNode;
        }
      
    }
}
