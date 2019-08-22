
using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
namespace P078_Subsetrs
{
    public class P078_Subsets
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(1, 1);
            List<List<int>> result = Subsets(new int[] { 1, 2, 3, 4 });

            foreach (var li in result)
            {
                foreach (var n in li)
                {
                    Console.Write(n + ", ");
                }
                Console.WriteLine();
            }
            /*
                1,
                
                2, 
                1, 2, 

                3, 
                1, 3, 
                2, 3, 
                1, 2, 3, 

                4, 
                1, 4, 
                2, 4, 
                1, 2, 4, 
                3, 4, 
                1, 3, 4, 
                2, 3, 4, 
                1, 2, 3, 4, 
             */

        }
        public List<List<int>> Subsets(int[] nums)
        {
            List<List<int>> l = new List<List<int>>();
            l.Add(new List<int>());
            List<int> temp = null;
            for (int x = 0; x < nums.Length; x++)
            {
                int s = l.Count;
                for (int y = 0; y < s; y++)
                {
                    temp = new List<int>(l[y]);
                    temp.Add(nums[x]);
                    l.Add(new List<int>(temp));
                }
            }
            return l;
        }
    }
}
