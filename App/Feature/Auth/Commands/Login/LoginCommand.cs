using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities;
using MediatR;
using System.Security.Cryptography;
using System.Text;

namespace Business.Feature.Auth.Commands.Login
{
    public class LoginCommand : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }


        public class LoginCommandHandler : IRequestHandler<LoginCommand>
        {
            private readonly IUserRepository _userRepository;

            public LoginCommandHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(i => i.Email == request.Email);

                if (user is null)
                {
                    throw new BusinessException("Giriş başarısız");
                }

                using HMACSHA512 hmac = new HMACSHA512(user.PasswordSalt);

                hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));

                byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));

                bool isPasswordMatch = computedHash.SequenceEqual(user.PasswordHash);

                if (!isPasswordMatch)
                {
                    throw new BusinessException("Giriş başarılı");
                }
            }
        }

    }
}
