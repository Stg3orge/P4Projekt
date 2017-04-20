using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class Statement : SyntaxNode
    {
        private Text text;
        private Identifiers identifiers;
        private Identifiers identifiers2;
        private Value value;
        private Expression expression;
        private CallingParameters callingParameters;
        private ControlStatements controlStatements;
        private PrefabMethods prefabMethods;


        public string NodeType { get; private set; }

        // Write
        public Statement(ParserContext context, Text text) : base(context)
        {
            this.text = text;
            NodeType = " ";   // TODO:
        }

        // Identifier assign
        public Statement(ParserContext context, Identifiers identifiers, Value value, Expression expression) : base(context)
        {
            this.identifiers = identifiers;
            this.value = value;
            this.expression = expression;
            NodeType = " ";   // TODO:
        }

        // ControlStatements
        public Statement(ParserContext context, ControlStatements controlStatements) : base(context)
        {
            this.controlStatements = controlStatements;
            NodeType = " ";   // TODO:
        }

        // Call 
        public Statement(ParserContext context, Identifiers identifiers, CallingParameters callingParameters) : base(context)
        {
            this.identifiers = identifiers;
            this.callingParameters = callingParameters;
            NodeType = " ";   // TODO:
        }

        // Call Prefab method
        public Statement(ParserContext context, PrefabMethods prefabMethods, CallingParameters callingParameters) : base(context)
        {
            this.prefabMethods = prefabMethods;
            this.callingParameters = callingParameters;
            NodeType = " ";   // TODO:
        }

        // Identifier Call method
        public Statement(ParserContext context, Identifiers identifiers, Identifiers identifiers2, CallingParameters callingParameters) : base(context)
        {
            this.identifiers = identifiers;
            this.identifiers2 = identifiers2;
            this.callingParameters = callingParameters;
            NodeType = " ";   // TODO:
        }

        // Identifier Prefab method
        public Statement(ParserContext context, Identifiers identifiers, PrefabMethods prefabMethods, CallingParameters callingParameters) : base(context)
        {
            this.identifiers = identifiers;
            this.prefabMethods = prefabMethods;
            this.callingParameters = callingParameters;
            NodeType = " ";   // TODO:
        }

    }
}