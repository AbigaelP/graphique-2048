using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphique
{
    public partial class Form1 : Form
    {
        // Définir l'aléatoire en dehors du void main pour gagner de la rapidité
        static Random random = new Random();

        // Déclarer le score
        static int score = 0;

        // Déclarer la victoire
        static bool gagner = false;

        // Déclarer le mouvement
        static bool controleMouvements = false;


        //initiation des variables
        Label[,] lblTableau = new Label[4, 4];
        int[,] tableau = new int[4, 4];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            for (int i = 0; i < tableau.GetLength(0); i++)
            {
                for (int j = 0; j < tableau.GetLength(1); j++)
                {
                    lblTableau[i, j] = new Label();
                    lblTableau[i, j].Bounds = new Rectangle(140 + 90 * i, 125 + 90 * j, 80, 80);
                    lblTableau[i, j].BackColor = Color.FromArgb(145, 211, 249);
                    lblTableau[i, j].Font = new Font("Arial", 10);
                    lblTableau[i, j].ForeColor = Color.Black;
                    Controls.Add(lblTableau[i, j]);
                }
            }
            // Mettre deux nombre aléatoire
            //for (int p = 0; p <= 1; p++)
            //{
            //Aleatoire();
            //}
            tableau[0,0]= 2;
            tableau[0,1]= 4;
            tableau[0,2]= 8; 
            tableau[0,3]= 16;
            tableau[1,0]= 32;
            tableau[1,1]= 64;
            tableau[1,2]= 128;
            tableau[1,3]= 256;
            tableau[2,0]= 512;
            tableau[2,1]= 1024;
            tableau[2,2]= 2048;
            
            AfficherTableau();

        }


        private void AfficherTableau()
        {
            for (int i = 0; i < tableau.GetLength(0); i++)
            {
                for (int j = 0; j < tableau.GetLength(1); j++)
                {
                    if (tableau[i, j] > 0)
                    {
                        lblTableau[i, j].Text = tableau[i, j].ToString();
                        switch (tableau[i, j])
                        {
                            case 2:
                                lblTableau[i, j].BackColor = Color.FromArgb(145, 162, 249);
                                break;
                            case 4:
                                lblTableau[i, j].BackColor = Color.FromArgb(90, 108, 199);
                                break;
                            case 8:
                                lblTableau[i, j].BackColor = Color.FromArgb(49, 58, 105);
                                break;
                            case 16:
                                lblTableau[i, j].BackColor = Color.FromArgb(74, 49, 105);
                                break;
                            case 32:
                                lblTableau[i, j].BackColor = Color.FromArgb(110, 73, 199);
                                break;
                            case 64:
                                lblTableau[i, j].BackColor = Color.FromArgb(135, 94, 249);
                                break;
                            case 128:
                                lblTableau[i, j].BackColor = Color.FromArgb(179, 94, 249);
                                break;
                            case 256:
                                lblTableau[i, j].BackColor = Color.FromArgb(203, 94, 249);
                                break;
                            case 512:
                                lblTableau[i, j].BackColor = Color.FromArgb(187, 56, 199);
                                break;
                            case 1024:
                                lblTableau[i, j].BackColor = Color.FromArgb(247, 163, 255);
                                break;
                            case 2048:
                                lblTableau[i, j].BackColor = Color.FromArgb(252, 214, 255);
                                break;
                            default:
                                lblTableau[i, j].BackColor = Color.FromArgb(145, 211, 249);
                                break;
                        }
                    }
                    else
                    {
                        lblTableau[i, j].Text = "";
                        lblTableau[i, j].BackColor = Color.FromArgb(145, 211, 249);
                    }
                }
            }
        }

        private int[] ChangerOrdre(int nb0, int nb1, int nb2, int nb3)
        {

            //interchanger deux valeurs numérique si un 0 est présent dans les valeurs
            if (nb2 == 0 && nb3 > 0)
            {
                nb2 = nb3;
                nb3 = 0;
                controleMouvements = true; //controler si le mouvements a eu lieu
            }

            if (nb1 == 0 && nb2 > 0)
            {
                nb1 = nb2;
                nb2 = nb3;
                nb3 = 0;
                controleMouvements = true; //controler si le mouvements a eu lieu
            }

            if (nb0 == 0 && nb1 > 0)
            {
                nb0 = nb1;
                nb1 = nb2;
                nb2 = nb3;
                nb3 = 0;
                controleMouvements = true; //controler si le mouvements a eu lieu
            }

            //fusionner les tuiles si elles ont les memes valeurs 
            if (nb0 == nb1 && nb0 != 0)
            {
                nb0 = nb0 + nb1; // +=nb1
                nb1 = nb2;
                nb2 = nb3;
                nb3 = 0;
                score += nb0; //calcule du score
                controleMouvements = true; //controle si le mouvements de la fusion a eu lieu
            }
            if (nb1 == nb2 && nb1 != 0)
            {
                nb1 = nb1 + nb2;
                nb2 = nb3;
                nb3 = 0;
                score += nb1;  //calcule du score
                controleMouvements = true; //controle si le mouvements de la fusion a eu lieu
            }
            if (nb2 == nb3 && nb2 != 0)
            {
                nb2 = nb2 + nb3;
                nb3 = 0;
                score += nb2;  //calcule du score
                controleMouvements = true; //controle si le mouvements de la fusion a eu lieu
            }

            //nouveau tableu contenant le (ou les) 0 dans la (ou les) dernière position
            int[] i = { nb0, nb1, nb2, nb3 };
            return i;
        }

        private void Aleatoire()
        {
            int ligne = tableau.GetLength(0);   //longueur de la dimmension x du tableau
            int colone = tableau.GetLength(1);  //longueur de la dimmension y du tableau

            int aleatoireLigne = random.Next(0, 4);  //ligne aléatoire du tableau
            int aleatoireColone = random.Next(0, 4);  //colone aléatoire du tableau 
            int nombreAleatoire = random.Next(0, 10);  //généré un nombre aléatoire

            //met un chiffre aléatoire uniquement s'il ecrase un 0
            if (tableau[aleatoireLigne, aleatoireColone] == 0)
            {

                //choix d'afficher un 2 ou un 4 avec 90% et 10% de chance
                if (nombreAleatoire == 9)
                {
                    tableau[aleatoireLigne, aleatoireColone] = 4;         //affiche un 4 dans le tableau
                }
                else
                {
                    tableau[aleatoireLigne, aleatoireColone] = 2;         //affiche un 2 dans le tableau
                }
            }

            //le chiffre écrasé n'est pas un 0 alors on recommence au début de la fonction
            else
            {
                Aleatoire();
            }

            
        }

        //Fonction déplacer les chiffres (tuiles) vers le bas
        private int[,] Droite()
        {
            int x, y, z, w;             //variable de position
            int[] bas = new int[4];

            //Passer dans chaques colones pour stocker les valeur des lignes et les manipuler
            for (int colone = 0; colone < tableau.GetLength(1); colone++)
            {
                //stocker les valeurs des lignes
                x = tableau[3, colone];
                y = tableau[2, colone];
                z = tableau[1, colone];
                w = tableau[0, colone];

                //changer l'ordre des numéros
                bas = ChangerOrdre(x, y, z, w);

                //redonner le nouvel ordre des nombres
                tableau[0, colone] = bas[3];
                tableau[1, colone] = bas[2];
                tableau[2, colone] = bas[1];
                tableau[3, colone] = bas[0];
            }
            
            return tableau;  //retourner le tableau complet avec les numéros != 0 en bas
        }

        //fonction déplacer les chiffres en haut
        private int[,] Gauche()
        {
            int x, y, z, w;             //variable de position
            int[] haut = new int[4];

            //Passer dans chaques colones pour stocker les valeur des lignes et les manipuler
            for (int colone = 0; colone < tableau.GetLength(1); colone++)
            {
                //stocker les valeurs des lignes
                x = tableau[0, colone];
                y = tableau[1, colone];
                z = tableau[2, colone];
                w = tableau[3, colone];

                //changer l'ordre des numéros
                haut = ChangerOrdre(x, y, z, w);   //haut[] veut dire qu'on parle d'une case en particulier,  pour tout le tableau on ne met pas [].

                //redonner le nouvel ordre des nombres
                tableau[0, colone] = haut[0];
                tableau[1, colone] = haut[1];
                tableau[2, colone] = haut[2];
                tableau[3, colone] = haut[3];

            }
            
            //retourner le tableau complet avec les numéros != 0 en haut
            return tableau;

        }

        //fonction déplacer les chiffres à droite
        private int[,] Bas()
        {
            int x, y, z, w;                 //variable de position
            int[] droite = new int[4];

            // Passer dans chaques lignes pour stocker les valeur des colones et les manipuler
            for (int ligne = 0; ligne < tableau.GetLength(0); ligne++)
            {
                //stocker les valeurs des colones
                x = tableau[ligne, 3];
                y = tableau[ligne, 2];
                z = tableau[ligne, 1];
                w = tableau[ligne, 0];

                //changer l'ordre des numéros
                droite = ChangerOrdre(x, y, z, w);

                //redonner le nouvel ordre des nombres
                tableau[ligne, 0] = droite[3];
                tableau[ligne, 1] = droite[2];
                tableau[ligne, 2] = droite[1];
                tableau[ligne, 3] = droite[0];
            }
            
            //retourner le tableau complet avec les numéros != 0 à droite
            return tableau;

        }

        //fonction déplacer les chiffres à gauche
        private int[,] Haut()
        {
            int x, y, z, w;                 //variable de position
            int[] gauche = new int[4];

            //Passer dans chaques lignes pour stocker les valeur des colones et les manipuler
            for (int ligne = 0; ligne < tableau.GetLength(0); ligne++)
            {
                x = tableau[ligne, 0];
                y = tableau[ligne, 1];
                z = tableau[ligne, 2];
                w = tableau[ligne, 3];

                //changer l'ordre des numéros
                gauche = ChangerOrdre(x, y, z, w);

                //redonner le nouvel ordre des nombres
                tableau[ligne, 0] = gauche[0];
                tableau[ligne, 1] = gauche[1];
                tableau[ligne, 2] = gauche[2];
                tableau[ligne, 3] = gauche[3];
            }
            
            //retourner le tableau complet avec les numéros != 0 à gauche
            return tableau;

        }

        // Fonction booléenne qui controle s'il reste un 0 dans le tableau ou si il y a un chiffre a 2028 ou s'il ont a perdu la game (plus de mouvements possible)
        private bool Controle()
        {
            int ligne = tableau.GetLength(0);  //longueur de la dimmension x du tableau
            int colone = tableau.GetLength(1);  //longueur de la dimmension y du tableau

            //controle si on a gagner: s'il y a un 2048 dans les tuiles
            while (!gagner)
            {
                gagner = ControleGagner();
                if (gagner)
                {
                    MessageBox.Show("Bravo vous avez gagné! Appyer sur C pour quitter ou sur les flèches pour continuer à jouer");
                }
                break;
            }



            // Parcourir les lignes du tableau
            for (int i = 0; i < ligne; i++)
            {
                // Parcourir les colonnes du tableau
                for (int j = 0; j < colone; j++)
                {
                    if (tableau[i, j] == 0)
                    {
                        return true;   //s'il reste un 0 dans le tableau, on retourne true

                    }
                }
                //controle si deux nombres dans une ligne sont identique
                if (ControlePerdu(tableau[i, 0], tableau[i, 1], tableau[i, 2], tableau[i, 3]))
                {
                    return true; //permet de continuer à jouer
                }
                //contrôle si deux nombres sont identique dans une colone
                if (ControlePerdu(tableau[0, i], tableau[1, i], tableau[2, i], tableau[3, i]))
                {
                    return true; //permet de continuer à jouer
                }
            }
            //on retourne false quand il n'y a plus de 0 dans le tableau ou deux nombres identiques contigües qui se suivent
            //on a perdu la game
            MessageBox.Show("Vous avez malheureusmeent perdu!");
            return false;
        }

        //méthode qui controle si deux nombre sont identique
        private bool ControlePerdu(int nb0, int nb1, int nb2, int nb3)
        {
            if (nb0 == nb1)
            {
                return true;
            }
            else if (nb1 == nb2)
            {
                return true;
            }
            else if (nb2 == nb3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Méthode qui controle si une case èà le nombre 2048
        private bool ControleGagner()
        {
            int ligne = tableau.GetLength(0);  //longueur de la dimmension x du tableau
            int colone = tableau.GetLength(1);  //longueur de la dimmension y du tableau

            for (int i = 0; i < ligne; i++)
            {
                for (int j = 0; j < colone; j++)
                {
                    if (tableau[i, j] == 2048)
                    {
                        return true; // si 2028 est présent on return true
                    }
                }
            }

            return false; // aucun 2048 dans les tuiles
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (Controle() == true)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        { //Fonction du mouvements des tuiles vers le haut
                            tableau = Gauche();
                            break;
                        }
                    case Keys.Right:
                        {//Fonction du mouvements des tuiles vers le bas
                            tableau = Droite();
                            break;
                        }
                    case Keys.Up:
                        {
                            //Fonction du mouvements des tuiles vers la gauche
                            tableau = Haut();
                            break;
                        }
                    case Keys.Down:
                        {
                            //Fonction du mouvements des tuiles vers la droite
                            tableau = Bas();
                            break;
                        }
                    case Keys.C:
                        {
                            // Arrêter le programme si la touche C est pressée
                            Application.Exit();
                            break;
                        }
                }
                //Générer un nombre aléatoire après le mouvement
                if (controleMouvements)
                {
                    Aleatoire();
                }
                // Afficher le tableau
                AfficherTableau();

                // Mettre le mouvements à false
                controleMouvements = false;
            }
               

        }


    }
}
