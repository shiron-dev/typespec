// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Input;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Providers;
using Microsoft.Generator.CSharp.Statements;
using static Microsoft.Generator.CSharp.Snippets.Snippet;

namespace SamplePlugin.Providers
{
    internal class SamplePluginMethodProviderCollection : ScmMethodProviderCollection
    {
        public SamplePluginMethodProviderCollection(InputOperation operation, TypeProvider enclosingType)
            : base(operation, enclosingType)
        {
        }

        protected override IReadOnlyList<MethodProvider> BuildMethods()
        {
            var methods = new List<MethodProvider>();

            // Add the base methods.
            methods.AddRange(base.BuildMethods());

            // Add an expression bodied method to demonstrate that we can still inject tracing in these.

            methods.Add(GetExpressionBodiedTestMethod());

            foreach (var method in methods)
            {
                // Only add tracing to protocol methods. Convenience methods will call into protocol methods.
                if (method is not ScmMethodProvider { IsProtocol: true })
                {
                    continue;
                }

                // Convert to a method with a body statement so we can add tracing.
                ConvertToBodyStatementMethodProvider(method);
                var ex = new VariableExpression(typeof(Exception), "ex");
                var decl = new DeclarationExpression(ex);
                var statements = new TryCatchFinallyStatement(
                    new[]
                    {
                        InvokeConsoleWriteLine(Literal($"Entering method {method.Signature.Name}.")),
                        method.BodyStatements!
                    },
                    new CatchExpression(
                        decl,
                        new[]
                        {
                            InvokeConsoleWriteLine(new FormattableStringExpression(
                                $"An exception was thrown in method {method.Signature.Name}: {{0}}", new[] { ex })),
                            Throw()
                        }),
                    InvokeConsoleWriteLine(Literal($"Exiting method {method.Signature.Name}.")));

                method.Update(bodyStatements: statements);
            }

            return methods;
        }

        private MethodProvider GetExpressionBodiedTestMethod() =>
            new ScmMethodProvider(
                new MethodSignature(
                    $"TestExpressionBodyConversion{ToTitleCase(Operation.Name)}",
                    $"Test expression body conversion.",
                    MethodSignatureModifiers.Public,
                    typeof(int),
                    $"Returns an int",
                    Array.Empty<ParameterProvider>()),
                Literal(42),
                EnclosingType) { IsProtocol = true };

        private string ToTitleCase(string name)
        {
            if (char.IsLetter(name[0]))
            {
                return char.ToUpper(name[0]) + name.Substring(1);
            }

            return name;
        }

        private void ConvertToBodyStatementMethodProvider(MethodProvider method)
        {
            if (method.BodyExpression != null)
            {
                MethodBodyStatement statements;
                if (method.BodyExpression is KeywordExpression { Keyword: "throw" } keywordExpression)
                {
                    statements = keywordExpression.Terminate();
                }
                else
                {
                    statements = new KeywordExpression("return", method.BodyExpression).Terminate();
                }
                method.Update(bodyStatements: statements);
            }
        }
    }
}
