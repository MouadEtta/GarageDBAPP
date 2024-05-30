using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.EntitySql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaragedbAPP
{
    public class Car
    {

        public string Targa { get; set; }
        public string Marca { get; set; }

        public string Tipo { get; set; }

        public string dataDiImmatricolazione { get; set; }
    }
}
