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
// XNA used for xbox360 controller 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
// User for serial ports
using System.IO.Ports;

namespace MarsRover
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SerialPort serialPort;

        public MainWindow()
        {
            InitializeComponent();
            
            serialPort = new SerialPort("COM5");

            serialPort.BaudRate = 9600;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.DataBits = 8;
            serialPort.Handshake = Handshake.None;
            

            serialPort.Open();

            // Controller processing
            while (GamePad.GetState(PlayerIndex.One).Buttons.Back != ButtonState.Pressed)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
                    Console.WriteLine("Pressed A.");

                 if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed)
                    Console.WriteLine("Pressed B.");

                 if (serialPort.IsOpen)
                 {
                     serialPort.WriteLine("stringme");
                 }
            }

            serialPort.Close();


        }
    }
}
