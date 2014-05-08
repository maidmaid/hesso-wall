using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ClassLibrary1
{
    public class User
    {
        public int UserId { get; set; }
        public String UserName { get; set; }
        public String UserPassword { get; set; }
    }
}
