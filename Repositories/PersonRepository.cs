using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace bguerreroS5.Repositories
{
    public class PersonRepository
    {
        string _dbPath;
        private SQLiteConnection _conn;
        public string StatusMessage { get; set; }

        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;
            Init();
        }

        private void Init()
        {
            if (_conn != null)
                return;
            _conn = new SQLiteConnection(_dbPath);
            _conn.CreateTable<Models.Persona>();
        }

        //INSERT
        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Nombre requerido");

                result = _conn.Insert(new Models.Persona { Nombre = name});
                StatusMessage = string.Format("{0} registro(s) añadido(s) [Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to añadir {0}. Error: {1}", name, ex.Message);
            }
        }

        //SELECT
        public List<Models.Persona> GetAllPersons()
        {
            try
            {
                Init();
                return _conn.Table<Models.Persona>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return new List<Models.Persona>();
        }

        //DELETE
        public bool DeletePerson(Models.Persona persona)
        {
            try
            {
                Init();
                return _conn.Delete(persona) > 0;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to eliminar {0}. Error: {1}", persona.Nombre, ex.Message);
                return false;
            }
        }
    }
}
