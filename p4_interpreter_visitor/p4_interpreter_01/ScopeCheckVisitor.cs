using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p4_interpreter_01.Nodes;

namespace p4_interpreter_01
{
    public class ScopeCheckVisitor : IVisitor
    {
        public ScopeCheckVisitor() { }

        public void Visit(StartupStucture obj)
        {
            Form1.formtest.testString = Form1.formtest.testString + obj.ToString();  // TODO: Test
        }

        public void Visit(BooleanExpression obj) { }
        public void Visit(BooleanExpressionExtention obj) { }
        public void Visit(BooleanValue obj) { }
        public void Visit(CallMethod obj) { }
        public void Visit(CallPrefabMethod obj) { }
        public void Visit(DeclarationCommand obj) { }
        public void Visit(DeclarationCommands obj) { }
        public void Visit(DeclarationList obj) { }
        public void Visit(DeclaringParameterComma obj) { }
        public void Visit(DeclaringParameters obj) { }
        public void Visit(IdentifiersPrimeStatement obj) { }
        public void Visit(IdentifiersStatement obj) { }
        public void Visit(MethodDeclaration obj) { }
        public void Visit(MethodDeclarationDeclarations obj) { }
        public void Visit(MethodParameter obj) { }
        public void Visit(MethodParameterComma obj) { }
        public void Visit(MethodTypeCreator obj) { }
        public void Visit(MethodTypePrefab obj) { }
        public void Visit(Operator obj) { }
        public void Visit(OperatorExpression obj) { }
        public void Visit(PrefabCreator obj) { }
        public void Visit(Prefix obj) { }
        public void Visit(Return obj) { }
        public void Visit(ReturnNull obj) { }
        public void Visit(RuleAssignment obj) { }
        public void Visit(RuleControlstatementIf obj) { }
        public void Visit(RuleControlStatements obj) { }
        public void Visit(RuleControlstatementWhile obj) { }
        public void Visit(RuleElseifStatementElseif obj) { }
        public void Visit(RuleElseifStatementExtend obj) { }
        public void Visit(RuleElseStatementExtendElse obj) { }
        public void Visit(RuleStatementIdentifiers obj) { }
        public void Visit(TextIdentifiers obj) { }
        public void Visit(TextPrimeIdentifiers obj) { }
        public void Visit(TextPrimeStringValue obj) { }
        public void Visit(TextValue obj) { }
        public void Visit(TypeCreator obj) { }
        public void Visit(TypeDeclaration obj) { }
        public void Visit(TypePrefab obj) { }
        public void Visit(TypeValueBoolean obj) { }
        public void Visit(TypeValueCreatorPoint obj) { }
        public void Visit(TypeValueDecimal obj) { }
        public void Visit(TypeValueIdentifier obj) { }
        public void Visit(TypeValueInteger obj) { }
        public void Visit(TypeValueKeywords obj) { }
        public void Visit(TypeValueString obj) { }
        public void Visit(ValueKeywords obj) { }
        public void Visit(WriteStatement obj) { }
        public void Visit(RuleStatementPrefabMethods obj) { }



    }
}
