namespace p4_interpreter_01
{
    public class MethodTypePrefab : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode PrefabClasses { get; private set; }

        public MethodTypePrefab(ParserContext parserContext, SyntaxNode prefabClasses) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.PrefabClasses = prefabClasses;
            Nodes.Add(this);
        }

        public override void Accept(NodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (PrefabClasses != null)
            {
                returnstring = returnstring + " " + PrefabClasses.ToString() + " ";
            }
            return returnstring;
        }
    }
}