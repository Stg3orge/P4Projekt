using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p4_interpreter_01.Nodes;
using Type = p4_interpreter_01.Nodes.Type;

namespace p4_interpreter_01
{
    public class ContextVisitor : IVisitor
    {
        private SymbolTable _symbolTable = new SymbolTable();
        private List<SymbolTable.Variable> _parameters = new List<SymbolTable.Variable>();
        private bool parameterAdd = false;
        private bool _preVisit = true;
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

            _preVisit = false;
            
            if (obj.Declarations != null)
                obj.Declarations.Accept(this);
            if (obj.DeclaringParameters != null)
            {
                obj.DeclaringParameters.Accept(this);
            }
            
            _symbolTable.Methods.Add(new SymbolTable.Method("Startup", "void", _parameters));
            _parameters.Clear();
            if (obj.Commands != null)
                obj.Commands.Accept(this);
            if (obj.Declarations2 != null)
                obj.Declarations2.Accept(this);
            if (obj.DeclaringParameters2 != null)
            {
                obj.DeclaringParameters2.Accept(this);
            }
            _symbolTable.Methods.Add(new SymbolTable.Method("GameLoop", "void", _parameters));
            _parameters.Clear();
            if (obj.Commands2 != null)
                obj.Commands2.Accept(this);
            if (obj.Declarations3 != null)
                obj.Declarations3.Accept(this);
            return null;
        }

        public object Visit(BooleanExpression obj)
        {
            if (obj.Value1.NodeType == Value.NodeTypes.IdentifierIdentifiersPrime)
            {
                if (obj.Value1.IdentifiersPrime != null)
                {
                    obj.Value1.Type = _symbolTable.GetSymbol(obj.Value1.Token1, obj.Value1.IdentifiersPrime.Identifier).Type;
                }
                else
                {
                    obj.Value1.Type = _symbolTable.GetSymbol(obj.Value1.Token1, null).Type;
                }
            }
            if (obj.Value2.NodeType == Value.NodeTypes.IdentifierIdentifiersPrime)
                if (obj.Value2.IdentifiersPrime != null)
                {
                    obj.Value2.Type = _symbolTable.GetSymbol(obj.Value2.Token1, obj.Value2.IdentifiersPrime.Identifier).Type;
                }
                else
                {
                    obj.Value2.Type = _symbolTable.GetSymbol(obj.Value2.Token1, null).Type;
                }
            if (obj.Value1.Type == obj.Value2.Type)
            {
                if (obj.Expression1 != null)
                {
                    if (obj.Expression1.Value.NodeType == Value.NodeTypes.IdentifierIdentifiersPrime)
                        if (obj.Expression1.Value.IdentifiersPrime != null)
                        {
                            obj.Expression1.Value.Type = _symbolTable.GetSymbol(obj.Expression1.Value.Token1, obj.Expression1.Value.IdentifiersPrime.Identifier).Type;
                        }
                        else
                        {
                            obj.Expression1.Value.Type = _symbolTable.GetSymbol(obj.Expression1.Value.Token1, null).Type;
                        }
                    if (obj.Value1.Type == obj.Expression1.Value.Type)
                        obj.Expression1.Accept(this);
                    else
                        throw new Exception();
                }
                if (obj.Expression2 != null)
                {
                    if (obj.Expression2.Value.NodeType == Value.NodeTypes.IdentifierIdentifiersPrime)
                        if (obj.Expression2.Value.IdentifiersPrime != null)
                        {
                            obj.Expression2.Value.Type = _symbolTable.GetSymbol(obj.Expression2.Value.Token1, obj.Expression2.Value.IdentifiersPrime.Identifier).Type;
                        }
                        else
                        {
                            obj.Expression2.Value.Type = _symbolTable.GetSymbol(obj.Expression2.Value.Token1, null).Type;
                        }
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

        public object Visit(CallingParameter obj)
        {
            if (obj.Value.NodeType == Value.NodeTypes.IdentifierIdentifiersPrime)
            {
                if (obj.Value.IdentifiersPrime != null)
                {
                    obj.Value.Type = _symbolTable.GetSymbol(obj.Value.Token1, obj.Value.IdentifiersPrime.Identifier).Type;
                }
                else
                {
                    obj.Value.Type = _symbolTable.GetSymbol(obj.Value.Token1, null).Type;
                }
            }
            _parameters.Add(new SymbolTable.Variable(null, obj.Value.Type, null));
            if (obj.Parameter != null)
                obj.Parameter.Accept(this);
            return null;
        }

        public object Visit(CallingParameters obj)
        {
            if (obj.Value.NodeType == Value.NodeTypes.IdentifierIdentifiersPrime)
            {
                if (obj.Value.IdentifiersPrime != null)
                {
                    obj.Value.Type =
                        _symbolTable.GetSymbol(obj.Value.Token1, obj.Value.IdentifiersPrime.Identifier).Type;
                }
                else
                {
                    obj.Value.Type = _symbolTable.GetSymbol(obj.Value.Token1, null).Type;
                }
            }
            _parameters.Add(new SymbolTable.Variable(null, obj.Value.Type, null));
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
            if (parameterAdd)
            {
                _parameters.Add(new SymbolTable.Variable(obj.IdentifierNode, obj.TypeNode.ValueType, null));
            }
            else
            {
                _symbolTable.AddToTable(obj.IdentifierNode, obj.TypeNode.ValueType, null);
            }
            return null;
        }

        public object Visit(Declarations obj)
        {
            if (obj.NodeType == Declarations.NodeTypes.DeclarationDeclarations)
            {
                obj.DeclarationNode.Accept(this);
            }
            else if (obj.NodeType == Declarations.NodeTypes.MethodDeclarationDeclarations)
            {
                obj.MethodDeclarationNode.Accept(this);
            }
            if (obj.DeclarationsNode != null)
            {
                obj.DeclarationsNode.Accept(this);
            }
            return null;
        }

        public object Visit(DeclaringParameter obj)
        {
            obj.Declaration.Accept(this);
            if (obj.Parameter != null)
                obj.Parameter.Accept(this);
            else
            {
                parameterAdd = false;
            }
            return null;
        }

        public object Visit(DeclaringParameters obj)
        {
            if (!_preVisit)
            {
                _symbolTable.OpenScope();
                if (obj.Declaration != null)
                    obj.Declaration.Accept(this);
                if (obj.DeclaringParameter != null)
                    obj.DeclaringParameter.Accept(this);
            }
            else
            {
                if (obj.Declaration != null)
                {
                    parameterAdd = true;
                    obj.Declaration.Accept(this);
                }

                if (obj.DeclaringParameter != null)
                {
                    obj.DeclaringParameter.Accept(this);
                }
                else
                {
                    parameterAdd = false;
                }
            }
           
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
                if (obj.Value.NodeType == Value.NodeTypes.IdentifierIdentifiersPrime)
                {
                    if (obj.Value.IdentifiersPrime != null)
                    {
                        obj.Value.Type = _symbolTable.GetSymbol(obj.Value.Token1, obj.Value.IdentifiersPrime.Identifier).Type;
                    }
                    else
                    {
                        obj.Value.Type = _symbolTable.GetSymbol(obj.Value.Token1, null).Type;
                    }
                }
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
            if (_preVisit)
            {
                if (obj.DeclaringParameters != null)
                {
                    obj.DeclaringParameters.Accept(this);
                    _symbolTable.Methods.Add(new SymbolTable.Method(obj.Value, obj.MethodType.MethodTypeValue, _parameters));
                    _parameters.Clear();
                }
            }
            else
            {
                obj.DeclaringParameters.Accept(this);
                if (obj.Commands != null)
                    obj.Commands.Accept(this);
                if (obj.ReturnStatement.Value == null && obj.MethodType.MethodTypeValue == "Void")
                {
                }
                else if (obj.ReturnStatement.Value.Token1 != null)
                {
                    if (obj.ReturnStatement.Value.NodeType == Value.NodeTypes.IdentifierIdentifiersPrime)
                    {
                        if (obj.ReturnStatement.Value.IdentifiersPrime != null)
                        {
                            obj.ReturnStatement.Value.Type = _symbolTable.GetSymbol(obj.ReturnStatement.Value.Token1, obj.ReturnStatement.Value.IdentifiersPrime.Identifier).Type;
                        }
                        else
                        {
                            obj.ReturnStatement.Value.Type = _symbolTable.GetSymbol(obj.ReturnStatement.Value.Token1, null).Type;
                        }
                    }
                    if (_symbolTable.Methods.Find(x => x.Name == obj.Value).Type == obj.ReturnStatement.Value.Type)
                        {
                            obj.ReturnStatement.Accept(this);
                        }
                        else
                        {
                            throw new Exception();
                        }
                    
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
            _symbolTable.CloseScope();
            return null;
        }

        public object Visit(Statement obj)
        {
            if (obj.NodeType == Statement.NodeTypes.Write)
            {
                obj.Text.Accept(this);
            }
            else if (obj.NodeType == Statement.NodeTypes.Assign)
            {
                if (obj.Value2.NodeType == Value.NodeTypes.IdentifierIdentifiersPrime)
                {
                    if (obj.Value2.IdentifiersPrime != null)
                    {
                        obj.Value2.Type = _symbolTable.GetSymbol(obj.Value2.Token1, obj.Value2.IdentifiersPrime.Identifier).Type;
                    }
                    else
                    {
                        obj.Value2.Type = _symbolTable.GetSymbol(obj.Value2.Token1, null).Type;
                    }
                }
                if (obj.Value1.IdentifiersPrime != null)
                {
                    obj.Value1.Type = _symbolTable.GetSymbol(obj.Value1.Token1, obj.Value1.IdentifiersPrime.Identifier).Type;
                }
                else
                {
                    obj.Value1.Type = _symbolTable.GetSymbol(obj.Value1.Token1, null).Type;
                }
                if (obj.Value1.Type == obj.Value2.Type)
                {
                    if (obj.Expression != null)
                    {
                        if (obj.Expression.Value.NodeType == Value.NodeTypes.IdentifierIdentifiersPrime)
                        {
                            if (obj.Value1.IdentifiersPrime != null)
                            {
                                obj.Expression.Value.Type = _symbolTable.GetSymbol(obj.Expression.Value.Token1, obj.Expression.Value.IdentifiersPrime.Identifier).Type;
                            }
                            else
                            {
                                obj.Expression.Value.Type = _symbolTable.GetSymbol(obj.Expression.Value.Token1, null).Type;
                            }
                        }
                        if (obj.Value1.Type == obj.Expression.Value.Type)
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
                if (_symbolTable.Methods.Find(x => x.Name == obj.Value1.Token1) != null)
                {
                    if (obj.CallingParameters != null)
                        obj.CallingParameters.Accept(this);
                    int i = 0;
                    foreach (SymbolTable.Variable parameter in _symbolTable.Methods.Find(x => x.Name == obj.Value1.Token1).Parameters)
                    {
                        if(_parameters.ElementAt(i).Type != parameter.Type)
                            throw new Exception();
                        i++;
                    }
                    _parameters.Clear();
                }
                else
                {
                    throw new Exception();
                }
            }
            else if (obj.NodeType == Statement.NodeTypes.PrefabMethod)
            {
                if (obj.CallingParameters != null)
                    obj.CallingParameters.Accept(this);
                int i = 0;
                    foreach (SymbolTable.Variable parameter in _symbolTable.prefabIdentifiers[obj.PrefabMethods.PrefabMethodType])
                    {
                        if (_parameters.ElementAt(i).Type != parameter.Type)
                            throw new Exception();
                        i++;
                    }
                    _parameters.Clear();
            }
            else if (obj.NodeType == Statement.NodeTypes.AssignMethod)
            {
                if (obj.Value1.IdentifiersPrime != null)
                {
                    obj.Value1.Type =
                        _symbolTable.GetSymbol(obj.Value1.Token1, obj.Value1.IdentifiersPrime.Identifier).Type;
                }
                else
                {
                    obj.Value1.Type = _symbolTable.GetSymbol(obj.Value1.Token1, null).Type;
                }
                if (obj.Value1.Type == _symbolTable.Methods.Find(x => x.Name == obj.Value2.Token1).Type)
                {
                    if (_symbolTable.Methods.Find(x => x.Name == obj.Value2.Token1) != null)
                    {
                        if (obj.Value1.Type == _symbolTable.Methods.Find(x => x.Name == obj.Value2.Token1).Type)
                        {
                            if (obj.CallingParameters != null)
                            {
                                obj.CallingParameters.Accept(this);
                            }
                            int i = 0;
                            if (_symbolTable.Methods.Find(x => x.Name == obj.Value2.Token1).Parameters != null)
                            {
                                foreach (
                                    SymbolTable.Variable parameter in
                                    _symbolTable.Methods.Find(x => x.Name == obj.Value2.Token1).Parameters)
                                {
                                    if (_parameters.ElementAt(i).Type != parameter.Type)
                                        throw new Exception();
                                    i++;
                                }
                                _parameters.Clear();
                            }
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                else
                    throw new Exception();
            }
            else if (obj.NodeType == Statement.NodeTypes.AssignPrefabMethod)
            {
                if (obj.Value1.IdentifiersPrime != null)
                {
                    obj.Value1.Type =
                        _symbolTable.GetSymbol(obj.Value1.Token1, obj.Value1.IdentifiersPrime.Identifier).Type;
                }
                else
                {
                    obj.Value1.Type = _symbolTable.GetSymbol(obj.Value1.Token1, null).Type;
                }
                if (obj.Value1.Type == obj.PrefabMethods.PrefabMethodType)
                {
                    if (obj.CallingParameters != null)
                        obj.CallingParameters.Accept(this);
                    int i = 0;
                    foreach (
                        SymbolTable.Variable parameter in
                        _symbolTable.prefabIdentifiers[obj.PrefabMethods.PrefabMethodType])
                    {
                        if (_parameters.ElementAt(i).Type != parameter.Type)
                            throw new Exception();
                        i++;
                    }
                    _parameters.Clear();
                }
                else
                {
                    throw new Exception();
                }
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
                        if (_symbolTable.GetSymbol(obj.Token1, null).ClassSymbolTable.Find(x => x.Name == obj.IdentifiersPrime.Identifier) != null)
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
            return null;
        }
    }
}
