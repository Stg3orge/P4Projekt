using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class Statement : SyntaxNode
    {
        private Text text;
        private Identifiers identifiers;
        private Identifiers identifiers2;
        private Value value;
        private Expression expression;
        private CallingParameters callingParameters;
        private ControlStatements controlStatements;
        private PrefabMethods prefabMethods;


        public string NodeType { get; private set; }

        //<Statement> ::= write '(' <Text> ')' ';'
        public Statement(ParserContext context, Text text) : base(context)
        {
            this.text = text;
            NodeType = " ";   // TODO:
        }

        //<Statement> ::= <Identifiers> '=' <Value> <Expression> ';'
        public Statement(ParserContext context, Identifiers identifiers, Value value, Expression expression) : base(context)
        {
            this.identifiers = identifiers;
            this.value = value;
            this.expression = expression;
            NodeType = " ";   // TODO:
        }

        //<Statement> ::= <ControlStatements>
        public Statement(ParserContext context, ControlStatements controlStatements) : base(context)
        {
            this.controlStatements = controlStatements;
            NodeType = " ";   // TODO:
        }

        //<Statement> ::= Call <Identifiers> '(' <CallingParameters> ')' ';'
        public Statement(ParserContext context, Identifiers identifiers, CallingParameters callingParameters) : base(context)
        {
            this.identifiers = identifiers;
            this.callingParameters = callingParameters;
            NodeType = " ";   // TODO:
        }

        //<Statement> ::= Call <PrefabMethods> '(' <CallingParameters> ')' ';'
        public Statement(ParserContext context, PrefabMethods prefabMethods, CallingParameters callingParameters) : base(context)
        {
            this.prefabMethods = prefabMethods;
            this.callingParameters = callingParameters;
            NodeType = " ";   // TODO:
        }

        //<Statement> ::= <Identifiers> '=' Call <Identifiers> '(' <CallingParameters> ')' ';'
        public Statement(ParserContext context, Identifiers identifiers, Identifiers identifiers2, CallingParameters callingParameters) : base(context)
        {
            this.identifiers = identifiers;
            this.identifiers2 = identifiers2;
            this.callingParameters = callingParameters;
            NodeType = " ";   // TODO:
        }

        //<Statement> ::= <Identifiers> '=' Call <PrefabMethods> '(' <CallingParameters> ')' ';'
        public Statement(ParserContext context, Identifiers identifiers, PrefabMethods prefabMethods, CallingParameters callingParameters) : base(context)
        {
            this.identifiers = identifiers;
            this.prefabMethods = prefabMethods;
            this.callingParameters = callingParameters;
            NodeType = " ";   // TODO:
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

    }
}