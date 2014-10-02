using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wetglad
{
    class Tournois
    {
        List<Equipe> EquipesParticipantes;
        public Tournois()
        {
            EquipesParticipantes = new List<Equipe>();
        }

        public void addEquipetoTn(Equipe eq)
        {
            EquipesParticipantes.Add(eq);
            TrieElo();
        }

        public void TrieElo()
        {

                EquipesParticipantes = EquipesParticipantes.OrderByDescending(Equipe => Equipe.getratio().getratio()).ToList<Equipe>();
        }

        public void showEquip()
        {
            foreach (Equipe eq in EquipesParticipantes)
            {
                Console.WriteLine(eq.getnom() + " Ratio de : "+ eq.getratio().getratio());
            }
        }
    }
}
