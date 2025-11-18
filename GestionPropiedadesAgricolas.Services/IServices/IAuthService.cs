using GestionPropiedadesAgricolas.Application.Dtos.Identity.User;
using GestionPropiedadesAgricolas.Application.Dtos.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPropiedadesAgricolas.Services.IServices
{

    public interface IAuthService
    {
        Task<UserRegistroResponseDto> RegistrarUsuario(UserRegistroRequestDto dto);
        Task<LoginUserResponseDto> Login(LoginUserRequestDto dto);
    }
}
