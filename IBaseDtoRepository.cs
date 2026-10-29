using System;
using System.Collections.Generic;

namespace TradingCompany.DAL.Interfaces
{
    public interface IBaseDtoRepository<TDto> : IDisposable
    {
        void Create(TDto dto);
        TDto? GetById(int id);
        IEnumerable<TDto> GetAll();
        void Update(int id, TDto dto);
        void Delete(int id);
    }
}