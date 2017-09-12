using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLundi
{
    public class MyLinkedElement<T>
    {

        public MyLinkedElement(T data, MyLinkedElement<T> next)
        {
            Data = data;
            Next = next;
        }

        public T Data { get; set; }
        public MyLinkedElement<T> Next { get; set; }
    }
    public class MyLinkedList<T>
    {
        MyLinkedElement<T> _first;

        public void Add(T element)
        {
            MyLinkedElement<T> _new = new MyLinkedElement<T>(element, _first);
            _first = _new;
        }

        public T GetAs(int idx)
        {
            MyLinkedElement<T> current = _first;
            for (int i = 0; i < idx; i++)
            {
                if (current == null) throw new Exception();
                current = current.Next;
            }
            return current.Data;
        }

        public void RemoveDoublon()
        {
            MyLinkedElement<T> current = _first;
            MyLinkedElement<T> doublon = _first;
            MyLinkedElement<T> fisrtDoublon = _first;
            T currentData = current.Data;
            do
            {
                currentData = current.Data;
                doublon = current;
                fisrtDoublon = current;
                do
                {
                    if (currentData.Equals(doublon.Next.Data))
                    {
                        doublon.Next = doublon.Next.Next;
                    }
                    else
                        doublon = doublon.Next;
                }
                while (doublon.Next != null);

                current = fisrtDoublon.Next;
            }
            while (current.Next != null);
        }
    }
}
