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

        //Constructeur
		public Gladiateur (string nomglad)
		{
			nb_gladiateur++;
			nom = nomglad;
			id_gladiateur = nb_gladiateur;
			ratio = new Ratio (0, 0);
			mesEquipements = new List<Equipement> ();
		}
        /// <summary>
        /// GETTER OF GLAD
        /// </summary>

        //Get the total point equipement of one glad
        public int getchargeglad()
        {
            int result = 0;
            foreach (Equipement objet in mesEquipements)
            {
                result = result + objet.getpointequipement();
            }
            return result;
        }

        //get name of one glad
        public string getnom()
        {
            return nom;
        }

        // Get list of weapons of glad
        public List<EqOffensif> getWeapons()
        {
            List<EqOffensif> armes = new List<EqOffensif>();

            foreach (Equipement stuff in mesEquipements)
            {
                if (stuff.getinitiative() > 0)
                    armes.Add((EqOffensif)stuff);
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


        /// <summary>
        /// FUNCTIONS
        /// </summary>

        //ADD stuff to one glad
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
        //Begin a combat against a challenger and check if the gladr win or not against the challenger
        public bool combat(Gladiateur challenger)
        {
            int nbcoup = 1;
            bool reussi;
            do
            {
                reussi = this.attaque(challenger);
                nbcoup++;
            }
            while (!reussi && nbcoup < this.getWeapons().Count);

            return reussi;

        }
        //Check if one glad kill another ( check block + touch)
        public bool attaque(Gladiateur challengerglad)
        {
            List<EqOffensif> Armes = this.getWeapons();
            List<EqDefensif> Protections = challengerglad.getprotect();
            if (touche(Armes[0]))
            {

                if (Protections.Count > 0 && block(Protections[0]))
                {
                    //attaque réussi mais bloqué
                    Console.WriteLine(" Attaque de " + this.getnom() + " bloqué par " + challengerglad.getnom()+" avec "+challengerglad.getprotect()[0].getnomequipement());
                    return false;
                }
                //attaque réussi
                else
                {
                    Console.WriteLine(" Attaque de " + this.getnom() + " touche " + challengerglad.getnom() + " avec " + this.getWeapons()[0].getnomequipement());
                    return true;
                }
            }
            //Attaque fail
            else
            {
                Console.WriteLine(" Attaque de " + this.getnom() + " loupe " + challengerglad.getnom() + " avec " + this.getWeapons()[0].getnomequipement());
                return false;
            }
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



        //Compare two glad to return the one who begin 
        public Gladiateur compareinitiative(Gladiateur glad)
        {
            int initiativeglad1 = 0;
            int initiativeglad2 = 0;

            //Boucle stuff glad 1
            foreach (EqOffensif stuff in this.getWeapons())
            {
                if (stuff.getinitiative() > initiativeglad1)
                    initiativeglad1 = stuff.getinitiative();
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




        /// <summary>
        /// AFFICHAGE
        /// </summary>
        /// 

        //Show sttaributes of glad
		public void showglad()
		{
			Console.WriteLine ( "Nom du glad : "+ nom +" Victoires : "+ratio.getvictoire()+ " / Defaites : "+ratio.getdefaite());
			Console.WriteLine ( " Le ratio du gladiateur est de : "+ ratio.getratio().ToString() +"%");
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


       

       
        
        

	}
}

