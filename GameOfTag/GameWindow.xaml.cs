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
using System.Windows.Shapes;

namespace GameOfTag
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        GameLogic game;
        public GameWindow()
        {
            InitializeComponent();
            game = new GameLogic();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private void NewGame_Button(object sender, RoutedEventArgs e)
        {
            GameWindow gameWindow = new GameWindow();
            gameWindow.Show();
            Close();
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            Close();
        }

        private void StartGame()
        {
            game.Start();
            for (int i = 0; i < 200; i++)
                game.ShiftRandom();

        }

        private void UpdatingButtons()
        {
            for (int i = 0; i < 16; i++)
            {
                int number = game.GetNumber(i);
                button(i).Content = number.ToString();
                if (number > 0)
                    button(i).Visibility = Visibility.Visible;
                else if (number == 0)
                    button(i).Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int position = Convert.ToInt16(((Button)sender).Tag);
            game.Shift(position);
            UpdatingButtons();
            if (game.CheckNumber())
                MessageBox.Show("Вы выиграли!");
        }

        private Button? button(int i)
        {
            switch (i)
            {
                case 0: return button0;
                case 1: return button1;
                case 2: return button2;
                case 3: return button3;
                case 4: return button4;
                case 5: return button5;
                case 6: return button6;
                case 7: return button7;
                case 8: return button8;
                case 9: return button9;
                case 10: return button10;
                case 11: return button11;
                case 12: return button12;
                case 13: return button13;
                case 14: return button14;
                case 15: return button15;
                default: return null;
            }
        }
    }
}
