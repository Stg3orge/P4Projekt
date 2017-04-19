namespace p4_interpreter_01
{
    public class StartupStucture : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode Declarations { get; private set; }
        public SyntaxNode DeclaringParameters { get; private set; }
        public SyntaxNode Commands { get; private set; }
        public SyntaxNode Declarations2 { get; private set; }
        public SyntaxNode DeclaringParameters2 { get; private set; }
        public SyntaxNode Commands2 { get; private set; }
        public SyntaxNode Declarations3 { get; private set; }

        public StartupStucture(ParserContext parserContext, SyntaxNode declarations, SyntaxNode declaringParameters,
            SyntaxNode commands, SyntaxNode declarations2, SyntaxNode declaringParameters2, SyntaxNode commands2,
            SyntaxNode declarations3) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.Declarations = declarations;
            this.DeclaringParameters = declaringParameters;
            this.Commands = commands;
            this.Declarations2 = declarations2;
            this.DeclaringParameters2 = declaringParameters2;
            this.Commands2 = commands2;
            this.Declarations3 = declarations3;
        }

        public override void Accept(IVisitor visitor)
        {
            foreach (IVisitable node in Nodes)
            {
                node.Accept(visitor);
            }
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (Declarations != null)
            {
                returnstring = returnstring + " " + Declarations.ToString() + " ";
            }
            if (DeclaringParameters != null)
            {
                returnstring = returnstring + " " + DeclaringParameters.ToString() + " ";
            }
            if (Commands != null)
            {
                returnstring = returnstring + " " + Commands.ToString() + " ";
            }
            if (Declarations2 != null)
            {
                returnstring = returnstring + " " + Declarations2.ToString() + " ";
            }
            if (DeclaringParameters2 != null)
            {
                returnstring = returnstring + " " + DeclaringParameters2.ToString() + " ";
            }
            if (Commands2 != null)
            {
                returnstring = returnstring + " " + Commands2.ToString() + " ";
            }
            if (Declarations3 != null)
            {
                returnstring = returnstring + " " + Declarations3.ToString() + " ";
            }
            return returnstring;
        }
    }
}