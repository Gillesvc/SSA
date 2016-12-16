using Oef2.DataAccess;
using Oef2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oef2.DAL.Repositories
{
    public class SessieRepository
    {
        private Database _db;

        public SessieRepository(Database db) {
            this._db = db;
        }

        public List<Session> GetSessies() {
            List<Session> s = new List<Session>();
            var reader = _db.GetData("SELECT * FROM Events");
            while (reader.Read())
            {
                s.Add(new Models.Session()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Description = reader["Description"].ToString(),
                    Name = reader["Name"].ToString(),
                    Slot = int.Parse(reader["Slot"].ToString())
                });
            }
            return s;
        }

        //public List<Session> GetSessies(int slot) {
        //    List<Session> s = new List<Session>();
        //    var reader = _db.GetData("SELECT * FROM Events WHERE slot=@slot");
        //    while (reader.Read())
        //    {
        //        s.Add(new Models.Session()
        //        {
        //            Id = int.Parse(reader["Id"].ToString()),
        //            Description = reader["Description"].ToString(),
        //            Name = reader["Name"].ToString(),
        //            Slot = int.Parse(reader["Slot"].ToString())
        //        });
        //    }
        //    return s;
        //}
    }
}
