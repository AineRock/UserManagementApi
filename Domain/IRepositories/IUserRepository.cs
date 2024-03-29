﻿using Domain.Entities;

namespace Domain.IRepositories
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User newUser);
    }
}
