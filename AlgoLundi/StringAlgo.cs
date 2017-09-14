using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLundi
{
    public class StringAlgo
    {
        public bool containOnlyUniqueChar(string stringToTest)
        {
            HashSet<char> charInString = new HashSet<char>();
            foreach (char c in stringToTest)
            {
                if (!charInString.Add(c)) return false;
            }
            return true;
        }

        public bool UniqueChar( string value)
        {
            int count = 1;
            foreach (char c in value)
            {
                foreach (var item in value.Skip(count))
                {
                    if (item == c) return false;
                }
                count++;
            }
            return true;
        }

        public bool Anagrame(string value, string permutation)
        {
            Dictionary<char, int> valueDictionnary = new Dictionary<char, int>();
            if (value.Length != permutation.Length || value == permutation) return false;
            foreach (var item in value)
            {
                int count = 0;
                if (valueDictionnary.TryGetValue(item, out count))
                    valueDictionnary[item] = ++count;
                else
                    valueDictionnary.Add(item, 1);
            }
            foreach (var item in permutation)
            {
                int count;
                if (valueDictionnary.TryGetValue(item, out count))
                    valueDictionnary[item] = --count;
            }
            if (valueDictionnary.Values.Where(c => c != 0).Count() != 0) return false;
            return true;
        }

        public char[] URilify(char[] value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if(value[i] == ' ')
                {
                    for (int j = value.Length -1; j > i; j--)
                    {
                        if(value[j] != char.MinValue)
                        {
                            value[j + 2] = value[j];
                        }
                    }
                    value[i] = '%';
                    value[i+1] = '2';
                    value[i+2] = '0';
                }
            }
            return value;
        }

        public bool IsPalindrome(string value)
        {
            Dictionary<char, int> valueDictionnary = new Dictionary<char, int>();
            foreach (var item in value)
            {
                int count = 0;
                if (valueDictionnary.TryGetValue(item, out count))
                    valueDictionnary[item] = ++count;
                else
                    valueDictionnary.Add(item, 1);
            }
            if (value.Length % 2 == 0 && valueDictionnary.Values.Where(c => c == 2).Count() != value.Length) return false;
            if (value.Length % 2 == 1 
                            && valueDictionnary.Values.Where(c => c == 2).Count() != value.Length - 1
                            && valueDictionnary.Values.Where(c => c == 1).Count() != 1) return false;
            return true;
        }

        public bool OneChange(string value, string change)
        {
            if (value.Length - change.Length < -1 || value.Length - change.Length > 1) return false;
            if (value.Length == change.Length)
            {
                bool sub = false;
                for (int i = 0; i < value.Length; i++)
                {
                    if (sub && value[i] != change[i]) return false;
                    if (value[i] != change[i]) sub = true;
                }
            }
            else if (value.Length - change.Length == 1)
            {
                bool sub = false;
                int j = 0;
                for (int i = 0; i < change.Length; i++)
                {
                    if (sub && value[i] != change[j]) return false;
                    if (value[i] != change[j])
                    {
                        j--;
                        sub = true;
                    }
                    j++;
                }
            }
            else if (value.Length - change.Length == -1)
            {
                bool sub = false;
                int j = 0;
                for (int i = 0; i < value.Length; i++)
                {
                    if (sub && value[i] != change[j]) return false;
                    if (value[i] != change[j])
                    {
                        j++;
                        sub = true;
                    }
                    j++;
                }
            }
            return true;
        }

        public string Compression(string value)
        {
            Dictionary<char, int> valueDictionnary = new Dictionary<char, int>();
            StringBuilder sb = new StringBuilder();
            int count = 1;
            for (int i = 0; i < value.Length; i++)
            {
                if (i == 0) ;
                else if (value[i - 1] == value[i]) count++;
                else if (value[i - 1] != value[i])
                {
                    sb.Append(value[i - 1]);
                    sb.Append(count);
                    count = 1;
                }
            }
            sb.Append(value.Last());
            sb.Append(count);
            return sb.Length > value.Length ? value : sb.ToString();
        }

        public short[,] Rotation(short[,] pixels)
        {
            short[,] rotationPixel = new short[pixels.GetLength(0), pixels.GetLength(1)];
            for (int i = 0; i < pixels.GetLength(0); i++)
            {
                for (int j = 0; j < pixels.GetLength(1); j++)
                {
                    rotationPixel[j, rotationPixel.GetLength(0) - 1 - i] = pixels[i, j];
                }
            }
            return rotationPixel;
        }

        public int[,] AddZero(int[,] pixels)
        {
            int[,] zeroPixel = new int[pixels.GetLength(0), pixels.GetLength(1)];
            for (int i = 0; i < pixels.GetLength(0); i++)
            {
                for (int j = 0; j < pixels.GetLength(1); j++)
                {
                    zeroPixel[i, j] = pixels[i, j];
                }
            }
            for (int i = 0; i < pixels.GetLength(0); i++)
            {
                for (int j = 0; j < pixels.GetLength(1); j++)
                {
                    if(pixels[i,j] == 0) ClearColAndLigne(zeroPixel, i, j);
                }
            }
            return zeroPixel;
        }

        private void ClearColAndLigne(int[,] zeroPixel, int i, int j)
        {
            for (int k = 0; k < zeroPixel.GetLength(0); k++)
            {
                zeroPixel[i, k] = 0;
            }
            for (int k = 0; k < zeroPixel.GetLength(1); k++)
            {
                zeroPixel[k, j] = 0;
            }
        }
    }
}
