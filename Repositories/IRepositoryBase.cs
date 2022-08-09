﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBingoAPI.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task Add(T model);
        Task<T> Get(Guid id);
        Task Update(T model);
        Task Delete(T model);
        Task<IEnumerable<T>> GetAll();
    }
}
