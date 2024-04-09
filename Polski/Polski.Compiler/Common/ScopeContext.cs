namespace Polski.Compiler.Common;

public class ScopeContext
{
    private ICollection<Member> CurrentScopeMembers
    {
        get
        {
            if (_stack.Count == 0)
            {
                throw new InvalidOperationException("There is no defined scope");
            }
            
            return _stack.Peek();
        }
    }
    
    private readonly Stack<ICollection<Member>> _stack = new();

    public void PushScope()
    {
        if (_stack.Count > 0)
        {
            var currentScope = _stack.Peek();
            _stack.Push(new HashSet<Member>(currentScope));
            return;    
        }
        
        _stack.Push(new HashSet<Member>());
    }
    
    public void PopScope()
    {
        if (_stack.Count == 0)
        {
            throw new InvalidOperationException("There is no defined scope");
        }
        
        _stack.Pop();
    }
    
    public Member AddMember(PolskiMember polskiMember, bool stackAllocated = false)
    {
        if (_stack.Count == 0)
        {
            throw new InvalidOperationException("There is no defined scope");
        }
        
        var member = GenerateMember(polskiMember, stackAllocated);
        CurrentScopeMembers.Add(member);
        return member;
    }

    public Member AddMember(string type, bool stackAllocated = false)
    {
        var member = GenerateMember(type, stackAllocated);
        CurrentScopeMembers.Add(member);
        return member;
    }
    
    public bool TryGetMember(string name, out Member member)
    {
        member = CurrentScopeMembers.SingleOrDefault(m => m.PolskiMember.Name == name)
                 ?? CurrentScopeMembers.SingleOrDefault(m => m.PolskiMember.Name == InternalMemberName(name));
        return member is not null;
    }

    private Member GenerateMember(PolskiMember polskiMember, bool stackAllocated)
    {
        var llvmName = GenerateMemberName();
        return new Member(polskiMember, llvmName, polskiMember.Type, stackAllocated);
    }

    private Member GenerateMember(string type, bool stackAllocated)
    {
        var llvmName = GenerateMemberName();
        return new Member(
            new PolskiMember(InternalMemberName(llvmName), type),
            llvmName,
            type,
            stackAllocated);
    }

    private string GenerateMemberName() => $"{CurrentScopeMembers.Count + 1}";
    private static string InternalMemberName(string memberName) => $"#{memberName}";
}