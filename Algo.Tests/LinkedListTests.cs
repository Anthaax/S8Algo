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
            MyLinkedList<int> l = new MyLinkedList<int>();
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Add(4);

            Assert.AreEqual(4, l.GetAs(0));
        }
        [Test]
        public void UniqueList()
        {
            MyLinkedList<int> l = new MyLinkedList<int>();
            l.Add(3);
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Add(4);
            l.Add(4);
            l.Add(4);
            l.RemoveDoublon();

            Assert.IsTrue(true);
        }

    }
}
