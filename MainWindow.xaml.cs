using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tutorial01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        bool success, success2, condition = true;
        private string console = "";
        private readonly string consoleTrue = "Verification reussi !", consoleFalse = " Verifier que vos/votre donée(s) soit bien ecris !";
        float value = 0;
        int values = 0;

        // exo 1
        float n1, n2, biggest = 0;
        private void BTNonClick_biggest(object sender, RoutedEventArgs e)
        {
            console = "exo 1 : ";
            success = float.TryParse(TB_nb1.Text, out value);// Convert a string to an float and return a bool after done 
            success2 = float.TryParse(TB_nb2.Text, out value);
            if (success && success2)
            {
                n1 = float.Parse(TB_nb1.Text);
                n2 = float.Parse(TB_nb2.Text);

                condition = n1 > n2;
                biggest = condition ? n1 : n2; // condition ? true : false ~~ ternary condition => shortcut to if condition

                LB_biggest.Content = biggest.ToString();
                console += consoleTrue;
            }
            else
            {
                console += consoleFalse;
            }
            LB_console.Content = console;
        }
        // fin exo 1

        // exo 2 
        float nbHeight, nbWeight, imc = 0;
        int nbAge = 0; //Pas d'utilite mais demandé
        string imcResult = "";
        private void BTNonClick_imc(object sender, RoutedEventArgs e)
        {
            console = "exo 2 : ";
            success = float.TryParse(TB_height.Text, out value);
            success2 = float.TryParse(TB_weight.Text, out value);
            if (success && success2)
            {
                nbHeight = float.Parse(TB_height.Text);
                nbWeight = float.Parse(TB_weight.Text);
                imc = nbWeight / (nbHeight * nbHeight); // imc is weight / height^2                   
                if (imc < 18)
                {
                    imcResult = "mince";
                }
                else if (imc >= 18 && imc < 25)
                {
                    imcResult = "en bonne santé";
                }
                else if (imc >= 25 && imc < 30)
                {
                    imcResult = "avoir des kilos en trop";
                }
                else
                {
                    imcResult = "obese";
                }
                LB_imc.Content = imcResult;
                console += consoleTrue;
            }
            else
            {
                console += consoleFalse;
            }
            LB_console.Content = console;
        }
        // fin exo 2
        // exo 3
        int nb_evenAndOdd = 0;
        string oddEven = "";
        private void BTNonClick_oddEven(object sender, RoutedEventArgs e)
        {
            console = "exo 3 : ";
            list_oddEven_result.Items.Clear(); // to not re-add rather than display , everythime i press the btn he supress everything in the listBox
            success = int.TryParse(TB_oddEven.Text, out values);
            if (success)
            {
                nb_evenAndOdd = int.Parse(TB_oddEven.Text);
                for (int i = 0; i < nb_evenAndOdd + 1; i++)
                {
                    condition = i % 2 == 0;

                    oddEven = i + " :";
                    oddEven += condition ? " Paire" : " Impaire"; // condition ? true : false ~~ ternary condition => shortcut to if condition

                    list_oddEven_result.Items.Add(oddEven);
                }
                console += consoleTrue;
            }
            else
            {
                console += consoleFalse;
            }
            LB_console.Content = console;
        }
        // fin exo 3
        // exo 4

        int nbr_max, nbr_min = 0;
        string? nbr_minMax = ""; // #nullable

        private void BTNonClick_minMax(object sender, RoutedEventArgs e)
        {
            console = "exo 4 : ";
            string[] arrayNbr = tb_arrayNbr.Text.Split(",");
            
            success2 = true; // true by default we only want to spot errors
            for (int i =0; i < arrayNbr.Length; i++) // Parse our array to spot any string caracter that could't convert in int 
            {
                success = int.TryParse(arrayNbr[i], out values);
                if (!success) // if any cannot convert set succes 2 as false to block the pgrm
                {
                    success2 = false;
                }
            }
            if (success2)
            {
                int[] nbrArray = Array.ConvertAll(arrayNbr, s => int.Parse(s));
                nbr_max = nbrArray.Max();
                nbr_min = nbrArray.Min();
                nbr_minMax = $"{nbr_min} ~~ {nbr_max}";
                LB_arrayBiggestLowest.Content = nbr_minMax;
                console += consoleTrue;
            }
            else
            {
                console += consoleFalse;
            }
            LB_console.Content = console;
        }
        // fin exo 4
        // exo 5
        string? rightWord, listChar = ""; // #nullable
        char[]? spliceWord;  // #nullable
        private void BTNonClick_inverse(object sender, RoutedEventArgs e)
        {
            console = "exo 5 : ";
            listChar = "";
            rightWord = TB_right.Text;
            spliceWord = rightWord.ToCharArray(); // cut a word/number or a string character by character to put them in an array/tab
            Array.Reverse(spliceWord);  //Reverse the order of elements in an array/tab
            foreach (char Char in spliceWord)
            {
                listChar += " " + Char + " ";
            }
            LB_inverse.Content = listChar;
        } //
          // fin exo 5
    }
}