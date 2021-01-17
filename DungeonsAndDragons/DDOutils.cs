using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragons
{
    static class DDOutils
    {
        static bool EviteAttaque(int agilite, int endurance)
        {
            Random rnd = new Random();
            int calcul = (int)(35 + (agilite * 0.2 - (endurance - 70) * 0.2));


            int ramdom = rnd.Next(0, 100);

            if (ramdom > calcul)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static string CalculDommageTheorique(Guilde guilde, int energie, int mana, int force, int endurance, int agilite)
        {
            Random rnd = new Random();
            if (guilde is IUtiliseArmeDeMelee)
            {
                energie = rnd.Next(((IUtiliseArmeDeMelee)guilde).ArmeDeMeleeActive.DommageMin, ((IUtiliseArmeDeMelee)guilde).ArmeDeMeleeActive.DommageMax);
                mana = 0;
                force = 0;
                endurance = 0;
                agilite = 0;
            }
            else if (guilde is IUtiliseLaMagie)
            {
                //energie *= rnd.Next(6, 10) / 10;
                //mana *= rnd.Next(6, 10) / 10;
                //force *= rnd.Next(6, 10) / 10;
                //endurance *= rnd.Next(6, 10) / 10;
                //agilite *= rnd.Next(6, 10) / 10;

                energie *= 2;
                mana *= 2;
                force *= 2;
                endurance *= 2;
                agilite *= 2;
            }

            string total = energie + "|" + mana + "|" + force + "|" + endurance + "|" + agilite;
            return total;
        }

        public static void CalculDommageReel(Guilde guilde, ref int energie, ref int mana, ref int force, ref int endurance, ref int agilite)
        {
            Random rnd = new Random();

            if (guilde is IUtiliseArmeDeMelee)
            {

                int a = ((IUtiliseArmeDeMelee)guilde).ArmeDeMeleeActive.DommageMin;
                int b = ((IUtiliseArmeDeMelee)guilde).ArmeDeMeleeActive.DommageMax;

                energie -= rnd.Next(a, b);
                //mana -= rnd.Next(a, b);
                //force -= rnd.Next(a, b);
                //endurance -= rnd.Next(a, b);
                //agilite -= rnd.Next(a, b);

                //if (energie < 0) { energie = 0; }
            }
            if (guilde is IUtiliseArmure)
            {

                int defMin = 0;
                int defMax = 0;
                if (guilde is Magicien)
                {
                    defMin = ((IUtiliseArmure)guilde).ArmureActive.DefenceMin;
                    defMax = ((IUtiliseArmure)guilde).ArmureActive.DefenceMin;
                }
                else if (guilde is Guerrier)
                {
                    defMin = ((IUtiliseArmure)guilde).ArmureActive.DefenceMin;
                    defMax = ((IUtiliseArmure)guilde).ArmureActive.DefenceMin;
                }

                energie -= rnd.Next(defMin, defMax);
                //mana -= rnd.Next(defMin, defMax);
                //force -= rnd.Next(defMin, defMax);
                //endurance -= rnd.Next(defMin, defMax);
                //agilite -= rnd.Next(defMin, defMax);

                // if(energie < 0) { energie = 0; }
            }
            if (guilde is IUtiliseLaMagie)
            {
                int couTmana = ((IUtiliseLaMagie)guilde).SortAttaqueActive.CoutMana;
                if (mana > 0)
                {
                    //energie -= ((IUtiliseLaMagie)guilde).SortAttaqueActive.DommageAgilite * rnd.Next(6, 10) / 10;
                    //mana -= ((IUtiliseLaMagie)guilde).SortAttaqueActive.DommageMana * rnd.Next(6, 10) / 10;
                    //force -= ((IUtiliseLaMagie)guilde).SortAttaqueActive.DommageForce * rnd.Next(6, 10) / 10;
                    //endurance -= ((IUtiliseLaMagie)guilde).SortAttaqueActive.DommageEndurance * rnd.Next(6, 10) / 10;
                    //agilite -= ((IUtiliseLaMagie)guilde).SortAttaqueActive.DommageAgilite * rnd.Next(6, 10) / 10;

                    energie -= ((IUtiliseLaMagie)guilde).SortAttaqueActive.DommageAgilite * rnd.Next(6, 10);
                    mana -= ((IUtiliseLaMagie)guilde).SortAttaqueActive.DommageMana * rnd.Next(6, 10);
                    force -= ((IUtiliseLaMagie)guilde).SortAttaqueActive.DommageForce * rnd.Next(6, 10);
                    endurance -= ((IUtiliseLaMagie)guilde).SortAttaqueActive.DommageEndurance * rnd.Next(6, 10);
                    agilite -= ((IUtiliseLaMagie)guilde).SortAttaqueActive.DommageAgilite * rnd.Next(6, 10);

                    //if (energie < 0) { energie = 0; }
                    //if (mana < 0) { mana = 0; }
                    //if (force < 0) { force = 0; }
                    //if (endurance < 0) { endurance = 0; }
                    //if (agilite < 0) { agilite = 0; }
                }
            }
        }
    }
}
