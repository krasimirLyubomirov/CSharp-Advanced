using System.Collections.Generic;

public abstract class Collection : IAdd  
{
    public Collection()
    {
        this.list = new List<string>();
    }

    private readonly List<string> list;

    protected IList<string> List => this.list;

    public abstract int Add(string element);
}

