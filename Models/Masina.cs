﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Medii_Mobile_App_Cadis_Voicila.Models
{
 
    
        public class Masina
        {
            [PrimaryKey, AutoIncrement]
            public int ID { get; set; }
            public string Description { get; set; }
            [OneToMany]
            public List<ListMasina> ListMasini { get; set; }
        }
    }

