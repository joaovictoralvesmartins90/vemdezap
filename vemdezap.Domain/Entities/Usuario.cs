using prmToolkit.NotificationPattern;
using vemdezap.Domain.Entities.Base;
using vemdezap.Domain.Extensions;

namespace vemdezap.Domain.Entities;

public class Usuario: BaseClass
{
    public string Nome { get; private set; } = string.Empty;
    public string Sobrenome { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public DateTime DataCadastro { get; private set; }
    public bool Ativo { get; private set; }

    public Usuario(string nome, string sobrenome, string email, string senha)
    {
        Nome = nome;
        Sobrenome = sobrenome;
        Email = email;
        Senha = senha;

        new AddNotifications<Usuario>(this)
            .IfNullOrInvalidLength(u => u.Nome, 3, 150, "Nome deve ter de 3 a 150 caracteres.")
            .IfNullOrInvalidLength(u => u.Sobrenome, 3, 150, "Sobrenome deve ter de 3 a 150 caracteres.")
            .IfNotEmail(u => u.Email, "O email deve ter um formato válido.")
            .IfNullOrInvalidLength(u => u.Senha, 3, 32, "A senha deve ter de 3 a 32 caracteres.");

        if (!string.IsNullOrEmpty(Senha))
        {
            Senha = Senha.ConvertToMD5();
        }

        DataCadastro = DateTime.Now;
        Ativo = false;
    }

    //privar os sets e deixar as propriedades obrigatórias para que um objeto exista a partir do construtor
}
