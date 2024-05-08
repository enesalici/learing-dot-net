using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Hashing;
using DataAccess.Abstracts;
using Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
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

                bool isPasswordMatch = HashingHelper.VerifyPasswordHash(request.Password,
                    user.PasswordHash, user.PasswordSalt);

                if (!isPasswordMatch)
                {
                    throw new BusinessException("Giriş başarılı");
                }
            }
        }

    }
}
