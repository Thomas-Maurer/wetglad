using System;

namespace Wetglad
{
	public class EqDefensif:Equipement
	{
		int blocage;
		public EqDefensif (string nomequip,int pointequip, int chancebloc):base(nomequip,pointequip)
		{
			blocage = chancebloc;
		}

		public override void showStuff()
		{
            base.showStuff();
			Console.WriteLine ("Chance de blocage : "+(blocage).ToString()+"%");
		}

        public override int getblocage()
        {
            return blocage;
        }
	}
}

