using System;

namespace Wetglad
{
    public class EqOffensif : Equipement
	{
		int toucher;
        int initiative;
		public EqOffensif (string nomequip,int pointequip, int chancetouch):base(nomequip,pointequip)
		{
			toucher = chancetouch;
            initiative = RandomNumber(1,100);
		}
		public override void showStuff()
		{
            base.showStuff();
            Console.WriteLine("Chance de toucher : " + (toucher).ToString() + "%");
            Console.WriteLine("Initiative : " + initiative.ToString());

		}

        public override int gettoucher()
        {
            return toucher;
        }

        public override int getinitiative()
        {
            return initiative;
        }


        //Function to get random number
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }
	}
}

