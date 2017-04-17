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
        void Visit(BooleanExpression obj);
        void Visit(BooleanExpressionExtention obj);
        void Visit(BooleanValue obj);
        void Visit(CallMethod obj);
        void Visit(CallPrefabMethod obj);
        void Visit(DeclarationCommand obj);
        void Visit(DeclarationCommands obj);
        void Visit(DeclarationList obj);
        void Visit(DeclaringParameterComma obj);
        void Visit(DeclaringParameters obj);
        void Visit(IdentifiersPrimeStatement obj);
        void Visit(IdentifiersStatement obj);
        void Visit(MethodDeclaration obj);
        void Visit(MethodDeclarationDeclarations obj);
        void Visit(MethodParameter obj);
        void Visit(MethodParameterComma obj);
        void Visit(MethodTypeCreator obj);
        void Visit(MethodTypePrefab obj);
        void Visit(Operator obj);
        void Visit(OperatorExpression obj);
        void Visit(PrefabCreator obj);
        void Visit(Prefix obj);
        void Visit(Return obj);
        void Visit(ReturnNull obj);
        void Visit(RuleAssignment obj);
        void Visit(RuleControlstatementIf obj);
        void Visit(RuleControlStatements obj);
        void Visit(RuleControlstatementWhile obj);
        void Visit(RuleElseifStatementElseif obj);
        void Visit(RuleElseifStatementExtend obj);
        void Visit(RuleElseStatementExtendElse obj);
        void Visit(RuleStatementIdentifiers obj);
        void Visit(StartupStucture obj);
        void Visit(TextIdentifiers obj);
        void Visit(TextPrimeIdentifiers obj);
        void Visit(TextPrimeStringValue obj);
        void Visit(TextValue obj);
        void Visit(TypeCreator obj);
        void Visit(TypeDeclaration obj);
        void Visit(TypePrefab obj);
        void Visit(TypeValueBoolean obj);
        void Visit(TypeValueCreatorPoint obj);
        void Visit(TypeValueDecimal obj);
        void Visit(TypeValueIdentifier obj);
        void Visit(TypeValueInteger obj);
        void Visit(TypeValueKeywords obj);
        void Visit(TypeValueString obj);
        void Visit(ValueKeywords obj);
        void Visit(WriteStatement obj);
    }
}
