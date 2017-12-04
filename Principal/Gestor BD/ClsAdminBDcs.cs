using System;
using Android.OS;
using System.IO;
using Mono.Data;
using SQLite;
using Mono.Data.Sqlite;

namespace Principal.Gestor_BD
{
    public class ClsAdminBDcs
    {
        //Code para crear la base de datos
        public string mtCrearBaseDatos()
        {
            var output = "";
            output += "Creando base de datos si no existe.";
            string dbPath = Path.Combine(System.Environment.GetFolderPath
                (System.Environment.SpecialFolder.Personal), "DBCalendario.db3");
            var db = new SqliteConnection(dbPath);
            output += "\nBase de datos Creada ...";
            return output;
        }

        //code para crear una tabla
        public string mtCrearTabla()
        {
            try
            {
                string dbPath = Path.Combine(System.Environment.GetFolderPath
               (System.Environment.SpecialFolder.Personal), "DBCalendario.db3");
                var db = new SQLiteConnection(dbPath);
                db.CreateTable<ClsTablas>();
                string result = "Tabla creada";
                return result;
            }
            catch (Exception e)
            {
                return "Error :" + e.Message;
            }

        }

        //code para insertar los datos
        public string mtInsertarDatos(int parCed, string parNombres, string parApellidos, string tipo, string tel, string cor)
        {
            try
            {
                string dbPath = Path.Combine(System.Environment.GetFolderPath
            (System.Environment.SpecialFolder.Personal), "DBCalendario.db3");
                var db = new SQLiteConnection(dbPath);
                ClsTablas item = new ClsTablas();
                item.Id= parCed;
                item.nombres = parNombres;
                item.apellidos = parApellidos;
                item.tipo = tipo;
                item.telefono = tel;
                item.correo = cor;
                db.Insert(item);
                return "Datos insertados";
            }
            catch (Exception e)
            {
                return "Error :" + e.Message;
            }
        }
        //code para mostrar los datos
        public ClsTablas mtMostrarDatosTel(int ced)
        {
            try
            {
                string dbPath = Path.Combine(System.Environment.GetFolderPath
              (System.Environment.SpecialFolder.Personal), "DBCalendario.db3");
                var db = new SQLiteConnection(dbPath);

                var item = db.Get<ClsTablas>(ced);
                //string[] array = new string[6];
                //array[0] = item.Id.ToString();
                //array[1] = item.nombres.ToString();
                //array[2] = item.apellidos.ToString();
                //array[3] = item.telefono.ToString();
                //array[4] = item.tipo.ToString();
                //array[5] = item.correo.ToString();

                return item;
            }
            catch (Exception e)
            {

                return null;
            }
        }
    }
}