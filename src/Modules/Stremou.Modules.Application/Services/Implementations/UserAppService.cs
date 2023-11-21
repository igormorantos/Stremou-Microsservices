using AutoMapper;
using Microsoft.Extensions.Logging;
using Stremou.Domain.Contracts;
using Stremou.Domain.Models;
using Stremou.Modules.Application.Handlers.User.Commands;
using Stremou.Modules.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Modules.Application.Services.Imp
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UserAppService(IUserRepository userRepository, IMapper mapper, ILogger logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;

        }

        public async Task<UserViewModel> GetByCPF(Cpf cpf)
        {
            return _mapper.Map<UserViewModel>(await _userRepository.GetByCpf(cpf));
        }

        public async Task<UserViewModel> GetByEmail(string email)
        {
            return _mapper.Map<UserViewModel>(await _userRepository.GetByEmail(email));

        }

        public async Task Save(CreateUserCommand commandCreate)
        {
            await _userRepository.Add(commandCreate.GetEntity());
        }
    }
}
