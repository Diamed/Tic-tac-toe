using System.Windows;
using System.Windows.Controls;
using Tic_tac_toe.Model;
using Tic_tac_toe.ViewModel;

namespace Tic_tac_toe
{
    public partial class MainWindow : Window
    {
        private ApplicationModel Model { get; set; } = new ApplicationModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ApplicationModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (Model.SetField(button.CommandParameter.ToString()))
            {
                button.Content = Model.Marker;
                if (Model.IsFinish())
                {
                    MessageBox.Show($"Победил игрок №{Model.Step + 1}");
                    Model = Model.NewGame();
                    ClearButtons();
                }
                else if (Model.IsDraw())
                {
                    MessageBox.Show($"Ничья!");
                    Model = Model.NewGame();
                    ClearButtons();
                }
                else
                {
                    Model.NextStep();
                    LblStep.Content = $"Ход игрока №{Model.Step + 1}";
                }
            }
        }

        private void ClearButtons()
        {
            Field0.Content = null;
            Field1.Content = null;
            Field2.Content = null;
            Field3.Content = null;
            Field4.Content = null;
            Field5.Content = null;
            Field6.Content = null;
            Field7.Content = null;
            Field8.Content = null;
        }
    }
}
