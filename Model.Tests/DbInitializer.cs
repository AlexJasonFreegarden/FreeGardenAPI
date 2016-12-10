using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Tests
{
    class DbInitializer : DropCreateDatabaseAlways<JardinContext>
    {

        protected override void Seed(JardinContext context)
        {
            Personne personne1 = new Personne()
            {
                Nom = "Collard",
                Prenom = "Alexandre",
                MotDePasse = "123",
                DateNaissance = new DateTime(1994, 9, 22),
                RemarqueComportement = new List<String>(),
                Mail = "Collard.Alexandre22@gmail.com",
                NumTel = 495304357
            };
            Personne personne2 = new Personne()
            {
                Nom = "Yagami",
                Prenom = "Light",
                MotDePasse = "123",
                DateNaissance = new DateTime(1996, 10, 3),
                RemarqueComportement = new List<String>(),
                Mail = "Light.Yagami@gmail.com",
                NumTel = 495304357
            };
            Personne personne3 = new Personne()
            {
                Nom = "...",
                Prenom = "L",
                MotDePasse = "123",
                DateNaissance = new DateTime(1996, 3, 10),
                RemarqueComportement = new List<String>(),
                Mail = "...L@gmail.com",
                NumTel = 495304357
            };
            Personne personne4 = new Personne()
            {
                Nom = "Pers4",
                Prenom = "Damien",
                MotDePasse = "123",
                DateNaissance = new DateTime(1994, 9, 22),
                RemarqueComportement = new List<String>(),
                Mail = "Pers4.Damien@gmail.com",
                NumTel = 495304357
            };


            Personne personne5 = new Personne()
            {
                Nom = "AdminGrp2",
                Prenom = "Jean",
                MotDePasse = "123",
                DateNaissance = new DateTime(1986, 4, 5),
                RemarqueComportement = new List<String>(),
                Mail = "Jean@gmail.com",
                NumTel = 495304357
            };
            Personne personne6 = new Personne()
            {
                Nom = "Pers2Grp2",
                Prenom = "Jaques",
                MotDePasse = "123",
                DateNaissance = new DateTime(1974, 9, 8),
                RemarqueComportement = new List<String>(),
                Mail = "Jaques@gmail.com",
                NumTel = 495304357
            };

            GroupeJardin groupeJardin1 = new GroupeJardin()
            {
                NomGroupe = "Beaux Jardins",
                Surface = 10,
                RueJardin = "Rue des anges verts",
                Ville = "Ville Sainte",
                CodePostal = 3600,
                numRueJardin = 1,
                Proprietaire = personne1,
                Membres = new HashSet<Personne>()
                {
                    personne2,
                    personne3,
                    personne4,
                    personne5
                }
            };

            GroupeJardin groupeJardin2 = new GroupeJardin()
            {
                NomGroupe = "Jardins Gris",
                Surface = 100,
                RueJardin = "Rue des morts",
                Ville = "Ville Jaune",
                CodePostal = 6600,
                numRueJardin = 7,
                Proprietaire = personne5,
                Membres = new HashSet<Personne>()
                {
                    personne4,
                    personne6
                }
            };


            context.Personnes.Add(personne1);
            context.Personnes.Add(personne2);
            context.Personnes.Add(personne3);
            context.Personnes.Add(personne4);
            context.Personnes.Add(personne5);
            context.Personnes.Add(personne6);
            context.GroupesJardin.Add(groupeJardin1);
            context.GroupesJardin.Add(groupeJardin2);
            context.SaveChanges();
        }
    }
}
