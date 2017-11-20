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
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;
using Lego;
using Lego.Ev3;

namespace LegoProject2017_byFocus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LegoBot legobot = new LegoBot();
        public bool stopButtonClicked = false;
        
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();

            //legobot = new LegoBot();
            await LegoBot.MainBrick.ConnectToBrick();
            
            await LegoBot.MainBrick.Brick.DirectCommand.ClearAllDevicesAsync();
            LegoBot.MainBrick.Brick.BrickChanged += Brick_BrickChanged;


                
        }

        private void  Brick_BrickChanged(object sender, BrickChangedEventArgs e)
        {
            //throw new NotImplementedException();
            gyroTextBox.Text = legobot.GyroSensor.SIValue.ToString();
            colourTextBox.Text = legobot.ColourSensor.SIValue.ToString();
            ultraTextBox.Text = legobot.UltrasonicSensor.SIValue.ToString();
           
        }

        private async void forwardButton_Click(object sender, RoutedEventArgs e)
        {
            //float distance = legobot.UltrasonicSensor.SIValue;
            while (legobot.UltrasonicSensor.SIValue >= 10 )
            {
                await legobot.MoveForward();
            } await legobot.Stop();
            
        }

        private async void backwardButton_Click(object sender, RoutedEventArgs e)
        {
            //float distance = legobot.UltrasonicSensor.SIValue;
            
            for(int i=0; i < 200; i++)
            { await legobot.MoveBackward(); }
                
            

        }

        private async void turnLeftButton_Click(object sender, RoutedEventArgs e)
        {
            await legobot.TurnLeft();

        }

        private async void turnRightButton_Click(object sender, RoutedEventArgs e)
        {
            await legobot.TurnRight();
        }

        private void turnAroundButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void stopButton_Click(object sender, RoutedEventArgs e)
        {
            //stopButtonClicked = true;
            await legobot.Stop();
        }
    }
}
