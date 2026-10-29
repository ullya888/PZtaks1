using TradingCompany.DAL.Models;
namespace TradingCompany.DAL.Repositories
{
    public abstract class BaseDtoRepository<TEntity, TDto> : IDisposable where TEntity : class
    {
        protected readonly TradingCompanyContext _context;
        private bool _disposed = false;

        protected BaseDtoRepository(TradingCompanyContext context)
        {
            _context = context;
        }

        protected abstract TEntity MapToEntity(TDto dto);
        protected abstract TDto MapToDto(TEntity entity);
        protected abstract TEntity? FindEntity(int id);
        protected abstract void UpdateEntityProperties(TEntity entity, TDto dto);

        public virtual void Create(TDto dto)
        {
            var entity = MapToEntity(dto);
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public virtual TDto? GetById(int id)
        {
            var entity = FindEntity(id);
            return entity == null ? default : MapToDto(entity);
        }

        public virtual IEnumerable<TDto> GetAll()
        {
            return _context.Set<TEntity>().ToList().Select(MapToDto);
        }

        public virtual void Update(int id, TDto dto)
        {
            var entity = FindEntity(id);
            if (entity != null)
            {
                UpdateEntityProperties(entity, dto);
                _context.Set<TEntity>().Update(entity);
                _context.SaveChanges();
            }
        }

        public virtual void Delete(int id)
        {
            var entity = FindEntity(id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }
}