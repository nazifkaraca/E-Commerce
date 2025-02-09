﻿using E_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Respositories.Interfaces
{
    public interface ISettingRepository
    {
        Task<Setting> GetByIdAsync(int id);
        Task UpdateByIdAsync(int id);
    }
}
