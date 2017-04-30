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
            VisitList.Add(this);
        }

        public ParserContext Context
        {
            get { return _context; }
        }


        // TODO:
        public static List<SyntaxNode> VisitList = new List<SyntaxNode>();

        public virtual object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }




        private readonly List<IVisitable> _childList = new List<IVisitable>();

        public IVisitable GetChild(int index)
        {
            return _childList[index];
        }

        protected void AddChild(IVisitable obj)
        {
            _childList.Add(obj);
        }

    }
}
