using vemdezap.Domain.Entities.Base;

namespace vemdezap.Domain.Entities;

public class Envio: BaseClass
{
    public Campanha Campanha { get; set; }
    public Grupo Grupo { get; set; }
    public Contato Contato { get; set; }
    public bool Enviado { get; set; }
}
