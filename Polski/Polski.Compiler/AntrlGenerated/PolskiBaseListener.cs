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
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="IPolskiListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.Diagnostics.DebuggerNonUserCode]
[System.CLSCompliant(false)]
public partial class PolskiBaseListener : IPolskiListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.program"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterProgram([NotNull] PolskiParser.ProgramContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.program"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitProgram([NotNull] PolskiParser.ProgramContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.line"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLine([NotNull] PolskiParser.LineContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.line"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLine([NotNull] PolskiParser.LineContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStatement([NotNull] PolskiParser.StatementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStatement([NotNull] PolskiParser.StatementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.functionDeclaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunctionDeclaration([NotNull] PolskiParser.FunctionDeclarationContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.functionDeclaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunctionDeclaration([NotNull] PolskiParser.FunctionDeclarationContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.functionBlock"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunctionBlock([NotNull] PolskiParser.FunctionBlockContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.functionBlock"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunctionBlock([NotNull] PolskiParser.FunctionBlockContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.block"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBlock([NotNull] PolskiParser.BlockContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.block"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBlock([NotNull] PolskiParser.BlockContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.if"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIf([NotNull] PolskiParser.IfContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.if"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIf([NotNull] PolskiParser.IfContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.while"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterWhile([NotNull] PolskiParser.WhileContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.while"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitWhile([NotNull] PolskiParser.WhileContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.functionCall"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunctionCall([NotNull] PolskiParser.FunctionCallContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.functionCall"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunctionCall([NotNull] PolskiParser.FunctionCallContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.print"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPrint([NotNull] PolskiParser.PrintContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.print"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPrint([NotNull] PolskiParser.PrintContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.read"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterRead([NotNull] PolskiParser.ReadContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.read"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitRead([NotNull] PolskiParser.ReadContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.booleanOrExpression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBooleanOrExpression([NotNull] PolskiParser.BooleanOrExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.booleanOrExpression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBooleanOrExpression([NotNull] PolskiParser.BooleanOrExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.booleanAndExpression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBooleanAndExpression([NotNull] PolskiParser.BooleanAndExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.booleanAndExpression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBooleanAndExpression([NotNull] PolskiParser.BooleanAndExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.booleanXorExpression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBooleanXorExpression([NotNull] PolskiParser.BooleanXorExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.booleanXorExpression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBooleanXorExpression([NotNull] PolskiParser.BooleanXorExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.booleanPrimaryExpression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBooleanPrimaryExpression([NotNull] PolskiParser.BooleanPrimaryExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.booleanPrimaryExpression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBooleanPrimaryExpression([NotNull] PolskiParser.BooleanPrimaryExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.booleanValue"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBooleanValue([NotNull] PolskiParser.BooleanValueContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.booleanValue"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBooleanValue([NotNull] PolskiParser.BooleanValueContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterExpression([NotNull] PolskiParser.ExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitExpression([NotNull] PolskiParser.ExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.additiveExpression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAdditiveExpression([NotNull] PolskiParser.AdditiveExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.additiveExpression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAdditiveExpression([NotNull] PolskiParser.AdditiveExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.multiplicativeExpression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMultiplicativeExpression([NotNull] PolskiParser.MultiplicativeExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.multiplicativeExpression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMultiplicativeExpression([NotNull] PolskiParser.MultiplicativeExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.unaryExpression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterUnaryExpression([NotNull] PolskiParser.UnaryExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.unaryExpression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitUnaryExpression([NotNull] PolskiParser.UnaryExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.primaryExpression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPrimaryExpression([NotNull] PolskiParser.PrimaryExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.primaryExpression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPrimaryExpression([NotNull] PolskiParser.PrimaryExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.number"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterNumber([NotNull] PolskiParser.NumberContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.number"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitNumber([NotNull] PolskiParser.NumberContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.declaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterDeclaration([NotNull] PolskiParser.DeclarationContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.declaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitDeclaration([NotNull] PolskiParser.DeclarationContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.definition"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterDefinition([NotNull] PolskiParser.DefinitionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.definition"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitDefinition([NotNull] PolskiParser.DefinitionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.assignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAssignment([NotNull] PolskiParser.AssignmentContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.assignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAssignment([NotNull] PolskiParser.AssignmentContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterType([NotNull] PolskiParser.TypeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitType([NotNull] PolskiParser.TypeContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolskiParser.numericType"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterNumericType([NotNull] PolskiParser.NumericTypeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolskiParser.numericType"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitNumericType([NotNull] PolskiParser.NumericTypeContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}
