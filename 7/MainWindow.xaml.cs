using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace CandidateApp
{
    public partial class AddEditWindow : Window
    {
        public Candidate Candidate { get; set; }

        // Конструктор для створення нового кандидата
        public AddEditWindow()
        {
            InitializeComponent();
            Candidate = new Candidate();
            DataContext = Candidate;
        }

        // Конструктор для редагування
        public AddEditWindow(Candidate candidate)
        {
            InitializeComponent();
            Candidate = candidate;
            DataContext = Candidate;
        }

        // Дозволити вводити тільки цифри
        private void NumberOnly(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        // Зберегти
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Candidate.FullName))
            {
                MessageBox.Show("Введіть ПІП!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DialogResult = true;
            Close();
        }
    }
}
public class Candidate
{
    public string FullName { get; set; }
    public DateTime? BirthDate { get; set; }
    public string Education { get; set; }
    public bool KnowsEnglish { get; set; }
    public string EnglishLevel { get; set; }
    public bool ComputerSkills { get; set; }
    public int WorkExperience { get; set; }
    public bool HasRecommendations { get; set; }
}




    

    
