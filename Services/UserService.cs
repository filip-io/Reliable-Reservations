using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Reliable_Reservations.Data.Repos.IRepos;
using Reliable_Reservations.Models;
using Reliable_Reservations.Models.DTOs.MenuItem;
using Reliable_Reservations.Models.DTOs.User;
using Reliable_Reservations.Services.IServices;

namespace Reliable_Reservations.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);

            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID: {id} not found.");
            }

            return _mapper.Map<UserDto>(user);
        }


        public async Task<UserDto?> GetUserByEmailAsync(string email)
        {
            var existingUser = _userRepository.GetUserByEmailAsync(email);

            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with {email} not found.");
            }

            return _mapper?.Map<UserDto>(existingUser);
        }


        public async Task<UserDto?> CreateUserAsync(UserCreateDto userCreateDto)
        {
            var userExists = _userRepository.UserExistsAsync(userCreateDto.Email);

            if (userExists != null)
            {
                throw new Exception("Email is already in use");
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(userCreateDto.Password);

            var newUser = new User
            {
                FirstName = userCreateDto.FirstName,
                LastName = userCreateDto.LastName,
                Email = userCreateDto.Email,
                PasswordHash = passwordHash
            };

            await _userRepository.AddUserAsync(newUser);

            return _mapper.Map<UserDto>(newUser);
        }
    }
}
