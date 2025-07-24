using OnlineStoreAuthAPI.Data;
using OnlineStoreAuthAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace OnlineStoreAuthAPI.Services
{
    public class AuthService
    {
        private readonly AppDbContext _db;
        public AuthService(AppDbContext db) => _db = db;

       public async Task<bool> RegisterAsync(string name, string surname, string username, string email, string password)
{
    if (await _db.Users.AnyAsync(u => u.Username == username || u.Email == email))
        return false;

    var user = new User
    {
        Name = name,
        Surname = surname,
        Username = username,
        Email = email,
        PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
    };

    _db.Users.Add(user);
    await _db.SaveChangesAsync();
    return true;
}
public async Task<IEnumerable<User>> GetAllUsersAsync()
{
    return await _db.Users.ToListAsync();
}


        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            var user = await _db.Users.SingleOrDefaultAsync(u => u.Username == username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return null;

            return user;
        }
    }
}
