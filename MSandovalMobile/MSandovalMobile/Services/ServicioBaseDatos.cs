using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using MSandovalMobile.DL;
using Microsoft.EntityFrameworkCore;

namespace MSandovalMobile.Services
{
    public class ServicioBaseDatos<T> : IServicioBaseDatos<T> where T : class
    {
        Conexion bd;
        public ServicioBaseDatos()
        {
            bd = App.BD; //Checar donde se creo
        }
        public virtual async Task<List<T>> GetAll()
        {
            return await bd.Set<T>().ToListAsync();
        }
        public virtual async Task<T> GetById(int id)
        {
            return await bd.Set<T>().FindAsync(id);
        }
        public virtual async Task<T> Add(T dato)
        {
            await bd.Set<T>().AddAsync(dato);
            await bd.SaveChangesAsync();
            return dato;
        }
        public virtual async Task<T> Update(T dato)
        {
            bd.Set<T>().Update(dato);
            await bd.SaveChangesAsync();
            return dato;
        }
        public async Task<bool> Delete(int id)
        {
            var entity = await GetById(id);
            bd.Set<T>().Remove(entity);
            await bd.SaveChangesAsync();
            return true;

        }
    }
}
