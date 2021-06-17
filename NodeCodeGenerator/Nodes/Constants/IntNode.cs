using System;
using System.Collections.Generic;
using System.Text;

namespace LittleCodingFox.NodeCodeGenerator.Nodes
{
    public class IntNode : NodeBase
    {
        public IntNode()
        {
            data = 0;
        }

        public override bool GenerateCode(List<Guid> checkedNodes, ref StringBuilder globalVariables, ref StringBuilder code, ref ulong variableID, byte outputID, ref StringBuilder errorLog)
        {
            if (!base.GenerateCode(checkedNodes, ref globalVariables, ref code, ref variableID, outputID, ref errorLog))
            {
                return false;
            }

            code.AppendLine($"\tint {variableName} = {data};");

            return true;
        }
    }
}
