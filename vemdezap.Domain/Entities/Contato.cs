using vemdezap.Domain.Entities.Base;
using vemdezap.Domain.Enums;

namespace vemdezap.Domain.Entities;

public class Contato: BaseClass
{
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public Nicho Nicho { get; set; }
    public Usuario Usuario { get; set; }
}
