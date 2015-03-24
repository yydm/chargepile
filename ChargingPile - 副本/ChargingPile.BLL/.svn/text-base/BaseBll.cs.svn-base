using System.Data;

namespace ChargingPile.BLL
{
    public abstract class BaseBll<T>
    {
        public abstract bool Exist(T bean);
        public abstract void Add(T bean);

        public abstract void Del(T bean);

        public abstract void Modify(T bean);

        public abstract DataTable Query(T bean);

        public abstract DataTable QueryByPage(T bean, int page, int rows);

        public abstract DataTable QueryByPage(T bean, int page, int rows, ref int count);
    }
}
