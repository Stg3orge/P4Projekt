using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class Statement : SyntaxNode
    {
        public Text Text { get; private set; }
        public Value Value1 { get; private set; }
        public Expression Expression { get; private set; }
        public CallingParameters CallingParameters { get; private set; }
        public PrefabMethods PrefabMethods { get; private set; }
        public Value Value2 { get; private set; }
        public BooleanExpression BooleanExpression { get; private set; }
        public Commands Commands { get; private set; }
        public IfStatementExtend IfStatementExtend { get; private set; }

        public NodeTypes NodeType { get; private set; }

        public enum NodeTypes
        {
            Write, Assign, Method, PrefabMethod, AssignMethod, AssignPrefabMethod, If, While
        }

        //<Statement> ::= write '(' <Text> ')' ';'
        public Statement(ParserContext context, Text text) : base(context)
        {
            this.Text = text;
            NodeType = NodeTypes.Write;
        }

        //<Statement> ::= <Identifiers> '=' <Value> <Expression> ';'
        public Statement(ParserContext context, Value value1, Value value2, Expression expression) : base(context)
        {
            this.Value1 = value1;
            this.Value2 = value2;
            this.Expression = expression;
            NodeType = NodeTypes.Assign;
        }

        //<Statement> ::= Call <Identifiers> '(' <CallingParameters> ')' ';'
        public Statement(ParserContext context, Value value, CallingParameters callingParameters) : base(context)
        {
            this.Value1 = value;
            this.CallingParameters = callingParameters;
            NodeType = NodeTypes.Method;
        }

        //<Statement> ::= Call <PrefabMethods> '(' <CallingParameters> ')' ';'
        public Statement(ParserContext context, PrefabMethods prefabMethods, CallingParameters callingParameters) : base(context)
        {
            this.PrefabMethods = prefabMethods;
            this.CallingParameters = callingParameters;
            NodeType = NodeTypes.PrefabMethod;
        }

        //<Statement> ::= <Identifiers> '=' Call <Identifiers> '(' <CallingParameters> ')' ';'
        public Statement(ParserContext context, Value value1, Value value2, CallingParameters callingParameters) : base(context)
        {
            this.Value1 = value1;
            this.Value2 = value2;
            this.CallingParameters = callingParameters;
            NodeType = NodeTypes.AssignMethod;
        }

        //<Statement> ::= <Identifiers> '=' Call <PrefabMethods> '(' <CallingParameters> ')' ';'
        public Statement(ParserContext context, Value value, PrefabMethods prefabMethods, CallingParameters callingParameters) : base(context)
        {
            this.Value1 = value;
            this.PrefabMethods = prefabMethods;
            this.CallingParameters = callingParameters;
            NodeType = NodeTypes.AssignPrefabMethod;
        }

        //<ControlStatements> ::= if '(' <BooleanExpression> ')' <Commands> <ElseIfStatementExtend> end if
        public Statement(ParserContext context, BooleanExpression booleanExpression, Commands commands, IfStatementExtend ifStatementExtend) : base(context)
        {
            this.BooleanExpression = booleanExpression;
            this.Commands = commands;
            this.IfStatementExtend = ifStatementExtend;
            NodeType = NodeTypes.If;
        }

        //<ControlStatements> ::= while '(' <BooleanExpression> ')' <Commands> end while
        public Statement(ParserContext context, BooleanExpression booleanExpression, Commands commands) : base(context)
        {
            this.BooleanExpression = booleanExpression;
            this.Commands = commands;
            NodeType = NodeTypes.While;
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }

    }
}