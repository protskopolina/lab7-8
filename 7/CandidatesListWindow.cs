using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp8
{
  
        public partial class CandidatesListWindow : Window
{
    public CandidatesListWindow()
    {
            InitializeComponent();
        DataContext = DataStore.Candidates;
    }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void FilterHigher(object sender, RoutedEventArgs e)
    {
        var filtered = DataStore.Candidates
            .Where(c => c.Education == "Вища")
            .ToList();

        DataContext = filtered;
    }

    private void FilterEnglish(object sender, RoutedEventArgs e)
    {
        var filtered = DataStore.Candidates
            .Where(c => c.KnowsEnglish && c.EnglishLevel == "Вільно")
            .ToList();

        DataContext = filtered;
    }
}

    }

