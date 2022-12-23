using System;
public interface IStaticAccess<TMember> 
{
    TMember Member1 { get; }
    protected static StaticAccessor<TMember> MemberAccessor 
        = new (nameof(Member1));

    TMember Member2 { get; }
    protected TMember Member2Constructor();

    Func<TMember> DelegateMember { get; }
    protected TMember DelegateMemberFunction();
}