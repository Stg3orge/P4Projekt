using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p4_interpreter_01.Nodes;

namespace p4_interpreter_01
{
    public interface IVisitor
    {
        // TODO: Add visits         // Void TO UnityEngine.Objects?

        object Visit(SyntaxNode node);
        object Visit(StartupStucture obj);
        object Visit(BooleanExpression obj);
        object Visit(BooleanExpressionExtension obj);
        object Visit(CallingParameter obj);
        object Visit(CallingParameters obj);
        object Visit(Commands obj);
        object Visit(ComparisonOperator obj);
        object Visit(Declaration obj);
        object Visit(Declarations obj);
        object Visit(DeclaringParameter obj);
        object Visit(DeclaringParameters obj);
        object Visit(ElseIfStatementExtend obj);
        object Visit(ElseStatementExtend obj);
        object Visit(Expression obj);
        object Visit(IdentifiersPrime obj);
        object Visit(LogicalOperator obj);
        object Visit(MethodDeclaration obj);
        object Visit(MethodType obj);
        object Visit(Operator obj);
        object Visit(Prefix obj);
        object Visit(ReturnStatement obj);
        object Visit(Statement obj);
        object Visit(Text obj);
        object Visit(TextPrime obj);
        object Visit(Nodes.Type obj);
        object Visit(Value obj);
    }
}
