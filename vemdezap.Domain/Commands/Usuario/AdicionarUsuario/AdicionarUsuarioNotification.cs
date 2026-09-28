using MediatR;

namespace vemdezap.Domain.Commands.Usuario.AdicionarUsuario;

public class AdicionarUsuarioNotification: INotification
{
    public Entities.Usuario Usuario { get; set; }

    public AdicionarUsuarioNotification(Entities.Usuario usuario)
    {
        Usuario = usuario;
    }
}
