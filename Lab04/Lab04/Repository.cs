using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab04_QuanLySanPham
{
    public class Repository<T> where T : IEntity
    {
        private readonly List<T> _items = new List<T>();

        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            if (FindById(item.Id) != null)
                throw new InvalidOperationException($"Id \"{item.Id}\" đã tồn tại trong repository.");
            _items.Add(item);
        }

        public bool Remove(string id)
        {
            T item = FindById(id);
            return item != null && _items.Remove(item);
        }

        public T FindById(string id)
        {
            if (id == null) return default;
            return _items.FirstOrDefault(x => string.Equals(x.Id, id.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        public List<T> Find(Func<T, bool> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            return _items.Where(predicate).ToList();
        }

        public List<T> GetAll()
        {
            return new List<T>(_items);
        }
    }
}
