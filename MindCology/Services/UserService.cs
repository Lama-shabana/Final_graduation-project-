using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MindCology.DAL;
using MindCology.DAL.Entities;
using MindCology.Helpers;
using MindCology.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;



namespace MindCology.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<UserEntity> GetAll();
        UserEntity GetById(int id);
    }

    public class UserService : IUserService
    {



        private readonly MindCologyContext _mindCologyContext;
    

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, MindCologyContext mindCologyContext)
        {
            _appSettings = appSettings.Value;
            _mindCologyContext = mindCologyContext;

        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _mindCologyContext.User.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<UserEntity> GetAll()
        {
            return _mindCologyContext.User;
        }

        public UserEntity GetById(int id)
        {
            return _mindCologyContext.User.FirstOrDefault(x => x.Id == id);
        }

        // helper methods

        private string generateJwtToken(UserEntity user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}