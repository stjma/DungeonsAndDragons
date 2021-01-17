using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragons
{
    class SortProtection
    {

        private string _Nom;
        private int _ProtectionAgilite;
        private int _ProtectionEndurance;
        private int _ProtectionEnergie;
        private int _ProtectionForce;
        private int _ProtectionMana;
        private int _CoutMana;
        public SortProtection(string nom, int dommageAgilite, int dommageEndurance, int dommageEnergie, int dommageForce, int dommageMana, int coutMana)
        {
            _Nom = nom;
            _ProtectionAgilite = dommageAgilite;
            _ProtectionEndurance = dommageEndurance;
            _ProtectionEnergie = dommageEnergie;
            _ProtectionForce = dommageForce;
            _ProtectionMana = dommageMana;
            _CoutMana = coutMana;
        }

        public string Nom
        {
            get { return _Nom; }
            set { value = _Nom; }
        }

        public int ProtectionEnergie
        {
            get { return _ProtectionEnergie; }
            set { value = _ProtectionEnergie; }
        }

        public int ProtectionMana
        {
            get { return _ProtectionMana; }
            set { value = _ProtectionMana; }
        }

        public int ProtectionForce
        {
            get { return _ProtectionForce; }
            set { value = _ProtectionForce; }
        }

        public int ProtectionEndurance
        {
            get { return _ProtectionEndurance; }
            set { value = _ProtectionEndurance; }
        }

        public int ProtectionAgilite
        {
            get { return _ProtectionAgilite; }
            set { value = _ProtectionAgilite; }
        }

        public int CoutMana
        {
            get { return _CoutMana; }
            set
            {
                if (value > 0)
                {
                    value = _CoutMana;
                }
                else
                {
                    value = 0;
                }
            }
        }

        public override string ToString()
        {
            return string.Format("{0} : ({1}-{2}-{3}-{4}-{5}-{6})", Nom, ProtectionEnergie, ProtectionMana, ProtectionForce, ProtectionEndurance, ProtectionAgilite, CoutMana);
        }

    }
}
