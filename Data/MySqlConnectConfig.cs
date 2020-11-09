using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace BlazerDapperCrud.Data 
{
    public class MySqlConnectConfig {
        ///∆: - ©Global-PROPERTIES
        //∆..............................
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string Value { get; }        
        //∆..............................

        ///∆ ............. Constructor .............
        public MySqlConnectConfig(string value) => Value = value;
    }
}