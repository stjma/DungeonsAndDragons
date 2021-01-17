using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragons
{
    interface IUtiliseLaMagie
    {
        SortAttaque SortAttaqueActive { get; }

        SortProtection SortProtectionActive { get; }

        void AjouterSortAttaque(SortAttaque sortAttaque);

        void AjouterSortProtection(SortProtection sortProtection);

        void ActiverSortAttaque(string activerSortAttaque);

        void ActiverSortProtection(string activerSortProtection);

        List<string> AfficherSortAttaque();

        List<string> AfficherSortProtection();

        void AttaqueMagique(Guilde guilde);

    }
}
