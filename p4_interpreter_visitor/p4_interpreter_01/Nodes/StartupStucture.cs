namespace p4_interpreter_01.Nodes
{
    public class StartupStucture : SyntaxNode
    {
        private ParserContext parserContext;
        public Declarations Declarations { get; private set; }
        public DeclaringParameters DeclaringParameters { get; private set; }
        public Commands Commands { get; private set; }
        public Declarations Declarations2 { get; private set; }
        public DeclaringParameters DeclaringParameters2 { get; private set; }
        public Commands Commands2 { get; private set; }
        public Declarations Declarations3 { get; private set; }

        public StartupStucture(ParserContext parserContext, Declarations declarations, DeclaringParameters declaringParameters,
            Commands commands, Declarations declarations2, DeclaringParameters declaringParameters2, Commands commands2,
            Declarations declarations3) : base(parserContext)
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
            visitor.Visit(this);
        }
    }
}