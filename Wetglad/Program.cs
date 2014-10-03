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
            Joueur j3 = new Joueur();
            Joueur j4 = new Joueur();

            Tournois t1 = new Tournois();

			EqOffensif epee = new EqOffensif ("épée", 5, 70);
			EqOffensif lance = new EqOffensif ("Lance", 7, 50);
			EqOffensif dague = new EqOffensif ("dague", 2,60);
			EqOffensif filet = new EqOffensif ("filet", 3,30);

            EqDefensif boubourond = new EqDefensif("Petit boubou rond", 5, 20);
            EqDefensif boubourect = new EqDefensif("Bouclier Rectangulaire", 8, 30);
            EqDefensif casque = new EqDefensif("casque", 2, 10);

            //Create Players
            j1.inscription("Vandame", "Jean-claude", "JCVD");
            j2.inscription("Michou", "Bob", "Best001");
            j3.inscription("Michou2", "Bob2", "Best002");
            j4.inscription("Michou3", "Bob3", "Best003");


            //Create team
            j1.create_team("L'equipe des bras cassés", "L'equipe des pgms kikoolols in da universe MADAFAKA");
            j2.create_team("L'equipe des bras cousus", "L'equipe des Petites gazelles");
            j3.create_team("L'equipe des Mongoles", "L'equipe des Petites Mongoles");
            j4.create_team("L'equipe des Best", "L'equipe des meilleures gazelles");
            Console.WriteLine("");

            //Create Glad
            j1.addgladtoteam(j1.getequipe(0), "Spartacus");
            j1.addgladtoteam(j1.getequipe(0), "Babar");
            j1.addgladtoteam(j1.getequipe(0), "Hercules");
            j2.addgladtoteam(j2.getequipe(0), "Trololo");
            j2.addgladtoteam(j2.getequipe(0), "Ulysse");
            j2.addgladtoteam(j2.getequipe(0), "Chuck norris");
            j3.addgladtoteam(j3.getequipe(0), "Atila");
            j3.addgladtoteam(j3.getequipe(0), "Hung Zu");
            j3.addgladtoteam(j3.getequipe(0), "Nem");
            j4.addgladtoteam(j4.getequipe(0), "Best1");
            j4.addgladtoteam(j4.getequipe(0), "Best2");
            j4.addgladtoteam(j4.getequipe(0), "Best3");

            // Add some gear to our glad
            j1.addstufftoglad(j1.getequipe(0), j1.getequipe(0).getmesglads()[1], lance);
            j1.addstufftoglad(j1.getequipe(0), j1.getequipe(0).getmesglads()[2], dague);
			j1.addstufftoglad(j1.getequipe(0), j1.getequipe (0).getmesglads () [0], epee);
            j1.addstufftoglad(j1.getequipe(0), j1.getequipe(0).getmesglads()[0], casque);
            

            j2.addstufftoglad(j2.getequipe(0), j2.getequipe(0).getmesglads()[1], lance);
            j2.addstufftoglad(j2.getequipe(0), j2.getequipe(0).getmesglads()[1], epee);
            j2.addstufftoglad(j2.getequipe(0), j2.getequipe(0).getmesglads()[2], dague);
            j2.addstufftoglad(j2.getequipe(0), j2.getequipe(0).getmesglads()[0], dague);
            j2.addstufftoglad(j2.getequipe(0), j2.getequipe(0).getmesglads()[0], casque);


            j3.addstufftoglad(j3.getequipe(0), j3.getequipe(0).getmesglads()[1], lance);
            j3.addstufftoglad(j3.getequipe(0), j3.getequipe(0).getmesglads()[1], epee);
            j3.addstufftoglad(j3.getequipe(0), j3.getequipe(0).getmesglads()[2], dague);
            j3.addstufftoglad(j3.getequipe(0), j3.getequipe(0).getmesglads()[0], dague);
            j3.addstufftoglad(j3.getequipe(0), j3.getequipe(0).getmesglads()[0], casque);

            j4.addstufftoglad(j4.getequipe(0), j4.getequipe(0).getmesglads()[1], lance);
            j4.addstufftoglad(j4.getequipe(0), j4.getequipe(0).getmesglads()[1], epee);
            j4.addstufftoglad(j4.getequipe(0), j4.getequipe(0).getmesglads()[2], dague);
            j4.addstufftoglad(j4.getequipe(0), j4.getequipe(0).getmesglads()[0], dague);
            j4.addstufftoglad(j4.getequipe(0), j4.getequipe(0).getmesglads()[0], casque);


            Console.WriteLine("");
            Console.WriteLine("");

            // Add equipe to our Tn
            t1.addEquipetoTn(j1.getequipe(0));
            t1.addEquipetoTn(j2.getequipe(0));
            t1.addEquipetoTn(j3.getequipe(0));
            t1.addEquipetoTn(j4.getequipe(0));

            t1.showEquip();
            // Launch Tn
            t1.Matchmaking();

            // pause the program
            Console.Read();

		}
	}
}
