using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
namespace NUnitProject1
{
    class TreeNode
    {
        public TreeNode left, right;
        public int value;
        public TreeNode(int val)
        {
            this.value = val;
        }
    }
    class P653_TwoSumIV_BST
    {
        /*
        Given a Binary Search Tree and a target number, return true if there exist two elements in the BST such that their sum is equal to the given target.

        Example 1:

        Input: 
            5
           / \
          3   6
         / \   \
        2   4   7

        Target = 9

        Output: True
        3 + 6 = 9
        2 + 7 = 9


        Example 2:

        Input: 
            5
           / \
          3   6
         / \   \
        2   4   7

        Target = 28

        Output: False

        */
        [Test]
        public void Test1()
        {
            TreeNode root = new TreeNode(5);
            root.left = new TreeNode(3);
            root.right = new TreeNode(6);
            root.left.left = new TreeNode(2);
            root.left.right = new TreeNode(4);
            root.right.right = new TreeNode(7);
            Assert.AreEqual(true, FindSum1(root, 9));
        }
        [Test]
        public void Test2()
        {
            TreeNode root = new TreeNode(5);
            root.left = new TreeNode(3);
            root.right = new TreeNode(6);
            root.left.left = new TreeNode(2);
            root.left.right = new TreeNode(4);
            root.right.right = new TreeNode(7);
            Assert.AreEqual(false, FindSum1(root, 100));
        }

        public bool FindSum(TreeNode root, int target)
        {
            HashSet<int> set = new HashSet<int>();
            return FindSum(root, target, set);
        }
        public bool FindSum(TreeNode root, int target, HashSet<int> set)
        {
            if (root == null) return false;
            if (set.Contains(target - root.value))
                return true;
            set.Add(root.value);
            return FindSum(root.left, target, set) || FindSum(root.right, target, set); 
        }

        public bool FindSum1(TreeNode root, int target)
        {
            var list = new List<int>();
            InOrder(root, target, list);
            if (!list.Any()) return false;
            int left = 0;
            int right = list.Count()-1;
            while(right > left)
            {
                if(list[left] + list[right] < target)
                {
                    left++;
                }
                else if (list[left] + list[right] > target)
                {
                    right--;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public void InOrder(TreeNode root, int target, List<int> list)
        {
            if (root == null) return;
            InOrder(root.left, target, list);
            list.Add(root.value);
            InOrder(root.right, target, list);
        }
    }
}
