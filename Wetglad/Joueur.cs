using System;
using System.Collections.Generic;

namespace Wetglad
{
	public class Joueur
	{
		static int nb_joueur = 0;
		int id_joueur;
		string nom_joueur;
		string prenom_joueur;
		string pseudo;
		DateTime dateinscr;
		List<Equipe> Mesequipes;


		public Joueur ()
		{

		}
		public void inscription(string nom,string prenom, string pseudo)
		{
			nb_joueur++;
			id_joueur = nb_joueur;
			nom_joueur = nom;
			prenom_joueur = prenom;
			this.pseudo = pseudo;
			dateinscr = DateTime.Now;
			Mesequipes = new List<Equipe> ();
		}

		// Create a team empty
		public void create_team(string nomeq,string desc)
		{
			Mesequipes.Add(new Equipe(nomeq, desc,this));
		}

		public string getnom()
		{
			return nom_joueur;
		}

		// show atribute of player
		public void showplayer()
		{
			Console.WriteLine ( "Nom du joueur : "+ nom_joueur +" Prénom : "+prenom_joueur+" Pseudo : "+pseudo+ " Date inscription : "+dateinscr.ToString());
		}
		// show Teams of player
		public void showTeam()
		{
			foreach (Equipe team in Mesequipes) 
			{
				team.showteam ();
			}

		}

		//get team of specific player
		public Equipe getequipe(int id_equipe)
		{
			return Mesequipes[id_equipe];
		}

		//get glad of specific team of specific player
		public Gladiateur getglad(int id_equipe, int id_glad)
		{
			return Mesequipes[id_equipe].getmesglads()[id_glad];
		}

		//Add some stuff to our glad
		public void addstufftoglad(Equipe eq,Gladiateur glad,Equipement stuff)
		{
			eq.addstufftoglad (stuff, glad);
		}


		//Add glad to specific team
		public void addgladtoteam(Equipe eq,string nomglad)
		{
			eq.addgladtoteam (nomglad);
		}

		//Show all the glad of all teams
		public void showgladofteam() 
		{
			foreach (Equipe team in Mesequipes) 
			{
				Console.WriteLine ("Equipe Numéro "+team.getid());
				team.showGlad ();
			}
		}
        //Show gear of specific glad in specific team
		public void showgear(Equipe eq, Gladiateur glad)
		{
			glad.showGear ();
		}
	}
}

