using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragons
{
    class Armure
    {
        private string _Nom;
        private int _DefMin;
        private int _DefMax;
        public Armure(string nom, int defMin, int defMax)
        {
            _Nom = nom;
            _DefMin = defMin;
            _DefMax = defMax;
        }

        public string Nom
        {
            get { return _Nom; }
            set { value = _Nom; }
        }
        public int DefenceMin
        {
            get { return _DefMin; }
            set { value = _DefMin; }
        }

        public int DefenceMax
        {
            get { return _DefMax; }
            set { value = _DefMax; }
        }

        public override string ToString()
        {
            return string.Format("{0} : ({1}-{2})", _Nom, _DefMin, _DefMax);

        }
    }
}
