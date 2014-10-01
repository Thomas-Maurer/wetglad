using System;
using System.Collections.Generic;

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

		public void addeqtoglad(Equipement stuff)
		{
			if (getchargeglad () + stuff.getpointequipement () <= 10)
				mesEquipements.Add (stuff);
			else
				Console.WriteLine ("Charge maximum pour un gladiateur");
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




	}
}

