using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragons
{
    abstract class Guilde
    {
        protected List<string> _ListGuilde = new List<string>();
        private Etre _Etre;
        public Guilde(Etre etre)
        {
            _Etre = etre;
        }

        //public Etre Race { get { return _Etre; } }


        public Etre Race
        {
            get { return _Etre; }
        }

        public abstract void SubirUneAttaque(Guilde guilde, int dommageEnergie, int dommageMana, int dommageForce, int dommageEndurance, int dommageAgilite);

        public delegate void LogAction(string message);

        public abstract event LogAction logAction;

        public abstract override string ToString();
    }
}
