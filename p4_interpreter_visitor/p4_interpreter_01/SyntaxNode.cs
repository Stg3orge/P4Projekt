using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public virtual void Execute()
        {

        }


        // TODO:
        private List<SyntaxNode> _nodes;

        public void Accept(IVisitor visitor)
        {
            foreach (SyntaxNode node in this._nodes)
            {
                node.Accept(visitor);
            }
        }


    }
}
