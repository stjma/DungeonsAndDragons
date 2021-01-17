using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragons
{
    interface IUtiliseArmure
    {
        Armure ArmureActive { get; }

        void AjouterArmure(Armure armure);

        void ActiverArmure(string activerArmure);

        List<string> AfficherArmure();

    }
}
