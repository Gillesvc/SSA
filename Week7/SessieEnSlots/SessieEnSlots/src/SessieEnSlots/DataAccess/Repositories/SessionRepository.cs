using LesDemo.DataAccess;
using System.Collections.Generic;
using SessieEnSlots.Models;

namespace SessieEnSlots.DataAccess.Repositories {
    public class SessionRepository {

        private Database _db;

        public SessionRepository(Database db) {
            this._db = db;
        }

        public List<Session> GetSessions() {
            string sql = "SELECT * FROM Session";
            var reader = _db.GetData(sql);
            List<Session> all = new List<Session>();
            while (reader.Read()) {
                all.Add(new Session() {
                    Id = int.Parse(reader["Id"].ToString()),
                    Description = reader["Description"].ToString(),
                    Name = reader["Name"].ToString(),
                    Slot = int.Parse(reader["Slot"].ToString())
                });
            }
            return all;
        }

        public Session GetSession(int id) {
            string sql = "SELECT * FROM Session WHERE Id = @id";
            var parameter = _db.BuildParameter("@id", id);
            var reader = _db.GetData(sql, parameter);

            while (reader.Read()) {
                Session session = new Session() {
                    Id = int.Parse(reader["Id"].ToString()),
                    Description = reader["Description"].ToString(),
                    Name = reader["Name"].ToString(),
                    Slot = int.Parse(reader["Slot"].ToString())
                };
                return session;
            }
            return null;
        }

        public List<Session> GetSessions(int slot) {
            string sql = "SELECT * FROM Session WHERE Slot = @slot";
            var parameter = _db.BuildParameter("@slot", slot);
            var reader = _db.GetData(sql, parameter);
            List<Session> all = new List<Session>();
            while (reader.Read()) {
                all.Add(new Session() {
                    Id = int.Parse(reader["Id"].ToString()),
                    Description = reader["Description"].ToString(),
                    Name = reader["Name"].ToString(),
                    Slot = int.Parse(reader["Slot"].ToString())
                });
            }
            return all;
        }
    }
}
