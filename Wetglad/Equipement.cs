using System;

namespace Wetglad
{
	public class Equipement
	{
		int id_equipement;
		static int nb_equipement =0;
		string nom;
		int ptEquip;

		public Equipement (string nomequipement,int pointequip)
		{
			nb_equipement++;
			id_equipement = nb_equipement;
			nom = nomequipement;
			ptEquip = pointequip;

		}

		public void showStuff()
		{
			Console.WriteLine ("Nom de l'équipement : "+nom);
			Console.WriteLine ("Charge de l'équipement : "+ptEquip);

		}

		public int getpointequipement()
		{
			return ptEquip;
		}
		public string getnomequipement()
		{
			return nom;
		}
	}
}

