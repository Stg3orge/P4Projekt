using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p4_interpreter_01.Nodes;

namespace p4_interpreter_01
{
    public class NodeVisitor : IVisitor
    {
        public NodeVisitor() { }

        // TODO: Add typechecking/scope logic

        public void Visit(BooleanExpression obj)
        {
            Form1.formtest.testString = Form1.formtest.testString + obj.ToString();
        }
        public void Visit(BooleanExpressionExtention obj)
        {
            Form1.formtest.testString = Form1.formtest.testString + obj.ToString();
        }
        public void Visit(BooleanValue obj)
        {
            Form1.formtest.testString = Form1.formtest.testString + obj.ToString();
        }
        public void Visit(CallMethod obj)
        {
            Form1.formtest.testString = Form1.formtest.testString + obj.ToString();
        }
        public void Visit(CallPrefabMethod obj)
        {
            Form1.formtest.testString = Form1.formtest.testString + obj.ToString();
        }
        public void Visit(DeclarationCommand obj)
        {
            Form1.formtest.testString = Form1.formtest.testString + obj.ToString();
        }
        public void Visit(DeclarationCommands obj)
        {
            Form1.formtest.testString = Form1.formtest.testString + obj.ToString();
        }
        public void Visit(DeclarationList obj)
        {
            Form1.formtest.testString = Form1.formtest.testString + obj.ToString();
        }
        public void Visit(DeclaringParameterComma obj)
        {
            Form1.formtest.testString = Form1.formtest.testString + obj.ToString();
        }
        public void Visit(DeclaringParameters obj)
        {
            Form1.formtest.testString = Form1.formtest.testString + obj.ToString();
        }
        public void Visit(IdentifiersPrimeStatement obj)
        {
            Form1.formtest.testString = Form1.formtest.testString + obj.ToString();
        }
        public void Visit(IdentifiersStatement obj)
        {
            Form1.formtest.testString = Form1.formtest.testString + obj.ToString();
        }
        public void Visit(MethodDeclaration obj)
        {
            Form1.formtest.testString = Form1.formtest.testString + obj.ToString();
        }
        public void Visit(MethodDeclarationDeclarations obj)
        {
            Form1.formtest.testString = Form1.formtest.testString + obj.ToString();
        }
        public void Visit(MethodParameter obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(MethodParameterComma obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(MethodTypeCreator obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(MethodTypePrefab obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(Operator obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(OperatorExpression obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(PrefabCreator obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(Prefix obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(Return obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(ReturnNull obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(RuleAssignment obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(RuleControlstatementIf obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(RuleControlStatements obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(RuleControlstatementWhile obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(RuleElseifStatementElseif obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(RuleElseifStatementExtend obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(RuleElseStatementExtendElse obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(RuleStatementIdentifiers obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(StartupStucture obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(TextIdentifiers obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(TextPrimeIdentifiers obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(TextPrimeStringValue obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(TextValue obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(TypeCreator obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(TypeDeclaration obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(TypePrefab obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(TypeValueBoolean obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(TypeValueCreatorPoint obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(TypeValueDecimal obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(TypeValueIdentifier obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(TypeValueInteger obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(TypeValueKeywords obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(TypeValueString obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(ValueKeywords obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }
        public void Visit(WriteStatement obj) { Form1.formtest.testString = Form1.formtest.testString + obj.ToString(); }

    }
}
