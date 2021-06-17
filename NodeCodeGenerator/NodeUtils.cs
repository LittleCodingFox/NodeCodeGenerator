using LittleCodingFox.NodeCodeGenerator.Nodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleCodingFox.NodeCodeGenerator
{
    public class NodeUtils
    {
        public static string Compile(NodeBase root)
        {
            var globalVariables = new StringBuilder();
            var code = new StringBuilder();
            var errorLog = new StringBuilder();
            ulong variableID = 0;

            if(!root.GenerateCode(new List<Guid>(), ref globalVariables, ref code, ref variableID, 0, ref errorLog))
            {
                return "";
            }

            if(errorLog.Length > 0)
            {
                Console.WriteLine($"Errors:\n{errorLog}");

                return "";
            }

            return $"{globalVariables}\n{code}";
        }

        public static string GenerateVariableName(ref ulong variableID)
        {
            variableID++;

            var variableName = "";
            var copyCounter = variableID;

            for (; ; )
            {
                variableName += (char)('a' + (copyCounter - 1) % 26);

                if (copyCounter <= 26)
                {
                    break;
                }

                copyCounter -= 26;
            }

            return variableName;
        }


        public static bool TypesAreCompatible(object a, object b)
        {
            if(a == null || b == null)
            {
                return false;
            }

            if(a is string)
            {
                return true;
            }
            else if(a is float)
            {
                if(b is float || b is int)
                {
                    return true;
                }
            }
            else if(a is int)
            {
                if(b is float || b is int)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
