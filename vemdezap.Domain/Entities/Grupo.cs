using vemdezap.Domain.Entities.Base;
using vemdezap.Domain.Enums;

namespace vemdezap.Domain.Entities;

public class Grupo: BaseClass
{
    public Usuario Usuario { get; set; }
    public string Nome { get; set; } = string.Empty;
    public Nicho Nicho { get; set; }
}
