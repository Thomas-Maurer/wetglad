using System;
using System.Collections.Generic;
using System.Linq;

namespace Wetglad
{
	public class Gladiateur
	{
		static int nb_gladiateur=0;
		int id_gladiateur;
		string nom;
		Ratio ratio;
		List<Equipement> mesEquipements;


		public Gladiateur (string nomglad)
		{
			nb_gladiateur++;
			nom = nomglad;
			id_gladiateur = nb_gladiateur;
			ratio = new Ratio (0, 0);
			mesEquipements = new List<Equipement> ();
		}
        public string getnom()
        {
            return nom;
        }

		public void addeqtoglad(Equipement stuff)
		{
            if (getchargeglad() + stuff.getpointequipement() <= 10)
            {
                mesEquipements.Add(stuff);
            }
            else
            {
                Console.WriteLine("Charge maximum pour un gladiateur");
                Console.WriteLine("L'équipement " + stuff.getnomequipement() + " n'a pas pu être ajouté");
            }
		}


		public void showglad()
		{
			Console.WriteLine ( "Nom du glad : "+ nom +" Victoires : "+ratio.getvictoire()+ " / Defaites : "+ratio.getdefaite());
			Console.WriteLine ( " Le ratio du gladiateur est de : "+ ratio.getratio().ToString() +"%");
		}

		public int getchargeglad()
		{
			int result = 0;
			foreach (Equipement objet in mesEquipements) {
				result = result + objet.getpointequipement ();
			}
			return result;
		}

		// show Gear of glad
		public void showGear()
		{
			Console.WriteLine("Le gladiateur : "+ nom +" est équipé de : ");
			foreach (Equipement stuff in mesEquipements) 
			{
				stuff.showStuff();
			}

		}


        public bool attaque(Gladiateur challengerglad)
        {
            if (touche(this.getWeapons()[0]))
            {
                if (challengerglad.getprotect().Count >0 && block(challengerglad.getprotect()[0]))
                {
                    //attaque réussi mais bloqué
                    Console.WriteLine(" Attaque de " + this.getnom() + " bloqué par " + challengerglad.getnom());
                    return false;
                }
                //attaque réussi
                else
                {
                    Console.WriteLine(" Attaque de " + this.getnom() + " touche " + challengerglad.getnom());
                    return true;
                }
            }
            //Attaque fail
            else
            {
                Console.WriteLine(" Attaque de " + this.getnom() + " loupe " + challengerglad.getnom());
                return false;
            }
        }


        public bool combat(Gladiateur challenger)
        {
            int nbcoup = 1;
            bool reussi;
            do
            {
                reussi = this.attaque(challenger);
                nbcoup++;
            }
            while (!reussi && nbcoup < this.getWeapons().Count );

            return reussi;

        }
        //Check if the glad block or not
        public bool block(EqDefensif defense)
        {
            int block = RandomNumber(1, 100);
            return block <= defense.getblocage();

        }
        //Check if the glad touch or not
        public bool touche(EqOffensif arme)
        {
            int toucher = RandomNumber(1, 100);
            return toucher <= arme.gettoucher();

        }

        // Get list of weapons of glad
        public List<EqOffensif> getWeapons()
        {
            List<EqOffensif> armes = new List<EqOffensif>();

            foreach (Equipement stuff in mesEquipements)
            {
                if (stuff.getinitiative() >0)
                    armes.Add((EqOffensif) stuff);
            }
            armes = armes.OrderBy(EqOffensif => EqOffensif.getinitiative()).ToList<EqOffensif>();
            return armes;
        }

        // Get list of protect of glad
        public List<EqDefensif> getprotect()
        {
            List<EqDefensif> protects = new List<EqDefensif>();

            foreach (Equipement stuff in mesEquipements)
            {
                if (stuff.getblocage() > 0)
                    protects.Add((EqDefensif)stuff);
            }
            protects = protects.OrderBy(EqDefensif => EqDefensif.getblocage()).ToList<EqDefensif>();
            return protects;
        }

        //Compare two glad to return the one who begin 
        public Gladiateur compareinitiative(Gladiateur glad)
        {
            int initiativeglad1=0;
            int initiativeglad2=0;

            //Boucle stuff glad 1
            foreach (EqOffensif stuff in this.getWeapons())
            {
                    if (stuff.getinitiative() > initiativeglad1)
                        initiativeglad1  = stuff.getinitiative();
            }
            //boucle stuff glad 2
            foreach (EqOffensif stuff in glad.getWeapons())
            {
                    if (stuff.getinitiative() > initiativeglad2)
                        initiativeglad2 = stuff.getinitiative();
            }
            //Compare initiative to know who begin
            if (initiativeglad1 > initiativeglad2)
                return this;
            else return glad;
        }

        //Function to get random number
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }

	}
}

