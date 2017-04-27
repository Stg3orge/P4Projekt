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
    public class ScopeCheckVisitor : IVisitor
    {
        private SymbolTable _symbolTable = new SymbolTable();
        private bool _preScopeCheck = true;
        public object Visit(SyntaxNode obj)
        {
            return null;
        }

        public object Visit(StartupStucture obj)
        {
            if(obj.Declarations != null)
                obj.Declarations.Accept(this);
            if(obj.Declarations2 != null)
                obj.Declarations2.Accept(this);
            if(obj.Declarations3 != null)
                obj.Declarations3.Accept(this);

            _preScopeCheck = false;

            if(obj.Declarations != null)
                obj.Declarations.Accept(this);
            if(obj.DeclaringParameters != null)
                obj.DeclaringParameters.Accept(this);
            if (obj.Commands != null)
                obj.Commands.Accept(this);
            if(obj.Declarations2 != null)
                obj.Declarations2.Accept(this);
            if(obj.DeclaringParameters2 != null)
                obj.DeclaringParameters2.Accept(this);

            if (obj.Commands2 != null)
                obj.Commands2.Accept(this);

            if(obj.Declarations3 != null)
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
            {
                obj.BooleanExpression.Accept(this);
            }
            return null;
        }

        public object Visit(CallingParameter obj) //check om calling passer til metodens declaring parameters
        {
            obj.Value.Accept(this);
            if (obj.Parameter != null)
                obj.Parameter.Accept(this);
            return null;
        }

        public object Visit(CallingParameters obj) //check om calling passer til metodens declaring parameters
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
            return null;
        }

        public object Visit(Declaration obj)
        {
            _symbolTable.AddToTable(obj.IdentifierNode, obj.TypeNode.ValueType, null);
            return null;
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
            if(obj.DeclaringParameter != null)
                obj.DeclaringParameter.Accept(this);
            _symbolTable.OpenScope();
            return null;
        }

        public object Visit(IfStatementExtend obj)
        {
            if (obj.NodeType == IfStatementExtend.NodeTypes.ElseIfStatement)
            {
                obj.BooleanExpression.Accept(this);
                if(obj.Commands != null)
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

        public object Visit(IdentifiersPrime obj) //i dunno man
        {
            return null;
        }

        public object Visit(LogicalOperator obj)
        {
            return null;
        }

        public object Visit(MethodDeclaration obj)
        {
            if (_preScopeCheck)
            {
                _symbolTable.AddToTable(obj.Value, obj.MethodType.MethodTypeValue, null);
            }
            else
            {
                obj.DeclaringParameters.Accept(this);
                if(obj.Commands != null)
                    obj.Commands.Accept(this);
                obj.ReturnStatement.Accept(this);
            }
            return null;
        }

        public object Visit(MethodType obj)
        {
            return null;
        }

        public object Visit(Operator obj)
        {
            return null;
        }

        public object Visit(Prefix obj)
        {
            return null;
        }

        public object Visit(ReturnStatement obj)
        {
            _symbolTable.CloseScope();
            return null;
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
            return null;
        }

        public object Visit(Value obj)
        {
            if (obj.NodeType == Value.NodeTypes.IdentifierIdentifiersPrime)
            {
                if (_symbolTable.ContainsName(obj.Token1))
                {
                    if (obj.IdentifiersPrime != null)
                    {
                        if (_symbolTable.GetSymbol(obj.Token1).ClassSymbolTable.Find(x => x.Name == obj.IdentifiersPrime.Identifier) != null)
                        {
                            //SUCCESS
                        }
                        else
                        {
                            throw new Exception();
                        }

                    }
                    else
                    {
                        //SUCCESS
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            return null;
        }

        public object Visit(PrefabMethods obj)
        {
            throw new NotImplementedException();
        }
    }
}
