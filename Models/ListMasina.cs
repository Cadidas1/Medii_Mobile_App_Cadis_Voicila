using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;


namespace Medii_Mobile_App_Cadis_Voicila.Models
{
    
    
        public class ListMasina
        {
            [PrimaryKey, AutoIncrement]
            public int ID { get; set; }
            [ForeignKey(typeof(Inchiriere))]
            public int InchiriereID { get; set; }
            public int MasinaID { get; set; }
        }
    }

