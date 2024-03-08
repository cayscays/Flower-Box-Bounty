/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Operations;
using MongoDB.Driver.Core.Connections;

namespace Data
{
    public static class ConnectionManager
    {
        public static Connection DatabaseConnection
        {
            get
            {
                try
                {
                    return new Connection();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }


}
