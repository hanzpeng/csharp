using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start..");
            var nums = new int[] { -1, 0, 3, 5, 9, 12 };
            var res = find1(nums, 9);
            Console.WriteLine(res);
            Console.Read();

        }
        static int find1(int[] nums, int target)
        {
            int mid, left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                mid = (left + right) / 2;
                if (target == nums[mid]) return mid;
                else if (target < nums[mid]) right = mid - 1;
                else left = mid + 1;
            }
            return -1;
        }
    }
}
