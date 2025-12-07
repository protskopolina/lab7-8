using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace WpfApp8
{
    class Candidate

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
    }
