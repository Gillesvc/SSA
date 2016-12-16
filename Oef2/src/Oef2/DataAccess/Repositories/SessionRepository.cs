using Oef2.DataAccess;
using Oef2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oef2.DataAccess.Repositories
{
    public class SessionRepository{
        private Database _db;
        public SessionRepository(Database db) {
            this._db = db;
        }
        public List<Session> GetSessions() {
            List<Session> sessies = new List<Models.Session>();
            var sql = "SELECT Id, Name, Description, Slot FROM Sessies";
            var reader = _db.GetData(sql);
            while (reader.Read()) {
                sessies.Add(new Models.Session() {
                    Id = int.Parse(reader["Id"].ToString()),
                    Description = reader["Description"].ToString(),
                    Name = reader["Name"].ToString(),
                    Slot = int.Parse(reader["Slot"].ToString())
                });
            }
            return sessies;
        }
        public List<Session> GetSessions(int slot) {
            List<Session> sessies = new List<Models.Session>();
            var sql = "SELECT Id, Name, Description, Slot FROM Sessies WHERE slot = @slot";
            var parameter = _db.BuildParameter("@slot", slot);
            var reader = _db.GetData(sql, parameter);
            while (reader.Read()) {
                sessies.Add(new Models.Session() {
                    Id = int.Parse(reader["Id"].ToString()),
                    Description = reader["Description"].ToString(),
                    Name = reader["Name"].ToString(),
                    Slot = int.Parse(reader["Slot"].ToString())
                });
            }
            return sessies;
        }
        public Session FindSession(int id) {
            var sql = "SELECT Id, Name, Description, Slot FROM Sessies WHERE Id = @id";
            var parameter = _db.BuildParameter("@id", id);
            var reader = _db.GetData(sql, parameter);
            while (reader.Read()) {
                Session sessies = new Models.Session() {
                    Id = int.Parse(reader["Id"].ToString()),
                    Description = reader["Description"].ToString(),
                    Name = reader["Name"].ToString(),
                    Slot = int.Parse(reader["Slot"].ToString())
                };
                return sessies;
            }
            //id niet gekend fout weergeven
            return null;
        }
        public Session AddSession(string Name, int? Slot, string Description) {
           
            var parameterName = _db.BuildParameter("@Name", Name);
            var parameterSlot = _db.BuildParameter("@Slot", Slot);
            var parameterDescription = _db.BuildParameter("@Description", Description);

            var sql = "INSERT INTO Sessies(Name, Slot, Description) VALUES (@Name, @Slot, @Description)";

            var insert = _db.InsertData(sql, parameterName, parameterSlot, parameterDescription);

            Session s = new Session();
            s.Name = Name;
            s.Slot = Convert.ToInt32(Slot);
            s.Description = Description;
            return s;

        }

        public Session EditSession(int? Id, string Name, int? Slot, string Description)
        {

            var parameterId = _db.BuildParameter("@Id", Id);
            var parameterName = _db.BuildParameter("@Name", Name);
            var parameterSlot = _db.BuildParameter("@Slot", Slot);
            var parameterDescription = _db.BuildParameter("@Description", Description);

            var sql = "UPDATE Sessies SET Name = @Nama, Slot = @Slot, Description = @Description WHERE Id = @Id; ";

            var insert = _db.InsertData(sql, parameterId, parameterName, parameterSlot, parameterDescription);

            Session s = new Session();
            s.Id = Convert.ToInt32(Id);
            s.Name = Name;
            s.Slot = Convert.ToInt32(Slot);
            s.Description = Description;
            return s;

        }
    }
}
