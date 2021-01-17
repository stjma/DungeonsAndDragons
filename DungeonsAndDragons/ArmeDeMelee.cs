using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragons
{
    class ArmeDeMelee
    {
        private string _Nom;
        private int _DommageMin;
        private int _DommageMax;
        private int _DefMin;
        private int _DefMax;

        public ArmeDeMelee(string nom, int dommageMin, int dommageMax, int defMax, int defMin)
        {
            _Nom = nom;
            _DommageMin = dommageMin;
            _DommageMax = dommageMax;
            _DefMin = defMax;
            _DefMax = defMin;
        }

        public string Nom
        {
            get { return _Nom; }
            set { value = _Nom; }
        }
        public int DommageMin
        {
            get { return _DommageMin; }
            set { value = _DommageMin; }
        }

        public int DommageMax
        {
            get { return _DommageMax; }
            set { value = _DommageMax; }
        }

        public int DefenseMin
        {
            get { return _DefMin; }
            set { value = _DefMin; }
        }

        public int DefenseMax
        {
            get { return _DefMax; }
            set { value = _DefMax; }
        }

        public override string ToString()
        {
            return string.Format("{0} : ({1}-{2}-{3}-{4})", _Nom, _DommageMin, _DommageMax, _DefMin, _DefMax);
        }
    }
}
