using System;

namespace Wetglad
{
	public class EqDefensif:Equipement
	{
		double blocage;
		public EqDefensif (string nomequip,int pointequip, double chancebloc):base(nomequip,pointequip)
		{
			blocage = chancebloc;
		}

		public void showStuff()
		{
			Console.WriteLine ("Nom de l'équipement : "+base.getnomequipement());
			Console.WriteLine ("Charge de l'équipement : "+base.getpointequipement());
			Console.WriteLine ("Chance de blocage : "+(blocage *100).ToString()+"%");
		}
	}
}

