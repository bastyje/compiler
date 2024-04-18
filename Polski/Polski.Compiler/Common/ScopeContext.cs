using Antlr4.Runtime;
using Polski.Compiler.Error;
using Polski.Compiler.LanguageDefinition;

namespace Polski.Compiler.Common;

public class ScopeContext
{
    private KeyValuePair<string?, ICollection<Member>> CurrentScope
    {
        get
        {
            if (_stack.Count == 0)
            {
                throw new SemanticErrorInternalException("There is no defined scope");
            }
            
            return _stack.Peek();
        }
    }
    
    private ICollection<Function> DeclaredFunctions { get; } = new HashSet<Function>();

    private int _variableCounter = 0;
    private int _globalVariableCounter = 0;
    
    private readonly Stack<KeyValuePair<string?, ICollection<Member>>> _stack = new();

    public void PushScope(string? scopeName = null)
    {
        if (_stack.Count > 0)
        {
            var currentScope = _stack.Peek().Value;
            var memberSet = new Member[currentScope.Count];
            currentScope.CopyTo(memberSet, 0);
            _stack.Push(new KeyValuePair<string?, ICollection<Member>>(scopeName, memberSet.ToHashSet()));
            return;    
        }
        
        _stack.Push(new KeyValuePair<string?, ICollection<Member>>(scopeName, new HashSet<Member>()));
    }
    
    public void PopScope(ParserRuleContext context)
    {
        if (_stack.Count == 0)
        {
            throw new SemanticErrorException("There is no defined scope", context);
        }

        if (CurrentScope.Key is not null)
        {
            _variableCounter = 0;
        }
        
        _stack.Pop();
    }
    
    public Member AddMember(PolskiMember polskiMember, ParserRuleContext context, bool stackAllocated = false, bool global = false)
    {
        if (_stack.Count == 0)
        {
            throw new SemanticErrorException("There is no defined scope", context);
        }
        
        if (CurrentScope.Value.Any(m => m.PolskiMember.Name == polskiMember.Name && m.Scope == CurrentScope.Key))
        {
            throw new SemanticErrorException($"Variable {polskiMember.Name} is already defined in this scope", context);
        }
        
        var member = GenerateMember(polskiMember, stackAllocated, global);
        CurrentScope.Value.Add(member);
        return member;
    }

    public Member AddMember(string type, bool stackAllocated = false)
    {
        var member = GenerateMember(type, stackAllocated);
        CurrentScope.Value.Add(member);
        return member;
    }
    
    public Member GetMember(string name, ParserRuleContext context)
    {
        return CurrentScope.Value
            .SingleOrDefault(m => m.PolskiMember.Name == name)
               ?? CurrentScope.Value.SingleOrDefault(m => m.PolskiMember.Name == InternalMemberName(name))
               ?? throw new SemanticErrorException($"Variable {name} is not defined in this scope", context);
    }
    
    public void AddAnonymousMember()
    {
        CurrentScope.Value.Add(GenerateMember(PolskiDataType.Anonymous, true));
    }
    
    public string GetNewLabel() => (++_variableCounter).ToString();
    
    public Function AddFunction(string returnType, List<Member> parameters, string name, ParserRuleContext context)
    {
        var function = new Function(returnType, parameters, name);
        
        if (DeclaredFunctions.Any(f => f.Name == name))
        {
            throw new SemanticErrorException($"Function {name} is already defined", context);
        }
        
        DeclaredFunctions.Add(function);
        
        CurrentScope.Value.Where(m => function.Parameters.Any(p => p.PolskiMember.Name == m.PolskiMember.Name))
            .ToList()
            .ForEach(m =>
            {
                m.StackAllocated = false;
                m.LlvmName = $"{int.Parse(m.LlvmName) - 1}";
            });
        
        return function;
    }
    
    public Function GetFunction(string name, ParserRuleContext context)
    {
        return DeclaredFunctions.SingleOrDefault(f => f.Name == name)
               ?? throw new SemanticErrorException($"Function {name} is not defined", context);
    }

    private Member GenerateMember(PolskiMember polskiMember, bool stackAllocated, bool global)
    {
        var llvmName = GenerateMemberName(global);
        return new Member(polskiMember, llvmName, polskiMember.Type, CurrentScope.Key, stackAllocated, global);
    }

    private Member GenerateMember(string type, bool stackAllocated)
    {
        var llvmName = GenerateMemberName(false);
        return new Member(
            new PolskiMember(InternalMemberName(llvmName), type),
            llvmName,
            type,
            CurrentScope.Key,
            stackAllocated);
    }
    
    private string GenerateMemberName(bool global) => global ? $"{_globalVariableCounter++}" : $"{++_variableCounter}";
    private static string InternalMemberName(string memberName) => $"#{memberName}";
}