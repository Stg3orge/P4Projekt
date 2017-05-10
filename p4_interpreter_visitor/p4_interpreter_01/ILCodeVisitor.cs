using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p4_interpreter_01.Nodes;
using Type = p4_interpreter_01.Nodes.Type;

namespace p4_interpreter_01
{
    class ILCodeVisitor : IVisitor
    {
        public object Visit(SyntaxNode node)
        {
            throw new NotImplementedException();
        }

        public object Visit(StartupStucture obj)
        {
            obj.Commands?.Accept(this);
            return null;
        }

        public object Visit(BooleanExpression obj)
        {
            throw new NotImplementedException();
        }

        public object Visit(BooleanExpressionExtension obj)
        {
            throw new NotImplementedException();
        }

        public object Visit(CallingParameter obj)
        {
            throw new NotImplementedException();
        }

        public object Visit(CallingParameters obj)
        {
            throw new NotImplementedException();
        }

        public object Visit(Commands obj)
        {
            if (obj.NodeType == Commands.NodeTypes.DeclarationCommands)
                obj.Declaration.Accept(this);
            else if (obj.NodeType == Commands.NodeTypes.StatementCommands)
                obj.Statement.Accept(this);
            obj.Commands1?.Accept(this);
            return null;
        }

        public object Visit(ComparisonOperator obj)
        {
            throw new NotImplementedException();
        }

        public object Visit(Declaration obj)
        {
            throw new NotImplementedException();
        }

        public object Visit(Declarations obj)
        {
            throw new NotImplementedException();
        }

        public object Visit(DeclaringParameter obj)
        {
            throw new NotImplementedException();
        }

        public object Visit(DeclaringParameters obj)
        {
            throw new NotImplementedException();
        }

        public object Visit(IfStatementExtend obj)
        {
            throw new NotImplementedException();
        }

        public object Visit(Expression obj)
        {
            throw new NotImplementedException();
        }

        public object Visit(IdentifiersPrime obj)
        {
            throw new NotImplementedException();
        }

        public object Visit(LogicalOperator obj)
        {
            throw new NotImplementedException();
        }

        public object Visit(MethodDeclaration obj)
        {
            throw new NotImplementedException();
        }

        public object Visit(MethodType obj)
        {
            throw new NotImplementedException();
        }

        public object Visit(Operator obj)
        {
            throw new NotImplementedException();
        }

        public object Visit(Prefix obj)
        {
            throw new NotImplementedException();
        }

        public object Visit(ReturnStatement obj)
        {
            throw new NotImplementedException();
        }

        public object Visit(Statement obj)
        {
            throw new NotImplementedException();
        }

        public object Visit(Text obj)
        {
            throw new NotImplementedException();
        }

        public object Visit(TextPrime obj)
        {
            throw new NotImplementedException();
        }

        public object Visit(Type obj)
        {
            throw new NotImplementedException();
        }

        public object Visit(Value obj)
        {
            throw new NotImplementedException();
        }

        public object Visit(PrefabMethods obj)
        {
            throw new NotImplementedException();
        }
    }
}
