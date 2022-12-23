using System;

public abstract class Preset<TEntity>
{
    //null so will throw exception if Setup hasnt been run
    public TEntity Entity { get; private set; }
	public Preset(int id)
	{
        Entity = this.InitializeProxyMember<TEntity>(nameof(Entity), () => Construct(id));
    }
    protected abstract TEntity Construct(int id);
    protected abstract void SetDependencies();
}


