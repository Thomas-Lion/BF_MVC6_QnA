using System.Collections;
using System.Collections.Generic;

namespace MVC6_QAndA.CC.Interfaces
{
    public interface IRepository<E> where E: class
    {
        public E Insert(E entity);
        public E Update(E entity);
        public E Get(int Id);
        public ICollection<E> GetAll();
        public int Save();
    }
}