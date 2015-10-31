using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace _06MyTreeTest
{
    public class BinarySearchTree<T> : IEnumerable<T>, ICloneable
        where T : IComparable 
    {
        private TreeNode<T> root;
        public int Count { get; private set; }

        public BinarySearchTree()
        {
            this.root = null;
            this.Count = 0;
        }

        // add element
        public void Add(T data)
        {
            TreeNode<T> newTreeNode = new TreeNode<T>(data);

            if (root == null)
            {
                root = newTreeNode;
            }
            else
            {
                this.InsertNode(root, newTreeNode);
            }

            this.Count++;

        }

        private void InsertNode(TreeNode<T> root, TreeNode<T> newNode)
        {
            TreeNode<T> temp;
            temp = root;

            if (newNode.Data.CompareTo(temp.Data) < 0)
            {
                if (temp.Left == null)
                {
                    temp.Left = newNode;
                }
                else
                {
                    temp = temp.Left;
                    this.InsertNode(temp, newNode);
                }
            }
            else
            {
                if (temp.Right == null)
                {
                    temp.Right = newNode;
                }
                else
                {
                    temp = temp.Right;
                    this.InsertNode(temp, newNode);
                }
            }
        }

        // searching element
        public bool Contains(T item)
        {
            TreeNode<T> searchedItem = this.root;

            while (true)
            {
                if (searchedItem.Data.CompareTo(item) == 0)
                {
                    return true;
                }
                else if (searchedItem.Left != null && 
                            searchedItem.Data.CompareTo(item) > 0)
                {
                    searchedItem = searchedItem.Left;
                }
                else if (searchedItem.Right != null)
                {
                    searchedItem = searchedItem.Right;
                }
                else
                {
                    return false;
                }
            }
        }

        // delete elements equals with item
        public int Delete(T item)
        {
            if (!this.Contains(item))
            {
                return 0;
            }

            BinarySearchTree<T> newTree = new BinarySearchTree<T>();
            int deleteCount = 0;

            IEnumerator<T> currentNode = this.GetEnumerator();

            while (currentNode.MoveNext())
            {
                if (currentNode.Current.CompareTo(item) != 0)
                {
                    newTree.Add(currentNode.Current);
                }
                else
                {
                    deleteCount++;
                }
            }

            this.root = newTree.root;

            return deleteCount;
        }

        public static bool operator ==(BinarySearchTree<T> first, BinarySearchTree<T> second)
        {
            if ((object)first == null && (object)second == null)
            {
                return true;
            }

            if ((object)first != null)
            {
                return first.Equals(second);
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(BinarySearchTree<T> first, BinarySearchTree<T> second)
        {
            return !(first == second);
        }

        public IEnumerator<T> GetEnumerator()
        {
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode<T> temp = queue.Dequeue();
                
                yield return temp.Data;

                if (temp.Left != null)
                {
                    queue.Enqueue(temp.Left);
                }

                if (temp.Right != null)
                {
                    queue.Enqueue(temp.Right);
                }
            }
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            // Call the generic version of the method
            return this.GetEnumerator();
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public BinarySearchTree<T> Clone()
        {
            BinarySearchTree<T> clone = new BinarySearchTree<T>();
            IEnumerator<T> item = this.GetEnumerator();

            while (item.MoveNext())
            {
                clone.Add(item.Current);
            }

            return clone;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            BinarySearchTree<T> newTree = obj as BinarySearchTree<T>;

            if (newTree != null && this.Count == newTree.Count)
            {
                IEnumerator<T> thisTree = this.GetEnumerator();

                thisTree.MoveNext();

                foreach (T item in newTree)
                {
                    if (item.CompareTo(thisTree.Current) != 0)
                    {
                        return false;
                    }

                    thisTree.MoveNext();
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.root.ToString().GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            bool isFirst = true;

            result.Append("[");

            IEnumerator<T> item = this.GetEnumerator();

            while (item.MoveNext())
            {
                if (isFirst)
                {
                    result.AppendFormat(" {0}", item.Current);
                    isFirst = false;
                }
                else
                {
                    result.AppendFormat(", {0}", item.Current);
                }
            }

            result.Append(" ]");

            return result.ToString();
        }
    }
}
