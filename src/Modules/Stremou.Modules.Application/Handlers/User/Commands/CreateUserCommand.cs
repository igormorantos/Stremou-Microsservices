using MediatR;
using Stremou.Domain.Models;
using Stremou.Modules.Application.Handlers.User.Responses;
using Stremou.Modules.Domain.ValueObjects;
using UserEntity = Stremou.Domain.Models.User;

namespace Stremou.Modules.Application.Handlers.User.Commands
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        public Guid Id { get; private set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public Cpf Cpf { get; set; }
        
        public CreateUserCommand()
        {
            Id = Guid.NewGuid();
        }

        public UserEntity GetEntity()
        {
            return new UserEntity(
                this.Name,
                this.Email,
                this.Password,
                this.Cpf
                );
        }
    
    
    }
}
