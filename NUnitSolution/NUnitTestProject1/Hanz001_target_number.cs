using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Hanz001_target_number
{
    class Hanz001_target_number
    {
        /****************************************************************************
        https://www.geeksforgeeks.org/number-of-ways-to-calculate-a-target-number-using-only-array-elements/
            Number of ways to calculate a target number using only array elements
            Given an integer array, find number of ways to calculate a target number 
            using only array elements and addition or subtraction operator.

            Example 1:

            Input: arr[] = {-3, 1, 3, 5}, k = 6
            Output: 4

            Explanation - 
            - (-3) + (3)
            + ( 1) + (5)
            + (-3) + (1) + (3) + (5)
            - (-3) + (1) - (3) + (5)
         ******************************************************************************/
        [Test]
        public void Test1()
        {
            Assert.AreEqual(4, Ways(new int[] { -3, 1, 3, 5 }, 6));
            Assert.AreEqual(4, Ways(new int[] { 1, 2, 3, 4 }, 5));
        }
        public int Ways(int[] nums, int target)
        {
            Dictionary<int, int> sumWays = new Dictionary<int, int>();
            sumWays[0] = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                Dictionary<int, int> sumWaysNew = new Dictionary<int, int>();
                foreach (var sw in sumWays)
                {
                    int key = sw.Key + nums[i];
                    sumWaysNew[key] = sw.Value + sumWaysNew.GetValueOrDefault(key, 0);

                    key = sw.Key - nums[i];
                    sumWaysNew[key] = sw.Value + sumWaysNew.GetValueOrDefault(key, 0);
                }

                foreach (var key in sumWaysNew.Keys)
                {
                    sumWays[key] = sumWaysNew[key] + sumWays.GetValueOrDefault(key, 0);
                }
            }
            return sumWays[target];
        }
    }
}
