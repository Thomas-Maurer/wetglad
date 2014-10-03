using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wetglad
{
    class Match
    {
        static int nb_match = 0;
        int id_match;
        int id_equipe_gagnant;
        int id_equipe_perdant;
        List<Equipe> EquipeenMatch = new List<Equipe>();

        //Constructeur
        public Match(Equipe eq1, Equipe eq2)
        {
            nb_match++;
            id_match = nb_match;
            EquipeenMatch.Add(eq1);
            EquipeenMatch.Add(eq2);
        }

        // Begin the fight against 2 equips
        public void Duel()
        {
            float nbvictoireeq0 = EquipeenMatch[0].getratio().getvictoire();
            float nbvictoireeq1 = EquipeenMatch[1].getratio().getvictoire();

            EquipeenMatch[0].fight(EquipeenMatch[1]);

            //Determine who win the match
            if (EquipeenMatch[0].getratio().getvictoire() > nbvictoireeq0)
            {
                id_equipe_gagnant = EquipeenMatch[0].getid();
                id_equipe_perdant = EquipeenMatch[1].getid();
            }else
            {
                id_equipe_gagnant = EquipeenMatch[1].getid();
                id_equipe_perdant = EquipeenMatch[0].getid();
            }
            Console.WriteLine("Le match "+id_match + " Est remporté par l'équipe : " + EquipeenMatch.First(Equipe =>Equipe.getid() == id_equipe_gagnant).getnom()+'\n');

        }

    }
}
