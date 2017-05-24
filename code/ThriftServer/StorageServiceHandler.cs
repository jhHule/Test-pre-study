using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using storage;

namespace ThriftServer
{
    public class StorageServiceHandler : StorageService.Iface
    {
        private readonly Dictionary<int, StoragePoint> _point;

        public StorageServiceHandler()
        {
            _point = new Dictionary<int, StoragePoint>
            {
                {0, new StoragePoint {StorageId = 0, Name = "Storage 1", Description = "Description 1"}},
                {1, new StoragePoint {StorageId = 1, Name = "Storage 2", Description = "Description 2"}},
                {2, new StoragePoint {StorageId = 2, Name = "Storage 3", Description = "Description 3"}},
                {3, new StoragePoint {StorageId = 3, Name = "Storage 4", Description = "Description 4"}}
            };
        }

        public bool AddStoragePoint(StoragePoint point)
        {
            if (!_point.ContainsKey(point.StorageId))
            {
                _point[point.StorageId] = point;
                return true;
            }
            return false;
        }

        public void ClearStorage()
        {
            _point.Clear();
        }

        public void ping()
        {
            Console.WriteLine("ping()");
        }

        public List<StoragePoint> StoragePoints()
        {
            return _point.Values.ToList();
        }

        List<StoragePoint> StorageService.ISync.storagePoints()
        {
            return _point.Values.ToList();
        }

        public string read(int id)
        {
            Console.WriteLine(String.Format("read id:{0}",id));
            if (!_point.ContainsKey(id))
            {
                return "N/A";
            }

            if (_point[id].Value == null)
            {
                return "N/A";
            }

            return _point[id].Value;
        }

        public bool write(int id, string value)
        {
            Console.WriteLine(String.Format("write id:{0}", id));
            if (string.IsNullOrEmpty(value))
                return false;

            if (!_point.ContainsKey(id))
            {
                return false;
            }

            _point[id].Value = value;
            return true;
        }
      

        public void close()
        {
            throw new NotImplementedException();
        }
    }
}
