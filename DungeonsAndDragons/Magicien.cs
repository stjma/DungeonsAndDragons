using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragons
{
    class Magicien : Guilde, IUtiliseLaMagie, IUtiliseArmure
    {
        private List<Armure> Larmure = new List<Armure>();
        private List<SortAttaque> lSortAttaque = new List<SortAttaque>();
        private List<SortProtection> lSortPretection = new List<SortProtection>();

        private int _Energie;
        private int _Mana;
        private int _Force;
        private int _Endurance;
        private int _agilite;

        private string _Nom;

        private Armure _armure;
        private SortAttaque _sortAttaque;
        private SortProtection _sortProtection;

        public Magicien(Etre etre) : base(etre)
        {
            _Energie = etre.Energie;
            _Mana = etre.Mana;
            _Force = etre.Force;
            _Endurance = etre.Endurance;
            _agilite = etre.Agilite;

            Armure ar = new Armure("Linge", 0, 1);
            _armure = ar;
            Larmure.Add(ar);

            SortAttaque st = new SortAttaque("Fleche de lumiere", 12, 0, 0, 0, 5, 10);
            _sortAttaque = st;
            lSortAttaque.Add(st);

            SortProtection sp = new SortProtection("Bouclier Magique", 7, 0, 0, 0, 0, 6);
            _sortProtection = sp;
            lSortPretection.Add(sp);

        }

        public Armure ArmureActive
        {
            get
            {
                return _armure;
            }
        }

        public SortAttaque SortAttaqueActive
        {
            get
            {
                return _sortAttaque;
            }
        }

        public SortProtection SortProtectionActive
        {
            get
            {
                return _sortProtection;
            }
        }

        public override event LogAction logAction;

        public void ActiverArmure(string activerArmure)
        {
            foreach (Armure ar in Larmure)
            {
                if (ar.Nom == activerArmure)
                {
                    _armure = ar;
                }
            }

        }

        public void ActiverSortAttaque(string activerSortAttaque)
        {
            foreach (SortAttaque ar in lSortAttaque)
            {
                if (ar.Nom == activerSortAttaque)
                {
                    _sortAttaque = ar;
                }
            }
        }

        public void ActiverSortProtection(string activerSortProtection)
        {
            foreach (SortProtection ar in lSortPretection)
            {
                if (ar.Nom == activerSortProtection)
                {
                    _sortProtection = ar;
                }
            }
        }

        public List<string> AfficherArmure()
        {
            List<string> AffArmure = new List<string>();
            foreach (Armure arm in Larmure)
            {
                AffArmure.Add(arm.Nom);
            }
            return AffArmure;
        }

        public List<string> AfficherSortAttaque()
        {
            List<string> ListAffSortAttaque = new List<string>();
            foreach (SortAttaque ar in lSortAttaque)
            {
                ListAffSortAttaque.Add(ar.Nom);
            }
            return ListAffSortAttaque;
        }

        public List<string> AfficherSortProtection()
        {
            List<string> ListAffSortProtection = new List<string>();
            foreach (SortProtection ar in lSortPretection)
            {
                ListAffSortProtection.Add(ar.Nom);
            }
            return ListAffSortProtection;
        }

        public void AjouterArmure(Armure armure)
        {
            Larmure.Add(armure);
        }

        public void AjouterSortAttaque(SortAttaque sortAttaque)
        {
            lSortAttaque.Add(sortAttaque);
        }

        public void AjouterSortProtection(SortProtection sortProtection)
        {
            lSortPretection.Add(sortProtection);
        }

        public void AttaqueMagique(Guilde guilde)
        {
            string[] splits = DDOutils.CalculDommageTheorique(guilde, _Energie, _Mana, _Force, _Endurance, _agilite).Split('|');
            int energie = int.Parse(splits[0]);
            int mana = int.Parse(splits[1]);
            int force = int.Parse(splits[2]);
            int endurance = int.Parse(splits[3]);
            int agilite = int.Parse(splits[4]);

            _Nom = guilde.Race.Nom;

            logAction("");

            SubirUneAttaque(guilde, energie, mana, force, endurance, agilite);
        }


        public override void SubirUneAttaque(Guilde guilde, int dommageEnergie, int dommageMana, int dommageForce, int dommageEndurance, int dommageAgilite)
        {
            DDOutils.CalculDommageReel(guilde, ref dommageEnergie, ref dommageMana, ref dommageForce, ref dommageEndurance, ref dommageAgilite);

            logAction("");
        }

        public override string ToString()
        {
            return base.Race.ToString() + "\n " + SortAttaqueActive.ToString() + "\n " + SortProtectionActive.ToString() + "\n " + ArmureActive.ToString(); ;
        }
    }
}
