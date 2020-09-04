using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Falser
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isFirst = true;
        bool isRun = false;
        bool canExecute = true;
        string etalon = "";
        private object thread;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void textInput_KeyDown(object sender, KeyEventArgs e)
        {
            if(canExecute == true)
            {
                if (e.Key == Key.Enter)
                {
                    if (isFirst == true)
                    {
                        textLabel.Content = textInput.Text;
                        isFirst = false;
                        etalon = textInput.Text;
                    }
                    else
                    {
                        if (etalon.Equals(textInput.Text))
                        {
                            this.Background = new SolidColorBrush(Colors.Green);
                            System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
                            sp.SoundLocation = "right.wav";
                            sp.Load();
                            sp.Play();
                        }
                        else
                        {
                            this.Background = new SolidColorBrush(Colors.Red);
                            System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
                            sp.SoundLocation = "wrong.wav";
                            sp.Load();
                            sp.Play();
                            canExecute = false;
                        }
                    }
                }
            }
            else
            {
                if (isRun == false)
                Task.Run(() =>
                {
                    isRun = true;
                    Thread.Sleep(3000);
                    canExecute = true;
                    isRun = false;
                });
            }

        }

    }
}
