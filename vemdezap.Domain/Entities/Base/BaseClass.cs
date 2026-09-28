using prmToolkit.NotificationPattern;

namespace vemdezap.Domain.Entities.Base;

public abstract class BaseClass: Notifiable
{

    protected BaseClass()
    {
        Id = Guid.NewGuid();       
    }

    public Guid Id { get; set; }
}
