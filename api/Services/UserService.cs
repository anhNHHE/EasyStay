using api.Dtos.Users;
using api.Interface.Repositories;
using api.Interface.Services;
using api.Mappers;


namespace api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;


        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }


        public async Task<UserDto> CreateSeekerAsync(CreateUserDto dto)
        {
            var user = UserMapper.ToEntity(dto);
            await _repo.AddAsync(user);
            await _repo.SaveChangesAsync();
            return UserMapper.ToDto(user);
        }

        public async Task<bool> DeactivateUserAsync(Guid id)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null) return false;

            user.IsActive = false;
            user.UpdatedAt = DateTime.UtcNow;

            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _repo.GetAllAsync();
            return users.Select(UserMapper.ToDto).ToList();
        }

        public async Task<UserDto?> UpdateUserAsync(Guid id, UpdateUserDto dto)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null || user.IsActive == false) return null;

            var allowedRole = new List<string> { "seeker", "tenant", "landlord" , "admin" };
            if (!allowedRole.Contains(dto.Role))
            {
                throw new ArgumentException("Invalid role specified.");
            }
            user.Name = dto.Name;
            user.Email = dto.Email;
            user.Role = dto.Role;
            user.Phone = dto.Phone;
            user.Address = dto.Address;
            user.Avatar = dto.Avatar;
            user.UpdatedAt = DateTime.UtcNow;

            await _repo.SaveChangesAsync();
            return UserMapper.ToDto(user);
        }
    }
}