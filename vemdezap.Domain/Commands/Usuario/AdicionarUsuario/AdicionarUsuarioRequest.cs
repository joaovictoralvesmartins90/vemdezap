using System;
using MediatR;

namespace vemdezap.Domain.Commands.Usuario.AdicionarUsuario;

public class AdicionarUsuarioRequest: IRequest<Response>
{
    public string Nome { get; set; } = string.Empty;
    public string Sobrenome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}
