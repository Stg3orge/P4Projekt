namespace p4_interpreter_01
{
    public class BooleanExpression : SyntaxNode, IVisitable
    {
        private ParserContext parserContext;
        private SyntaxNode syntaxNode1;
        private SyntaxNode syntaxNode2;
        private SyntaxNode syntaxNode3;
        private SyntaxNode syntaxNode4;
        private SyntaxNode syntaxNode5;
        private SyntaxNode syntaxNode6;

        public BooleanExpression(ParserContext parserContext, SyntaxNode syntaxNode1, SyntaxNode syntaxNode2,
            SyntaxNode syntaxNode3, SyntaxNode syntaxNode4, SyntaxNode syntaxNode5, SyntaxNode syntaxNode6)
            : base(parserContext)
        {
            this.parserContext = parserContext;
            this.syntaxNode1 = syntaxNode1;
            this.syntaxNode2 = syntaxNode2;
            this.syntaxNode3 = syntaxNode3;
            this.syntaxNode4 = syntaxNode4;
            this.syntaxNode5 = syntaxNode5;
            this.syntaxNode6 = syntaxNode6;

            Nodes.Add(this);
        }

        public new void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (syntaxNode1 != null)
            {
                returnstring = returnstring + " " + syntaxNode1.ToString() + " ";
            }
            if (syntaxNode2 != null)
            {
                returnstring = returnstring + " " + syntaxNode2.ToString() + " ";
            }
            if (syntaxNode3 != null)
            {
                returnstring = returnstring + " " + syntaxNode3.ToString() + " ";
            }
            if (syntaxNode4 != null)
            {
                returnstring = returnstring + " " + syntaxNode4.ToString() + " ";
            }
            if (syntaxNode5 != null)
            {
                returnstring = returnstring + " " + syntaxNode5.ToString() + " ";
            }
            if (syntaxNode6 != null)
            {
                returnstring = returnstring + " " + syntaxNode6.ToString() + " ";
            }
            return returnstring;
        }
    }
}