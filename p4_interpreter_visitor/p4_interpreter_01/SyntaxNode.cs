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
            Nodes.Add(this);
        }

        public ParserContext Context
        {
            get { return _context; }
        }

        public virtual void Execute()
        {

        }


        // TODO:
        public static List<SyntaxNode> Nodes = new List<SyntaxNode>();

        public void Accept(IVisitor visitor)
        {
            foreach (SyntaxNode node in Nodes)
            {
                node.Accept(visitor);
            }
        }


    }
}
