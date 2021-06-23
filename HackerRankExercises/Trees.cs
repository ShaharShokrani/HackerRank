using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankExercises
{
    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
    }

    [TestClass]
    public class Trees
    {
        
        ///// <summary>
        ///// https://www.youtube.com/watch?v=py3R23aAPCA
        ///// </summary>
        //[TestMethod]
        //public void LowestCommonAncestorTest()
        //{
        //    TreeNode zNode = new TreeNode()
        //    {
        //        Value = 'z',
        //        Left = new TreeNode
        //        {
        //            Value = 'x',
        //            Left = null,
        //            Right = null
        //        },
        //        Right = new TreeNode
        //        {
        //            Value = 'q',
        //            Left = null,
        //            Right = new TreeNode
        //            {
        //                Value = 'y',
        //                Left = null,
        //                Right = null
        //            }
        //        }
        //    };

        //    TreeNode lNode = new TreeNode()
        //    {
        //        Value = 'l',
        //        Left = zNode,
        //        Right = null
        //    };

        //    TreeNode kNode = new TreeNode()
        //    {
        //        Value = 'k',
        //        Left = lNode,
        //        Right = new TreeNode()
        //        {
        //            Value = 'b',
        //            Left= null,
        //            Right = null
        //        }
        //    };

        //    Assert.AreEqual(zNode, LCA(zNode, 'x', 'y'));
        //    Assert.AreEqual(zNode, LCA(lNode, 'x', 'y'));
        //}

        //public TreeNode LCA(TreeNode treeNode, char leftValue, char rightValue)
        //{
        //    if (treeNode == null) return null;

        //    if (treeNode.Value.Equals(leftValue) ||
        //        treeNode.Value.Equals(rightValue))
        //        return treeNode;

        //    TreeNode leftResult = LCA(treeNode.Left, leftValue, rightValue);
        //    TreeNode rightResult = LCA(treeNode.Right, leftValue, rightValue);

        //    if (leftResult == null) return rightResult;
        //    if (rightResult == null) return leftResult;

        //    return treeNode;
        //}

        ///// <summary>
        ///// https://www.youtube.com/watch?v=gcR28Hc2TNQ
        ///// </summary>
        //[TestMethod]
        //public void BinaryTreeLevelOrderTraversalTest()
        //{
        //    TreeNode dNode = new TreeNode()
        //    {
        //        Value = 'd',
        //        Left = new TreeNode
        //        {
        //            Value = 'h',
        //            Left = null,
        //            Right = null
        //        },
        //        Right = null
        //    };

        //    TreeNode bNode = new TreeNode()
        //    {
        //        Value = 'b',
        //        Left = dNode,
        //        Right = new TreeNode()
        //        {
        //            Value = 'e',
        //            Left = null,
        //            Right = null
        //        }
        //    };

        //    TreeNode cNode = new TreeNode()
        //    {
        //        Value = 'c',
        //        Left = new TreeNode()
        //        {
        //            Value = 'f'
        //        },
        //        Right = new TreeNode()
        //        {
        //            Value = 'g'
        //        }
        //    };

        //    TreeNode aNode = new TreeNode()
        //    {
        //        Value = 'a',
        //        Left = bNode,
        //        Right = cNode
        //    };

        //    CollectionAssert.AreEquivalent(new List<char>() { 'a','b','c','d','e','f','g','h' }, LevelOrderTraversal(aNode));
        //}

        //Queue<TreeNode> queue = new Queue<TreeNode>();
        //public List<char> LevelOrderTraversal(TreeNode treeNode)
        //{
        //    List<char> result = new List<char>();
        //    queue.Enqueue(treeNode);                

        //    while (queue.Count > 0)
        //    {
        //        var inQueue = queue.Dequeue();
        //        result.Add(inQueue.Value);

        //        if (inQueue.Left != null)
        //        {
        //            queue.Enqueue(inQueue.Left);
        //        }
                    
        //        if (inQueue.Right != null)
        //        {
        //            queue.Enqueue(inQueue.Right);
        //        }
        //    }
        //    return result;
        //}

        [TestMethod]
        public void FindMaxTest()
        {
            TreeNode fiveNode = new TreeNode()
            {
                Value = 5,
                Left = new TreeNode()
                {
                    Value = 2
                },
                Right = new TreeNode()
                {
                    Value = 10
                }
            };

            TreeNode sevenNode = new TreeNode()
            {
                Value = 7,
                Left = null,
                Right = new TreeNode()
                {
                    Value = 8
                }
            };

            TreeNode oneNode = new TreeNode()
            {
                Value = 1,
                Left = fiveNode,
                Right = sevenNode
            };

            Assert.AreEqual(10, FindMax(oneNode));
        }

        //LRN
        //public int FindMax(TreeNode treeNode)
        //{
        //    if (treeNode == null) return 0;

        //    var leftMaxValue = FindMax(treeNode.Left);

        //    var rightMaxValue = FindMax(treeNode.Right);

        //    var childMax = Math.Max(leftMaxValue, rightMaxValue);

        //    return Math.Max(childMax, treeNode.Value);            
        //}
        //private int _max = 0;
        

        /// <summary>
        /// Finds the max of a tree without recursion
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int FindMax(TreeNode root)
        {
            int _max = 0;
            Queue<TreeNode> _queue = new Queue<TreeNode>();

            if (root == null) return 0;

            _queue.Enqueue(root);
            _max = root.Value;

            while (_queue.Count != 0)
            {
                //Process (de-queue):
                var treeNode = _queue.Dequeue();

                //Check if is bigger than max:
                if (treeNode.Value > _max)
                    _max = treeNode.Value;

                //Add his right and left:
                if (treeNode.Left != null)
                    _queue.Enqueue(treeNode.Left);

                if (treeNode.Right != null)
                    _queue.Enqueue(treeNode.Right);
            }

            return _max;
        }
    }
}
