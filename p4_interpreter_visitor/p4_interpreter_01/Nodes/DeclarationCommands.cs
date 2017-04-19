namespace p4_interpreter_01
{
    public class DeclarationCommands : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode Declaration { get; private set; }
        public SyntaxNode Commands { get; private set; }

        public DeclarationCommands(ParserContext parserContext, SyntaxNode declaration, SyntaxNode commands)
            : base(parserContext)
        {
            this.parserContext = parserContext;
            this.Declaration = declaration;
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
            if (Declaration != null)
            {
                returnstring = returnstring + " " + Declaration.ToString() + " ";
            }
            if (Commands != null)
            {
                returnstring = returnstring + " " + Commands.ToString() + " ";
            }
            return returnstring;
        }
    }
}