﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Personne
    {
        public long Id { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public String MotDePasse { get; set; }
        public DateTime DateNaissance { get; set; }
        public IList<String> RemarqueComportement { get; set; }
        public String Mail { get; set; }
        public long NumTel { get; set; }
        public virtual IList<GroupeJardin> GroupesJardin { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public Personne()
        {
            GroupesJardin = new List<GroupeJardin>();
            RemarqueComportement = new List<String>();
        }
    }
}
