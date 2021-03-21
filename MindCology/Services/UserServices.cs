using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MindCology;
using MindCology.DAL.Entities;
using MindCology.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace WebApi.Services
{
    public interface IUserService
    {
        LoginViewModel Authenticate(LoginModel model);
        IEnumerable<LoginModel> GetAll();
        LoginModel GetById(int id);
    }

    public class UserService: IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<LoginEntity> _users = new List<LoginEntity>
        {
            new LoginEntity { Id = 1, Username = "lama-shabana", Password = "test123456" }
        };

        private readonly AppSettings _appSettings;

        

        public LoginModel Authenticate(LoginModel model)
        {
            var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new LoginModel(user, token);
        }

        private object generateJwtToken(LoginModel user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoginEntity> GetAll()
        {
            return _users;
        }

        public LoginEntity GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        // helper methods

        private string generateJwtToken(LoginEntity user)
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

        LoginViewModel IUserService.Authenticate(LoginModel model)
        {
            throw new NotImplementedException();
        }

        IEnumerable<LoginModel> IUserService.GetAll()
        {
            throw new NotImplementedException();
        }

        LoginModel IUserService.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}