using Oef2.Models;
using Oef2.PresentationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oef2.DataAccess.Repositories
{
    public class RegistrationRepository{
        private Database _db;
        public RegistrationRepository(Database db) {
            this._db = db;
        }

        public List<Registration> GetRegistrations() {
            List<Registration> registration = new List<Models.Registration>();
            var sql = "SELECT Id, Name, Firstname, Email, Age, ClosingParty FROM Registration";
            var reader = _db.GetData(sql);
            while (reader.Read()) {
                registration.Add(new Models.Registration() {
                    RegisterId = int.Parse(reader["Id"].ToString()),
                    Naam = reader["Name"].ToString(),
                    Voornaam = reader["Firstname"].ToString(),
                    Email = reader["Email"].ToString(),
                    Leeftijd = int.Parse(reader["Age"].ToString()),
                    ClosingParty = (bool)reader["ClosingParty"]
                });
            }
            return registration;
        }

        public List<Registration> GetRegistrationsSlot(int? slot)
        {
            List<Registration> registration = new List<Models.Registration>();
            var sql = "Select * From Registration r INNER JOIN Register_Session rs on rs.SessionId = @slot";
            var parameter = _db.BuildParameter("@slot", slot);
            var reader = _db.GetData(sql, parameter);
            while (reader.Read())
            {
                registration.Add(new Models.Registration()
                {
                    RegisterId = int.Parse(reader["Id"].ToString()),
                    Naam = reader["Name"].ToString(),
                    Voornaam = reader["Firstname"].ToString(),
                    Email = reader["Email"].ToString(),
                    Leeftijd = int.Parse(reader["Age"].ToString()),
                    ClosingParty = (bool)reader["ClosingParty"]
                });
            }
            return registration;
        }

        public List<Registration> InsertRegistration(PMRegistration _user) {

            List<Registration> regis = new List<Models.Registration>();


            var n = _db.BuildParameter("@name", _user.newRegistration.Naam);
            var fn = _db.BuildParameter("@firstname", _user.newRegistration.Voornaam);
            var em = _db.BuildParameter("@email", _user.newRegistration.Email);
            var age = _db.BuildParameter("@age", _user.newRegistration.Leeftijd);
            var p = _db.BuildParameter("@party", _user.newRegistration.ClosingParty);
            var orid = _db.BuildParameter("@organisationId", _user.newRegistration.SelectedOrganization);

            var s1 = _db.BuildParameter("@slot1", _user.newRegistration.SelectedSlot1);
            var s2 = _db.BuildParameter("@slot2", _user.newRegistration.SelectedSlot2);
            var s3 = _db.BuildParameter("@slot3", _user.newRegistration.SelectedSlot3);

            string sql = "INSERT INTO Registration (Name, Firstname, Email, Age, ClosingParty) VALUES (@name, @firstname, @email, @age, @party)";

            var register_id = _db.InsertData(sql, n, fn, em, age, p);

            //int selected_Id = 0;
            //sql = "SELECT Id FROM Registration";
            //var reader = _db.GetData(sql);
            //while (reader.Read()) {

            //    selected_Id = int.Parse(reader["Id"].ToString());

            // };

            //selected_Id


            return null;
        }
    }
}
