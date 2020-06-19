using NUnit.Framework;
using System.Linq;

namespace Libo_Google
{
    class PLibo
    {
        [Test]
        public void test1(){
            Assert.AreEqual("111110111010",
                WetOrDry(new int[] {3,1,2,1,3,5,1,2,2,4,3,4},
                new int[] { 4, 6, 8, 10 }));
        }
        static string WetOrDry(int[] height, int[] pump)
        {
            int N = height.Length;
            int K = pump.Length;
            bool[] limit = new bool[N];
            char[] res = new char[N];
            for (var i = 0; i < N; i++)
                res[i] = '0';
            for (int k = K - 1; k >= 0; k--){
                int p = pump[k];
                if (res[p] == '1') 
                    continue;//already wet, skip and check the next pump
                res[p] = '1';
                int l = p - 1;
                while (l >= 0 && !limit[l] && height[l] <= height[p])
                    res[l--] = '1';
                if (l >= 0)
                    limit[l] = true;
                int r = p + 1;
                while (r < N && !limit[r] && height[r] <= height[p])
                    res[r++] = '1';
                if (r < N)
                    limit[r] = true;
            }
            return string.Join("", res);
        }
    }
}

