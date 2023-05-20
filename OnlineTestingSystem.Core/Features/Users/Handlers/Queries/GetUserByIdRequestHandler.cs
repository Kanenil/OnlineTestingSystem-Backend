using AutoMapper;
using MediatR;
using OnlineTestingSystem.Application.Contracts.Persistence;
using OnlineTestingSystem.Application.DTOs.Course;
using OnlineTestingSystem.Application.DTOs.User;
using OnlineTestingSystem.Application.Features.Users.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Features.Users.Handlers.Queries
{
    public class GetUserByIdRequestHandler : IRequestHandler<GetUserByIdRequest, UserDTO>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public GetUserByIdRequestHandler(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var user = await _usersRepository.GetAsync(request.Id);
            return _mapper.Map<UserDTO>(user);
        }
    }
}
