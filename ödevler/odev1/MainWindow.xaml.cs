using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using TetrisApp.Models;

namespace TetrisApp
{
    public enum GameTheme { Neon, Classic, DeepSpace }

    public partial class MainWindow : Window
    {
        private const int Rows = 20;
        private const int Cols = 10;
        private const int CellSize = 30;

        private GameEngine _game;
        private DispatcherTimer _timer;
        private GameTheme _currentTheme = GameTheme.Neon;

        public MainWindow()
        {
            InitializeComponent();
            _game = new GameEngine(Rows, Cols);
            
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(500);
            _timer.Tick += GameTick;
        }

        private void ThemeButton_Click(object sender, RoutedEventArgs e)
        {
            _currentTheme = (GameTheme)(((int)_currentTheme + 1) % 3);
            ApplyTheme();
            Draw();
        }

        private void ApplyTheme()
        {
            // We need to name the main grid in XAML to access it easily, 
            // but for now we can access it via Content if it's the only child.
            var mainGrid = this.Content as Grid;
            if (mainGrid == null) return;

            switch (_currentTheme)
            {
                case GameTheme.Neon:
                    GameCanvas.Background = new SolidColorBrush(Color.FromRgb(10, 10, 10));
                    var gradient = new LinearGradientBrush();
                    gradient.StartPoint = new Point(0.5, 0);
                    gradient.EndPoint = new Point(0.5, 1);
                    gradient.GradientStops.Add(new GradientStop(Color.FromRgb(26, 11, 46), 0));
                    gradient.GradientStops.Add(new GradientStop(Color.FromRgb(46, 11, 37), 1));
                    mainGrid.Background = gradient;
                    break;
                case GameTheme.Classic: // Now "Vaporwave"
                    GameCanvas.Background = new SolidColorBrush(Color.FromRgb(30, 30, 30));
                    var vaporGradient = new LinearGradientBrush();
                    vaporGradient.StartPoint = new Point(0, 0);
                    vaporGradient.EndPoint = new Point(1, 1);
                    vaporGradient.GradientStops.Add(new GradientStop(Color.FromRgb(255, 113, 206), 0)); // Neon Pink
                    vaporGradient.GradientStops.Add(new GradientStop(Color.FromRgb(1, 205, 254), 1));   // Sky Blue
                    mainGrid.Background = vaporGradient;
                    break;
                case GameTheme.DeepSpace:
                    GameCanvas.Background = Brushes.Black;
                    mainGrid.Background = new SolidColorBrush(Color.FromRgb(20, 20, 20));
                    break;
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            _game = new GameEngine(Rows, Cols);
            GameOverText.Visibility = Visibility.Collapsed;
            _timer.Start();
            Draw();
        }

        private void GameTick(object sender, EventArgs e)
        {
            _game.MovePieceDown();
            if (_game.GameOver)
            {
                _timer.Stop();
                GameOverText.Visibility = Visibility.Visible;
            }
            Draw();
        }

        private void Draw()
        {
            GameCanvas.Children.Clear();
            DrawBoard();
            DrawPiece();
            DrawNextPiece();
            ScoreText.Text = _game.Score.ToString("D5");
        }

        private void DrawBoard()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    Color? color = _game.Board.GetCell(r, c);
                    if (color.HasValue)
                    {
                        DrawCell(GameCanvas, r, c, color.Value);
                    }
                }
            }
        }

        private void DrawPiece()
        {
            int[,] matrix = _game.CurrentPiece.GetMatrix();
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == 1)
                    {
                        DrawCell(GameCanvas, _game.CurrentPiece.Row + r, _game.CurrentPiece.Column + c, _game.CurrentPiece.Color);
                    }
                }
            }
        }

        private void DrawNextPiece()
        {
            NextPieceCanvas.Children.Clear();
            int[,] matrix = _game.NextPiece.GetMatrix();
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == 1)
                    {
                        DrawCell(NextPieceCanvas, r, c, _game.NextPiece.Color, 20);
                    }
                }
            }
        }

        private void DrawCell(Canvas canvas, int r, int c, Color color, int size = CellSize)
        {
            Rectangle rect = new Rectangle
            {
                Width = size - 2,
                Height = size - 2,
                RadiusX = 4,
                RadiusY = 4
            };

            switch (_currentTheme)
            {
                case GameTheme.Neon:
                    rect.Fill = new SolidColorBrush(color);
                    rect.Stroke = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                    rect.StrokeThickness = 1;
                    rect.Effect = new System.Windows.Media.Effects.DropShadowEffect
                    {
                        Color = color,
                        BlurRadius = 10,
                        ShadowDepth = 0,
                        Opacity = 0.8
                    };
                    break;
                case GameTheme.Classic: // Vaporwave blocks
                    rect.Fill = new SolidColorBrush(Color.FromArgb(180, color.R, color.G, color.B));
                    rect.Stroke = Brushes.White;
                    rect.StrokeThickness = 2;
                    rect.RadiusX = 8;
                    rect.RadiusY = 8;
                    rect.Effect = new System.Windows.Media.Effects.DropShadowEffect
                    {
                        Color = Colors.White,
                        BlurRadius = 5,
                        ShadowDepth = 0,
                        Opacity = 0.5
                    };
                    break;
                case GameTheme.DeepSpace:
                    rect.Fill = Brushes.Transparent;
                    rect.Stroke = new SolidColorBrush(color);
                    rect.StrokeThickness = 2;
                    rect.Effect = new System.Windows.Media.Effects.DropShadowEffect
                    {
                        Color = color,
                        BlurRadius = 5,
                        ShadowDepth = 0,
                        Opacity = 1
                    };
                    break;
            }

            Canvas.SetTop(rect, r * size);
            Canvas.SetLeft(rect, c * size);
            canvas.Children.Add(rect);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (_game.GameOver) return;

            switch (e.Key)
            {
                case Key.Left:
                    _game.MovePieceLeft();
                    break;
                case Key.Right:
                    _game.MovePieceRight();
                    break;
                case Key.Down:
                    _game.MovePieceDown();
                    break;
                case Key.Up:
                    _game.RotatePiece();
                    break;
                case Key.Space:
                    while (!_game.GameOver)
                    {
                        if (_game.MovePieceDown()) break;
                    }
                    break;
            }
            Draw();
        }
    }
}