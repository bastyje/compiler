//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /home/sebastian/studia/inf/8/jfk/proj/Polski/Polski.Compiler/LanguageDefinition/Polski.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="PolskiParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public interface IPolskiListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProgram([NotNull] PolskiParser.ProgramContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProgram([NotNull] PolskiParser.ProgramContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLine([NotNull] PolskiParser.LineContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLine([NotNull] PolskiParser.LineContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatement([NotNull] PolskiParser.StatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatement([NotNull] PolskiParser.StatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignment([NotNull] PolskiParser.AssignmentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignment([NotNull] PolskiParser.AssignmentContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpression([NotNull] PolskiParser.ExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpression([NotNull] PolskiParser.ExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.additiveExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAdditiveExpression([NotNull] PolskiParser.AdditiveExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.additiveExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAdditiveExpression([NotNull] PolskiParser.AdditiveExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.multiplicativeExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMultiplicativeExpression([NotNull] PolskiParser.MultiplicativeExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.multiplicativeExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMultiplicativeExpression([NotNull] PolskiParser.MultiplicativeExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.unaryExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnaryExpression([NotNull] PolskiParser.UnaryExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.unaryExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnaryExpression([NotNull] PolskiParser.UnaryExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.primaryExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrimaryExpression([NotNull] PolskiParser.PrimaryExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.primaryExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrimaryExpression([NotNull] PolskiParser.PrimaryExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNumber([NotNull] PolskiParser.NumberContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNumber([NotNull] PolskiParser.NumberContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDeclaration([NotNull] PolskiParser.DeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDeclaration([NotNull] PolskiParser.DeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.definition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDefinition([NotNull] PolskiParser.DefinitionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.definition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDefinition([NotNull] PolskiParser.DefinitionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterType([NotNull] PolskiParser.TypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitType([NotNull] PolskiParser.TypeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.numericType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNumericType([NotNull] PolskiParser.NumericTypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.numericType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNumericType([NotNull] PolskiParser.NumericTypeContext context);
}
