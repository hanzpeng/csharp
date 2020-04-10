using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
namespace NUnitProject1
{
    public class P236_LowestCommonAncestorBinaryTree
    {
        [Test]
        public void Test1()
        {
            var n1 = new TreeNode(1);
            var n2 = new TreeNode(2);
            var n3 = new TreeNode(3);
            var n4 = new TreeNode(4);
            var n5 = new TreeNode(5);
            var n6 = new TreeNode(6);
            var n7 = new TreeNode(7);
            var n8 = new TreeNode(8);
            n1.left = n2;
            n1.right = n3;
            Assert.AreEqual(1, FindLCA(n1, n2, n3).val);
            Assert.AreEqual(2, FindLCA(n1, n2, n2).val);
            Assert.AreEqual(3, FindLCA(n1, n3, n3).val);
            Assert.AreEqual(1, FindLCA(n1, n1, n3).val);
            Assert.AreEqual(1, FindLCA(n1, n1, n2).val);

            n2.left = n4;
            n2.right = n5;
            Assert.AreEqual(2, FindLCA(n1, n4, n5).val);
            Assert.AreEqual(2, FindLCA(n1, n4, n2).val);
            Assert.AreEqual(1, FindLCA(n1, n4, n3).val);
            n3.left = n6;
            n6.right = n7;
            Assert.AreEqual(1, FindLCA(n1, n5, n7).val);



        }
        public class TreeNode
        {
            public int val;
            public TreeNode left, right;
            public TreeNode(int val)
            {
                this.val = val;
            }
        }
        public TreeNode FindLCA(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || p == null || q == null) return null;
            if (p == q)
            {
                return PreOrderSearch(root, p);
            }
            //return PostOrderSearch(root, p, q, new bool[2]);
            return lowestCommonAncestor(root, p, q);
        }
        public TreeNode PostOrderSearch(TreeNode root, TreeNode p, TreeNode q, bool[] res)
        {
            if (root == null) return null;

            var lRes = new bool[2];
            var leftFoundNode = PostOrderSearch(root.left, p, q, lRes);
            if (leftFoundNode != null) return leftFoundNode;

            var rRes = new bool[2];
            var rightFoundNode = PostOrderSearch(root.right, p, q, rRes);
            if (rightFoundNode != null) return rightFoundNode;

            res[0] = (p == root) || lRes[0] || rRes[0];
            res[1] = (q == root) || lRes[1] || rRes[1];

            if (res[0] && res[1]) return root;

            return null;
        }

        public TreeNode PreOrderSearch(TreeNode root, TreeNode s)
        {
            if (root == null) return null;
            if (s == root) return root;
            return PreOrderSearch(root.left, s) ?? PreOrderSearch(root.right, s);
        }

        // since p and q are different and both values will exist in the binary tree: we can do the following:
        public TreeNode lowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == q || root == p) return root;
            TreeNode left = lowestCommonAncestor(root.left, p, q);
            TreeNode right = lowestCommonAncestor(root.right, p, q);
            if (left != null && right != null) return root;
            return left ?? right;
        }

    }
}
