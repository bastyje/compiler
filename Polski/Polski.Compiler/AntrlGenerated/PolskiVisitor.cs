//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /home/sebastian/studia/curr/jfk/proj/Polski/Polski.Compiler/LanguageDefinition/Polski.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="PolskiParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public interface IPolskiVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="PolskiParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProgram([NotNull] PolskiParser.ProgramContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="PolskiParser.line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLine([NotNull] PolskiParser.LineContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="PolskiParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatement([NotNull] PolskiParser.StatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="PolskiParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignment([NotNull] PolskiParser.AssignmentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="PolskiParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression([NotNull] PolskiParser.ExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="PolskiParser.arithmeticExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArithmeticExpression([NotNull] PolskiParser.ArithmeticExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="PolskiParser.number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumber([NotNull] PolskiParser.NumberContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="PolskiParser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeclaration([NotNull] PolskiParser.DeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="PolskiParser.definition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDefinition([NotNull] PolskiParser.DefinitionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="PolskiParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitType([NotNull] PolskiParser.TypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="PolskiParser.numericType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumericType([NotNull] PolskiParser.NumericTypeContext context);
}
