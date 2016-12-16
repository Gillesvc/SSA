using Oef2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oef2.DataAccess.Repositories{
    public class OrganizationRepository    {
        private Database _db;
        public OrganizationRepository(Database db) {
            this._db = db;
        }
        public List<Organization> GetOrganizations() {
            List<Organization> sessies = new List<Models.Organization>();
            var sql = "SELECT Id, Name FROM Organization";
            var reader = _db.GetData(sql);
            while (reader.Read()) {
                sessies.Add(new Models.Organization() {
                    Id = int.Parse(reader["Id"].ToString()),
                    Name = reader["Name"].ToString()
                });
            }
            return sessies;
        }

        public List<Organization> GetOrganization(int id) {
            List<Organization> sessies = new List<Models.Organization>();
            var sql = "SELECT Id, Name FROM Organization WHERE id = @id";
            var parameter = _db.BuildParameter("@id", id);
            var reader = _db.GetData(sql, parameter);
            while (reader.Read()) {
                sessies.Add(new Models.Organization() {
                    Id = int.Parse(reader["Id"].ToString()),
                    Name = reader["Name"].ToString()
                });
            }
            return sessies;
        }


    }
}

