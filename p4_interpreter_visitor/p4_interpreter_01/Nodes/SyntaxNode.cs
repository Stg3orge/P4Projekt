using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
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

        public virtual object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
