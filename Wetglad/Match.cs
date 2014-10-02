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


        public Match(Equipe eq1, Equipe eq2)
        {
            nb_match++;
            id_match = nb_match;
            EquipeenMatch.Add(eq1);
            EquipeenMatch.Add(eq2);
        }


        public void Duel()
        {
            EquipeenMatch[0].fight(EquipeenMatch[1]);

        }

    }
}
