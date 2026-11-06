using System;
using System.Collections.Generic;
using SQLite;
using System.Text;

namespace bguerreroS5.Models
{
    [Table("persona")]
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(25)]
        public string Nombre { get; set; }
    }
}
