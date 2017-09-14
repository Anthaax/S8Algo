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
    public class AlgoTests
    {
        [Test]
        public void Unique_char_in_string()
        {
            StringAlgo s = new StringAlgo();
            Assert.IsTrue(s.containOnlyUniqueChar("Unique"));
            Assert.IsFalse(s.containOnlyUniqueChar("Tests"));
            Assert.IsTrue(s.UniqueChar("Unique"));
            Assert.IsFalse(s.UniqueChar("Tests"));
        }

        [Test]
        public void Annagrame_in_string()
        {
            StringAlgo s = new StringAlgo();
            Assert.IsTrue(s.Anagrame("unique", "euqinu"));
            Assert.IsTrue(s.Anagrame("uniqeuee", "euqeeinu"));
            Assert.IsFalse(s.Anagrame("tests", "testts"));
            Assert.IsFalse(s.Anagrame("tests", "tests"));
        }

        [Test]
        public void Palindrome_in_string()
        {
            StringAlgo s = new StringAlgo();
            Assert.IsTrue(s.IsPalindrome("kayak"));
            Assert.IsTrue(s.IsPalindrome("kkaay"));
            Assert.IsFalse(s.IsPalindrome("test"));
            Assert.IsFalse(s.IsPalindrome("tzest"));
        }

        [Test]
        public void OneChange_in_string()
        {
            StringAlgo s = new StringAlgo();
            Assert.IsTrue(s.OneChange("kayak", "tayak"));
            Assert.IsTrue(s.OneChange("kayak", "kayak"));
            Assert.IsTrue(s.OneChange("kkaay", "kaay"));
            Assert.IsTrue(s.OneChange("kkaay", "kkkaay"));
            Assert.IsFalse(s.OneChange("test", "tets"));
        }

        [Test]
        public void Compression()
        {
            StringAlgo s = new StringAlgo();
            Assert.AreEqual("kayak",s.Compression("kayak"));
            Assert.AreEqual("k3a3y3",s.Compression("kkkaaayyy"));
            Assert.AreEqual("k2a1l1a1e10",s.Compression("kkalaeeeeeeeeee"));
        }
        [Test]
        public void Rotation()
        {
            short count = 0;
            StringAlgo s = new StringAlgo();
            short[,] basePixel = new short[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    basePixel[i, j] = count++;
                }
            }
            var newPixel = s.Rotation(basePixel);
            count++;
        }

        [Test]
        public void AddZero()
        {
            int count = 0;
            StringAlgo s = new StringAlgo();
            int[,] basePixel = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    basePixel[i, j] = count++;
                }
            }
            var newPixel = s.AddZero(basePixel);
            count++;
        }

        [Test]
        public void Substring()
        {
            
        }

        [Test]
        public void Uri()
        {
            StringAlgo s = new StringAlgo();

            char[] charArray = new char[100];
            charArray[0] = 'u';
            charArray[1] = 'u';
            charArray[2] = 'u';
            charArray[3] = 'u';
            charArray[4] = ' ';
            charArray[5] = 'u';
            charArray[6] = 'u';
            charArray[7] = ' ';
            charArray[8] = 'u';
            charArray[9] = 'u';
            charArray[10] = 'u';

            int exept = charArray.Where(c => c == 'u').Count();
            int space = charArray.Where(c => c != 'u' && c != char.MinValue).Count();
            Assert.AreEqual(exept, s.URilify(charArray).Where(c => c == 'u').Count());
            Assert.AreEqual(space * 3, s.URilify(charArray).Where(c => c != 'u' && c != char.MinValue).Count());
        }
    }
}
