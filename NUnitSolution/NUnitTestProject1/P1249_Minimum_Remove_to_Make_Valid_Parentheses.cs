using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace NUnitTestProject1
{
    class P1249_Minimum_Remove_to_Make_Valid_Parentheses
    {
        /*
Given a string s of '(' , ')' and lowercase English characters. 

Your task is to remove the minimum number of parentheses ( '(' or ')', in any positions ) so that the resulting parentheses string is valid and return any valid string.

Formally, a parentheses string is valid if and only if:

It is the empty string, contains only lowercase characters, or
It can be written as AB (A concatenated with B), where A and B are valid strings, or
It can be written as (A), where A is a valid string.

example 1:
Input: s = "a)b(c)d"
Output: "ab(c)d"
Example 2:

Input: s = "))(("
Output: ""
Explanation: An empty string is also valid.

Example 3:
Input: s = "(a(b(c)d)"
Output: "a(b(c)d)" 
         * 
         * 
         * */
        [Test]
        public void Test1()
        {
            Assert.AreEqual("abc(d(e)f)gh", MinRemoveToMakeValid("abc(d(e)f)gh)"));
            Assert.AreEqual("", MinRemoveToMakeValid(")))(("));
            Assert.AreEqual("ab(c)d", MinRemoveToMakeValid("a)b(c)d"));
        }
        public string MinRemoveToMakeValid(string s)
        {
            if (s == null || s.Length == 0)
            {
                return s;
            }
            var leftPara = new Stack<int>();
            var indexToRemove = new HashSet<int>();
            var sb = new StringBuilder();


            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    leftPara.Push(i);
                }
                else if (s[i] == ')')
                {
                    if (leftPara.Count > 0)
                    {
                        leftPara.Pop();
                    }
                    else
                    {
                        indexToRemove.Add(i);
                    }
                }
            }

            while (leftPara.Count > 0)
            {
                indexToRemove.Add(leftPara.Pop());
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (!indexToRemove.Contains(i))
                {
                    sb.Append(s[i]);
                }
            }

            return sb.ToString();
        }

        public string MinRemoveToMakeValid1(string s)
        {
            if (s == null || s.Length == 0)
            {
                return s;
            }
            var l = new Stack<int>();
            var r = new Stack<int>();
            var sb = new StringBuilder(s);


            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    l.Push(i);
                }
                else if (s[i] == ')')
                {
                    if (l.Count > 0)
                    {
                        l.Pop();
                    }
                    else
                    {
                        r.Push(i);
                    }
                }
            }

            while (l.Count > 0 && r.Count > 0)
            {
                if (l.Peek() > r.Peek())
                {
                    sb.Remove(l.Pop(), 1);
                }
                else
                {
                    sb.Remove(r.Pop(), 1);
                }
            }

            while (l.Count > 0)
            {
                sb.Remove(l.Pop(), 1);
            }

            while (r.Count > 0)
            {
                sb.Remove(r.Pop(), 1);
            }

            return sb.ToString();
        }
    }
}
