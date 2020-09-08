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
using System.Windows.Threading;

namespace Falser
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isFirst = true;
 //       bool isRun = false;
 //       bool canExecute = true;
        int pause = 3;
        string etalon = "";
        private object thread;
 //       string barcode = "";
        DispatcherTimer timer;




            public MainWindow()
        {
            InitializeComponent();
            textInput.Focus();
            textTimer.Text = pause.ToString();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(pause);
            timer.Tick += timer_Tick;
        }


        private void textInput_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                if (isFirst == true)
                {
                    textLabel.Content = textInput.Text;
                    isFirst = false;
                    etalon = textInput.Text;
                    textInput.Text = "";
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
                        textInput.Text = "";

                    }
                    else
                    {
                        this.Background = new SolidColorBrush(Colors.Red);
                        System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
                        sp.SoundLocation = "wrong.wav";
                        sp.Load();
                        sp.Play();
                        textInput.Text = "";
                        textInput.IsEnabled = false;
                        timer.Start();
                    }
                }
            }


            //            if (canExecute == true)
            //            {
            //                if (e.Key == Key.Enter)
            //                {
            //                    if (isFirst == true)
            //                    {
            //                        textLabel.Content = textInput.Text;
            //                        isFirst = false;
            //                        etalon = textInput.Text;
            //                        textInput.Text = "";
            //                    }
            //                    else
            //                    {
            //                        if (etalon.Equals(textInput.Text))
            //                        {
            //                            this.Background = new SolidColorBrush(Colors.Green);
            //                            System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
            //                            sp.SoundLocation = "right.wav";
            //                            sp.Load();
            //                            sp.Play();
            //                            textInput.Text = "";

            //                        }
            //                        else
            //                        {
            //                            this.Background = new SolidColorBrush(Colors.Red);
            //                            System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
            //                            sp.SoundLocation = "wrong.wav";
            //                            sp.Load();
            //                            sp.Play();
            //                            textInput.Text = "";
            //                            textInput.IsEnabled = false;
            ////                            canExecute = false;
            //                            timer.Start();
            //  //                          Task.Run(() =>
            //  //                          {
            //  //                              isRun = true;
            //  //                              //                       textInput.IsEnabled = false;
            //  //                              Thread.Sleep(3000);
            //  //                              enablebinput();
            //  ////                              textInput.IsEnabled = true;
            //  //                              canExecute = true;
            //  //                              isRun = false;

            //  //                          });
            // //                           textInput.IsEnabled = true;
            //                        }
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                //        textInput.Text = "";
            //                if (isRun == false)
            //                    Task.Run(() =>
            //                    {
            //                        isRun = true;
            // //                       textInput.IsEnabled = false;
            //                        Thread.Sleep(3000);
            //                        textInput.IsEnabled = true;
            //                        canExecute = true;
            //                        isRun = false;

            //                    });
            //            }




            //if (e.Key == Key.Enter)
            //{

            //    if (canExecute == true)
            //    {
            //        if (isFirst == true)
            //        {
            //            //               textLabel.Content = textInput.Text;
            //            textLabel.Content = barcode;
            //            isFirst = false;
            //            //                        etalon = textInput.Text;
            //            etalon = barcode;
            //            textInput.Text = "";
            //        }
            //        else
            //        {
            //            //                     if (etalon.Equals(textInput.Text))
            //            if (etalon.Equals(barcode))
            //            {
            //                this.Background = new SolidColorBrush(Colors.Green);
            //                System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
            //                sp.SoundLocation = "right.wav";
            //                sp.Load();
            //                sp.Play();
            //                textInput.Text = "";

            //            }
            //            else
            //            {
            //                this.Background = new SolidColorBrush(Colors.Red);
            //                System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
            //                sp.SoundLocation = "wrong.wav";
            //                sp.Load();
            //                sp.Play();
            //                textInput.Text = "";
            //                canExecute = false;
            //            }
            //        }
            //    }
            //    else
            //    {
            //                textInput.Text = "";
            //        if (isRun == false)
            //            Task.Run(() =>
            //            {
            //                isRun = true;
            //                Thread.Sleep(3000);
            //                canExecute = true;
            //                isRun = false;

            //            });
            //    }

            //}
            //else
            //{
            //    barcode = textInput.Text;
            //}






        }

        private void enablebinput()
        {
            textInput.IsEnabled = true;
            textInput.Text = "fgcxxcbv";
        }


        void timer_Tick(object sender, EventArgs e)
        {
             textInput.IsEnabled = true;
            textInput.Focus();
            timer.Stop();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int pause = Int32.Parse(textTimer.Text);
                this.pause = pause;
                timer.Interval = TimeSpan.FromSeconds(pause);
                textInput.Focus();
            }
            catch
            {

            }
        }
    }
}
