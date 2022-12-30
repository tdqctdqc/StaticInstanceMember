using System;
public interface IStaticAccess<TMember> 
{
    //two styles of accessing 
    //first is for when you want to set the member by reflection 
    //second is for when you want implementing class to determine member
    
    TMember Member1 
        => Member1Accessor
            .Get(this.GetType());
    protected static StaticAccessor<TMember> Member1Accessor 
        = new (nameof(Member1));



    TMember Member2 
        => Member2Accessor.GetSet
            (this.GetType(), Member2Constructor);
    protected TMember Member2Constructor();
    protected static StaticAccessor<TMember> Member2Accessor 
        = new (nameof(Member2));





    Func<TMember> Delegate1
        => Delegate1Accessor.Get(this.GetType());
    protected static StaticAccessor<Func<TMember>> Delegate1Accessor 
        = new (nameof(Delegate1));

        
    Func<TMember> Delegate2 
        => Delegate2Accessor
            .GetSetDelegate<Func<TMember>>
                (nameof(Delegate2), Delegate2Function);
    protected TMember Delegate2Function();
    protected static StaticAccessor<Func<TMember>> Delegate2Accessor 
        = new (nameof(Delegate2));
}