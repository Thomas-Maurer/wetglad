using System;

namespace Wetglad
{
	public class EqOffensif:Equipement
	{
		double toucher;
		public EqOffensif (string nomequip,int pointequip, double chancetouch):base(nomequip,pointequip)
		{
			toucher = chancetouch;
		}
		public void showStuff()
		{
			Console.WriteLine ("Nom de l'équipement : "+base.getnomequipement());
			Console.WriteLine ("Charge de l'équipement : "+base.getpointequipement());
			Console.WriteLine ("Chance de toucher : "+(toucher *100).ToString()+"%");

		}
	}
}

