using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p4_interpreter_01.Nodes;
using Type = p4_interpreter_01.Nodes.Type;

namespace p4_interpreter_01
{
    public class TypeCheckVisitor : IVisitor
    {
        private SymbolTable _symbolTable = new SymbolTable();

        public object Visit(SyntaxNode node)
        {
            throw new NotImplementedException();
        }

        public object Visit(StartupStucture obj)
        {
            if (obj.Declarations != null)
                obj.Declarations.Accept(this);
            if (obj.DeclaringParameters != null)
                obj.DeclaringParameters.Accept(this);
            if (obj.Commands != null)
                obj.Commands.Accept(this);
            if (obj.Declarations2 != null)
                obj.Declarations2.Accept(this);
            if (obj.DeclaringParameters2 != null)
                obj.DeclaringParameters2.Accept(this);
            if (obj.Commands2 != null)
                obj.Commands2.Accept(this);
            if (obj.Declarations3 != null)
                obj.Declarations3.Accept(this);
            return null;
        }



        public object Visit(BooleanExpression obj)
        {
            obj.Value1.Accept(this);
            if (obj.Expression1 != null)
                obj.Expression1.Accept(this);
            obj.Value2.Accept(this);
            if (obj.Expression2 != null)
                obj.Expression2.Accept(this);
            if (obj.BooleanExpressionExtension != null)
                obj.BooleanExpressionExtension.Accept(this);
            return null;
        }

        public object Visit(BooleanExpressionExtension obj)
        {
            if (obj.BooleanExpression != null)
                obj.BooleanExpression.Accept(this);

            return null;
        }

        public object Visit(CallingParameter obj)
        {
            obj.Value.Accept(this);

            if(obj.Parameter != null)
                obj.Parameter.Accept(this);

            return null;
        }

        public object Visit(CallingParameters obj)
        {
            obj.Value.Accept(this);

            if (obj.CallingParameter != null)
                obj.CallingParameter.Accept(this);
            return null;
        }

        public object Visit(Commands obj)
        {
            if (obj.NodeType == Commands.NodeTypes.DeclarationCommands)
                obj.Declaration.Accept(this);
            else if (obj.NodeType == Commands.NodeTypes.StatementCommands)
                obj.Statement.Accept(this);
            if (obj.Commands1 != null)
                obj.Commands1.Accept(this);
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
            if (obj.NodeType == Declarations.NodeTypes.DeclarationDeclarations)
                obj.DeclarationNode.Accept(this);
            else if (obj.NodeType == Declarations.NodeTypes.MethodDeclarationDeclarations)
                obj.MethodDeclarationNode.Accept(this);
            if (obj.DeclarationsNode != null)
                obj.DeclarationsNode.Accept(this);
            return null;
        }

        public object Visit(DeclaringParameter obj)
        {
            obj.Declaration.Accept(this);
            if (obj.Parameter != null)
                obj.Parameter.Accept(this);
            return null;
        }

        public object Visit(DeclaringParameters obj)
        {
            obj.Declaration.Accept(this);
            if (obj.DeclaringParameter != null)
                obj.DeclaringParameter.Accept(this);
            return null;
        }

        public object Visit(IfStatementExtend obj)
        {
            if (obj.NodeType == IfStatementExtend.NodeTypes.ElseIfStatement)
            {
                obj.BooleanExpression.Accept(this);
                if (obj.Commands != null)
                    obj.Commands.Accept(this);
                if (obj.StatementExtend != null)
                    obj.StatementExtend.Accept(this);
            }
            else if (obj.NodeType == IfStatementExtend.NodeTypes.ElseStatement)
            {
                if (obj.Commands != null)
                    obj.Commands.Accept(this);
            }
            return null;
        }

        public object Visit(Expression obj)
        {
            obj.Value.Accept(this);
            if (obj.Expression1 != null)
                obj.Expression1.Accept(this);
            return null;
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
            obj.DeclaringParameters.Accept(this);
            if (obj.Commands != null)
                obj.Commands.Accept(this);
            obj.ReturnStatement.Accept(this);

            return null;
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
            if (obj.NodeType == Statement.NodeTypes.Write)
            {
                if (obj.Text != null)
                    obj.Text.Accept(this);
            }
            else if (obj.NodeType == Statement.NodeTypes.Assign)
            {
                obj.Value1.Accept(this);
                obj.Value2.Accept(this);
                if (obj.Expression != null)
                    obj.Expression.Accept(this);
            }
            else if (obj.NodeType == Statement.NodeTypes.Method)
            {
                obj.Value1.Accept(this);
                if (obj.CallingParameters != null)
                    obj.CallingParameters.Accept(this);
            }
            else if (obj.NodeType == Statement.NodeTypes.PrefabMethod)
                if (obj.CallingParameters != null)
                    obj.CallingParameters.Accept(this);
                else if (obj.NodeType == Statement.NodeTypes.AssignMethod)
                {
                    obj.Value1.Accept(this);
                    obj.Value2.Accept(this);
                    if (obj.CallingParameters != null)
                        obj.CallingParameters.Accept(this);
                }
                else if (obj.NodeType == Statement.NodeTypes.AssignPrefabMethod)
                {
                    obj.Value1.Accept(this);
                    if (obj.CallingParameters != null)
                        obj.CallingParameters.Accept(this);
                }
                else if (obj.NodeType == Statement.NodeTypes.If)
                {
                    if (obj.BooleanExpression != null)
                        obj.BooleanExpression.Accept(this);
                    if (obj.Commands != null)
                        obj.Commands.Accept(this);
                    if (obj.IfStatementExtend != null)
                        obj.IfStatementExtend.Accept(this);
                }
                else if (obj.NodeType == Statement.NodeTypes.While)
                {
                    if (obj.BooleanExpression != null)
                        obj.BooleanExpression.Accept(this);
                    if (obj.Commands != null)
                        obj.Commands.Accept(this);
                }
            return null;
        }

        public object Visit(Text obj)
        {
            if (obj.NodeType == Text.NodeTypes.IdentifiersTextPrime)
                obj.Value.Accept(this);
            if (obj.TextPrime != null)
                obj.TextPrime.Accept(this);
            return null;
        }

        public object Visit(TextPrime obj)
        {
            if (obj.NodeType == TextPrime.NodeTypes.IdentifiersTextPrime)
                obj.Value.Accept(this);
            if (obj.Prime != null)
                obj.Prime.Accept(this);
            return null;
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
            return obj.PrefabMethodType;
        }
    }
}
