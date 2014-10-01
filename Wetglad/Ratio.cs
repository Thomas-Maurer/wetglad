using System;

namespace Wetglad
{
	public class Ratio
	{
		int defaite;
		int victoire;

		public Ratio (int vic, int def)
		{
			defaite = def;
			victoire = vic;
		}

		// Calcul and return ratio
		public float getratio()
		{
			if ((victoire + defaite) != 0) {
				return (victoire / (victoire + defaite))*100;
			} else
				return 0;
		}
		public string getvictoire(){
			return victoire.ToString();
		}
		public string getdefaite(){
			return defaite.ToString();
		}
	}
}

