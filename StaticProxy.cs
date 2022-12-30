using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public static class StaticProxy<TMember>
{
    private static Dictionary<Type, Dictionary<string, TMember>> _dic = new Dictionary<Type, Dictionary<string, TMember>>();
    public static TMember GetSetDelegate(string name, Type instanceType, TMember delegateMethod)
    {
        //if delegate is instance method on TInstance it should not alter instance!
        if(_dic.ContainsKey(instanceType) == false) 
        {
            _dic.Add(instanceType, new Dictionary<string, TMember>());
        }
        if(_dic[instanceType].ContainsKey(name) == false)
        {
            if(typeof(Delegate).IsAssignableFrom(typeof(TMember)) == false) 
            {
                throw new Exception();
            }
            _dic[instanceType][name] = delegateMethod;
        }
        return _dic[instanceType][name];
    }
    public static TMember GetSet(string name, Type instanceType, Func<TMember> constructor)
    {
        if(_dic.ContainsKey(instanceType) == false) 
        {
            _dic.Add(instanceType, new Dictionary<string, TMember>());
        }
        if(_dic[instanceType].ContainsKey(name) == false)
        {
            _dic[instanceType][name] = constructor();
        }
        return _dic[instanceType][name];
    }

    public static TMember Initialize(string name, Type instanceType, Func<TMember> constructor)
    {
        if(_dic.ContainsKey(instanceType) && _dic[instanceType].ContainsKey(name))
        {
            throw new Exception();
        }
        return GetSet(name, instanceType, constructor);
    }
}
public static class StaticProxyExt
{
    public static TMember GetSetProxy<TMember>(this object o, string name, Func<TMember> constructor)
        => StaticProxy<TMember>.GetSet(name, o.GetType(), constructor);
    public static TMember GetSetDelegate<TMember>(this object o, string name, TMember delegateMember)
        => StaticProxy<TMember>.GetSetDelegate(name, o.GetType(), delegateMember);
    public static TMember InitializeProxyMember<TMember>(this object o, string name, Func<TMember> constructor)
        =>  StaticProxy<TMember>.Initialize(name, o.GetType(), constructor);
}
