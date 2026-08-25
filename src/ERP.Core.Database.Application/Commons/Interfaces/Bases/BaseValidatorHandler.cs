using MediatR;
using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories;

using ERP.Core.Application.Commons.Interfaces;

namespace ERP.Core.Database.Application.Commons.Interfaces.Bases
{
    public class AccessValidationResult<T>
    {
        public bool IsSuccess { get; set; }
        public Role? Role { get; set; }
        public T? ErrorResponse { get; set; }
        public User User { get; set; } = new();
        public UserProfile Profile { get; set; } = new();
    }

    public abstract class BaseValidatorHandler<TRequest, TResponse>(IUnitOfWork _unitOfWork, IErrorManager _errorManager) : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        protected readonly IUnitOfWork _unitOfWork = _unitOfWork;
        protected readonly IErrorManager _errorManager = _errorManager;

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

        protected async Task<AccessValidationResult<TResponse>> ValidateAccessAsync(Guid userId, Guid companyId, string moduleCode, CancellationToken ct, bool onlyUser = false)
        {
            // 1. Validar Usuario
            var user = await _unitOfWork.Users.FirstOrDefaultAsync(u => u.Id == userId, ct);

            if (user is null)
            {
                return new AccessValidationResult<TResponse> { 
                    IsSuccess = false, 
                    ErrorResponse = _errorManager.ThrowBadRequest<TResponse>("Este usuario no existe!", "ERP:003") 
                };
            }

            if (user.UserStatus != UserStatus.Active)
            {
                switch (user.UserStatus)
                {
                    case UserStatus.Locked:
                    {
                        return new AccessValidationResult<TResponse> { 
                            IsSuccess = false, 
                            ErrorResponse = _errorManager.ThrowBadRequest<TResponse>("Usuario se encuentra temporalmente bloqueado, comunicar con el area de informatica", "ERP:02") 
                        };
                    }
                    case UserStatus.Inactive:
                    {
                        return new AccessValidationResult<TResponse> { 
                            IsSuccess = false, 
                            ErrorResponse = _errorManager.ThrowBadRequest<TResponse>("Usuario se encuentra inactivo, comunicar con el area de informatica", "ERP:03") 
                        };
                    }
                    default:
                    {
                        return new AccessValidationResult<TResponse> { 
                            IsSuccess = false, 
                            ErrorResponse = _errorManager.ThrowBadRequest<TResponse>("El usuario no se encuentra activo, comunicar con el area de informatica", "ERP:03") 
                        };
                    }
                }
            }

            // 2. Validar Perfil
            var profile = await _unitOfWork.Profiles.Entities
                .Where(p => p.UserId == userId && p.CompanyId == companyId)
                .Include(p => p.Company)
                .FirstOrDefaultAsync(ct);

            if (profile is null)
            {
                return new AccessValidationResult<TResponse> { 
                    IsSuccess = false, 
                    ErrorResponse = _errorManager.ThrowBadRequest<TResponse>("No existe un perfil asociado a esta empresa", "ERP:004") 
                };
            }
            
            Role? role = null;

            if (!onlyUser)
            {
                // 3. Validar Módulo
                var module = await _unitOfWork.UserModules.FirstOrDefaultAsync(m => m.ModuleCode == moduleCode && m.UserProfileId == profile.Id, ct);

                if (module is null)
                {
                    return new AccessValidationResult<TResponse> { 
                        IsSuccess = false, 
                        ErrorResponse = _errorManager.ThrowBadRequest<TResponse>("No tienes acceso a este módulo", "ERP:005") 
                    };
                }

                // 4. Obtener Rol
                role = await _unitOfWork.Roles.FirstOrDefaultAsync(r => r.Id == module.RoleId, ct);
                
                if (role is null)
                {
                    return new AccessValidationResult<TResponse> { 
                        IsSuccess = false, 
                        ErrorResponse = _errorManager.ThrowBadRequest<TResponse>("El rol asignado no es válido", "ERP:006") 
                    };
                }   
            }

            return new AccessValidationResult<TResponse> { IsSuccess = true, Role = role, User = user, Profile = profile };
        }
    }
}
