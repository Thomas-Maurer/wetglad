using System;
using System.Collections.Generic;
namespace Wetglad
{
	public class Equipe
	{
		static int nb_equipe =0;
		protected int id_equipe;
		string nom;
		string descriptif;
		Ratio ratio;
		Joueur joueur;
		List<Gladiateur> mesGladiateurs;


		public Equipe (string nomequipe,string descriptifeq, Joueur j)
		{
			nb_equipe++;
			id_equipe = nb_equipe;
			nom = nomequipe;
			descriptif = descriptifeq;
			joueur = j;
			mesGladiateurs = new List<Gladiateur>();
            ratio = new Ratio(RandomNumber(1, 100), RandomNumber(1,100));
		}
        public Ratio getratio()
        {
            return ratio;
        }
		public int getid(){
			return id_equipe;
		}
		public List<Gladiateur> getmesglads(){
			return mesGladiateurs;
		}
		public string getnom(){
			return nom;
		}
		public string getdescriptif(){
			return descriptif;
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

		// Show attribute of a team + show who own the team
		public void showteam()
		{
			Console.WriteLine ( "Nom de l'equipe : "+ nom +" descriptif : "+descriptif+" Victoires : "+ratio.getvictoire()+ " Defaites : "+ratio.getdefaite());
			Console.WriteLine ("L'equipe appartient au joueur : " + joueur.getnom());
			Console.WriteLine ( " Le ratio de l'équipe est de : "+ ratio.getratio().ToString() +"%");
		}
		// add glad to a team
		public void addgladtoteam(string nomdemonglad)
		{
			if (mesGladiateurs.Count < 3) {
				mesGladiateurs.Add (new Gladiateur (nomdemonglad));
			} else
				Console.WriteLine ("Vous avez déjà atteind le max de gladiateur par équipe");
		}
	
		// show Glad of each team
		public void showGlad()
		{
			foreach (Gladiateur glad in mesGladiateurs) 
			{
				glad.showglad ();
			}

		}
		//Add some stuff to our glad
		public void addstufftoglad(Equipement stuff, Gladiateur glad)
		{
			glad.addeqtoglad (stuff);
		}

        // Return the looser of the fight
        public Equipe fight(Equipe challenger)
        {
            
            List<Gladiateur> Gladsurvivanteqthis = new List<Gladiateur>() ;
            List<Gladiateur> Gladsurvivanteqchallenger = new List<Gladiateur>() ;

            Gladsurvivanteqthis = this.getmesglads();
            Gladsurvivanteqchallenger = challenger.getmesglads();
            while (Gladsurvivanteqthis.Count > 0 && Gladsurvivanteqchallenger.Count > 0)
            {
                bool victoire = false;
                Gladiateur gladbegin;
                
                gladbegin = Gladsurvivanteqthis[0].compareinitiative(Gladsurvivanteqchallenger[0]);
                if (Gladsurvivanteqthis.Contains(gladbegin))
                {
                    //Equipe this commence
                    while (!victoire)
                    {
                        
                        gladbegin = Gladsurvivanteqthis[0];
                        if (gladbegin.combat(Gladsurvivanteqchallenger[0]))
                        {
                            Gladsurvivanteqchallenger.Remove(Gladsurvivanteqchallenger[0]);
                            victoire = true;
                        }
                        else
                        {
                            if (challenger.getmesglads()[0].combat(gladbegin))
                            {
                                Gladsurvivanteqthis.Remove(Gladsurvivanteqthis[0]);
                                victoire = true;
                            }
                            
                        }
                    }
                }
                else
                {
                    //equipe Challenger commence
                    while (!victoire)
                    {

                        gladbegin = Gladsurvivanteqchallenger[0];
                        if (gladbegin.combat(Gladsurvivanteqthis[0]))
                        {
                            Gladsurvivanteqthis.Remove(Gladsurvivanteqthis[0]);
                            victoire = true;
                        }
                        else
                        {
                            if (Gladsurvivanteqthis[0].combat(gladbegin))
                            {
                                Gladsurvivanteqchallenger.Remove(Gladsurvivanteqchallenger[0]);
                                victoire = true;
                            }

                        }
                    }
                }
            }
            Console.WriteLine("");
            if (Gladsurvivanteqthis.Count > 0)
            {
                Console.WriteLine("L'équipe : " + this.getnom() + " Remporte le Match");
                this.ratio.setvictoire();
                challenger.ratio.setdefaite();
                return (challenger);
            }
            else { 
                Console.WriteLine("L'équipe : " + challenger.getnom() + " Remporte le Match");
                challenger.ratio.setvictoire();
                this.ratio.setdefaite();
                return (this);
            }
       }
	}
}

