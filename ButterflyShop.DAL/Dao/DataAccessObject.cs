﻿using System;
using System.Data;

namespace FurnitureShop.DAL.Dao
{
    public class DataAccessObject
    {
        protected IDbConnection Connection { get; set; }

        public DataAccessObject(IDbConnection connection) => Connection = connection;
    }
}
