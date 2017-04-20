using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01
{
    public interface INode
    {
        // TODO: Add accepts
        void Accept(NodeVisitor visitor);


    }
}
