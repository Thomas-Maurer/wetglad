using System;
using System.Collections.Generic;

namespace Wetglad
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			// Création des instances de test pour le jeu

			Joueur j1 = new Joueur ();
			EqOffensif epee = new EqOffensif ("épée", 5, 0.7);
			EqOffensif lance = new EqOffensif ("Lance", 7, 0.5);
			EqOffensif dague = new EqOffensif ("dague", 2, 0.6);
			EqOffensif filet = new EqOffensif ("filet", 3, 0.3);


			j1.inscription ("Vandame", "Jean-claude", "JCVD");
			j1.showplayer ();
			j1.create_team ("L'equipe des bras cassés", "L'equipe des pgms kikoolols in da universe MADAFAKA");
			j1.showTeam ();

			j1.addgladtoteam (j1.getequipe (0), "Spartacus");
			j1.showgladofteam ();

			j1.addstufftoglad (j1.getequipe (0), j1.getequipe (0).getmesglads () [0], epee);
			j1.showgear (j1.getequipe (0), j1.getequipe (0).getmesglads () [0]);

		}
	}
}
