﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wintellect.PowerCollections.Tests
{
    [TestClass]
    public class BigList_LeafEnumrator
    {
        [TestMethod]
        public void AddLast()
        {
            var leafNodeEnumrator = new BigList<int>.LeafNodeEnumrator();

            var numberList = new List<int>() { 1, 2, 3 };
            foreach (var number in numberList)
                leafNodeEnumrator.AddLast(new BigList<int>.LeafNode(number));

            BigList<int>.LeafNode node = leafNodeEnumrator.FirstNode;
            foreach(var number in numberList)
            {
                Assert.AreEqual(number, node.items[0]);
                node = node.Next;
            }
        }

        [TestMethod]
        public void AddNext()
        {
            var leafNodeEnumrator = new BigList<int>.LeafNodeEnumrator();

            var node1 = new BigList<int>.LeafNode(1);
            leafNodeEnumrator.AddNext(leafNodeEnumrator.FirstNode, node1);

            var node2 = new BigList<int>.LeafNode(4);
            leafNodeEnumrator.AddNext(leafNodeEnumrator.LastNode, node2);

            var node3 = new BigList<int>.LeafNode(2);
            leafNodeEnumrator.AddNext(leafNodeEnumrator.FirstNode, node3);

            var node4 = new BigList<int>.LeafNode(3);
            leafNodeEnumrator.AddNext(node3, node4);

            BigList<int>.LeafNode node = leafNodeEnumrator.FirstNode;

            Assert.AreEqual(1, node.items[0]);
            node = node.Next;

            Assert.AreEqual(2, node.items[0]);
            node = node.Next;

            Assert.AreEqual(3, node.items[0]);
            node = node.Next;

            Assert.AreEqual(4, node.items[0]);
            node = node.Next;

            Assert.AreEqual(4, leafNodeEnumrator.LastNode.items[0]);
        }

        [TestMethod]
        public void AddBefore()
        {
            var leafNodeEnumrator = new BigList<int>.LeafNodeEnumrator();

            var node1 = new BigList<int>.LeafNode(4);
            leafNodeEnumrator.AddBefore(leafNodeEnumrator.FirstNode, node1);

            var node2 = new BigList<int>.LeafNode(1);
            leafNodeEnumrator.AddBefore(leafNodeEnumrator.LastNode, node2);

            var node3 = new BigList<int>.LeafNode(3);
            leafNodeEnumrator.AddBefore(node1, node3);

            var node4 = new BigList<int>.LeafNode(2);
            leafNodeEnumrator.AddBefore(node3, node4);

            BigList<int>.LeafNode node = leafNodeEnumrator.FirstNode;

            Assert.AreEqual(1, node.items[0]);
            node = node.Next;

            Assert.AreEqual(2, node.items[0]);
            node = node.Next;

            Assert.AreEqual(3, node.items[0]);
            node = node.Next;

            Assert.AreEqual(4, node.items[0]);
            node = node.Next;

            Assert.AreEqual(4, leafNodeEnumrator.LastNode.items[0]);
        }

        [TestMethod]
        public void Remove()
        {
            var leafNodeEnumrator = new BigList<int>.LeafNodeEnumrator();

            var node1 = new BigList<int>.LeafNode(1);
            leafNodeEnumrator.AddLast(node1);
            var node2 = new BigList<int>.LeafNode(2);
            leafNodeEnumrator.AddLast(node2);
            var node3 = new BigList<int>.LeafNode(3);
            leafNodeEnumrator.AddLast(node3);
            var node4 = new BigList<int>.LeafNode(4);
            leafNodeEnumrator.AddLast(node4);

            leafNodeEnumrator.Remove(node2);
            Assert.IsNull(node2.Next);
            Assert.IsNull(node2.Previous);

            leafNodeEnumrator.Remove(node1);
            Assert.IsNull(node1.Next);
            Assert.IsNull(node1.Previous);

            leafNodeEnumrator.Remove(node4);
            Assert.IsNull(node4.Next);
            Assert.IsNull(node4.Previous);

            var firstNode = leafNodeEnumrator.FirstNode;
            Assert.AreEqual(3, firstNode.items[0]);
            Assert.IsNull(firstNode.Next);
            Assert.IsNull(firstNode.Previous);
        }

        [TestMethod]
        public void ReplaceTest()
        {
            var leafNodeEnumrator = new BigList<int>.LeafNodeEnumrator();

            var node1 = new BigList<int>.LeafNode(1);
            leafNodeEnumrator.AddLast(node1);
            var node2 = new BigList<int>.LeafNode(2);
            leafNodeEnumrator.AddLast(node2);
            var node3 = new BigList<int>.LeafNode(3);
            leafNodeEnumrator.AddLast(node3);
            var node4 = new BigList<int>.LeafNode(4);
            leafNodeEnumrator.AddLast(node4);

            var newNode = new BigList<int>.LeafNode(5);
            leafNodeEnumrator.Replace(node2,newNode);
            Assert.IsNotNull(node2.Next);
            Assert.IsNotNull(node2.Previous);

            newNode = new BigList<int>.LeafNode(5);
            leafNodeEnumrator.Replace(node1, newNode);
            Assert.IsNotNull(node1.Next);
            Assert.IsNull(node1.Previous);

            newNode = new BigList<int>.LeafNode(5);
            leafNodeEnumrator.Replace(node4, newNode);
            Assert.IsNotNull(node4.Previous);
            Assert.IsNull(node4.Next);

            newNode = new BigList<int>.LeafNode(5);
            leafNodeEnumrator.Replace(node3, newNode);
            Assert.IsNotNull(node3.Previous);
            Assert.IsNotNull(node3.Next);

            BigList<int>.LeafNode node = leafNodeEnumrator.FirstNode;
            while (node != null)
            {
                Assert.AreEqual(5, node.items[0]);
                node = node.Next;
            }
        }
    }
}
