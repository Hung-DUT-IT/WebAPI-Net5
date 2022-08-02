using MyWebAPI_APP.Data;
using MyWebAPI_APP.Models;

namespace MyWebAPI_APP.Services
{
    public class TypeRepository : ITypeRepository
    {
        private readonly MyDbContext _context;

        public TypeRepository(MyDbContext context )
        {
            _context = context;
        }
        public TypeProductVM AddType(TypeProductModel typeProduct)
        {
            var type = new TypeProduct
            {
                NameType = typeProduct.NameType,
            };
            _context.Add(type);
            _context.SaveChanges();
            return new TypeProductVM
            {
                IdType = type.IdType,
                NameType = type.NameType,
            };
        }

        public void Delete(int id)
        {
            var type = _context.TypeProducts.SingleOrDefault(p => p.IdType == id);
            if (type != null)
            {
                _context.Remove(type);
                _context.SaveChanges();
            }
        }

        public List<TypeProductVM> GetAll()
        {
            var listType = _context.TypeProducts.Select(p => new TypeProductVM
            {
                IdType = p.IdType,
                NameType = p.NameType
            });
            return listType.ToList();
        }

        public TypeProductVM GetTypeByID(int id)
        {
            var type = _context.TypeProducts.SingleOrDefault(p => p.IdType == id );
            if(type != null )
            {
                return new TypeProductVM
                {
                    IdType = type.IdType,
                    NameType = type.NameType,
                };
            }
            return null;
        }

        public void Update(TypeProductVM typeProduct)
        {
            var type = _context.TypeProducts.SingleOrDefault(p => p.IdType == typeProduct.IdType);
            if (type != null)
            {
                type.NameType = typeProduct.NameType;
                _context.SaveChanges();
            }
        }
    }
}
