using MediatR;
using prmToolkit.NotificationPattern;
using vemdezap.Domain.Interfaces;

namespace vemdezap.Domain.Commands.Usuario.AdicionarUsuario;

public class AdicionarUsuarioHandler : Notifiable, IRequestHandler<AdicionarUsuarioRequest, Response>   
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMediator _mediator;

    public AdicionarUsuarioHandler(IUsuarioRepository usuarioRepository, IMediator mediator)
    {
        _usuarioRepository = usuarioRepository;
        _mediator = mediator;
    }

    public async Task<Response> Handle(AdicionarUsuarioRequest request, CancellationToken cancellationToken)
    {
        //validar se pedido é válido/preenchido
        if(request == null)
        {
            AddNotification("Request", "Request não está válido!");
            return new Response(this);
        }

        //ver se usuário já existe por email
        if (_usuarioRepository.Existe(u => u.Email == request.Email))
        {
            AddNotification("Request", "Email já cadastrado no sistema");
            return new Response(this);
        }

        Entities.Usuario usuario = new Entities.Usuario
        (
            request.Nome,
            request.Sobrenome,
            request.Email,
            request.Senha
        );
        AddNotifications(usuario);

        if (IsInvalid())
        {
            return new Response(this);
        }

        usuario = _usuarioRepository.Adicionar(usuario);

        //criar notificação
        AdicionarUsuarioNotification adicionarUsuarioNotification = new AdicionarUsuarioNotification(usuario);
        await _mediator.Publish(adicionarUsuarioNotification);

        //criar resposta
        var response = new Response(this, usuario);
        return await Task.FromResult(response);
    }
}
