using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragons
{
    class Guerrier : Guilde, IUtiliseArmeDeMelee, IUtiliseArmure
    {
        private List<Armure> Larmure = new List<Armure>();
        private List<ArmeDeMelee> lArmeDeMelee = new List<ArmeDeMelee>();

        private int _Energie;
        private int _Mana;
        private int _Force;
        private int _Endurance;
        private int _agilite;

        private string _Nom;

        private Etre _etre;

        private string nnn;

        private ArmeDeMelee _ArmeDeMelee;
        private Armure _Armure;
        public Guerrier(Etre etre) : base(etre)
        {
            _etre = etre;
            etre.Energie += 20;
            etre.Force += 10;
            _Energie = etre.Energie;
            _Mana = etre.Mana;
            _Force = etre.Force;
            _Endurance = etre.Endurance;
            _agilite = etre.Agilite;

            ArmeDeMelee aaa = new ArmeDeMelee("Poing", 1, 5, 0, 5);
            _ArmeDeMelee = aaa;
            lArmeDeMelee.Add(aaa);

            Armure bbb = new Armure("Linge", 0, 1);
            _Armure = bbb;
            Larmure.Add(bbb);
        }

        public ArmeDeMelee ArmeDeMeleeActive
        {
            get
            {
                return _ArmeDeMelee;
            }
        }

        public Armure ArmureActive
        {
            get
            {
                return _Armure;
            }
        }

        public override event LogAction logAction;

        public void ActiverArmeDeMelee(string ArmeDeMeleeActive)
        {
            foreach (ArmeDeMelee ar in lArmeDeMelee)
            {
                if (ar.Nom == ArmeDeMeleeActive)
                {
                    _ArmeDeMelee = ar;
                }
            }
        }

        public void ActiverArmure(string activerArmure)
        {
            foreach (Armure ar in Larmure)
            {
                if (ar.Nom == activerArmure)
                {
                    _Armure = ar;
                }
            }
        }

        public List<string> AfficherArmeDeMelee()
        {
            List<string> ListeArmeAffi = new List<string>();
            foreach (ArmeDeMelee arm in lArmeDeMelee)
            {
                ListeArmeAffi.Add(arm.Nom);
            }
            return ListeArmeAffi;
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

        public void AjouterArmeDeMelee(ArmeDeMelee ArmeDeMelee)
        {
            lArmeDeMelee.Add(ArmeDeMelee);
        }

        public void AjouterArmure(Armure armure)
        {
            Larmure.Add(armure);
        }

        private int test;
        public void AttaqueCorpsACorps(Guilde guilde)
        {
            string[] splits = DDOutils.CalculDommageTheorique(guilde, _Energie, _Mana, _Force, _Endurance, _agilite).Split('|');
            int energie = int.Parse(splits[0]);
            int mana = int.Parse(splits[1]);
            int force = int.Parse(splits[2]);
            int endurance = int.Parse(splits[3]);
            int agilite = int.Parse(splits[4]);

            _Nom = guilde.Race.Nom;
            logAction(nnn + " attaque " + _Nom);
            SubirUneAttaque(guilde, energie, mana, force, endurance, agilite);



            
        }
       
        public override void SubirUneAttaque(Guilde guilde, int dommageEnergie, int dommageMana, int dommageForce, int dommageEndurance, int dommageAgilite)
        {
            DDOutils.CalculDommageReel(guilde, ref dommageEnergie, ref dommageMana, ref dommageForce, ref dommageEndurance, ref dommageAgilite);

            test = 11;

           
        }

        public override string ToString()
        {
            //base.Race.Energie -= test;
            nnn = base.Race.Nom;
            return base.Race.ToString() + "\n " + ArmeDeMeleeActive.ToString() + "\n " + ArmureActive.ToString();
            
        }
    }
}
