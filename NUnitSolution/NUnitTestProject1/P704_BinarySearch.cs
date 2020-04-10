
using NUnit.Framework;
namespace NUnitProject1
{
    class P704_BinarySearch
    {
        [Test]
        public void test1()
        {
            Assert.AreEqual(4, find(new int[] { -1, 0, 3, 5, 9, 12 }, 9));
            Assert.AreEqual(-1, find(new int[] { -1, 0, 3, 5, 9, 12 }, 900));
            Assert.AreEqual(-1, find(new int[] { -1, 0, 3, 5, 9, 12 }, -900));
        }
        static int find(int[] nums, int target)
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

