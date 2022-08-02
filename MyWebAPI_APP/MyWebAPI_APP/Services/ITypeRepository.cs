using MyWebAPI_APP.Models;

namespace MyWebAPI_APP.Services
{
    public interface ITypeRepository
    {
        List<TypeProductVM> GetAll();
        TypeProductVM GetTypeByID(int id);
        TypeProductVM AddType(TypeProductModel typeProduct);
        void Update(TypeProductVM typeProduct);
        void Delete(int id);
    }
}
