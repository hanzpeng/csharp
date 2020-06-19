using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace P1048
{
    class P1048
    {
        [Test]
        public void test1()
        {
            //Assert.AreEqual(4,
            //    LongestStrChain(
            //        new string[]
            //        { "a","b","ba","bca","bda","bdca" }
            //    ));
            Assert.AreEqual(7,
                LongestStrChain(
                    new string[]
                    { "ksqvsyq", "ks", "kss", "czvh", "zczpzvdhx",
                        "zczpzvh", "zczpzvhx", "zcpzvh", "zczvh",
                        "gr", "grukmj", "ksqvsq", "gruj", "kssq",
                        "ksqsq", "grukkmj", "grukj", "zczpzfvdhx", "gru" }
                ));
            /*
             * 
             * ks  
             * kss 
             * kssq 
             * ksqsq
             * ksqvsq
             * ksqvsyq
             * 
             * gr
             * gru
             * gruj
             * grukj
             * grukmj
             * grukkmj
             * 
             *  c  zvh
             * zc  zvh
             * zc pzvh
             * zczpzvh
             * zczpzv  hx
             * zczpz vdhx
             * zczpzfvdhx
             * */
        }
        public static int LongestStrChain(string[] words)
        {

            if (words == null || words.Length == 0)
                return 0;

            var maxWordLen = 0;
            foreach (var w in words)
            {
                if (w.Length > maxWordLen)
                    maxWordLen = w.Length;
            }

            var lenWords = new Dictionary<int, List<string>>();

            for (int i = 1; i <= maxWordLen; i++)
            {
                lenWords[i] = new List<string>();
            }

            foreach (var w in words)
            {
                lenWords[w.Length].Add(w);
            }

            var res = new List<Stack<string>>();
            int longestChain = 0;
            for (int i = 1; i <= maxWordLen; i++)
            {

                if (lenWords[i].Count == 0)
                {
                    res = new List<Stack<string>>();
                    continue;
                }

                if (res.Count == 0)
                {
                    foreach (var w in lenWords[i])
                    {
                        var stack = new Stack<string>();
                        stack.Push(w);
                        res.Add(stack);
                    }
                }
                else
                {
                    foreach (var w in lenWords[i])
                    {
                        var res1 = new List<Stack<string>>();

                        foreach (var r in res)
                        {
                            if (isPre(r.Peek(), w))
                            {
                                r.Push(w);
                            }
                            else
                            {
                                var stack = new Stack<string>();
                                stack.Push(w);
                                res1.Add(stack);
                            }
                        }
                        foreach(var stack in res1)
                        {
                            res.Add(stack);
                        }
                    }
                }
                foreach(var stack in res)
                {
                    longestChain = (stack.Count > longestChain) ? stack.Count : longestChain;
                }

            }
            return longestChain;

        }

        public static bool isPre(string a, string b)
        {
            /*
            for(int i=0;i<b.Length;i++){
                if(b.Substring(0,i)+b.Substring(i+1,b.Length-i-1) == a){
                    return true;
                }
            }

            return false;
            */

            if ((b.Length - a.Length) != 1) return false;
            int i = 0;
            int j = 0;
            bool oneDiff = false;
            while (true)
            {
                if (i == a.Length)
                {
                    break;
                }
                if (a[i] == b[j])
                {
                    i++;
                    j++;
                    continue;
                }
                else
                {
                    if (oneDiff)
                    {
                        return false;
                    }
                    oneDiff = true;
                    j++;
                }
            }
            if (oneDiff && j == i + 1 || (!oneDiff && j == i))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

