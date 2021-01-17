using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragons
{
    interface IUtiliseArmeDeMelee
    {
        ArmeDeMelee ArmeDeMeleeActive { get; }

        void AjouterArmeDeMelee(ArmeDeMelee ArmeDeMelee);

        void ActiverArmeDeMelee(string ArmeDeMeleeActive);

        List<string> AfficherArmeDeMelee();

        void AttaqueCorpsACorps(Guilde guilde);

    }
}
