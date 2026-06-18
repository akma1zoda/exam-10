using Application.Common;
using Application.DTOs.Users;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.BackGroundServices;

public class DeleteUsersAsync(UserManager<User> userManager)
{
    public async Task DeleteNotConfirmedUsersAsync()
    {
        var users = userManager.Users.ToList();
        
        var confirmedUsers = users.Where(u => u.EmailConfirmed == false).ToList();
        
        foreach (var s in confirmedUsers)
        {
            await userManager.DeleteAsync(s);
        }
    }
}