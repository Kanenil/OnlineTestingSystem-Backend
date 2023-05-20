using AutoMapper;
using MediatR;
using OnlineTestingSystem.Application.Contracts.Persistence;
using OnlineTestingSystem.Application.DTOs.User;
using OnlineTestingSystem.Application.Exeptions;
using OnlineTestingSystem.Application.Features.Users.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Features.Users.Handlers.Queries
{
    public class GetUserBySlugRequestHandler : IRequestHandler<GetUserBySlugRequest, UserDTO>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public GetUserBySlugRequestHandler(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(GetUserBySlugRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _usersRepository.GetUserBySlugAsync(request.Slug);
                return _mapper.Map<UserDTO>(user);
            } 
            catch
            {
                throw new NotFoundException("User with slug", request.Slug);
            }
        }
    }
}
