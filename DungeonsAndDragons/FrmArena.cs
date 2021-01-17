using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DungeonsAndDragons
{
    public partial class FrmArena : Form
    {

        Dictionary<string, Guilde> listePersonnage = new Dictionary<string, Guilde>();
        Guilde C1 = null;
        Guilde C2 = null;

        public FrmArena()
        {
            InitializeComponent();
        }


        private void cmdCreerPersonnage_Click(object sender, EventArgs e)
        {
            Guilde p = null;
            Etre r = null;

            switch (lstRace.SelectedItem.ToString())
            {
                case "Humain":
                    r = new Humain(txtNomPersonnage.Text);
                    break;

                case "Elf":
                    r = new Elf(txtNomPersonnage.Text);
                    break;
            }


            switch (lstGuilde.SelectedItem.ToString())
            {
                case "Guerrier":
                    p = new Guerrier(r);
                    break;

                case "Magicien":
                    p = new Magicien(r);
                    break;
            }

            listePersonnage.Add(p.Race.Nom, p);

            lstPersonnage.Items.Clear();
            lstPersonnage.Items.AddRange(listePersonnage.Keys.ToArray());

        }

        private void lstPersonnage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guilde g = listePersonnage[lstPersonnage.SelectedItem.ToString()];

            lstConfigArmeMelee.Items.Clear();
            lstConfigArmure.Items.Clear();
            lstConfigSortAttaque.Items.Clear();
            lstConfigSortProtection.Items.Clear();

            rTxtInfoPersonnage.Text = g.ToString();

            tabOutils.TabPages.Remove(tabPageArmeMelee);
            tabOutils.TabPages.Remove(tabPageArmure);
            tabOutils.TabPages.Remove(tabPageMagieAttaque);
            tabOutils.TabPages.Remove(tabPageMagieProtection);

            if (g is IUtiliseLaMagie)
            {
                tabOutils.TabPages.Insert(0, tabPageMagieProtection);
                tabOutils.TabPages.Insert(0, tabPageMagieAttaque);

                lstConfigSortAttaque.Items.AddRange(((IUtiliseLaMagie)g).AfficherSortAttaque().ToArray());

                lstConfigSortProtection.Items.AddRange(((IUtiliseLaMagie)g).AfficherSortProtection().ToArray());
            }


            if (g is IUtiliseArmure)
            {
                tabOutils.TabPages.Insert(0, tabPageArmure);

                lstConfigArmure.Items.AddRange(((IUtiliseArmure)g).AfficherArmure().ToArray());
            }

            if (g is IUtiliseArmeDeMelee)
            {
                tabOutils.TabPages.Insert(0, tabPageArmeMelee);

                lstConfigArmeMelee.Items.AddRange(((IUtiliseArmeDeMelee)g).AfficherArmeDeMelee().ToArray());
            }

        }

        private void cmdAddArmeMelee_Click(object sender, EventArgs e)
        {
            IUtiliseArmeDeMelee g = (IUtiliseArmeDeMelee)listePersonnage[lstPersonnage.SelectedItem.ToString()];
            ArmeDeMelee arme = new ArmeDeMelee(txtArmeNom.Text, int.Parse(txtArmeAttaqueMin.Text), int.Parse(txtArmeAttaqueMax.Text), int.Parse(txtArmeDefenseMin.Text), int.Parse(txtArmeDefenseMax.Text));
            g.AjouterArmeDeMelee(arme);
            lstConfigArmeMelee.Items.Clear();
            lstConfigArmeMelee.Items.AddRange(g.AfficherArmeDeMelee().ToArray());

        }

        private void cmdAddArmure_Click(object sender, EventArgs e)
        {
            IUtiliseArmure g = (IUtiliseArmure)listePersonnage[lstPersonnage.SelectedItem.ToString()];
            Armure armure = new Armure(txtArmureNom.Text, int.Parse(txtArmureMin.Text), int.Parse(txtArmureMax.Text));
            g.AjouterArmure(armure);
            lstConfigArmure.Items.Clear();
            lstConfigArmure.Items.AddRange(g.AfficherArmure().ToArray());
        }

        private void cmdAddSortAttaque_Click(object sender, EventArgs e)
        {
            IUtiliseLaMagie g = (IUtiliseLaMagie)listePersonnage[lstPersonnage.SelectedItem.ToString()];
            SortAttaque sort = new SortAttaque(txtSortAttaqueNom.Text, int.Parse(txtSortAttaqueEnergie.Text), int.Parse(txtSortAttaqueMana.Text), int.Parse(txtSortAttaqueForce.Text), int.Parse(txtSortAttaqueEndurance.Text), int.Parse(txtSortAttaqueAgilite.Text), int.Parse(txtSortAttaqueCout.Text));
            g.AjouterSortAttaque(sort);
            lstConfigSortAttaque.Items.Clear();
            lstConfigSortAttaque.Items.AddRange(g.AfficherSortAttaque().ToArray());
        }

        private void cmdAddSortProtection_Click(object sender, EventArgs e)
        {
            IUtiliseLaMagie g = (IUtiliseLaMagie)listePersonnage[lstPersonnage.SelectedItem.ToString()];
            SortProtection sort = new SortProtection(txtSortProtectionNom.Text, int.Parse(txtSortProtectionEnergie.Text), int.Parse(txtSortProtectionMana.Text), int.Parse(txtSortProtectionForce.Text), int.Parse(txtSortProtectionEndurance.Text), int.Parse(txtSortProtectionAgilite.Text), int.Parse(txtSortProtectionCout.Text));
            g.AjouterSortProtection(sort);
            lstConfigSortProtection.Items.Clear();
            lstConfigSortProtection.Items.AddRange(g.AfficherSortProtection().ToArray());

        }

        private void cmdAutoGenerate_Click(object sender, EventArgs e)
        {
            Guilde conan = new Guerrier(new Humain("Conan"));
            Guilde bob = new Magicien(new Humain("Bob"));
            Guilde fling = new Guerrier(new Elf("Fling"));
            Guilde flang = new Magicien(new Elf("Flang"));

            ((Guerrier)conan).AjouterArmeDeMelee(new ArmeDeMelee("Glaive", 5, 20, 2, 7));
            ((Guerrier)conan).AjouterArmure(new Armure("Veste en cuir", 2, 7));

            ((Magicien)bob).AjouterSortAttaque(new SortAttaque("Éclair", 10, 3, 2, 2, 0, 6));
            ((Magicien)bob).AjouterSortProtection(new SortProtection("Plaster Magique", 10, 0, 0, 0, 0, 10));
            ((Magicien)bob).AjouterArmure(new Armure("Veste en cuir", 2, 7));


            ((Guerrier)fling).AjouterArmeDeMelee(new ArmeDeMelee("Glaive", 5, 20, 2, 7));
            ((Guerrier)fling).AjouterArmure(new Armure("Veste en cuir", 2, 7));

            ((Magicien)flang).AjouterSortAttaque(new SortAttaque("Éclair", 10, 3, 2, 2, 0, 6));
            ((Magicien)flang).AjouterSortProtection(new SortProtection("Plaster Magique", 10, 0, 0, 0, 0, 10));
            ((Magicien)flang).AjouterArmure(new Armure("Veste en cuir", 2, 7));


            listePersonnage.Add("Conan", conan);
            listePersonnage.Add("Bob", bob);
            listePersonnage.Add("Fling", fling);
            listePersonnage.Add("Flang", flang);

            lstPersonnage.Items.Clear();
            lstPersonnage.Items.AddRange(listePersonnage.Keys.ToArray());


        }

        private void cmdSetCombatant1_Click(object sender, EventArgs e)
        {
            cmdCombatant1Attaque.Enabled = false;
            cmdCombatant1Magie.Enabled = false;

            C1 = listePersonnage[lstPersonnage.SelectedItem.ToString()];
            C1.logAction += new Guilde.LogAction(LogC1Action);

            if (C1 is IUtiliseArmeDeMelee)
            {
                cmdCombatant1Attaque.Enabled = true;
            }
            if (C1 is IUtiliseLaMagie)
            {
                cmdCombatant1Magie.Enabled = true;
            }

            rTxtArenaInfo1.Text = C1.ToString();
        }


        private void cmdSetCombatant2_Click(object sender, EventArgs e)
        {
            cmdCombatant2Attaque.Enabled = false;
            cmdCombatant2Magie.Enabled = false;

            C2 = listePersonnage[lstPersonnage.SelectedItem.ToString()];
            C2.logAction += new Guilde.LogAction(LogC2Action);

            if (C2 is IUtiliseArmeDeMelee)
            {
                cmdCombatant2Attaque.Enabled = true;
            }
            if (C2 is IUtiliseLaMagie)
            {
                cmdCombatant2Magie.Enabled = true;
            }

            rTxtArenaInfo2.Text = C2.ToString();
        }

        public void LogC1Action(string message)
        {
            rTxtArenaAction1.Text = message;
        }

        public void LogC2Action(string message)
        {
            rTxtArenaAction2.Text = message;
        }

        private void cmdCombatant1Attaque_Click(object sender, EventArgs e)
        {
            ((IUtiliseArmeDeMelee)C1).AttaqueCorpsACorps(C2);
            RefreshInfoArena();
        }

        private void cmdCombatant1Magie_Click(object sender, EventArgs e)
        {
            ((IUtiliseLaMagie)C1).AttaqueMagique(C2);
            RefreshInfoArena();

        }

        private void cmdCombatant2Attaque_Click(object sender, EventArgs e)
        {
            ((IUtiliseArmeDeMelee)C2).AttaqueCorpsACorps(C1);
            RefreshInfoArena();
        }

        private void cmdCombatant2Magie_Click(object sender, EventArgs e)
        {
            ((IUtiliseLaMagie)C2).AttaqueMagique(C1);
            RefreshInfoArena();
        }

        private void lstConfigArmeMelee_SelectedIndexChanged(object sender, EventArgs e)
        {
            IUtiliseArmeDeMelee g = (IUtiliseArmeDeMelee)listePersonnage[lstPersonnage.SelectedItem.ToString()];
            g.ActiverArmeDeMelee(lstConfigArmeMelee.Text);
            rTxtInfoPersonnage.Text = g.ToString();
        }

        private void lstConfigArmure_SelectedIndexChanged(object sender, EventArgs e)
        {
            IUtiliseArmure g = (IUtiliseArmure)listePersonnage[lstPersonnage.SelectedItem.ToString()];
            g.ActiverArmure(lstConfigArmure.Text);
            rTxtInfoPersonnage.Text = g.ToString();
        }

        private void lstConfigSortAttaque_SelectedIndexChanged(object sender, EventArgs e)
        {
            IUtiliseLaMagie g = (IUtiliseLaMagie)listePersonnage[lstPersonnage.SelectedItem.ToString()];
            g.ActiverSortAttaque(lstConfigSortAttaque.Text);
            rTxtInfoPersonnage.Text = g.ToString();
        }

        private void lstConfigSortProtection_SelectedIndexChanged(object sender, EventArgs e)
        {
            IUtiliseLaMagie g = (IUtiliseLaMagie)listePersonnage[lstPersonnage.SelectedItem.ToString()];
            g.ActiverSortProtection(lstConfigSortProtection.Text);
            rTxtInfoPersonnage.Text = g.ToString();
        }

        private void FrmArena_Load(object sender, EventArgs e)
        {

        }

        public void RefreshInfoArena()
        {
            rTxtArenaInfo2.Text = C2.ToString();
            rTxtArenaInfo1.Text = C1.ToString();

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (tabControl1.SelectedTab == tabPageArena)
            {
                KeyEventArgs e = new KeyEventArgs(keyData);
                if (e.KeyCode == Keys.Q && C1 is IUtiliseArmeDeMelee)
                {

                    ((IUtiliseArmeDeMelee)C1).AttaqueCorpsACorps(C2);
                    

                }
                if (e.KeyCode == Keys.W && C1 is IUtiliseLaMagie)
                {
                    ((IUtiliseLaMagie)C1).AttaqueMagique(C2);
                    
                }

                if (e.KeyCode == Keys.O && C2 is IUtiliseArmeDeMelee)
                {
                    ((IUtiliseArmeDeMelee)C2).AttaqueCorpsACorps(C1);
                    
                }

                if (e.KeyCode == Keys.P && C2 is IUtiliseLaMagie)
                {
                    ((IUtiliseLaMagie)C2).AttaqueMagique(C1);
                    
                }
                RefreshInfoArena();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
