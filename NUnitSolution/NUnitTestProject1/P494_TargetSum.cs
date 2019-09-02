using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace P494_TargetSum
{
    class P494_TargetSum
    {
        /****************************************************************************
            You are given a list of non-negative integers, 
            a1, a2, ..., an, 
            and a target, S. 
            Now you have 2 symbols + and -. 
            For each integer, you should choose one from + and - as its new symbol.
            
            Find out how many ways to assign symbols to make sum of integers equal to target S.

            Example 1:
            Input: nums is [1, 1, 1, 1, 1], S is 3. 
            Output: 5
            Explanation: 

            -1+1+1+1+1 = 3
            +1-1+1+1+1 = 3
            +1+1-1+1+1 = 3
            +1+1+1-1+1 = 3
            +1+1+1+1-1 = 3

            There are 5 ways to assign symbols to make the sum of nums be target 3.
            Note:
            The length of the given array is positive and will not exceed 20.
            The sum of elements in the given array will not exceed 1000.
            Your output answer is guaranteed to be fitted in a 32-bit integer.
         ******************************************************************************/
        [Test]
        public void Test1()
        {
            Assert.AreEqual(5, WaysByBuilder(new int[] { 1,1,1,1,1}, target: 3));
            Assert.AreEqual(5, WaysByRecurssion(new int[] { 1, 1, 1, 1, 1 }, target: 3));
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
                sumWays = sumWaysNew;
            }
            return sumWays[target];
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
                WaysByRecurssionHelper(nums, target - nums[lastIndex], lastIndex - 1, waysToTargetsAtIndex);

            waysToTargetsAtIndex[lastIndex][target] = ways;
            return ways;
        }
    }
}
