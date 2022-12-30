using System;
public class StaticAccessor<TMember>
{
    private readonly string _name;
    public StaticAccessor(string name)
    {
        _name = name;
    }
    public TMember Get(Type instanceType) 
	{
        //will throw exception if member hasnt been initialized
		return StaticProxy<TMember>.GetSet(_name, instanceType, null);
	}
    public TMember GetSet(Type instanceType, Func<TMember> constructor) 
	{
        //will throw exception if member hasnt been initialized
		return StaticProxy<TMember>.GetSet(_name, instanceType, constructor);
	}
    public void Initialize(TMember member, Type instanceType)
    {
        //will throw exception if has already been set 
        StaticProxy<TMember>.Initialize(_name, instanceType, () => member);
    }
}
