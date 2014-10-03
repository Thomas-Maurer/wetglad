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
        public void Matchmaking()
        {
            int compteur=0;
            List<Equipe> Equipegagnante = EquipesParticipantes;
            Console.WriteLine("\nLe tournois commence !\n");

            //Direct elimination
             while (compteur + 1 < Equipegagnante.Count && Equipegagnante.Count > 1)
            {
               Equipegagnante.Remove(EquipesParticipantes[compteur].fight(EquipesParticipantes[compteur+1]));
               compteur++;
               if (compteur + 1 > Equipegagnante.Count && Equipegagnante.Count > 1)
               {
                   Console.WriteLine("Phase " + compteur);
                   compteur = 0;
               }
            }
            // sort all the equip by ratio
            TrieElo();


            Console.WriteLine(" [!] Le tournois est terminé, le vainqueur est : " + Equipegagnante[0].getnom() + " [!]");
        }
    }
}
