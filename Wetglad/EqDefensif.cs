using System;

namespace Wetglad
{
	public class EqDefensif:Equipement
	{
		int blocage;
        //Constructeur
		public EqDefensif (string nomequip,int pointequip, int chancebloc):base(nomequip,pointequip)
		{
			blocage = chancebloc;
		}

        //Show stats
		public override void showStuff()
		{
            base.showStuff();
			Console.WriteLine ("Chance de blocage : "+(blocage).ToString()+"%");
		}

        //Get the stats
        public override int getblocage()
        {
            return blocage;
        }
	}
}

