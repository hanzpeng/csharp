using System;
using System.Collections;
using System.Collections.Generic;

namespace FreqStack
{
    class FreqStack
    {
        Dictionary <int, int> freq;
        Dictionary<int, Stack<int>> group;
        int maxfreq;

        public FreqStack()
        {
            freq = new Dictionary<int, int>();
            group = new Dictionary<int, Stack<int>>();
            maxfreq = 0;
        }

        public void push(int x)
        {
            int f = 1;
            if (!freq.ContainsKey(x))
            {
                f = ++freq[x];
            }
            else
            {
                freq.Add(x, 1);
                f = 1;
            }
            if (f > maxfreq)
                maxfreq = f;

            if (!group.ContainsKey(f))
            {
                group.Add(f,new Stack<int>());
            }
            group[f].Push(x);
        }

        public int pop()
        {
            int x = group[maxfreq].Pop();
            freq[x]--;
            if (group[maxfreq].Count == 0)
                maxfreq--;
            return x;
        }
    }
}
