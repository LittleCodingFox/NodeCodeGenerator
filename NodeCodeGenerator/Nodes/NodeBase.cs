using System;
using System.Collections.Generic;
using System.Text;

namespace LittleCodingFox.NodeCodeGenerator.Nodes
{
    public class NodeBase
    {
        public Guid guid = Guid.NewGuid();
        public List<NodeBase> inputs = new List<NodeBase>();
        public string variableName;
        public object data;

        public virtual bool GenerateCode(List<Guid> checkedNodes, ref StringBuilder globalVariables, ref StringBuilder code, ref ulong variableID, byte outputID, ref StringBuilder errorLog)
        {
            for(var i = 0; i < inputs.Count; i++)
            {
                if(inputs[i] == null || checkedNodes.Contains(inputs[i].guid))
                {
                    continue;
                }

                checkedNodes.Add(guid);

                if(!inputs[i].GenerateCode(checkedNodes, ref globalVariables, ref code, ref variableID, (byte)i, ref errorLog))
                {
                    return false;
                }
            }

            variableName = NodeUtils.GenerateVariableName(ref variableID);

            return true;
        }
        public void AddNode(NodeBase node)
        {
            inputs.Add(node);
        }
    }
}
