using LabWPF_5.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace LabWPF_5.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Student _selectedStudent;

        public ObservableCollection<Student> Students { get; set; }

        public string EditLastName { get; set; }
        public string EditFirstName { get; set; }
        public int EditAge { get; set; } = 16;
        public string EditGender { get; set; }

        public RelayCommand AddCommand { get; }
        public RelayCommand EditCommand { get; }
        public RelayCommand DeleteCommand { get; }

        public Student SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                OnPropertyChanged();
                if (_selectedStudent != null)
                {
                    EditLastName = _selectedStudent.LastName;
                    EditFirstName = _selectedStudent.FirstName;
                    EditAge = _selectedStudent.Age;
                    EditGender = _selectedStudent.Gender;
                    OnPropertyChanged(nameof(EditLastName));
                    OnPropertyChanged(nameof(EditFirstName));
                    OnPropertyChanged(nameof(EditAge));
                    OnPropertyChanged(nameof(EditGender));
                }
            }
        }

        public MainViewModel()
        {
            Students = new ObservableCollection<Student>();

            // Тестові дані
            Students.Add(new Student { LastName = "Іванов", FirstName = "Іван", Age = 20, Gender = "Чол" });
            Students.Add(new Student { LastName = "Петрова", FirstName = "Марія", Age = 19, Gender = "Жін" });

            AddCommand = new RelayCommand(obj =>
            {
                if (ValidateInput())
                {
                    Students.Add(new Student
                    {
                        LastName = EditLastName,
                        FirstName = EditFirstName,
                        Age = EditAge,
                        Gender = EditGender
                    });
                    ClearInputs();
                }
            });

            EditCommand = new RelayCommand(obj =>
            {
                if (SelectedStudent != null && ValidateInput())
                {
                    SelectedStudent.LastName = EditLastName;
                    SelectedStudent.FirstName = EditFirstName;
                    SelectedStudent.Age = EditAge;
                    SelectedStudent.Gender = EditGender;
                    ClearInputs();
                    SelectedStudent = null;
                }
            }, obj => SelectedStudent != null);

            DeleteCommand = new RelayCommand(obj =>
            {
                var result = MessageBox.Show("Ви впевнені, що хочете видалити студента?", "Підтвердження", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    Students.Remove(SelectedStudent);
                    ClearInputs();
                }
            }, obj => SelectedStudent != null);
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(EditLastName) ||
                string.IsNullOrWhiteSpace(EditFirstName) ||
                string.IsNullOrWhiteSpace(EditGender))
            {
                MessageBox.Show("Всі поля (Прізвище, Ім'я, Стать) обов'язкові!");
                return false;
            }

            if (EditAge < 16 || EditAge > 100)
            {
                MessageBox.Show("Вік повинен бути в діапазоні від 16 до 100!");
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            EditLastName = ""; EditFirstName = ""; EditAge = 16; EditGender = "";
            OnPropertyChanged(nameof(EditLastName));
            OnPropertyChanged(nameof(EditFirstName));
            OnPropertyChanged(nameof(EditAge));
            OnPropertyChanged(nameof(EditGender));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}