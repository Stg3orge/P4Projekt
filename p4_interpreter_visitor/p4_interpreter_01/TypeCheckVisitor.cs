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
        private bool _preTypeCheck = true;
        public object Visit(SyntaxNode obj)
        {
            return null;
        }

        public object Visit(StartupStucture obj)
        {
            if (obj.Declarations != null)
                obj.Declarations.Accept(this);
            if (obj.Declarations2 != null)
                obj.Declarations2.Accept(this);
            if (obj.Declarations3 != null)
                obj.Declarations3.Accept(this);

            _preTypeCheck = false;

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
            if (obj.Value1.Type == obj.Value2.Type)
            {
                if (obj.Expression1 != null)
                {
                    if (obj.Value1.Type == obj.Expression1.Value.Type)
                        obj.Expression1.Accept(this);
                    else
                        throw new Exception();
                }
                if (obj.Expression2 != null)
                {
                    if (obj.Value1.Type == obj.Expression2.Value.Type)
                        obj.Expression2.Accept(this);
                    else
                        throw new Exception();
                }
            }
            else
            {
                throw new Exception();
            }
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
            if (obj.DeclaringParameter != null)
                obj.DeclaringParameter.Accept(this);
            _symbolTable.OpenScope();
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
            if (obj.Expression1 != null)
            {
                if (obj.Expression1.Value.Type == obj.Value.Type)
                    obj.Expression1.Accept(this);
                else
                    throw new Exception();
            }
            return null;
        }

        public object Visit(IdentifiersPrime obj)
        {
            return null;
        }

        public object Visit(LogicalOperator obj)
        {
            return null;
        }

        public object Visit(MethodDeclaration obj)
        {
            if (_preTypeCheck)
            {
                _symbolTable.AddMethod(obj.Value, obj.MethodType, obj.DeclaringParameters);
            }
            else
            {
                if (obj.Commands != null)
                    obj.Commands.Accept(this);
                if (obj.MethodType.MethodTypeValue == obj.ReturnStatement.Value.Type || obj.MethodType.MethodTypeValue == _symbolTable.GetSymbol(obj.ReturnStatement.Value.Token1).Type)
                {
                    obj.ReturnStatement.Accept(this);
                }
                else
                {
                    throw new Exception();
                }
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
            if (obj.Expression != null)
            {
                if (obj.Value.Type == obj.Expression.Value.Type)
                    obj.Expression.Accept(this);
                else
                    throw new Exception();
            }
            return null;
        }

        public object Visit(Statement obj)
        {
            if (obj.NodeType == Statement.NodeTypes.Assign)
            {
                if (obj.Value1.Type == obj.Value2.Type)
                {
                    if (obj.Expression != null)
                    {
                        if (obj.Expression.Value.Type == obj.Value1.Type)
                            obj.Expression.Accept(this);
                        else
                            throw new Exception();
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            else if (obj.NodeType == Statement.NodeTypes.Method)
            {
                obj.Value1.Accept(this);
                if (obj.CallingParameters != null)
                    obj.CallingParameters.Accept(this);
            }
            else if (obj.NodeType == Statement.NodeTypes.PrefabMethod)
            {
                if (obj.CallingParameters != null)
                    obj.CallingParameters.Accept(this);
            }
            else if (obj.NodeType == Statement.NodeTypes.AssignMethod)
            {
                if (obj.Value1.Type == _symbolTable.GetSymbol(obj.Value2.Token1).Type)
                { }
                else
                    throw new Exception();
                if (obj.CallingParameters != null)
                    obj.CallingParameters.Accept(this);
            }
            else if (obj.NodeType == Statement.NodeTypes.AssignPrefabMethod)
            {
                if(obj.Value1.Type == _symbolTable.GetSymbol(obj.PrefabMethods.PrefabMethodType).Type)
                { }
                else
                {
                    throw new Exception();
                }
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
            return null;
        }

        public object Visit(TextPrime obj)
        {
            return null;
        }

        public object Visit(Type obj)
        {
            return null;
        }

        public object Visit(Value obj)
        {
            return null;
        }

        public object Visit(PrefabMethods obj)
        {
            return null;
        }
    }
}
