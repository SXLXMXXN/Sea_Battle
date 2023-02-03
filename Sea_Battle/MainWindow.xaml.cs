
using Sea_Battle;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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


namespace Sea_Battle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _gameconditions = 40;
        private int _left;
        private int _current = 0;
        private int _deckcount4 = 0;
        private int _deckcount3 = 0;
        private int _deckcount2 = 0;
        private int _deckcount1 = 0;
        private int[] _numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private char[] _letters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
        private string _appDir => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private string _relativePath = "Files";
        private string _dirPath => Path.Combine(_appDir, _relativePath);
        private string _filePath => Path.Combine(_dirPath, "save.txt");

        SeaBattleController _seaBattleController = new SeaBattleController();
        List<Ship> _ships => _seaBattleController.ShipsController.Ships;

        public MainWindow()
        {
            InitializeComponent();
            SetBestScoreLabel();
            SetNumbers();
            SetLetters();
        }

        private void SetBestScoreLabel()
        {
            int best = GetBestScore();
            if (best > -1)
            {
                bestScore.Text = "Best score: " + best;
            }
            
        }
        private void SetBestScore()
        {
            if (!Directory.Exists(_dirPath))
            {
                Directory.CreateDirectory(_dirPath);
                
            }
            File.WriteAllText(_filePath, _current.ToString()); 
        }

        private int GetBestScore()
        {
            if (!Directory.Exists(_dirPath))
            {
                return -1;
            }
            if (!File.Exists(_filePath))
            {
                return -1;
            }

            string save = File.ReadAllText(_filePath);
            
            if (int.TryParse(save, out int best))
            {
                return best;
            }
            return -1;
        }

        private void SetNumbers()
        {
            int [] numbersArray = new int[] {1,2, 3, 4, 5, 6, 7,8, 9,10};
            for(int i = 0; i < _numbers.Length; i++)
            {
                numbers.Items.Add(_numbers[i]);
            }
        }

        private void SetLetters()
        {
            for (int i = 0; i < _letters.Length; i++)
            {
                letters.Items.Add(_letters[i]);
            }
        }

        private void ResetInfoFields()
        {
            _left = _gameconditions;
            turnsLeft.Text = "Turns left: " + _left;
            _current = 0;
            currentScore.Text = "Current score: " + _current;
            start.Content = "Restart";
            _deckcount1 = 0;
            _deckcount2 = 0;
            _deckcount3 = 0;
            _deckcount4 = 0;
            for (int i = 0; i < _ships.Count; i++)
            {
                if (_ships[i].DeckCount == 4)
                {
                    _deckcount4++;
                }
                else if (_ships[i].DeckCount == 3)
                {
                    _deckcount3++;
                }
                else if (_ships[i].DeckCount == 2)
                {
                    _deckcount2++;
                }
                else
                {
                    _deckcount1++;
                }
            }
            deck1.Text = "x" + _deckcount1;
            deck2.Text = "x" + _deckcount2;
            deck3.Text = "x" + _deckcount3;
            deck4.Text = "x" + _deckcount4;
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            Field.IsHitTestVisible = true;
            Field.Items.Clear();
            _seaBattleController.Generate();
            var cells = _seaBattleController.CellsController.Cells;
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for(int j = 0; j < cells.GetLength(1); j++)
                {

                    CellButton newBtn = new CellButton();
                    newBtn.Cell = cells[i,j];
                    cells[i, j].SetCellButton(newBtn);
                    newBtn.Name = "Button" + i.ToString();
                    newBtn.Background = cells[i,j].Color;
                    newBtn.Click += CellBtn_Clicked;
                    Field.Items.Add(newBtn);
                }
            }
            ResetInfoFields();
        }

        private void CellBtn_Clicked(object sender, EventArgs e)
        {
            CellButton currentBtn = sender as CellButton;
            if (_left > 0)
            {
                if (currentBtn.Cell.IsShip)
                {
                    currentBtn.Cell.IsShip = false;
                    currentBtn.Cell.IsKnocked = true;
                    currentBtn.Background = currentBtn.Cell.Color;
                    bool checkresult = true;
                    for (int i = 0; i < currentBtn.Cell.Ship.ShipPlace.Count; i++)
                    {
                        checkresult = checkresult & currentBtn.Cell.Ship.ShipPlace[i].IsKnocked;
                    }
                    if (checkresult)
                    {
                        var shipPlace = currentBtn.Cell.Ship.ShipPlace;
                        var nearShip = currentBtn.Cell.Ship.NearShip;
                        for (int i = 0; i < shipPlace.Count; i++)
                        {
                            shipPlace[i].IsSink = true;
                            shipPlace[i].IsKnocked = false;
                            shipPlace[i].CellButton.Background = shipPlace[i].Color;
                        }
                        for (int i = 0; i < nearShip.Count; i++)
                        {
                            nearShip[i].IsMiss = true;
                            nearShip[i].CellButton.Background = nearShip[i].Color;
                            nearShip[i].CellButton.IsHitTestVisible = false;
                        }
                        currentBtn.Cell.Ship.IsSink = true;
                        {
                            if (currentBtn.Cell.Ship.DeckCount == 4)
                            {
                                _deckcount4--;
                            }
                            else if (currentBtn.Cell.Ship.DeckCount == 3)
                            {
                                _deckcount3--;
                            }
                            else if (currentBtn.Cell.Ship.DeckCount == 2)
                            {
                                _deckcount2--;
                            }
                            else
                            {
                                _deckcount1--;
                            }

                            deck1.Text = "x" + _deckcount1;
                            deck2.Text = "x" + _deckcount2;
                            deck3.Text = "x" + _deckcount3;
                            deck4.Text = "x" + _deckcount4;
                        }
                    }
                }
                else
                {
                    currentBtn.Cell.IsMiss = true;
                    currentBtn.Background = currentBtn.Cell.Color;
                    _current++;
                    _left--;
                    currentScore.Text = "Current score: " + _current.ToString();
                    turnsLeft.Text = "Turns left: " + _left.ToString();
                }
            }
            else
            {
                turnsLeft.Text = "Game over: "+_left.ToString();
            }
            bool result = true;
            for (int i = 0; i < _ships.Count; i++)
            {
                result = result & _ships[i].IsSink;
            }
            if (result)
            {
                turnsLeft.Text = "You Win! Turns left:" + _left;
                Field.IsHitTestVisible = false;
                int best = GetBestScore();
                if (_current < best || best == -1 )
                {
                    SetBestScore();
                    SetBestScoreLabel();
                }
            }
            currentBtn.IsHitTestVisible = false;
        }
    }
}