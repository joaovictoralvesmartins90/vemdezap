namespace vemdezap.Domain.Entities.Base;

public abstract class BaseClass
{

    protected BaseClass()
    {
        Id = Guid.NewGuid();       
    }

    public Guid Id { get; set; }
}
