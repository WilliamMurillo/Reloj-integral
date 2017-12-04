using System;
using System.Data;
using System.IO;
using SQLite;

namespace Principal.Gestor_BD
{
    [Table("TblCalendario")]
    public class ClsTablas
    {
        [PrimaryKey,Column("_Id")]
        public int Id { get; set; }
        public string nombres
        {
            get;
            set;
        }
        public string apellidos
        {
            get;
            set;
        }
        public string tipo { set; get; }

        public string telefono { get; set; }

        public string correo { get; set; }
    }
    }
