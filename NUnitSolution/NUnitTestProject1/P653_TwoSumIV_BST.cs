using System;
using System.Collections.Generic;
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
            Assert.AreEqual(true, FindSum(root, 9));
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
            Assert.AreEqual(false, FindSum(root, 100));
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

    }
}
