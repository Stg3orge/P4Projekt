using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p4_interpreter_01.Nodes;

namespace p4_interpreter_01
{
    public class SyntaxNode : IVisitable
    {
        private ParserContext _context;

        public SyntaxNode(ParserContext context)
        {
            _context = context;
        }

        public ParserContext Context
        {
            get { return _context; }
        }


        // TODO:
        public static List<IVisitable> Nodes = new List<IVisitable>();

        public virtual void Accept(IVisitor visitor)
        {
            //visitor.Visit(this);
        }
    }
}
