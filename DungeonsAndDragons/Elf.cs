using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragons
{
    class Elf : Etre
    {
        private int _Agilite;
        private int _Endurance;
        private int _Energie;
        private int _Force;
        private int _Mana;

        private string _Nom;

        Random rnd = new Random();
        public Elf(string nom) : base(nom)
        {
            _Nom = nom;
            _Agilite = rnd.Next(75, 100);
            _Endurance = rnd.Next(100, 150);
            _Energie = rnd.Next(65, 100);
            _Force = rnd.Next(65, 90);
            _Mana = rnd.Next(100, 150);
        }

        public override int Agilite
        {
            get { return _Agilite; }
            set { value = _Agilite; }
        }

        public override int Endurance
        {
            get { return _Endurance; }
            set { value = _Endurance; }
        }

        public override int Energie
        {
            get { return _Energie; }
            set { value = _Energie; }
        }

        public override int Force
        {
            get { return _Force; }
            set { value = _Force; }
        }

        public override int Mana
        {
            get { return _Mana; }
            set { value = _Mana; }
        }

        public override string ToString()
        {
            return string.Format("Elf : Nom : {0}\n Energie : {1}\n Mana : {2}\n Force : {3}\n Endurance : {4}\n Agilite : {5}", _Nom, _Energie, _Mana, _Force, _Endurance, _Agilite);
        }
    }
}