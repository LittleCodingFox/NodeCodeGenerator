using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleCodingFox.NodeCodeGenerator.Nodes
{
    public class AddNode : NodeBase
    {
        public override bool GenerateCode(List<Guid> checkedNodes, ref StringBuilder globalVariables, ref StringBuilder code, ref ulong variableID, byte outputID, ref StringBuilder errorLog)
        {
            if (!base.GenerateCode(checkedNodes, ref globalVariables, ref code, ref variableID, outputID, ref errorLog) || inputs.Count != 2 || inputs.Any(x => x == null))
            {
                return false;
            }

            if(!NodeUtils.TypesAreCompatible(inputs[0].data, inputs[1].data))
            {
                errorLog.AppendLine("Data types are not compatible");

                return false;
            }

            if(inputs[0].data is string)
            {
                code.AppendLine($"\tstring {variableName} = {inputs[0].variableName} + {inputs[1].variableName}.ToString();");
            }
            else if(inputs[0].data is float)
            {
                code.AppendLine($"\tfloat {variableName} = {inputs[0].variableName} + {inputs[1].variableName};");
            }
            else if (inputs[0].data is int)
            {
                code.AppendLine($"\tint {variableName} = {inputs[0].variableName} + (int){inputs[1].variableName};");
            }

            data = inputs[0].data;

            return true;
        }
    }
}
