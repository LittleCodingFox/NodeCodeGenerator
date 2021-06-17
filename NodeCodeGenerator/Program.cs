using LittleCodingFox.NodeCodeGenerator;
using LittleCodingFox.NodeCodeGenerator.Nodes;
using System;
using System.Collections.Generic;

namespace NodeCodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            NodeBase aNode = new IntNode()
            {
                data = 1,
            };

            NodeBase bNode = new IntNode()
            {
                data = 2,
            };

            var addNode = new AddNode();

            addNode.AddNode(aNode);
            addNode.AddNode(bNode);

            var root = new NodeStatement();

            root.AddNode(addNode);

            aNode = new StringNode()
            {
                data = "asdf",
            };

            var otherAddNode = new AddNode();

            otherAddNode.AddNode(aNode);
            otherAddNode.AddNode(addNode);

            root.AddNode(otherAddNode);

            var result = NodeUtils.Compile(root);

            if(result.Length > 0)
            {
                Console.WriteLine($"Result:\n{result}");
            }
        }
    }
}
