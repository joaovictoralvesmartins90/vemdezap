using System;
using vemdezap.Domain.Entities;
using vemdezap.Domain.Interfaces;

namespace vemdezap.Infra.Repositories;

public class UsuarioRepository: RepositoryBase<Usuario, Guid>, IUsuarioRepository
{
    private readonly AppDbContext context;

    public UsuarioRepository(AppDbContext context): base(context)
    {
        this.context = context;
    }
}
