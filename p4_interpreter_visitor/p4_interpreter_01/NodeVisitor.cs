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
            _symbolTable.OpenScope();

            obj.DeclaringParameters.Accept(this);
            obj.Commands.Accept(this);
            _symbolTable.CloseScope();

            obj.Declarations2.Accept(this);
            _symbolTable.OpenScope();

            obj.DeclaringParameters2.Accept(this);
            obj.Commands2.Accept(this);

            _symbolTable.CloseScope();
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
            return obj.ToString();
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
            obj.DeclarationsNode.Accept(this);
            
            return null;
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
            //<MethodDeclaration> ::= method <Methodtype> Identifier '(' <DeclaringParameters> ')' <Commands> <returnstatement> end method


            _symbolTable.AddToTable(obj.Value, obj.MethodType.MethodTypeValue, null);



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
