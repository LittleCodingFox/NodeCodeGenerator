﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LittleCodingFox.NodeCodeGenerator.Nodes
{
    public class FloatNode : NodeBase
    {
        public FloatNode()
        {
            data = 0.0f;
        }

        public override bool GenerateCode(List<Guid> checkedNodes, ref StringBuilder globalVariables, ref StringBuilder code, ref ulong variableID, byte outputID, ref StringBuilder errorLog)
        {
            if(!base.GenerateCode(checkedNodes, ref globalVariables, ref code, ref variableID, outputID, ref errorLog))
            {
                return false;
            }

            code.AppendLine($"\tfloat {variableName} = {data};");

            return true;
        }
    }
}
