using api.Dtos.Users;


namespace api.Interface.Services
{
    public interface IUserService
    {
        Task<UserDto> CreateSeekerAsync(CreateUserDto dto);
        Task<List<UserDto>> GetAllAsync();

        Task<UserDto> UpdateUserAsync(Guid id, UpdateUserDto dto);
        Task<bool> DeactivateUserAsync(Guid id);
    }
}