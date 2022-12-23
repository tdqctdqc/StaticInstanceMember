using System;
public class StaticAccessor<TMember>
{
    private readonly string _name;
    public StaticAccessor(string name)
    {
        _name = name;
    }
    public TMember Get<TInstance>() 
	{
        //will throw exception if member hasnt been initialized
		return StaticProxy<TMember>.Get(_name, typeof(TInstance), null);
	}
    public void SetMember<TInstance>(TMember member)
    {
        //will throw exception if has already been set 
        StaticProxy<TMember>.Initialize(_name, typeof(TInstance), () => member);
    }
    public TMember Get(Type instanceType) 
	{
        //will throw exception if member hasnt been initialized
		return StaticProxy<TMember>.Get(_name, instanceType, null);
	}
    public void SetMember(TMember member, Type instanceType)
    {
        //will throw exception if has already been set 
        StaticProxy<TMember>.Initialize(_name, instanceType, () => member);
    }
}
