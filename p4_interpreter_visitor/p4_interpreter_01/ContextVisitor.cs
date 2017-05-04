using System;
using System.CodeDom;
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
        private readonly SymbolTable _symbolTable = new SymbolTable();
        private readonly List<SymbolTable.Variable> _parameters = new List<SymbolTable.Variable>();
        private bool _parameterAdd;
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

            obj.DeclaringParameters.Accept(this);
            _symbolTable.Methods.Add(new SymbolTable.Method("Startup", "Void", _parameters));
            _parameters.Clear();

            if (obj.Commands != null)
                obj.Commands.Accept(this);

            _symbolTable.CloseScope();

            if (obj.Declarations2 != null)
                obj.Declarations2.Accept(this);

            obj.DeclaringParameters2.Accept(this);
            _symbolTable.Methods.Add(new SymbolTable.Method("GameLoop", "Void", _parameters));
            _parameters.Clear();

            if (obj.Commands2 != null)
                obj.Commands2.Accept(this);

            _symbolTable.CloseScope();

            if (obj.Declarations3 != null)
                obj.Declarations3.Accept(this);
            return null;
        }

        public object Visit(BooleanExpression obj)
        {
            if (obj.Value1.Accept(this).ToString() == obj.Value2.Accept(this).ToString())
            {
                if (obj.Expression1 != null)
                {
                    if (obj.Value1.Accept(this).ToString() != obj.Expression1.Accept(this).ToString())
                        throw new Exception();
                }
                if (obj.Expression2 != null)
                {
                    if (obj.Value1.Accept(this).ToString() != obj.Expression2.Accept(this).ToString())
                        throw new Exception();
                }
            }
            else
                throw new Exception();
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
            _parameters.Add(new SymbolTable.Variable(null, obj.Value.Accept(this).ToString()));
            if (obj.Parameter != null)
                obj.Parameter.Accept(this);
            return null;
        }

        public object Visit(CallingParameters obj)
        {
            _parameters.Add(new SymbolTable.Variable(null, obj.Value.Accept(this).ToString()));
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
            if (_parameterAdd)
                _parameters.Add(new SymbolTable.Variable(obj.IdentifierNode, obj.TypeNode.Accept(this).ToString()));
            else
                _symbolTable.AddToTable(obj.IdentifierNode, obj.TypeNode.Accept(this).ToString());
            return null;
        }

        public object Visit(Declarations obj)
        {
            if (_preVisit && obj.NodeType == Declarations.NodeTypes.DeclarationDeclarations)
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
            else
                _parameterAdd = false;
            return null;
        }

        public object Visit(DeclaringParameters obj)
        {
            if (_preVisit)
            {
                if (obj.Declaration == null)
                    return null;
                _parameterAdd = true;
                obj.Declaration.Accept(this);
                if (obj.DeclaringParameter != null)
                    obj.DeclaringParameter.Accept(this);
                else
                    _parameterAdd = false;
            }
            else
            {
                _symbolTable.OpenScope();
                if (obj.Declaration != null)
                    obj.Declaration.Accept(this);
                if (obj.DeclaringParameter != null)
                    obj.DeclaringParameter.Accept(this);
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
                if (obj.Value.Accept(this).ToString() != obj.Expression1.Accept(this).ToString())
                    throw new Exception();
            }
            return obj.Value.Accept(this);
        }

        public object Visit(IdentifiersPrime obj)
        {
            if (obj.Prime == null)
                return obj.Identifier;
            return obj.Prime.Accept(this);
        }

        public object Visit(LogicalOperator obj)
        {
            return null;
        }

        public object Visit(MethodDeclaration obj)
        {
            string methodType = obj.MethodType.Accept(this).ToString();
            if (_preVisit)
            {
                if (_symbolTable.Methods.Find(x => x.Name == obj.Value) == null)
                {
                    obj.DeclaringParameters.Accept(this);
                    _symbolTable.Methods.Add(new SymbolTable.Method(obj.Value, methodType, _parameters));
                    _parameters.Clear();
                }
                else
                {
                    throw new Exception();
                }
            }
            else
            {
                obj.DeclaringParameters.Accept(this);
                if (obj.Commands != null)
                    obj.Commands.Accept(this);
                if (methodType != obj.ReturnStatement.Accept(this).ToString())
                    throw new Exception();
            }
            _symbolTable.CloseScope();
            return null;
        }

        public object Visit(MethodType obj)
        {
            return obj.MethodTypeValue;
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
            if (obj.Value != null)
            {
                if (obj.Expression != null)
                {
                    if (obj.Value.Accept(this).ToString() != obj.Expression.Accept(this).ToString())
                        throw new Exception();
                }
                return obj.Value.Accept(this).ToString();
            }
            return "Void";
        }

        public object Visit(Statement obj)
        {
            if (obj.NodeType == Statement.NodeTypes.Write)
                obj.Text.Accept(this);
            else if (obj.NodeType == Statement.NodeTypes.Assign)
            {
                if (obj.Value1.Accept(this).ToString() != obj.Value2.Accept(this).ToString())
                    throw new Exception();
                if (obj.Expression != null)
                {
                    if (obj.Value1.Accept(this).ToString() != obj.Expression.Accept(this).ToString())
                        throw new Exception();
                }
            }
            else if (obj.NodeType == Statement.NodeTypes.Method)
            {
                if (_symbolTable.Methods.Find(x => x.Name == obj.Value1.Token1) != null)                                    //BRUGER CHILDS FIELD
                {
                    if (obj.CallingParameters != null)
                        obj.CallingParameters.Accept(this);
                    int i = 0;
                    foreach (SymbolTable.Variable parameter in _symbolTable.Methods.Find(x => x.Name == obj.Value1.Token1).Parameters)
                    {
                        if (_parameters.ElementAt(i).Type != parameter.Type)
                                throw new Exception();
                        i++;
                    }
                    _parameters.Clear();
                }
                else
                    throw new Exception();
            }
            else if (obj.NodeType == Statement.NodeTypes.PrefabMethod)
            {
                _parameters.Clear();
                if (obj.CallingParameters != null)
                    obj.CallingParameters.Accept(this);
                int i = 0;
                foreach (SymbolTable.Variable parameter in _symbolTable.PrefabParameters[obj.PrefabMethods.Accept(this).ToString()])
                {
                    if (_parameters.ElementAt(i).Type != parameter.Type)
                    {
                        if (parameter.Type != "Prefab" || !_symbolTable.PrefabIdentifiers.ContainsKey(_parameters.ElementAt(i).Type))
                            throw new Exception();
                    }
                    i++;
                }
                _parameters.Clear();
            }
            else if (obj.NodeType == Statement.NodeTypes.AssignMethod)
            {
                SymbolTable.Method method;
                if ((method = _symbolTable.Methods.Find(x => x.Name == obj.Value2.Token1)) != null)
                {
                    if (obj.Value1.Accept(this).ToString() == method.Type)
                    {
                        if (obj.CallingParameters != null)
                            obj.CallingParameters.Accept(this);
                        int i = 0;
                        foreach (SymbolTable.Variable parameter in method.Parameters)
                        {
                            if (_parameters.ElementAt(i).Type != parameter.Type)
                                throw new Exception();
                            i++;
                        }
                        _parameters.Clear();
                    }
                    else
                        throw new Exception();
                }
                else
                    throw new Exception();
            }
            else if (obj.NodeType == Statement.NodeTypes.AssignPrefabMethod)
            {
                if (_symbolTable.Methods.Find(x => x.Name == obj.PrefabMethods.Accept(this).ToString()).Type != obj.Value1.Accept(this).ToString())
                    throw new Exception();
                if (obj.CallingParameters != null)
                    obj.CallingParameters.Accept(this);
                int i = 0;
                foreach (SymbolTable.Variable parameter in _symbolTable.PrefabParameters[obj.PrefabMethods.Accept(this).ToString()])
                {
                    if (_parameters.ElementAt(i).Type != parameter.Type)
                    {
                        if (parameter.Type != "Prefab" || !_symbolTable.PrefabIdentifiers.ContainsKey(_parameters.ElementAt(i).Type))
                            throw new Exception();
                    }
                    i++;
                }
                _parameters.Clear();
            }
            else if (obj.NodeType == Statement.NodeTypes.If)
            {
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
            return obj.ValueType;
        }

        public object Visit(Value obj)
        {
            if (obj.NodeType == Value.NodeTypes.IdentifierIdentifiersPrime)
            {
                string type;
                if ((type = _symbolTable.Variables.Find(x => x.Name == obj.Token1).Type) != null)
                {
                    if (obj.IdentifiersPrime != null)
                    {
                        if ((type = _symbolTable.GetSymbol(obj.Token1, obj.IdentifiersPrime.Accept(this).ToString()).Type) != null)
                            return type;
                        throw new Exception();
                    }
                    return type;
                }
                throw new Exception();
            }
            return obj.Type;
        }

        public object Visit(PrefabMethods obj)
        {
            return obj.PrefabMethodType;
        }
    }
}
