﻿using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data;

namespace P01_HospitalDatabase
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var db = new HospitalContext();
            db.Database.Migrate();
        }
    }
}
