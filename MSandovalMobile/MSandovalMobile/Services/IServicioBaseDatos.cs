using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSandovalMobile.Services
{
    public interface IServicioBaseDatos<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(T dato);
        Task<T> Update(T dato);
        Task<bool> Delete(int dato);

    }
}
