using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GroupeJardin
    {
        public long Id { get; set; }
        public String NomGroupe { get; set; }
        public long Surface { get; set; }
        public String RueJardin { get; set; }
        public String Ville { get; set; }
        public long CodePostal { get; set; }
        public long BoiteJardin { get; set; }
        public long numRueJardin { get; set; }
        public Personne Proprietaire { get; set; }
        public virtual ICollection<Personne> Membres { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public GroupeJardin()
        {
            Membres = new HashSet<Personne>();
        }
    }
}
