using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using System;

namespace P1048
{
    class P1048
    {
        [Test]
        public void test1()
        {
            Assert.AreEqual(4,
                LongestStrChain(
                    new string[]
                    { "a","b","ba","bca","bda","bdca" }
                ));
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
        public static int LongestStrChain(string[] words){
            if (words == null || words.Length == 0)
                return 0;
            var maxWordLen = 0;
            foreach (var w in words){
                if (w.Length > maxWordLen)
                    maxWordLen = w.Length;
            }
            var lenWords = new Dictionary<int, List<string>>();
            for (int i = 1; i <= maxWordLen; i++){
                lenWords[i] = new List<string>();
            }
            foreach (var w in words){
                lenWords[w.Length].Add(w);
            }

            var res = new Dictionary<string,int>();
            int longestChain = 0;
            for (int i = 1; i <= maxWordLen; i++){
                if (lenWords[i].Count == 0){
                    res = new Dictionary<string, int>();
                    continue;
                }else if (res.Count == 0){
                    foreach (var w in lenWords[i]){
                        res[w] = 1;
                    }
                    longestChain = Math.Max(longestChain, 1);
                    continue;
                }else{
                    var res1 = new Dictionary<string, int>();
                    foreach (var w in lenWords[i]){
                        foreach (var k in res.Keys){
                            if (isPre(k, w)){
                                var oldVal = 0;
                                if (res1.ContainsKey(w)){
                                    oldVal = res1[w];
                                }
                                res1[w] = Math.Max(oldVal, res[k] + 1);
                            }
                        }
                        if (!res1.ContainsKey(w)){
                            res1[w] = 1;
                        }
                    }
                    res = res1;
                    longestChain = Math.Max(longestChain, res.Values.Max());
                }
            }
            return longestChain;
        }

        public static bool isPre(string a, string b)
        {
            if ((b.Length - a.Length) != 1) return false;
            int i = 0;
            int j = 0;
            bool oneDiff = false;
            while (true){
                if (i == a.Length){
                    break;
                }else if (a[i] == b[j]){
                    i++;
                    j++;
                    continue;
                }else{
                    if (oneDiff){
                        return false;
                    }
                    oneDiff = true;
                    j++;
                }
            }
            if (oneDiff && j == i + 1 || (!oneDiff && j == i)){
                return true;
            }else{
                return false;
            }

            /*
            for(int i=0;i<b.Length;i++){
                if(b.Substring(0,i)+b.Substring(i+1,b.Length-i-1) == a){
                    return true;
                }
            }
            return false;
            */
        }
    }
}

