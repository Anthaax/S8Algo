using AlgoLundi;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Tests
{
    [TestFixture]
    class LinkedListTests
    {
        [Test]
        public void AddInsideList()
        {
            MyLinkedList l = new MyLinkedList();
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Add(4);

            Assert.AreEqual(4, l.GetAs(0));
        }
        [Test]
        public void UniqueList()
        {
            MyLinkedList l = new MyLinkedList();
            l.Add(3);
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Add(4);
            l.Add(4);
            l.Add(4);
            l.RemoveDoublon();

            Assert.AreEqual(l.Count, 4);
        }
        [Test]
        public void ReverseIndex()
        {
            MyLinkedList l = new MyLinkedList();
            for (int i = 0; i < 10; i++)
            {
                l.Add(i);
            }
            Assert.AreEqual(l.GetAs(5), l.GetAsReverse(4));
            Assert.AreEqual(l.GetAs(9), l.GetAsReverse(0));
            Assert.AreEqual(l.GetAs(0), l.GetAsReverse(9));
        }

        [Test]
        public void RemoveWithoutFirst()
        {
            MyLinkedList l = new MyLinkedList();
            for (int i = 0; i < 10; i++)
            {
                l.Add(i);
            }
            var element = l.GetElement(4);
            int data = element.Data;
            l.RemoveWithoutFirst(element);
            Assert.AreNotEqual(data, l.GetAs(4));
            Assert.AreEqual(data, l.GetAs(4) + 1);
        }

        [Test]
        public void Reorder()
        {
            MyLinkedList l = new MyLinkedList();
            for (int i = 0; i < 10; i++)
            {
                l.Add(i);
            }
            l.Reoder(4);
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(i, l.GetAs(i));
            }
        }
        [Test]
        public void Addition()
        {
            MyLinkedList l = new MyLinkedList();
            l.Add(7);
            l.Add(7);
            l.Add(7);
            MyLinkedList l2 = new MyLinkedList();
            l2.Add(7);
            l2.Add(7);
            l2.Add(7);
            MyLinkedList l3 = MyLinkedList.LinkedListAddition(l, l2);
            MyLinkedList l4 = MyLinkedList.LinkedListAddition(l, l2, false);
            string exptedNumber = "1554";
            int count = l3.Count;
            int order = 0;
            foreach (var item in exptedNumber)
            {
                Assert.AreEqual(int.Parse(item.ToString()), l3.GetAs(--count));
                Assert.AreEqual(int.Parse(item.ToString()), l4.GetAs(order++));
            }
        }

        [Test]
        public void Palindrome()
        {
            MyLinkedList l = new MyLinkedList();
            l.Add(1);
            l.Add(7);
            l.Add(7);
            l.Add(1);
            MyLinkedList l2 = new MyLinkedList();
            l2.Add(1);
            l2.Add(7);
            l2.Add(1);
            l2.Add(7);
            l2.Add(1);
            MyLinkedList l3 = new MyLinkedList();
            l3.Add(1);
            l3.Add(7);
            l3.Add(1);
            l3.Add(1);
            Assert.IsTrue(l.IsPalindrome());
            Assert.IsTrue(l2.IsPalindrome());
            Assert.IsFalse(l3.IsPalindrome());
        }

        [Test]
        public void Intersection()
        {
            MyLinkedList l = new MyLinkedList();
            MyLinkedList l2 = new MyLinkedList();
            for (int i = 0; i < 10; i++)
            {
                l.Add(i);
                l2.Add(i);
            }
            Assert.IsFalse(MyLinkedList.Intersection(l, l2));
            l2.AddElement(l.GetElement(4));
            Assert.IsTrue(MyLinkedList.Intersection(l, l2));
        }

        [Test]
        public void CorruptedList()
        {
            MyLinkedList l = new MyLinkedList();
            for (int i = 0; i < 10; i++)
            {
                l.Add(i);
            }
            Assert.IsNull(MyLinkedList.IsCorruptedList(l));
            MyLinkedElement error = l.GetElement(4);
            l.AddElement(error);
            Assert.AreEqual(error.Data, MyLinkedList.IsCorruptedList(l).Data);
        }
    }
}
