using System;

namespace Wetglad
{
	public class Ratio
	{
		float defaite;
		float victoire;

		public Ratio (float vic, float def)
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
        public float setvictoire()
        {
            return victoire++;
        }
        public float setdefaite()
        {
            return defaite++;
        }
		public float getvictoire(){
			return victoire;
		}
		public float getdefaite(){
			return defaite;
		}
	}
}

