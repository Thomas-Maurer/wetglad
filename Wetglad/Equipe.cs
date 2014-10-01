using System;
using System.Collections.Generic;
namespace Wetglad
{
	public class Equipe
	{
		static int nb_equipe =0;
		int id_equipe;
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
			ratio = new Ratio (0, 0);
		}
		public string getid(){
			return id_equipe.ToString ();
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
	}
}

