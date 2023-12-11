using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4_Bondareva.Models;
using System.Data.Entity.Migrations;

namespace Lab4_Bondareva
{
    public static class AppData
    {
        public static Lab4Entities1 db = new Lab4Entities1();

        public static Lab4Table SearchInfo(string name, string messege)
        {
            return db.Lab4Table.FirstOrDefault(u => u.Name_ == name && u.Message_ == messege);
        }


        public static Lab4Table GetById(int id)
        {
            return db.Lab4Table.FirstOrDefault(x => x.ID == id);
        }

        public static Lab4Table GetByName(string name)
        {
            return db.Lab4Table.FirstOrDefault(x => x.Name_ == name);
        }

        public static void AddRecord(string name, string messege)
        {
            Lab4Table recordNode1 = db.Lab4Table.FirstOrDefault(x => x.Name_ == name && x.Message_ == messege);
            if (recordNode1 == null)
            {
                Lab4Table recordNode = new Lab4Table();
                recordNode.Name_ = name;
                recordNode.Message_ = messege;
                db.Lab4Table.Add(recordNode);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Такой пользователь с этой записью уже есть!");
            }
        }

        public static void UpdateRecord(int id, string messageUpdate)
        {
            Lab4Table recordNode = db.Lab4Table.FirstOrDefault(x => x.ID == id);
            recordNode.Message_ = messageUpdate;

            db.Lab4Table.AddOrUpdate(recordNode);
            db.SaveChanges();
        }

        public static void RemoveRecord(int id)
        {
            Lab4Table recordNode = db.Lab4Table.FirstOrDefault(x => x.ID == id);
            db.Lab4Table.Remove(recordNode);
            db.SaveChanges();
        }
    }
}
