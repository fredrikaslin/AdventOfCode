using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Common
{
    public static class NodeHelper
    {
        public static Node GetNewNode(int data)
        {
            Node node = new Node();
            node.data = data;
            node.left = null;
            node.right = null;
            return (node);
        }
    }
}
