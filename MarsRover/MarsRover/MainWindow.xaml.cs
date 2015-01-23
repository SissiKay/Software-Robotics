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

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MarsRover
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            while (GamePad.GetState(PlayerIndex.One).Buttons.Back != ButtonState.Pressed)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                    Console.WriteLine("Pressed A.");


            }
        }
    }
}
