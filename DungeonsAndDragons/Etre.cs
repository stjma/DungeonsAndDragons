using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragons
{
    public abstract class Etre
    {
        private string _Nom;
        public Etre(string nom)
        {
            _Nom = nom;
        }

        public virtual string Nom { get { return _Nom; } }

        public abstract int Energie { get; set; }
        public abstract int Mana { get; set; }
        public abstract int Force { get; set; }
        public abstract int Endurance { get; set; }
        public abstract int Agilite { get; set; }

        public override string ToString()
        {
            if (Energie <= 0)
            {
                return Nom + " est mort";
            }
            else
            {
                return string.Format("Nom : {0}\n Energie : {1}\n Mana : {2}\n Force : {3}\n Endurance : {4}\n Agilite : {5}", Nom, Energie, Mana, Force, Endurance, Agilite);
            }
        }
    }
}
