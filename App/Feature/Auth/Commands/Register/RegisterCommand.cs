using AutoMapper;
using Core.Utilities.Hashing;
using DataAccess.Abstracts;
using Entities;
using MediatR;

namespace Business.Feature.Auth.Commands.Register
{
    public class RegisterCommand : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand>
        {
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;

            public RegisterCommandHandler(IMapper mapper, IUserRepository userRepository)
            {
                _mapper = mapper;
                _userRepository = userRepository;
            }

            public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                User user = _mapper.Map<User>(request);

                byte[] passwordHast, passwordSalt;

                HashingHelper.CreatePasswordHash(request.Password, out passwordHast, out passwordSalt);

                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHast;

                await _userRepository.AddAsync(user);
            }
        }
    }
}
