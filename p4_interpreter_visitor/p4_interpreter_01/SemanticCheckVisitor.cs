﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p4_interpreter_01.Nodes;
using Type = p4_interpreter_01.Nodes.Type;

namespace p4_interpreter_01
{
    public class SemanticCheckVisitor : IVisitor
    {
        private SymbolTable _symbolTable = new SymbolTable();
        private bool _preScopeCheck = true;


        public object Visit(SyntaxNode node)
        {
            return null;
        }

        public object Visit(StartupStucture obj)
        {
            if (_preScopeCheck)
            {
                if (obj.Declarations != null)
                    obj.Declarations.Accept(this);
                if (obj.Declarations2 != null)
                    obj.Declarations2.Accept(this);
                if (obj.Declarations3 != null)
                    obj.Declarations3.Accept(this);

                _preScopeCheck = false;
            }

            return null;
        }

        public object Visit(BooleanExpression obj)
        {
            return null;
        }

        public object Visit(BooleanExpressionExtension obj)
        {
            return null;
        }

        public object Visit(CallingParameter obj)
        {
            return null;
        }

        public object Visit(CallingParameters obj)
        {
            return null;
        }

        public object Visit(Commands obj)
        {
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
            return null;
        }

        public object Visit(DeclaringParameter obj)
        {
            return null;
        }

        public object Visit(DeclaringParameters obj)
        {
            _symbolTable.OpenScope();
            return null;
        }

        public object Visit(IfStatementExtend obj)
        {
            return null;
        }

        public object Visit(Expression obj)
        {
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
            if (_preScopeCheck)
            {
                _symbolTable.AddToTable(obj.Value, obj.MethodType.MethodTypeValue, null);
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
            if (obj.NodeType == Value.NodeTypes.IdentifierIdentifiersPrime)
            {
                if (_symbolTable.ContainsName(obj.Token1))
                {
                    if (obj.IdentifiersPrime != null)
                    {
                        //if (_symbolTable.GetSymbol(obj.Token1).ClassSymbolTable.Find(x => x.Name == obj.IdentifiersPrime.Identifier) != null)
                        //{
                        //    //SUCCESS
                        //}
                        //else
                        //{
                        //    throw new Exception();
                        //}
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
