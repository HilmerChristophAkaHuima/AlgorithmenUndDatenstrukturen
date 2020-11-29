using System;
using System.Collections.Generic;
using System.Text;

namespace Blatt7
{
    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
    }
    public class Tree
    {
        private TreeNode root { get; set; }
        private static int preOrderIndex = 0;

        public bool Contains(int o)
        {
            TreeNode curr = root;
            while (curr != null)
            {
                if (curr.Value == o)
                {
                    return true;
                }
                else
                {
                    if (o <= curr.Value)
                    {
                        curr = curr.Left;
                    }
                    else
                    {
                        curr = curr.Right;
                    }
                }
            }

            return false;
        }

        private void Insert(TreeNode currRoot, TreeNode elem)
        {
            if (elem.Value <= currRoot.Value)
            {
                if (currRoot.Left == null)
                {
                    currRoot.Left = elem;
                }
                else
                {
                    Insert(currRoot.Left, elem);
                }
            }
            else
            {
                if (currRoot.Right == null)
                {
                    currRoot.Right = elem;
                }
                else
                {
                    Insert(currRoot.Right, elem);
                }
            }
        }

        public void Insert(int o)
        {
            TreeNode elem = new TreeNode();
            elem.Value = o;
            elem.Left = null;
            elem.Right = null;
            if (root == null)
            {
                root = elem;
            }
            else
            {
                Insert(root, elem);
            }
        }

        public void Print()
        {
            Print(root);
            Console.WriteLine();
        }

        private void Print(TreeNode root)
        {
            if (root != null)
            {
                Console.Write("(");
                Print(root.Left);
                Console.Write($", {root.Value}, ");
                Print(root.Right);
                Console.Write(")");
            }
            else
            {
                Console.Write("n");
            }
        }

        public void DeleteValue(int o)
        {
            root = DeleteValue(root, o);
        }

        private TreeNode DeleteValue(TreeNode rootPar, int o)
        {
            if (rootPar == null)
            {
                return null;
            }

            if (o < rootPar.Value)
            {
                rootPar.Left = DeleteValue(rootPar.Left, o);
            }
            else
            {
                if (o > rootPar.Value)
                {
                    rootPar.Right = DeleteValue(rootPar.Right, o);
                }
                else
                {
                    if (rootPar.Left == null)
                    {
                        return rootPar.Right;
                    }
                    else if (rootPar.Right == null)
                    {
                        return rootPar.Left;
                    }

                    TreeNode rootParTemp = rootPar;
                    int kleinsterWert = rootParTemp.Right.Value;
                    while (rootParTemp.Left != null)
                    {
                        kleinsterWert = rootParTemp.Left.Value;
                        rootParTemp = rootParTemp.Left;
                    }

                    rootPar.Value = kleinsterWert;
                    rootPar.Right = DeleteValue(rootPar.Right, rootPar.Value);
                }
            }

            return rootPar;
        }

        public void DeleteValueIterativ(int o)
        {
            TreeNode iterator = root;
            TreeNode prev = null;

            while (iterator != null && iterator.Value != o)
            {
                prev = iterator;
                if (o < iterator.Value)
                {
                    iterator = iterator.Left;
                }
                else
                {
                    iterator = iterator.Right;
                }
            }

            if (iterator == null)
            {
                return;
            }

            if (iterator.Left == null || iterator.Right == null)
            {
                TreeNode temp = iterator.Right ?? iterator.Left;

                if (prev == null)
                {
                    root = temp;
                    return;
                }

                if (iterator == prev.Left)
                {
                    prev.Left = temp;
                }
                else
                {
                    prev.Right = temp;
                }
            }
            else
            {
                TreeNode secondIterator = null;
                TreeNode secondPrev = iterator.Right;

                while (secondPrev.Left != null)
                {
                    secondIterator = secondPrev;
                    secondPrev = secondPrev.Left;
                }

                if (secondIterator != null)
                {
                    secondIterator.Left = secondPrev.Right;
                }
                else
                {
                    iterator.Right = secondPrev.Right;
                }

                iterator.Value = secondPrev.Value;
            }
        }
        

        public static Tree InOrderPreOrderTreeCreater(int[] inorder, int[] preorder)
        {
            return new Tree(){root = InOrderPreOrderTreeCreaterRekursiv(inorder, preorder,0, inorder.Length -1)}; 
        }

        private static TreeNode InOrderPreOrderTreeCreaterRekursiv(int[] inorder, int[] preorder, int buildStart, int buildEnd)
        {
            if (buildStart > buildEnd)
            {
                return null;
            }

            TreeNode elm = new TreeNode(){Value = preorder[preOrderIndex]};
            preOrderIndex++;

            if (buildStart == buildEnd)
            {
                return elm;
            }

            int index;
            for (index = buildStart; index < buildEnd; index++)
            {
                if (inorder[index] == elm.Value)
                {
                    break;
                }
            }

            elm.Left = InOrderPreOrderTreeCreaterRekursiv(inorder, preorder, buildStart, index - 1);
            elm.Right = InOrderPreOrderTreeCreaterRekursiv(inorder, preorder, index + 1, buildEnd);

            return elm;
        }
    }
}
