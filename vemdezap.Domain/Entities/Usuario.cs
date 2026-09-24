using vemdezap.Domain.Entities.Base;

namespace vemdezap.Domain.Entities;

public class Usuario: BaseClass
{
    public string Nome { get; set; } = string.Empty;
    public string Sobrenome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}
