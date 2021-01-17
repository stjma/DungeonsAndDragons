using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragons
{
    class SortAttaque
    {
        private string _Nom;
        private int _DommageEnergie;
        private int _DommageMana;
        private int _DommageForce;
        private int _DommageEndurance;
        private int _DommageAgilite;
        private int _CoutMana;

        public SortAttaque(string nom, int dommageEnergie, int dommageMana, int dommageForce, int dommageEndurance, int dommageAgilite, int coutMana)
        {
            _Nom = nom;
            _DommageEnergie = dommageEnergie;
            _DommageMana = dommageMana;
            _DommageForce = dommageForce;
            _DommageEndurance = dommageEndurance;
            _DommageAgilite = dommageAgilite;
            _CoutMana = coutMana;
        }

        public string Nom
        {
            get { return _Nom; }
            set { value = _Nom; }
        }

        public int DommageEnergie
        {
            get { return _DommageEnergie; }
            set { value = _DommageEnergie; }
        }

        public int DommageMana
        {
            get { return _DommageMana; }
            set { value = _DommageMana; }
        }

        public int DommageForce
        {
            get { return _DommageForce; }
            set { value = _DommageForce; }
        }

        public int DommageEndurance
        {
            get { return _DommageEndurance; }
            set { value = _DommageEndurance; }
        }

        public int DommageAgilite
        {
            get { return _DommageAgilite; }
            set { value = _DommageAgilite; }
        }

        public int CoutMana
        {
            get { return _CoutMana; }
            set { value = _CoutMana; }
        }

        public override string ToString()
        {
            return string.Format("{0} : ({1}{2}{3}{4}{5}{6} )", Nom, DommageEnergie, DommageMana, DommageForce, DommageEndurance, DommageAgilite, CoutMana);
        }
    }
}
