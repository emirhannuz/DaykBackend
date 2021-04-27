using Business.Abstract;
using Core.Entites.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Username = userForRegisterDto.Username,
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                TcNo = userForRegisterDto.TcNo,
                PhoneNumber = userForRegisterDto.PhoneNumber,
                Address = userForRegisterDto.Address,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            var result = _userService.Add(user);
            if (!result.Success)
            {
                return new ErrorDataResult<User>(result.Message);
            }
            return new SuccessDataResult<User>(user, "Kayıt işlemi başarılı");
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (!userToCheck.Success)
            {
                return new ErrorDataResult<User>("kullanıcı bulunamadı.");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>("şifre yanlıs");
            }

            return new SuccessDataResult<User>(userToCheck.Data, "giriş başarılı");
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email).Success)
            {
                return new ErrorResult("email kullanılıyor");
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, "erişim anahtarı oluşturuldu.");
        }
    }
}
