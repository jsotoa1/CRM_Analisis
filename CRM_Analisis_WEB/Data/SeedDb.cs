using CRM_Analisis_WEB.Data.Entidades;
using CRM_Analisis_WEB.Helpers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Analisis_WEB.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRolesAsync("Administrador", "Solo area de mensajes", true);

            var rolI =  _context.Roles.FirstOrDefault(r => r.Name == "Administrador");
            Rol rol = new Rol
            {
                Id = rolI.Id,
                Name = rolI.Name,
                ConcurrencyStamp = rolI.ConcurrencyStamp,
                NormalizedName = rolI.NormalizedName
            };
            await CheckUserAsync("12345", "José", "Soto", "jsotoa1@miumg.edu.gt", "322 311 4620", "Calle Luna Calle Sol", rol);
        }

        private async Task CheckRolesAsync(string name, string descripccion, bool estado)
        {
            Rol rol = new Rol
            {
                Name = name,
                Descripcion = descripccion,
                Estado = estado
            };

            await _userHelper.AddRoleAsync(rol);
        }

        private async Task<User> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            Rol rol)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    PrimerNombre = firstName,
                    PrimerApellido = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Direccion = address,
                    Documento = document,
                    rol = rol
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, rol.Name);
            }

            return user;
        }

    }
}
