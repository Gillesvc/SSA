

using SessieEnSlots.Models;
using System;
using System.Collections.Generic;

namespace SessieEnSlots.DataAccess {
    public class Data
    {
 
        private static List<Organization> organizations = new List<Organization>();
        private static List<Device> devices = new List<Device>();

        static Data()
        {
 
            organizations.Add(new Organization() { Id = 1, Name = "Howest" });
            organizations.Add(new Organization() { Id = 2, Name = "Vives" });
            organizations.Add(new Organization() { Id = 3, Name = "HoGent" });
            organizations.Add(new Organization() { Id = 4, Name = "HoLimburg" });
            organizations.Add(new Organization() { Id = 4, Name = "De blauwe smurfen" });

            devices.Add(new Device() { Id = 1, Name = "Laptop" });
            devices.Add(new Device() { Id = 2, Name = "Tablet" });
            devices.Add(new Device() { Id = 3, Name = "Apple Watch" });
        }

        internal static void DeleteOrganization(Organization org) {
            throw new NotImplementedException();
        }

        public static void AddOrganization(Organization org) {
            org.Id = organizations.Count + 1;
            organizations.Add(org);
        }

        public static List<Device> GetDevices()
        {
            return devices;
        }

        public static List<Organization> GetOrganizations()
        {
            return organizations;
        }

        public static Organization GetOrganization(int id)
        {
            return organizations.Find(o => o.Id == id);
        }
    }
}