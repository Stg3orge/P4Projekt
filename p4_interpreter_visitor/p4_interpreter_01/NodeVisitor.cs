using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p4_interpreter_01.Nodes;
using System.Windows;
using Type = p4_interpreter_01.Nodes.Type;

namespace p4_interpreter_01
{
    public class Nodevisitor : IVisitor
    {
        public Nodevisitor() { }
        public object Visit(SyntaxNode obj)
        {
            return obj.ToString();
        }

        public object Visit(StartupStucture obj)
        {
            return obj.ToString();
        }

        public object Visit(BooleanExpression obj)
        {
            return obj.ToString();
        }

        public object Visit(BooleanExpressionExtension obj)
        {
            return obj.ToString();
        }

        public object Visit(CallingParameter obj)
        {
            return obj.ToString();
        }

        public object Visit(CallingParameters obj)
        {
            return obj.ToString();
        }

        public object Visit(Commands obj)
        {
            return obj.ToString();
        }

        public object Visit(ComparisonOperator obj)
        {
            return obj.ToString();
        }

        public object Visit(Declaration obj)
        {
            return obj.ToString();
        }

        public object Visit(Declarations obj)
        {
            return obj.ToString();
        }

        public object Visit(DeclaringParameter obj)
        {
            return obj.ToString();
        }

        public object Visit(DeclaringParameters obj)
        {
            return obj.ToString();
        }

        public object Visit(ElseIfStatementExtend obj)
        {
            return obj.ToString();
        }

        public object Visit(ElseStatementExtend obj)
        {
            return obj.ToString();
        }

        public object Visit(Expression obj)
        {
            return obj.ToString();
        }

        public object Visit(IdentifiersPrime obj)
        {
            return obj.ToString();
        }

        public object Visit(LogicalOperator obj)
        {
            return obj.ToString();
        }

        public object Visit(MethodDeclaration obj)
        {
            return obj.ToString();
        }

        public object Visit(MethodType obj)
        {
            return obj.ToString();
        }

        public object Visit(Operator obj)
        {
            return obj.ToString();
        }

        public object Visit(Prefix obj)
        {
            return obj.ToString();
        }

        public object Visit(ReturnStatement obj)
        {
            return obj.ToString();
        }

        public object Visit(Statement obj)
        {
            return obj.ToString();
        }

        public object Visit(Text obj)
        {
            return obj.ToString();
        }

        public object Visit(TextPrime obj)
        {
            return obj.ToString();
        }

        public object Visit(Type obj)
        {
            return obj.ToString();
        }

        public object Visit(Value obj)
        {
            return obj.ToString();
        }
    }
}
