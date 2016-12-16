using Oef2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oef2.DataAccess.Repositories{
    public class DeviceRepository {
        private Database _db;
        public DeviceRepository(Database db) {
            this._db = db;
        }

        public List<Device> GetDevices() {
            List<Device> devices = new List<Models.Device>();
            var sql = "SELECT Id, Name FROM Devices";
            var reader = _db.GetData(sql);
            while (reader.Read()) {
                devices.Add(new Models.Device() {
                    Id = int.Parse(reader["Id"].ToString()),
                    Name = reader["Name"].ToString()
                });
            }
            return devices;
        }

    }
}
