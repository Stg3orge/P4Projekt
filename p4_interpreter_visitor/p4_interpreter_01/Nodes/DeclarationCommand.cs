namespace p4_interpreter_01
{
    public class DeclarationCommand : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode Statement { get; private set; }
        public SyntaxNode Commands { get; private set; }

        public DeclarationCommand(ParserContext parserContext, SyntaxNode statement, SyntaxNode commands)
            : base(parserContext)
        {
            this.parserContext = parserContext;
            this.Statement = statement;
            this.Commands = commands;
            Nodes.Add(this);
        }

        public override void Accept(NodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (Statement != null)
            {
                returnstring = returnstring + " " + Statement.ToString() + " ";
            }
            if (Commands != null)
            {
                returnstring = returnstring + " " + Commands.ToString() + " ";
            }
            return returnstring;
        }
    }
}