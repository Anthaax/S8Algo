using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLundi
{
    public class MyLinkedElement
    {

        public MyLinkedElement(int data, MyLinkedElement next)
        {
            Data = data;
            Next = next;
        }

        public int Data { get; set; }
        public MyLinkedElement Next { get; set; }
    }
    public class MyLinkedList
    {
        MyLinkedElement _first;
        int _count = 0;

        public int Count => _count;

        public void Add(int element)
        {
            MyLinkedElement _new = new MyLinkedElement(element, _first);
            _first = _new;
            _count++;
        }

        public void AddElement(MyLinkedElement element)
        {
            MyLinkedElement last = GetElement(_count - 1);
            last.Next = element;
            _count++;
        }

        public int GetAs(int idx)
        {
            return GetElement(idx).Data;
        }

        public MyLinkedElement GetElement(int idx)
        {
            if (_count < idx) throw new IndexOutOfRangeException();
            MyLinkedElement current = _first;
            for (int i = 0; i < idx; i++)
            {
                if (current == null) throw new Exception();
                current = current.Next;
            }
            return current;
        }

        public void Clean()
        {
            _first = null;
            _count = 0;
        }
        public void RemoveDoublon()
        {
            MyLinkedElement current = _first;
            MyLinkedElement doublon = _first;
            while (current.Next != null)
            {
                doublon = current;
                while (doublon.Next != null)
                {
                    if (current.Data == doublon.Next.Data)
                    {
                        doublon.Next = doublon.Next.Next;
                        _count--;
                    }
                    else
                        doublon = doublon.Next;
                }

                current = current.Next;
            }
        }

        public int GetAsReverse(int idx)
        {
            if (_count < idx) throw new IndexOutOfRangeException();
            MyLinkedElement current = _first;
            MyLinkedElement search = _first;
            do
            {
                search = current;
                for (int i = 0; i <= idx; i++)
                {
                    if (i < idx && search.Next == null) throw new IndexOutOfRangeException();
                    if (i == idx && search.Next == null) return current.Data;
                    search = search.Next;
                }
                current = current.Next;
            } while (current.Next != null);
            return default(int);
        }

        public void RemoveWithoutFirst(MyLinkedElement item)
        {
            item.Data = item.Next.Data;
            item.Next = item.Next.Next;
            _count--;
        }

        public void Reoder(int idx)
        {
            MyLinkedElement current = _first;
            List<int> newList = new List<int>();
            do
            {
                newList.Add(current.Data);
                current = current.Next;
            } while (current.Next != null);
            newList.Add(current.Data);
            Clean();
            foreach (var item in newList.OrderByDescending(i => i))
            {
                Add(item);
            }
        }
        public bool IsPalindrome()
        {
            StringBuilder listStringBuilder = new StringBuilder();
            for (int i = 0; i < _count; i++)
            {
                listStringBuilder.Append(GetAs(i));
            }
            string list = listStringBuilder.ToString();
            for (int i = 0; i < Count/2; i++)
            {
                if (list[i] != list[_count - 1 - i]) return false;
            }
            return true;
        }

        public static bool Intersection(MyLinkedList list1, MyLinkedList list2)
        {
            for (int i = 0; i < list1.Count; i++)
            {
                MyLinkedElement current = list1.GetElement(i);
                for (int j = 0; j < list2.Count; j++)
                {
                    if (current == list2.GetElement(j))
                        return true;
                }
            }
            return false;
        }

        public static MyLinkedElement IsCorruptedList(MyLinkedList list)
        {
            HashSet<MyLinkedElement> hashSetList = new HashSet<MyLinkedElement>();
            MyLinkedElement current = list._first;
            do
            {
                if (!hashSetList.Add(current)) return current;
                current = current.Next;
            } while (current.Next != null);
            return null;
        }

        public static MyLinkedList LinkedListAddition(MyLinkedList list1, MyLinkedList list2, bool reverse = true)
        {
            StringBuilder list1String = new StringBuilder(); 
            StringBuilder list2String = new StringBuilder();
            MyLinkedList newList = new MyLinkedList();
            for (int i = list1.Count-1; i >= 0 ; i--)
            {
                list1String.Append(list1.GetAs(i));
            }
            for (int i = list2.Count - 1; i >= 0; i--)
            {
                list2String.Append(list2.GetAs(i));
            }
            long additionNum = long.Parse(list1String.ToString()) + long.Parse(list2String.ToString());
            foreach (var item in reverse ? additionNum.ToString() : additionNum.ToString().Reverse())
            {
                newList.Add(int.Parse(item.ToString()));
            }
            return newList;
        }
    }
}
