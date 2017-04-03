using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_3.expressions
{
    public class SyntaxNode
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
    }
}
