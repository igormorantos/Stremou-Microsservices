﻿using Stremou.Domain.Models;
using Stremou.Modules.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Domain.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);

        Task<User> GetByCpf(Cpf cpf);

        Task<IEnumerable<User>> GetList();

        Task Add(User user);

        void Update(User user);

        void Remove(User user);
    }
}
