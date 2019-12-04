using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ECE_PROJET_FINAL
{
    class Program
    {
        static void Main(string[] args)
        {
            Bienvenue();
        }

        static void Bienvenue()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Bienvenue dans le Jeu de Nîme!" + "\n");
            Menu();
        }
        static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("MENU:" + "\n" + "\nPressez 1: pour voir les regles du jeu" + "\nPressez 2: pour jouer" + "\nPressez 3: Pour entrer dans les options" +  "\nPressez 4: pour quitter le jeu de Nîme");

            ConsoleKeyInfo ChoixMenu;
            ChoixMenu = Console.ReadKey(true);
            switch (ChoixMenu.KeyChar)
            {
                case '1':
                    ReglesDeJeux(); break;
                case '2':
                    ModeDeJeux(); break;
                case '3':
                    AutresOptions(); break;
                case '4':
                    Console.WriteLine("Au revoir"); break;
                default:
                    Console.Clear(); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Choix Inexistant" + "\nVeuillez refaire un choix" + "\n"); Console.ForegroundColor = ConsoleColor.White; Menu(); break;
            }
        }
        static void ReglesDeJeux()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Voici les règles du jeux de Nîme:" + "\n" + "\nLes règles sont simples." + "\nCe jeu se joue à deux, contre une personne ou un ordinateur." + "\nIl suffit de piocher tour à tour une, deux ou trois allumettes." + "\nLe Perdant est celui qui pioche la dernière allumette." + "\n" + "\nAppuyer sur un bouton pour revenir au Menu.");
            ConsoleKeyInfo ChoixR;
            ChoixR = Console.ReadKey(true);
            switch (ChoixR.KeyChar)
            { default: Console.Clear(); Menu(); break; }
        }
        static void ModeDeJeux()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("MODE DE JEUX:" + "\nChoissiez le mode de jeu souhaitez." + "\n" + "\nMode 1: Contre une autre personne" + "\nMode 2: Contre une intelligence artificielle" + "\n");
            ConsoleKeyInfo ChoixMode;
            ChoixMode = Console.ReadKey(true);
            switch (ChoixMode.KeyChar)
            {
                case '1':
                    ChoixMultiJoueur();
                    break;
                case '2':
                    ChoixContreOrdinateur();
                    break;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Choix Inexistant" + "\nVeuillez refaire un choix" + "\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    ModeDeJeux();
                    break;
            }
        }
        static void AutresOptions()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("OPTION\n" + "\n1: Voir LeaderBoard\n" + "\n2: Voir Score\n"+ "\n3: Revenir au Menu");

            ConsoleKeyInfo ChoixOptions;
            ChoixOptions = Console.ReadKey(true);
            switch (ChoixOptions.KeyChar)
            {
                case '1':
                    //Menu(); break;
                case '2':
                    RecherchePointJoueur("pseudo"); break;
                case '3':
                    Console.Clear();Menu(); break;
                default:
                    Console.Clear(); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Choix Inexistant" + "\nVeuillez refaire un choix" + "\n"); Console.ForegroundColor = ConsoleColor.White; AutresOptions(); break;
            }
        }
        


        static void ChoixMultiJoueur()
        {
            Console.Clear();
            Console.WriteLine("Mode Multijoueur\n" + "\n1 VS 1\n" + "\n1: Mode choix de position libre" + "\n2: Mode choix de position consécutif");
            ConsoleKeyInfo ChoixModeJeu1;
            ChoixModeJeu1 = Console.ReadKey(true);
            switch (ChoixModeJeu1.KeyChar)
            {
                case '1':
                    MultiJoueurLibre();
                    break;
                case '2':
                    MultiJoueurConsecutif();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Choix Inexistant" + "\nVeuillez refaire un choix" + "\n"); Console.ForegroundColor = ConsoleColor.White; ChoixMultiJoueur(); break;
            }
        }
        static void ChoixContreOrdinateur()
        {
            Console.Clear();
            Console.WriteLine("MODE DE JEUX:" + "\nMode contre l'ordinateur" + "\n" + "\n1: Niveau de l'IA > Facile" + "\n2: Niveau de l'IA > Difficile");
            ConsoleKeyInfo ChoixModeJeu2;
            ChoixModeJeu2 = Console.ReadKey(true);
            switch (ChoixModeJeu2.KeyChar)
            {
                case '1':
                    IAOrdinateurFacile();
                    break;
                case '2':
                    IAOrdinateurDifficile();
                    break;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Choix Inexistant" + "\nVeuillez refaire un choix" + "\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    ChoixContreOrdinateur();
                    break;
            }
        }


        static void MultiJoueurLibre()
        {
            string pseudo = " ", gagnant = " "; int t = 1;
            string joueur1 = IdentificationJoueur(pseudo, t);t = 2;
            string joueur2 = IdentificationJoueur(pseudo, t);
            int nbAllumette, tirage, position, turn = 0;
            Console.Clear();

            do
            {
                Console.WriteLine("Choisissez le nombre d'allumette pour jouer entre 5 et 30");
                int.TryParse(Console.ReadLine(), out nbAllumette);
            } while (nbAllumette < 5 || nbAllumette > 30);
            Console.Clear();

            var tab = new string[nbAllumette];
            TableauSet(ref tab);
            turn = TurnToPlay(turn);
            int y = nbAllumette;
            do
            {
                Tableau(ref nbAllumette, ref tab);

                do
                {
                    if (turn == 1) { Console.WriteLine("\nTour de " + joueur1); }
                    if (turn == 2) { Console.WriteLine("\nTour de " + joueur2); }
                    do
                    {
                        Console.WriteLine("\nCombien d'allumettes voulez-vous retirer (entre une et trois) ?");
                        int.TryParse(Console.ReadLine(), out tirage);
                    } while (tirage < 1 || tirage > 3);
                    if ((tirage + 1) > y) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Impossible pas assez d'allumettes "); Console.ForegroundColor = ConsoleColor.White; }
                } while ((tirage + 1) > y);

                do
                {
                    do
                    {
                        Console.WriteLine("\nSaisir la position de l'allumette à retirer");
                        int.TryParse(Console.ReadLine(), out position);
                    } while (position < 1 || position > tab.Length);

                    bool ok = false;
                    if (tab[position - 1] == "    ")
                        TableauPositionVide(ref ok, ref position, ref tab);

                    if (tab[position - 1] == "  | ")
                    {
                        TableauRemove(ref nbAllumette, ref tab, ref position);
                        if (turn == 1) { Console.WriteLine("\nTour de " + joueur1); }
                        if (turn == 2) { Console.WriteLine("\nTour de " + joueur2); }
                    }

                    tirage--;
                    y--;
                } while (tirage > 0);
                Console.WriteLine();
                if (!VerifGagnant(ref y))
                    turn = 1 + (turn % 2);
            } while (y > 1);
            Console.Clear();
            Console.Write("Partie Terminé\n");
            if (turn == 1) { Console.Write("\n" + joueur1 + " a gagné la partie"); gagnant = joueur1; /*RechercheGagnant(gagnant);*/ }
            if (turn == 2) { Console.Write("\n" + joueur2 + " a gagné la partie"); gagnant = joueur2; /*RechercheGagnant(gagnant);*/}
            FinMultiJoueurLibreChoix();
        }
        static void FinMultiJoueurLibreChoix()
        {
            Console.WriteLine("\n" + "\n1: Refaire une partie" + "\n2: Revenir au Menu Principal" + "\n3: quitter");
            ConsoleKeyInfo Choix;
            Choix = Console.ReadKey(true);
            switch (Choix.KeyChar)
            {
                case '1': Console.Clear(); MultiJoueurLibre(); break;
                case '2': Console.Clear(); Menu(); break;
                case '3': Console.Clear(); Console.WriteLine("Au revoir"); break;
                default: Console.Clear(); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Choix Inexistant" + "\nVeuillez refaire un choix" + "\n"); Console.ForegroundColor = ConsoleColor.White; FinMultiJoueurLibreChoix(); break;
            }

        }
        
        static void MultiJoueurConsecutif()
        {
            string pseudo = " "; int t = 1;
            string joueur1 = IdentificationJoueur(pseudo, t); t = 2;
            string joueur2 = IdentificationJoueur(pseudo, t);
            int nbAllumette, tirage, position, turn = 0;
            Console.Clear();

            do
            {
                Console.WriteLine("Choisissez le nombre d'allumette pour jouer entre 5 et 30");
                int.TryParse(Console.ReadLine(), out nbAllumette);
            } while (nbAllumette < 5 || nbAllumette > 30);
            Console.Clear();

            var tab = new string[nbAllumette];
            TableauSet(ref tab);
            turn = TurnToPlay(turn);

            int y = nbAllumette;
            do
            {
                Tableau(ref nbAllumette, ref tab);

                do
                {
                    if (turn == 1) { Console.WriteLine("\nTour de " + joueur1); }
                    if (turn == 2) { Console.WriteLine("\nTour de " + joueur2); }
                    do
                    {
                        Console.WriteLine("\nCombien d'allumettes voulez-vous retirer (entre une et trois) ?");
                        int.TryParse(Console.ReadLine(), out tirage);
                    } while (tirage < 1 || tirage > 3);
                    if ((tirage + 1) > y) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Impossible pas assez d'allumettes "); Console.ForegroundColor = ConsoleColor.White; }
                } while ((tirage + 1) > y);

                do
                {
                    Console.WriteLine("\nSaisir la position pour retirer la ou les allumettes");
                    int.TryParse(Console.ReadLine(), out position);
                } while (position < 1 || position > tab.Length);

                ChoixConsécutifs(ref tirage, ref tab, ref position);

                int j = 0;
                do
                {

                    TableauRemoveConsecutif(ref nbAllumette, ref tab, ref position, ref y);
                    if (turn == 1) { Console.WriteLine("\nTour de " + joueur1); }
                    if (turn == 2) { Console.WriteLine("\nTour de " + joueur2); }


                    j++;
                } while (j < tirage);
                Console.WriteLine();
                if (!VerifGagnant(ref y))
                    turn = 1 + (turn % 2);
            } while (y > 1);
            Console.Clear();
            Console.Write("Partie Terminé");
            if (turn == 1) { Console.Write("\n" + joueur1 +" a gagné la partie"); /*RechercheGagnant(gagnant);*/ }
            if (turn == 2) { Console.Write("\n" + joueur2 + " a gagné la partie"); /*RechercheGagnant(gagnant);*/ }
            FinMultiJoueurConsecutifChoix();
        }
        static void FinMultiJoueurConsecutifChoix()
        {
            Console.WriteLine("\n" + "\n1: Refaire une partie" + "\n2: Revenir au Menu Principal" + "\n3: quitter");
            ConsoleKeyInfo Choix;
            Choix = Console.ReadKey(true);
            switch (Choix.KeyChar)
            {
                case '1': Console.Clear(); MultiJoueurConsecutif(); break;
                case '2': Console.Clear(); Menu(); break;
                case '3': Console.Clear(); Console.WriteLine("Au revoir"); break;
                default: Console.Clear(); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Choix Inexistant" + "\nVeuillez refaire un choix" + "\n"); Console.ForegroundColor = ConsoleColor.White; FinMultiJoueurConsecutifChoix(); break;
            }

        }


        static void IAOrdinateurFacile()
        {
            string pseudo = " "; int t = 1;
            string joueur1 = IdentificationJoueur(pseudo, t);
            Console.Clear();
            int TirageOrdi = 0, PositionOrdi = 0;
            int nbAllumette, tirage, position = 0, turn = 0;
            do
            {
                Console.WriteLine("Choisissez le nombre d'allumette pour jouer entre 5 et 30");
                nbAllumette = int.Parse(Console.ReadLine());
            } while (nbAllumette < 5 || nbAllumette > 30);
            Console.Clear();

            var tab = new string[nbAllumette];
            TableauSet(ref tab);
            turn = TurnToPlay(turn);

            int y = nbAllumette, j = 0;
            do
            {
                Tableau(ref nbAllumette, ref tab);

                if (turn == 1)
                {
                    do
                    {
                        Console.WriteLine("\n A votre tour de jouer " + joueur1);
                        do
                        {
                            Console.WriteLine("\nCombien d'allumettes voulez-vous retirer (entre une et trois) ?");
                            int.TryParse(Console.ReadLine(), out tirage);
                        } while (tirage < 1 || tirage > 3);
                        if ((tirage + 1) > y) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Impossible pas assez d'allumettes "); Console.ForegroundColor = ConsoleColor.White; }
                    } while ((tirage + 1) > y);
                    j = 0;
                    do
                    {
                        do
                        {
                            Console.WriteLine("\nSaisir la position de l'allumette " + (j + 1) + " à retirer");
                            int.TryParse(Console.ReadLine(), out position);
                        } while (position < 1 || position > tab.Length);

                        bool ok = false;
                        if (tab[position - 1] == "    ")
                        {
                            TableauPositionVide(ref ok, ref position, ref tab);
                        }
                        if (tab[position - 1] == "  | ")
                        {
                            TableauRemove(ref nbAllumette, ref tab, ref position);
                            Console.WriteLine("\nTour de Joueur 1");
                        }
                        tirage--;
                        y--;
                    } while (tirage > 0);
                    Console.WriteLine();
                }
                if (turn == 2)
                {
                    OrdinateurFacileTirage(ref TirageOrdi, ref y);
                    do
                    {
                        OrdinateurFacilePosition1(ref PositionOrdi, ref position, ref tab);
                        bool ok = false;
                        if (tab[PositionOrdi - 1] == "    ")
                            OrdinateurFacilePosition2(ref PositionOrdi, ref position, ref tab, ref ok);

                        if (tab[position - 1] == "  | ")
                            TableauRemove(ref nbAllumette, ref tab, ref position);

                        TirageOrdi--;
                        y--;
                    } while (TirageOrdi > 0);
                }

                if (!VerifGagnant(ref y))
                    turn = 1 + (turn % 2);
            } while (y > 1);

            Console.Write("Partie Terminé");
            if (turn == 1) { Console.Write("\nVous avez gagné la partie " + joueur1); /*RechercheGagnant(gagnant);*/ }
            if (turn == 2) { Console.Write("\nL'Ordinateur a gagné la partie"); }
            FinIAOrdinateurFacileChoix();

        }
        static void FinIAOrdinateurFacileChoix()
        {
            Console.WriteLine("\n" + "\n1: Refaire une partie" + "\n2: Revenir au Menu Principal" + "\n3: quitter");
            ConsoleKeyInfo Choix;
            Choix = Console.ReadKey(true);
            switch (Choix.KeyChar)
            {
                case '1': Console.Clear(); IAOrdinateurFacile(); break;
                case '2': Console.Clear(); Menu(); break;
                case '3': Console.Clear(); Console.WriteLine("Au revoir"); break;
                default: Console.Clear(); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Choix Inexistant" + "\nVeuillez refaire un choix" + "\n"); Console.ForegroundColor = ConsoleColor.White; FinIAOrdinateurFacileChoix(); break;
            }

        }


        static void IAOrdinateurDifficile()
        {
            string pseudo = " "; int t = 1;
            string joueur1 = IdentificationJoueur(pseudo, t);
            Console.Clear();
            int nbAllumette, tirage, position, turn = 0;
            int TirageOrdi = 0, PositionOrdi = 0;
            do
            {
                Console.WriteLine("Choisissez le nombre d'allumette pour jouer (entre 5 et 30)");
                nbAllumette = int.Parse(Console.ReadLine());
            } while (nbAllumette < 5 || nbAllumette > 30);
            Console.Clear();
            int AllumetesRestantes = nbAllumette;

            var tab = new string[nbAllumette];
            TableauSet(ref tab);
            turn = TurnToPlay(turn);

            int y = nbAllumette, j = 0;
            do
            {
                Tableau(ref nbAllumette, ref tab);
                if (turn == 1)
                {
                    do
                    {
                        Console.WriteLine("\n A votre tour de jouer " + joueur1);
                        do
                        {
                            Console.WriteLine("\nCombien d'allumettes voulez-vous retirer (entre une et trois) ?");
                            int.TryParse(Console.ReadLine(), out tirage);
                        } while (tirage < 1 || tirage > 3);
                        if ((tirage + 1) > y) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Impossible pas assez d'allumettes "); Console.ForegroundColor = ConsoleColor.White; }
                    } while ((tirage + 1) > y);
                    j = 0;
                    do
                    {
                        do
                        {
                            Console.WriteLine("\nSaisir la position de l'allumette " + (j + 1) + " à retirer");
                            int.TryParse(Console.ReadLine(), out position);
                        } while (position < 1 || position > tab.Length);

                        bool ok = false;
                        if (tab[position - 1] == "    ")
                        {
                            TableauPositionVide(ref ok, ref position, ref tab);
                        }
                        if (tab[position - 1] == "  | ")
                        {
                            TableauRemove(ref nbAllumette, ref tab, ref position);
                            Console.WriteLine("\nTour de Joueur 1");
                        }
                        tirage--;
                        y--;
                    } while (tirage > 0);
                    Console.WriteLine();
                    AllumetesRestantes = y;
                }
                if (turn == 2)
                {
                    Console.WriteLine("\nL'ordinateur réfléchis . . .");
                    System.Threading.Thread.Sleep(2000);
                    OrdinateurDifficile(AllumetesRestantes, ref TirageOrdi);
                    Console.WriteLine("L'Ordinateur a choisi d'enlever " + TirageOrdi + " allumette(s).");
                    System.Threading.Thread.Sleep(1000);
                    TableauOrdiRemove(ref TirageOrdi, ref PositionOrdi, ref tab, ref y);
                    Console.WriteLine();
                    AllumetesRestantes = y;
                }
                if (!VerifGagnant(ref y))
                    turn = 1 + (turn % 2);
            } while (y > 1);

            Console.Write("Partie Terminé");
            if (turn == 1) { Console.Write("\nVous avez gagné la partie " + joueur1); /*RechercheGagnant(gagnant);*/ }
            if (turn == 2) { Console.Write("\nL'Ordinateur a gagné la partie"); }
            FinIAOrdinateurDifficileChoix();
        }
        static void FinIAOrdinateurDifficileChoix()
        {
            Console.WriteLine("\n" + "\n1: Refaire une partie" + "\n2: Revenir au Menu Principal" + "\n3: quitter");
            ConsoleKeyInfo Choix;
            Choix = Console.ReadKey(true);
            switch (Choix.KeyChar)
            {
                case '1': Console.Clear(); IAOrdinateurDifficile(); break;
                case '2': Console.Clear(); Menu(); break;
                case '3': Console.Clear(); Console.WriteLine("Au revoir"); break;
                default: Console.Clear(); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Choix Inexistant" + "\nVeuillez refaire un choix" + "\n"); Console.ForegroundColor = ConsoleColor.White; FinIAOrdinateurDifficileChoix(); break;
            }
        }
        

        static void TableauSet(ref string[] tab)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                if (i < 10)
                { Console.Write(" "); }
                tab[i] = "  | ";
                Console.Write(" " + (i + 1) + " ");
            }
            Console.WriteLine();
        }
        static void Tableau(ref int nbAllumette, ref string[] tab)
        {
            Console.Clear();
            LigneVerte(nbAllumette);
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < nbAllumette; i++)
            {
                if (i < 10) { Console.Write(" "); }
                Console.Write(" " + (i + 1) + " ");
            }
            Console.WriteLine();
            LigneVerte(nbAllumette);
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < nbAllumette; i++)
            { Console.Write(tab[i]); }
            Console.WriteLine();
            LigneVerte(nbAllumette);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void TableauPositionVide(ref bool ok, ref int position, ref string[] tab)
        {
            do
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nSaisir une autre position car la position " + position + " est deja vide ");
                    Console.ForegroundColor = ConsoleColor.White;
                    position = int.Parse(Console.ReadLine());
                } while (position < 1 || position > tab.Length);
                if (tab[position - 1] == "  | ")
                    ok = true;
            } while (!ok);
        }
        static void TableauRemove(ref int nbAllumette, ref string[] tab, ref int position)
        {
            Console.Clear();
            LigneVerte(tab.Length);
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < nbAllumette; i++)
            {
                if (i < 10) { Console.Write(" "); }
                tab[position - 1] = "    ";
                Console.Write(" " + (i + 1) + " ");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            LigneVerte(tab.Length);
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < nbAllumette; i++)
            { Console.Write(tab[i]); }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            LigneVerte(tab.Length);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void LigneVerte(int nbAllumette)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" ");
            for (int i = 0; i < nbAllumette; i++)
            {
                if (i < 10) { Console.Write("_"); }
                Console.Write("___" + (i > 9 ? "_" : ""));
            }
        }

        static void TableauRemoveConsecutif(ref int nbAllumette, ref string[] tab, ref int position, ref int y)
        {
            LigneVerte(nbAllumette);
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < nbAllumette; i++)
            {
                if (i < 10) { Console.Write(" "); }
                tab[position - 1] = "    ";
                Console.Write(" " + (i + 1) + " ");
            }
            Console.WriteLine();
            LigneVerte(nbAllumette);
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < nbAllumette; i++)
            { Console.Write(tab[i]); }
            Console.WriteLine();
            LigneVerte(nbAllumette);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            y--;
            position++;
        }
        static void ChoixConsécutifs(ref int tirage, ref string[] tab, ref int position)
        {
            bool okok = false;
            do
            {
                if (position + tirage - 1 > tab.Length)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nImpossible ressaisir une position");
                    Console.ForegroundColor = ConsoleColor.White;
                    int.TryParse(Console.ReadLine(), out position);
                }
                else
                    okok = true;
                if (tirage == 1)
                {
                    if (tab[position - 1] == "    ")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nImpossible ressaisir une position");
                        Console.ForegroundColor = ConsoleColor.White;
                        int.TryParse(Console.ReadLine(), out position);
                    }
                    else
                        okok = true;
                }
                if (tirage == 2)
                {
                    if (tab[position - 1] == "    " || tab[position] == "    ")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nImpossible ressaisir une position");
                        Console.ForegroundColor = ConsoleColor.White;
                        int.TryParse(Console.ReadLine(), out position);
                    }
                    else
                        okok = true;
                }
                if (tirage == 3)
                {
                    if (tab[position - 1] == "    " || tab[position] == "    " || tab[position + 1] == "    ")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nImpossible ressaisir une position");
                        Console.ForegroundColor = ConsoleColor.White;
                        int.TryParse(Console.ReadLine(), out position);
                    }
                    else
                        okok = true;
                }
            } while (okok == false);
        }

        static void TableauOrdiRemove(ref int TirageOrdi, ref int PositionOrdi, ref string[] tab, ref int y)
        {
            do
            {
                PositionOrdi = tab.ToList().IndexOf("  | ");
                Console.Clear();
                LigneVerte(tab.Length);
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 0; i < tab.Length; i++)
                {
                    if (i < 10) { Console.Write(" "); }
                    tab[PositionOrdi] = "    ";
                    Console.Write(" " + (i + 1) + " ");
                }
                Console.WriteLine();
                LigneVerte(tab.Length);
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                for (int i = 0; i < tab.Length; i++)
                { Console.Write(tab[i]); }
                Console.WriteLine();
                LigneVerte(tab.Length);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                TirageOrdi--;
                y--;
            } while (TirageOrdi > 0);
        }
        static void OrdinateurFacileTirage(ref int TirageOrdi, ref int y)
        {
            Random tirageOr = new Random();
            do
            {
                TirageOrdi = tirageOr.Next(1, 4);
                Console.WriteLine("L'Ordinateur a choisi d'enlever " + TirageOrdi + " allumettes.");
            } while ((TirageOrdi + 1) > y);
        }
        static void OrdinateurFacilePosition1(ref int PositionOrdi, ref int position, ref string[]tab)
        {
            Random positionOr = new Random();
            Console.WriteLine("\nL'ordinateur réfléchis . . .");
            System.Threading.Thread.Sleep(2000);
            do
            {
                PositionOrdi = positionOr.Next(1, tab.Length);
                position = PositionOrdi;
            } while (position < 1 || position > tab.Length);
            System.Threading.Thread.Sleep(2000);
        }
        static void OrdinateurFacilePosition2(ref int PositionOrdi, ref int position, ref string[] tab,ref bool ok)
        {
            do
            {
                Random positionOr = new Random();
                do
                {
                    PositionOrdi = positionOr.Next(1, tab.Length);
                    position = PositionOrdi;
                } while (position < 1 || position > tab.Length);

                if (tab[position - 1] == "  | ")
                { ok = true; }
            } while (!ok);
        }
        static int OrdinateurDifficile(int AllumetesRestantes, ref int TirageOrdi)
        {
            if (AllumetesRestantes % 4 == 0)
                TirageOrdi = 3;
            if (AllumetesRestantes % 4 == 1 || AllumetesRestantes % 4 == 3)
                TirageOrdi = 2;
            if (AllumetesRestantes % 4 == 2)
                TirageOrdi = 1;

            return TirageOrdi;
        }

        static int TurnToPlay(int turn)
        {            
            Random RandomTurn = new Random();
            turn = RandomTurn.Next(1,3);
            Console.WriteLine(turn);
            return turn;
        }
        static bool VerifGagnant(ref int y)
        {
            if (y == 1)
                return true;
            else
                return false;
        }


        static string IdentificationJoueur(string pseudo, int t)
        {
            string F = "C:\\Users\\Axel\\Desktop\\ECE PROJET FINAL\\F.txt";
            Console.Clear();
            Console.Write("\nJoueur " + t + " entrez votre pseudo : ");
            pseudo = Console.ReadLine();
            RechercherJoueur(ref F, ref pseudo);

            return pseudo;
        }
        static void RechercherJoueur(ref string F, ref string pseudo)
        {
            string res = null;
            bool found = false;
            try
            {
                StreamReader sr = new StreamReader(F);
                string ligne = " ";
                while (sr.Peek() > 0 && !found)
                {
                    ligne = sr.ReadLine();
                    string[] temp = ligne.Split(' ');
                    if (temp[0] == pseudo)
                    {
                        res = temp[0];
                        found = true;
                    }
                }
                sr.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            if (found == false)
            { EnregistrerJoueur(ref F, ref pseudo); }
        }
        static void EnregistrerJoueur(ref string F, ref string pseudo)
        {
            int point = 0;
            try
            {
                StreamWriter sw = new StreamWriter(F, true);
                sw.WriteLine(pseudo + " " + point);
                sw.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
        }

        static void RecherchePointJoueur(string pseudo)
        {
            Console.Clear();
            Console.Write("\nEntrez votre pseudo : ");
            pseudo = Console.ReadLine();
            PointJoueur(pseudo);
            ChoixPointJoueur();
        }
        static void PointJoueur(string pseudo)
        {
            Console.Clear();
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\Axel\\Desktop\\ECE PROJET FINAL\\F.txt");
                string ligne = " ";
                while (sr.EndOfStream == false)
                {
                    ligne = sr.ReadLine();
                    string[] temp = ligne.Split(' ');
                    if (temp[0] == pseudo) Console.WriteLine("Voici les informations de " + pseudo + " :" + "\n   " + temp[1] + " points cumulés");
                }sr.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
        }
        static void ChoixPointJoueur()
        {
            Console.WriteLine("\n1: Refaire une recherche"+"\n2: Revenir aux Options"+"\n3: Revenir au Menu Principal"+"\n4: Quitter le Jeu");
            ConsoleKeyInfo ChoixRechercheInfoJoueur;
            ChoixRechercheInfoJoueur = Console.ReadKey(true);
            switch (ChoixRechercheInfoJoueur.KeyChar)
            {
                case '1':
                    RecherchePointJoueur("pseudo"); break;
                case '2':
                    AutresOptions(); break;
                case '3':
                    Menu(); break;
                case '4':
                    Console.WriteLine("Au revoir"); break;
                default:
                    Console.Clear(); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Choix Inexistant" + "\nVeuillez refaire un choix" + "\n"); Console.ForegroundColor = ConsoleColor.White; ChoixPointJoueur(); break;
            }
        }


        // --------------------- MARCHE PAS ---------------------



        /*
        static void Top5()
        {
           
            Console.Clear();
            List<string> liste = new List<string>();
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\Axel\\Desktop\\ECE PROJET FINAL\\F.txt");
                string ligne = " ";
                while (sr.EndOfStream == false)
                {
                    ligne = sr.ReadLine();
                    if (!string.IsNullOrEmpty(ligne)) liste.Add(ligne);
                }
                sr.Close();

            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }

            IOrderedEnumerable<string> listeOrdonnee liste.OrderBy(element > Convert.ToInt32(element.Split(' ')[2]));

            try
            {
                StreamWriter sw = new StreamWriter("C:\\Users\\Axel\\Desktop\\ECE PROJET FINAL\\F.txt",true);
                foreach (string ligne in listeOrdonnee)
                {
                    sw.WriteLine(ligne);
                }
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            
        }

        static void RechercheGagnant(string gagnant)
        {
            bool trouve = false;
            RechercheDuGagnant(gagnant, ref trouve);
            //if (trouve == true)
            //PointGagnant(gagnant, ref point);

        }
        static bool RechercheDuGagnant(string gagnant, ref bool trouve)
        {
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\Axel\\Desktop\\ECE PROJET FINAL\\F.txt");
                string ligne = " ";
                while (sr.EndOfStream == false)
                {
                    ligne = sr.ReadLine();
                    string[] temp = ligne.Split(' ');
                    if (temp[0] == gagnant)
                    {
                        StreamWriter sw = new StreamWriter("C:\\Users\\Axel\\Desktop\\ECE PROJET FINAL\\F.txt", true);
                        sw.Write(temp[1 + 1]);
                        sw.Close();
                        trouve = true;
                    }
                }
                sr.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            return trouve;

        }
        /*static void PointGagnant(string gagnant,ref int point)
        {
            try
            {

                StreamWriter sw = new StreamWriter("C:\\Users\\Axel\\Desktop\\ECE PROJET FINAL\\F.txt", true);
                sw.WriteLine(point + 1);
                sw.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
        }*/
    }
}
