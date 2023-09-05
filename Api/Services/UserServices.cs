using Api.Dtos;
using Application.Contratos;
using Application.Helpers.Security;
using Application.Services;
using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Api.Services;
public class UserServices : IUserServices
{
    private readonly IUnitOfWork _UnitOfWork;
    private readonly PasswordHasher<User> _PasswordHasher;
    private readonly IJwtGenerator _JwtGenerator;
    private readonly JWT _Jwt;    

    public UserServices(
        IUnitOfWork UnitOfWork,
        PasswordHasher<User> PasswordHasher,
        IJwtGenerator JwtGenerator,
        IOptions<JWT> Jwt
    )
    {
        _Jwt = Jwt.Value;
        _UnitOfWork = UnitOfWork;
        _PasswordHasher = PasswordHasher;
        _JwtGenerator = JwtGenerator;        
    }


    public async Task<string> AddRolAsync(AddRolDto model){
        User? user = _UnitOfWork.Users.FindUserByUsername(model.Username);
        if (user == null){
            return $"No existe algún usuario registrado con la cuenta {model.Username}.";
        }else if(ValidatePassword(user,model.Password)){
            return $"Credenciales incorrectas para el usuario {model.Username}.";
        }
        var existingRol = _UnitOfWork.Rols.FindFirst(x => x.Description == model.Rol);
        if (existingRol == null){
             return $"Rol {model.Rol} agregado a la cuenta {model.Username} de forma exitosa.";
        }
        
        var userHasRol = user.Rols.Any(x => x.IdPk == existingRol.IdPk);
        if (!userHasRol)
        {
            user.Rols.Add(existingRol);
            _UnitOfWork.Users.Update(user);
            await _UnitOfWork.SaveChanges();
        }
        return $"Rol {model.Rol} agregado a la cuenta {model.Username} de forma exitosa.";
        
        
    }

    public async Task<UserDataDto> GetTokenAsync(LogginDto model){
        UserDataDto userData = new(){
            IsAuthenticated = false,            
        };
        var user = _UnitOfWork.Users.FindUserByUsername(model.Username);
        if (user == null){
            userData.Message = $"No existe ningún usuario con el username {model.Username}.";
        }else if(!ValidatePassword(user, model.Password)){
            userData.Message =  $"Credenciales incorrectas para el usuario {model.Username}.";;
        }else{
            userData.Message = "Ok";
            userData.IsAuthenticated = true;
            userData.Username = user.Usename;
            userData.Email = user.Email;
            userData.Token = _JwtGenerator.CreateToken(user);
        }
        return userData;

    }

    public async Task<string> RegisterAsync(SingUpDto model)
    {
        var user = CreateUser(model);

        var existingUser = _UnitOfWork.Users.FindUserByUsername(model.Username);
        if (existingUser != null){
            return $"El usuario con {model.Username} ya se encuentra registrado.";
        }

        var defaultRol =  _UnitOfWork.Rols.FindByRol( Authorization.Default_role )!;

        try{
            user.Rols.Add(defaultRol);
            _UnitOfWork.Users.Add(user);
            await _UnitOfWork.SaveChanges();
            return $"El usuario  {model.Username} ha sido registrado exitosamente";
        }catch(Exception ex){
            return $"Error: {ex.Message}";
        }
        
    }

    private User CreateUser(SingUpDto model){
        User user = new(){
            Email = model.Email,
            Usename = model.Username
        };
        user.Password = _PasswordHasher.HashPassword(user,model.Password);
        return user;
    }    

    private bool ValidatePassword(User user, string password){
        return _PasswordHasher.VerifyHashedPassword(user, user.Password, password) == PasswordVerificationResult.Success;
    }
}