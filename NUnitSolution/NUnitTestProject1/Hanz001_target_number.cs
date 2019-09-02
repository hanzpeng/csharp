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
            Assert.AreEqual(4, WaysByBuilder(new int[] { -3, 1, 3, 5 }, target: 6));
            Assert.AreEqual(4, WaysByBuilder(new int[] { 1, 2, 3, 4 }, target: 5));
            Assert.AreEqual(10, WaysByBuilder(new int[] { -3, 1, 3, 5, 7 }, target: 6));

            Assert.AreEqual(4, WaysByRecurssion(new int[] { -3, 1, 3, 5 }, target: 6));
            Assert.AreEqual(4, WaysByRecurssion(new int[] { 1, 2, 3, 4 }, target: 5));
            Assert.AreEqual(10, WaysByRecurssion(new int[] { -3, 1, 3, 5, 7 }, target: 6));

        }
        public int WaysByBuilder(int[] nums, int target)
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

            // Space Complexity: O(2*SumRange)   -> O(2*SumRange)
            // Time  Complexity: O(3*SumRange*N) -> O(SumRange*N)
        }
        public int WaysByRecurssion(int[] nums, int target)
        {
            int lastIndex = nums.Length - 1;
            Dictionary<int, int>[] waysForTargetsAtIndex = new Dictionary<int, int>[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                waysForTargetsAtIndex[i] = new Dictionary<int, int>();
            }
            return WaysByRecurssionHelper(nums, target, lastIndex, waysForTargetsAtIndex);
        }
        public int WaysByRecurssionHelper(int[] nums, int target, int lastIndex, Dictionary<int, int>[] waysToTargetsAtIndex)
        {
            if (lastIndex == -1)
            {
                if (target == 0) return 1;
                else return 0;
            }

            if (waysToTargetsAtIndex[lastIndex].ContainsKey(target))
            {
                return waysToTargetsAtIndex[lastIndex][target];
            }

            int ways =
                WaysByRecurssionHelper(nums, target + nums[lastIndex], lastIndex - 1, waysToTargetsAtIndex) +
                WaysByRecurssionHelper(nums, target - nums[lastIndex], lastIndex - 1, waysToTargetsAtIndex) +
                WaysByRecurssionHelper(nums, target, lastIndex - 1, waysToTargetsAtIndex);

            waysToTargetsAtIndex[lastIndex][target] = ways;
            return ways;

            //Space Complexity: O(SumRange*N)
            //Time  Complexity: O(SumRange*N) : each N array Dictionary with key in SumRange, each item is filled only at most once.

            // without Memoization, the time complexity is O(3^N)

        }
    }
}
