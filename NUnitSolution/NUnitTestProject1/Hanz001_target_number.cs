﻿using System;
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

             Given an non-zero integer array, find number of ways to calculate a target number 
             each element can be used zero time or once 
             You can use positive or negative value for each number
 
             ==========================
             Example 1:

             Input: arr[] = {1, 2, 3, 4}
             target = 5
 

             Explanation
 
             2 + 3
             1 + 4
             -1 + 2 + 4
             -2 + 3 + 4

             Output: 4

             ==========================
             Example 2:

             Input: arr[] = {3, 1, 3, 5}, 
             Target = 5

             Explanation - 
 
             3 + 3
             1 + 5
            -3 + 1 + 3 + 5
             3 + 1 - 3 + 5
             Output: 4

             ==========================

         ******************************************************************************/

        [Test]
        public void Test1()
        {

            Assert.AreEqual(4, BruteForce1_recur(new int[] { 3, 1, 3, 5 }, target: 6));
            Assert.AreEqual(4, BruteForce1_recur(new int[] { 1, 2, 3, 4 }, target: 5));
            Assert.AreEqual(10, BruteForce1_recur(new int[] { 3, 1, 3, 5, 7 }, target: 6));

            Assert.AreEqual(4, BruteForce1_iter(new int[] { 3, 1, 3, 5 }, target: 6));
            Assert.AreEqual(4, BruteForce1_iter(new int[] { 1, 2, 3, 4 }, target: 5));
            Assert.AreEqual(10, BruteForce1_iter(new int[] { 3, 1, 3, 5, 7 }, target: 6));


            Assert.AreEqual(4, WaysByBuilder(new int[] { 3, 1, 3, 5 }, target: 6));
            Assert.AreEqual(4, WaysByBuilder(new int[] { 1, 2, 3, 4 }, target: 5));
            Assert.AreEqual(10, WaysByBuilder(new int[] { 3, 1, 3, 5, 7 }, target: 6));

            Assert.AreEqual(4, WaysByRecurssion(new int[] { 3, 1, 3, 5 }, target: 6));
            Assert.AreEqual(4, WaysByRecurssion(new int[] { 1, 2, 3, 4 }, target: 5));
            Assert.AreEqual(10, WaysByRecurssion(new int[] { 3, 1, 3, 5, 7 }, target: 6));

        }
        public int BruteForce1_recur(int[] nums, int target)
        {
            if (nums.Length == 0) return 0;

            //var allLists = GetAllListsRecur(nums,nums.Length-1);

            var allLists = new List<List<int>>();
            allLists = GetAllLists_TailRecur(nums, nums.Length - 1, allLists);

            int count = 0;
            foreach (var li in allLists)
            {
                int sum = 0;
                foreach (var val in li)
                {
                    sum += val;
                }

                if (sum == target)
                {
                    count++;
                }
            }
            return count;

            // Space Complexity: O(N*3^N)    (Max Lengh of the sumList/tempList)
            // Time  Complexity: O(N * 3^(N+1)) each value of tempList is process N times (3^0 + 3^1 + 3^2 + .... + 3^n-1 + 3^N))
        }

        List<List<int>> GetAllListsRecur(int[] nums, int index)
        {
            var allLists = new List<List<int>>();
            if (index == 0)
            {
                var l0 = new List<int>();
                var l1 = new List<int>();
                var l2 = new List<int>();

                l0.Add(0);
                l1.Add(nums[index]);
                l2.Add(-nums[index]);

                allLists.Add(l0);
                allLists.Add(l1);
                allLists.Add(l2);

                return allLists;
            }

            var preLists = GetAllListsRecur(nums, index - 1);
            var tempLists = new List<List<int>>(preLists);
            foreach(var li in preLists)
            {
                var l0 = new List<int>(li);
                var l1 = new List<int>(li);
                var l2 = new List<int>(li);
                l1.Add(nums[index]);
                l2.Add(-nums[index]);
                tempLists.Add(l1);
                tempLists.Add(l2);
            }
            return tempLists;
        }

        List<List<int>> GetAllLists_TailRecur(int[] nums, int index, List<List<int>> allLists)
        {
            var nextIndex = index++;
            if (index == 0)
            {
                var l0 = new List<int>();
                var l1 = new List<int>();
                var l2 = new List<int>();

                l0.Add(0);
                l1.Add(nums[index]);
                l2.Add(-nums[index]);

                allLists.Add(l0);
                allLists.Add(l1);
                allLists.Add(l2);
                return allLists;
            }
            else if (index < nums.Length)
            {
                var tempLists = new List<List<int>>(allLists);
                foreach (var li in allLists)
                {
                    var l0 = new List<int>(li);
                    var l1 = new List<int>(li);
                    var l2 = new List<int>(li);
                    l1.Add(nums[index]);
                    l2.Add(-nums[index]);
                    tempLists.Add(l1);
                    tempLists.Add(l2);
                }
            }

            return GetAllLists_TailRecur(nums, index-1, allLists);
        }

        public int BruteForce1_iter(int[] nums, int target)
        {
            if (nums.Length == 0) return 0;
            var allLists = new List<List<int>>();
            var l0 = new List<int>();
            var l1 = new List<int>();
            var l2 = new List<int>();
            l0.Add(0);
            l1.Add(nums[0]);
            l2.Add(-nums[0]);

            allLists.Add(l0);
            allLists.Add(l1);
            allLists.Add(l2);
            for (int i = 1; i < nums.Length; i++)
            {
                var tempLists = new List<List<int>>(allLists);
                foreach (var li in allLists)
                {
                    l1 = new List<int>(li);
                    l2 = new List<int>(li);
                    l1.Add(nums[i]);
                    l2.Add(-nums[i]);
                    tempLists.Add(l1);
                    tempLists.Add(l2);
                }
                allLists = tempLists;
            }

            int count = 0;
            foreach (var li in allLists)
            {
                int sum = 0;
                foreach(var val in li)
                {
                    sum += val;
                }

                if(sum == target)
                {
                    count++;
                }
            }
            return count;

            // Space Complexity: O(N*3^N)    (Max Lengh of the sumList/tempList)
            // Time  Complexity: O(N * 3^(N+1)) each value of tempList is process N times (3^0 + 3^1 + 3^2 + .... + 3^n-1 + 3^N))
        }

        public int BruteForce2(int[] nums, int target)
        {
            List<int> sumList = new List<int>();
            sumList.Add(0); // this is important, this is the case that we do not pick any element
            for (int i = 0; i < nums.Length; i++)
            {
                var tempList = new List<int>();
                foreach (var s in sumList)
                {
                    tempList.Add(s + nums[i]);  // plus value
                    tempList.Add(s - nums[i]);  // minues value
                    tempList.Add(s);            // ignore value
                }
                sumList = tempList;
            }
            int count = 0;
            foreach(var s in sumList)
            {
                if (s == target) count++;
            }
            return count;

            // Space Complexity: O(3^N)    (Max Lengh of the sumList/tempList)
            // Time  Complexity: O(N * 3^N) each value of tempList is process N times 
        }

        public int WaysByBuilder(int[] nums, int target)
        {
            // number of ways to get to target, key=target, val= number of ways
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
            Dictionary<int, int>[] waysForTargetsAtIndex = new Dictionary<int, int>[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                waysForTargetsAtIndex[i] = new Dictionary<int, int>();
            }
            return WaysByRecurssionHelper(nums, target, 0, waysForTargetsAtIndex);
        }
        public int WaysByRecurssionHelper(int[] nums, int target, int index, Dictionary<int, int>[] waysToTargetsAtIndex)
        {
            if (index == nums.Length)
            {
                if (target == 0) return 1;
                else return 0;
            }

            if (waysToTargetsAtIndex[index].ContainsKey(target))
            {
                return waysToTargetsAtIndex[index][target];
            }

            int ways =
                WaysByRecurssionHelper(nums, target + nums[index], index + 1, waysToTargetsAtIndex) +
                WaysByRecurssionHelper(nums, target - nums[index], index + 1, waysToTargetsAtIndex) +
                WaysByRecurssionHelper(nums, target, index + 1, waysToTargetsAtIndex);

            waysToTargetsAtIndex[index][target] = ways;
            return ways;

            //Space Complexity: O(SumRange*N)
            //Time  Complexity: O(SumRange*N) : each N array Dictionary with key in SumRange, each item is filled only at most once.

            // without Memoization, the time complexity is O(3^N)

        }
    }
}
