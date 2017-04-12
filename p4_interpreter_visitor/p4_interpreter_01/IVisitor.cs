using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p4_interpreter_01.Nodes;

namespace p4_interpreter_01
{
    public interface IVisitor
    {
        // TODO: Add visits         // Void TO UnityEngine.Objects?
        void Visit(PrefabCreator prefab);
    }
}
