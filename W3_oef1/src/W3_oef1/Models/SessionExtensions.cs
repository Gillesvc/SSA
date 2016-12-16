using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CookieDemo {
    public static class SessionExtensions {

        public static void SetObject<T>(this ISession session, string key, T obj){
            byte[] data;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream()) {
                bf.Serialize(ms, obj);
                data = ms.ToArray();
            }
            session.Set(key, data);
        }

        public static T GetObject<T>(this ISession session, string key)   {
            var data = session.Get(key);
            if (data == null) {
                return default(T);
            }

            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(data, 0, data.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            T obj = (T)binForm.Deserialize(memStream);
            return obj;
        }

        //public static void SetPerson(this ISession session, string key, Person person) {
        //    byte[] data;
        //    BinaryFormatter bf = new BinaryFormatter();
        //    using (MemoryStream ms = new MemoryStream()) {
        //        bf.Serialize(ms, person);
        //        data = ms.ToArray();
        //    }
        //    session.Set(key, data);
        //}

        //public static Person GetPerson(this ISession session, string key) {
        //    var data = session.Get(key);
        //    if (data == null) {
        //        return null;
        //    }

        //    MemoryStream memStream = new MemoryStream();
        //    BinaryFormatter binForm = new BinaryFormatter();
        //    memStream.Write(data, 0, data.Length);
        //    memStream.Seek(0, SeekOrigin.Begin);
        //    Person obj = (Person)binForm.Deserialize(memStream);

        //    return obj;

        //}

        public static bool? GetBoolean(this ISession session, string key) {
            var data = session.Get(key);
            if (data == null) {
                return null;
            }
            return BitConverter.ToBoolean(data, 0);
        }

        public static void SetBoolean(this ISession session, string key, bool value) {
            session.Set(key, BitConverter.GetBytes(value));
        }
    }
}
