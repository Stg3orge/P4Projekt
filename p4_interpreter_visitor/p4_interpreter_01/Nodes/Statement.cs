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
        private Value value;
        private Expression expression;
        private CallingParameters callingParameters;
        private PrefabMethods prefabMethods;
        private Value value1;
        private BooleanExpression booleanExpression;
        private Commands commands;
        private ElseIfStatementExtend elseIfStatementExtend;

        public string NodeType { get; private set; }

        //<Statement> ::= write '(' <Text> ')' ';'
        public Statement(ParserContext context, Text text) : base(context)
        {
            this.text = text;
            NodeType = " ";   // TODO:
        }

        //<Statement> ::= <Identifiers> '=' <Value> <Expression> ';'
        public Statement(ParserContext context, Value value, Value value1, Expression expression) : base(context)
        {
            this.value1 = value1;
            this.value = value;
            this.expression = expression;
            NodeType = " ";   // TODO:
        }

        //<Statement> ::= Call <Identifiers> '(' <CallingParameters> ')' ';'
        public Statement(ParserContext context, Value value, CallingParameters callingParameters) : base(context)
        {
            this.value = value;
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
        public Statement(ParserContext context, Value value, Value value1, CallingParameters callingParameters) : base(context)
        {
            this.value = value;
            this.value1 = value1;
            this.callingParameters = callingParameters;
            NodeType = " ";   // TODO:
        }

        //<Statement> ::= <Identifiers> '=' Call <PrefabMethods> '(' <CallingParameters> ')' ';'
        public Statement(ParserContext context, Value value, PrefabMethods prefabMethods, CallingParameters callingParameters) : base(context)
        {
            this.value = value;
            this.prefabMethods = prefabMethods;
            this.callingParameters = callingParameters;
            NodeType = " ";   // TODO:
        }
        //<ControlStatements> ::= if '(' <BooleanExpression> ')' <Commands> <ElseIfStatementExtend> end if
        public Statement(ParserContext context, BooleanExpression booleanExpression, Commands commands, ElseIfStatementExtend elseIfStatementExtend) : base(context)
        {
            this.booleanExpression = booleanExpression;
            this.commands = commands;
            this.elseIfStatementExtend = elseIfStatementExtend;
        }
        //<ControlStatements> ::= while '(' <BooleanExpression> ')' <Commands> end while
        public Statement(ParserContext context, BooleanExpression booleanExpression, Commands commands) : base(context)
        {
            this.booleanExpression = booleanExpression;
            this.commands = commands;
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }

    }
}