using NetDevPack.Domain;
using Stremou.Modules.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;


namespace Stremou.Domain.Models
{
    public class User : Entity, IAggregateRoot
    {

        public User(string name, string email, string password, Cpf cpf)
        {
            Name = name;
            Email = email;
            Password = password;
            Cpf = cpf;
        }

        public string? Name { get; private set; }

        public string? Email { get; private set; }

        public string? Password { get; private set; }

        public Cpf Cpf { get; private set; }

    }
}