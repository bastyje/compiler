namespace Polski.Compiler.Visitor;

/// <summary>
/// This partial class covers arithmetic expressions
/// </summary>
public partial class PolskiVisitor
{
    public override NodeResult VisitArithmeticExpression(PolskiParser.ArithmeticExpressionContext context)
    {
        if (context.IDENTIFIER() is { } identifier)
        {
            if (!TryGetIdentifier(identifier.GetText(), out var registeredIdentifier))
            {
                throw new Exception($"Identifier {identifier.GetText()} is not declared in this scope.");
            }

            return new NodeResult
            {
                Identifier = registeredIdentifier!.LlvmName,
                Type = registeredIdentifier.LlvmType
            };
        }

        if (context.MULTIPLY() is not null)
        {
            var left = Visit(context.arithmeticExpression(0));
            var right = Visit(context.arithmeticExpression(1));

            var resultIdentifier = GenerateAndRegisterLlvmVariableName(left.Type!);
            
            return new NodeResult
            {
                // todo use proper division operator with respect to operand types
                Code = $"%{resultIdentifier} = mul {left.Type} %{left.Identifier}, %{right.Identifier}\n",
                Identifier = resultIdentifier,
                Type = left.Type
            };
        }

        if (context.DIVIDE() is not null)
        {
            var left = Visit(context.arithmeticExpression(0));
            var right = Visit(context.arithmeticExpression(1));

            var resultIdentifier = GenerateAndRegisterLlvmVariableName(left.Type!);
            
            return new NodeResult
            {
                // todo use proper division operator with respect to operand types
                Code = $"%{resultIdentifier} = div {left.Type} %{left.Identifier}, %{right.Identifier}\n",
                Identifier = resultIdentifier,
                Type = left.Type
            };
        }

        if (context.PLUS() is not null)
        {
            var left = Visit(context.arithmeticExpression(0));
            var right = Visit(context.arithmeticExpression(1));

            var resultIdentifier = GenerateAndRegisterLlvmVariableName(left.Type!);
            
            return new NodeResult
            {
                // todo use proper division operator with respect to operand types
                Code = $"%{resultIdentifier} = add {left.Type} %{left.Identifier}, %{right.Identifier}\n",
                Identifier = resultIdentifier,
                Type = left.Type
            };
        }

        if (context.MINUS() is not null)
        {
            var left = Visit(context.arithmeticExpression(0));
            var right = Visit(context.arithmeticExpression(1));

            var resultIdentifier = GenerateAndRegisterLlvmVariableName(left.Type!);
            
            return new NodeResult
            {
                // todo use proper division operator with respect to operand types
                Code = $"%{resultIdentifier} = sub {left.Type} %{left.Identifier}, %{right.Identifier}\n",
                Identifier = resultIdentifier,
                Type = left.Type
            };
        }

        return string.Empty; // todo
    }
}