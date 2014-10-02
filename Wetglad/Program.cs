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
            Joueur j2 = new Joueur();
            Tournois t1 = new Tournois();
			EqOffensif epee = new EqOffensif ("épée", 5, 70);
			EqOffensif lance = new EqOffensif ("Lance", 7, 50);
			EqOffensif dague = new EqOffensif ("dague", 2,60);
			EqOffensif filet = new EqOffensif ("filet", 3,30);

            EqDefensif boubourond = new EqDefensif("Petit boubou rond", 5, 20);
            EqDefensif boubourect = new EqDefensif("Bouclier Rectangulaire", 8, 30);
            EqDefensif casque = new EqDefensif("casque", 2, 10);


            j1.inscription("Vandame", "Jean-claude", "JCVD");
            j2.inscription("Michou", "Bob", "Best001");

			j1.showplayer ();
            Console.WriteLine("");
            j2.showplayer();
            Console.WriteLine("");
            j1.create_team("L'equipe des bras cassés", "L'equipe des pgms kikoolols in da universe MADAFAKA");
            j1.showTeam();
            Console.WriteLine("");
            j2.create_team("L'equipe des bras cousus", "L'equipe des Petites gazelles");
            j2.showTeam();
            Console.WriteLine("");


            j1.addgladtoteam(j1.getequipe(0), "Spartacus");
            j1.addgladtoteam(j1.getequipe(0), "Babar");
            j1.addgladtoteam(j1.getequipe(0), "Hercules");
            j2.addgladtoteam(j2.getequipe(0), "Trololo");
            j2.addgladtoteam(j2.getequipe(0), "Ulysse");
            j2.addgladtoteam(j2.getequipe(0), "Chuck norris");
			j1.showgladofteam ();
            Console.WriteLine("");
            j2.showgladofteam();


            j1.addstufftoglad(j1.getequipe(0), j1.getequipe(0).getmesglads()[1], lance);
            j1.addstufftoglad(j1.getequipe(0), j1.getequipe(0).getmesglads()[2], dague);
			j1.addstufftoglad(j1.getequipe (0), j1.getequipe (0).getmesglads () [0], epee);
            j1.addstufftoglad(j1.getequipe(0), j1.getequipe(0).getmesglads()[0], casque);
			j1.showgear (j1.getequipe (0), j1.getequipe (0).getmesglads () [0]);
            
            Console.WriteLine("");
            Console.WriteLine("");

            j2.addstufftoglad(j2.getequipe(0), j2.getequipe(0).getmesglads()[1], lance);
            j2.addstufftoglad(j2.getequipe(0), j2.getequipe(0).getmesglads()[1], epee);
            j2.addstufftoglad(j2.getequipe(0), j2.getequipe(0).getmesglads()[2], dague);
            j2.addstufftoglad(j2.getequipe(0), j2.getequipe(0).getmesglads()[0], dague);
            j2.addstufftoglad(j2.getequipe(0), j2.getequipe(0).getmesglads()[0], casque);
            j2.showgear(j2.getequipe(0), j2.getequipe(0).getmesglads()[0]);


            Console.WriteLine("");
            Console.WriteLine("");

            Match m1 = new Match(j1.getequipe(0), j2.getequipe(0));

            m1.Duel();

            Console.WriteLine("");
            Console.WriteLine("");


            t1.addEquipetoTn(j1.getequipe(0));
            t1.addEquipetoTn(j2.getequipe(0));

            t1.showEquip();

            // pause the program
            Console.Read();

		}
	}
}
