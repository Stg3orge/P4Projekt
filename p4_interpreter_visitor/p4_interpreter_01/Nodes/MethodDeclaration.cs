namespace p4_interpreter_01
{
    public class MethodDeclaration : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode Methodtype { get; private set; }
        public string Identifier { get; private set; }
        public SyntaxNode DeclaringParameters { get; private set; }
        public SyntaxNode Commands { get; private set; }
        public SyntaxNode returnstatement { get; private set; }

        public MethodDeclaration(ParserContext parserContext, SyntaxNode methodtype, string identifier,
            SyntaxNode declaringParameters, SyntaxNode commands, SyntaxNode returnstatement) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.Methodtype = methodtype;
            this.Identifier = identifier;
            this.DeclaringParameters = declaringParameters;
            this.Commands = commands;
            this.returnstatement = returnstatement;
            Nodes.Add(this);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (Methodtype != null)
            {
                returnstring = returnstring + " " + Methodtype.ToString() + " ";
            }
            if (Identifier != null)
            {
                returnstring = returnstring + " " + Identifier.ToString() + " ";
            }
            if (DeclaringParameters != null)
            {
                returnstring = returnstring + " " + DeclaringParameters.ToString() + " ";
            }
            if (Commands != null)
            {
                returnstring = returnstring + " " + Commands.ToString() + " ";
            }
            if (returnstatement != null)
            {
                returnstring = returnstring + " " + returnstatement.ToString() + " ";
            }
            return returnstring;
        }
    }
}