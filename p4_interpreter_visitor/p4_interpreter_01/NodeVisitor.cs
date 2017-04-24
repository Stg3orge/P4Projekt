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
        private SymbolTable _symbolTable = new SymbolTable();

        public Nodevisitor() { }
        public object Visit(SyntaxNode obj)
        {
            return null;  //TODO:
        }


        public object Visit(StartupStucture obj)
        {
            obj.Declarations.Accept(this);

            obj.DeclaringParameters.Accept(this);
            obj.Commands.Accept(this);

            obj.Declarations2.Accept(this);

            obj.DeclaringParameters2.Accept(this);
            obj.Commands2.Accept(this);

            obj.Declarations3.Accept(this);

            return null;
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
            if (obj.Declaration != null)
                obj.Declaration.Accept(this);
            else if (obj.Statement != null)
                obj.Statement.Accept(this);
            if (obj.Commands1 != null)
                obj.Commands1.Accept(this);

            _symbolTable.CloseScope();
            return null;
        }

        public object Visit(ComparisonOperator obj)
        {
            return obj.ToString();
        }

        public object Visit(Declaration obj)
        {
            _symbolTable.AddToTable(obj.IdentifierNode, obj.TypeNode.ValueType, null);
            return null;
        }

        public object Visit(Declarations obj)
        {
            if (obj.NodeType == "<Declarations> ::= <Declaration> ';' <Declarations>")
            {
                obj.DeclarationNode.Accept(this);
            }
            else if (obj.NodeType == "<Declarations> ::= <MethodDeclaration> <Declarations>")
            {
                obj.MethodDeclarationNode.Accept(this);
            }
            if(obj.DeclarationsNode != null)
                obj.DeclarationsNode.Accept(this);
            
            return null;
        }

        public object Visit(DeclaringParameter obj)
        {
            //<DeclaringParameter> ::= ',' <Declaration> <DeclaringParameter>
            obj.Declaration.Accept(this);
            if (obj.Parameter != null)
                obj.Parameter.Accept(this);
            return null;
        }

        public object Visit(DeclaringParameters obj)
        {
            //<DeclaringParameters> ::= <Declaration> <DeclaringParameter>
            _symbolTable.OpenScope();
            obj.Declaration.Accept(this);
            if (obj.DeclaringParameter != null)
                obj.DeclaringParameter.Accept(this);
            return null;
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
            //<MethodDeclaration> ::= method <Methodtype> Identifier '(' <DeclaringParameters> ')' <Commands> <returnstatement> end method
            _symbolTable.AddToTable(obj.Value, obj.MethodType.MethodTypeValue, null);
            obj.DeclaringParameters.Accept(this);
            obj.Commands.Accept(this);
            obj.ReturnStatement.Accept(this);
            _symbolTable.CloseScope();
            return null;
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
            if (obj.NodeType == Statement.NodeTypes.Write)
                obj.Text.Accept(this);
            return null;   
        }

        public object Visit(Text obj)
        {
            if (obj.NodeType == "<Text> ::= <Identifiers> <TextPrime>")
                obj.Value.Accept(this);
            else if(obj.NodeType == "<Text> ::= StringValue <TextPrime>")
                //codegen?
            obj.TextPrime.Accept(this);
            return null;
        }

        public object Visit(TextPrime obj)
        {
            return obj.ToString();
        }

        public object Visit(Type obj)
        {
            //<Type> ::= Integer
            //<Type> ::= Decimal
            //<Type> ::= String
            //<Type> ::= Boolean
            //<Type> ::= Point
            //<PrefabClasses> ::= Character
            //<PrefabClasses> ::= Enemy
            //<PrefabClasses> ::= Camera
            //<PrefabClasses> ::= Square
            //<PrefabClasses> ::= Triangle
            //<PrefabClasses> ::= Sprite
            //<PrefabClasses> ::= Text
            //<PrefabClasses> ::= Trigger
            return obj.ValueType;
        }

        public object Visit(Value obj)
        {
            if (obj.NodeType == "//<Identifiers> ::= Identifier <IdentifiersPrime>")
            {
                if (_symbolTable.ContainsName(obj.Token1))
                    return _symbolTable.GetSymbol(obj.Token1);
                else
                {
                    //scopecheck error, navnet kunne ikke findes
                }
            }
            return null;
        }
    }
}
