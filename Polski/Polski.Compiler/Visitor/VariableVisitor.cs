using Polski.Compiler.Common;
using Polski.Compiler.Generator;

namespace Polski.Compiler.Visitor;

public partial class PolskiVisitor
{
    private Stack<HashSet<RegisteredIdentifier>> UsedIdentifiers { get; } = new();

    #region Visitors

    public override NodeResult VisitDeclaration(PolskiParser.DeclarationContext context)
    {
        var identifier = context.IDENTIFIER().GetText();
        var type = Visit(context.type());

        if (!UsedIdentifiers.TryPeek(out var identifiers))
        {
            identifiers = new();
            UsedIdentifiers.Push(identifiers);
        }
        
        var llvmName = GenerateAndRegisterVariableName(type.Type!, identifier);

        return new NodeResult
        {
            Code = LlvmGenerator.AllocateVariable(identifier, type.Type!),
            Type = type.Type,
            Identifier = llvmName
        };
    }
    
    public override NodeResult VisitDefinition(PolskiParser.DefinitionContext context)
    {
        var declarationStatement = Visit(context.declaration());
        return declarationStatement; // todo
    }

    #endregion

    #region Helpers

    public string GenerateAndRegisterVariableName(string type, string? name = null)
    {
        if (!UsedIdentifiers.TryPeek(out var identifiers))
        {
            identifiers = new();
            UsedIdentifiers.Push(identifiers);
        }
        
        if (name is not null && identifiers.Any(i => i.Name == name))
        {
            // todo exception
            throw new Exception($"Variable {name} is already declared in this scope.");
        }
        
        if (!LlvmDataType.TryMapFromPolski(type, out var llvmType))
        {
            // todo exception
            throw new Exception($"Type {type} is not supported.");
        }
        
        var llvmName = $"{identifiers.Count + 1}";
        identifiers.Add(new(name, type, llvmName, llvmType));
        return llvmName;
    }
    
    private string GenerateAndRegisterLlvmVariableName(string llvmType)
    {
        if (!UsedIdentifiers.TryPeek(out var identifiers))
        {
            identifiers = new();
            UsedIdentifiers.Push(identifiers);
        }
        
        var llvmName = $"{identifiers.Count + 1}";
        identifiers.Add(new(llvmName, llvmType));
        return llvmName;
    }
    
    private bool TryGetIdentifier(string identifier, out RegisteredIdentifier? registeredIdentifier)
    {
        if (UsedIdentifiers.TryPeek(out var identifiers))
        {
            registeredIdentifier = identifiers.FirstOrDefault(i => i.Name == identifier);
            return registeredIdentifier is not null;
        }

        registeredIdentifier = null;
        return false;
    }

    #endregion


}