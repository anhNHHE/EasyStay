using api.Dtos.Users;
using api.Models;


namespace api.Mappers
{
    public static class UserMapper
    {
        public static User ToEntity(CreateUserDto dto)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Phone = dto.Phone,
                Role = "seeker",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };
        }


        public static UserDto ToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                IsActive = user.IsActive ?? false
            };
        }
    }
}