using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Reliable_Reservations.Data.Repos.IRepos;
using Reliable_Reservations.Models;
using Reliable_Reservations.Models.DTOs.Admin;
using Reliable_Reservations.Models.DTOs.MenuItem;
using Reliable_Reservations.Services.IServices;

namespace Reliable_Reservations.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public AdminService(IAdminRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }

        public async Task<AdminDto> GetAdminByIdAsync(int id)
        {
            var user = await _adminRepository.GetAdminByIdAsync(id);

            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID: {id} not found.");
            }

            return _mapper.Map<AdminDto>(user);
        }


        public async Task<Admin?> GetAdminByEmailAsync(string email)
        {
            var existingUser = await _adminRepository.GetAdminByEmailAsync(email);

            //if (existingUser == null)
            //{
            //    throw new KeyNotFoundException($"User with {email} not found.");
            //}

            return _mapper.Map<Admin>(existingUser);
        }


        public async Task<AdminDto?> CreateAdminAsync(AdminCreateDto userCreateDto)
        {
            var userExists = await _adminRepository.AdminExistsAsync(userCreateDto.Email);

            if (userExists)
            {
                throw new Exception("Email is already in use");
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(userCreateDto.Password);

            var newUser = new Admin
            {
                FirstName = userCreateDto.FirstName,
                LastName = userCreateDto.LastName,
                Email = userCreateDto.Email,
                PasswordHash = passwordHash
            };

            await _adminRepository.AddAdminAsync(newUser);

            return _mapper.Map<AdminDto>(newUser);
        }
    }
}
