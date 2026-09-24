using vemdezap.Domain.Entities.Base;

namespace vemdezap.Domain.Entities;

public class Campanha: BaseClass
{
    public string Nome { get; set; } = string.Empty;
    public Usuario Usuario { get; set; }
}
