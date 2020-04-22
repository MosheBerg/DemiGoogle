using System;
using System.Collections.Generic;
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

namespace DemiGoogle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool switched = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textChanged(object sender, TextChangedEventArgs e)
        {
            if (switched == false)
            {
                var tb = (TextBox)sender;
                using (tb.DeclareChangeBlock())
                {
                    foreach (var c in e.Changes)
                    {

                        if (c.AddedLength == 0) continue;

                        tb.Select(c.Offset, c.AddedLength);
                        if (tb.Text.Length == 1)
                            switchLetter(tb, 'ק', 'כ');
                        else if (tb.Text.Length == 2)
                            switchLetter(tb, 'ל', 'ל');
                        else if (tb.Text.Length == 4)
                            switchLetter(tb, 'ש', 'ה');
                        else if (tb.Text.Length == 5)
                            switchLetter(tb, 'ש', 'כ');
                        else if (tb.Text.Length == 6)
                            switchLetter(tb, 'ו', 'ב');
                        else if (tb.Text.Length == 7)
                            switchLetter(tb, 'ן', 'ד');
                        else if (tb.Text.Length == 9)
                            switchLetter(tb, 'ו', 'ל');
                        else if (tb.Text.Length == 10)
                            switchLetter(tb, 'ק', 'כ');
                        else if (tb.Text.Length == 11)
                            switchLetter(tb, 'ל', 'ו');
                        else if (tb.Text.Length == 13)
                            switchLetter(tb, 'ש', 'ל');
                        else if (tb.Text.Length == 14)
                            switchLetter(tb, 'מ', 'מ');
                        else if (tb.Text.Length == 15)
                            switchLetter(tb, 'ח', 'ט');
                        else if (tb.Text.Length == 16)
                            switchLetter(tb, 'ה', 'ב');
                        else if (tb.Text.Length == 17)
                            switchLetter(tb, '!', 'ח');
                        else switchLetter(tb, 'ז', ' ');
                        //חסד ואמת צדק ושלום
                        //שבע ארבע אחד שמונה
                        //tb.Select(tb.Text.Length, 0);
                        tb.CaretIndex = tb.Text.Length;
                    }
                }
            }
            switched = false;
        }

        private void switchLetter(TextBox tb, char oldChar, char newChar)
        {
            
            int pos = tb.Text.Length - 1;
            if (tb.Text[pos] == ' ')
                return;
            if (tb.Text[pos] == oldChar)
                if (pos > 0) tb.Text = tb.Text.Substring(0, pos) + newChar;
                else tb.Text = "" + newChar;
            else 
            {
                Random rand = new Random();
                do
                {
                    if (pos > 0) tb.Text = tb.Text.Substring(0, pos) + (char)('א' + rand.Next(0, 21));
                    else tb.Text = "" + (char)('א' + rand.Next(0, 21));
                } while (tb.Text[pos] == newChar);
            }
            switched = true;
        }
        
    }

}