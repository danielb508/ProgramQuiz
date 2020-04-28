using Caliburn.Micro;
using quizMAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizMAX.ViewModels
{
    public class QuizModeViewModel : Screen
    {
        readonly IWindowManager _windowManager;

        private TestModel _selectedTest;
        private string _numberOfQuestionsValue;
        private string _questionNumberForQuizValue;
        private string _percentToPassValue;
        private string _timeValue;
        private string _startQuizIsEnabled;
        private string _questionNumberForQuizFieldBackground;
        private string _percentToPassFieldBackground;
        private string _timeFieldBackground;
        private string _questionNumberForQuizFieldIsEnabled;
        private string _percentToPassFieldIsEnabled;
        private string _timeFieldIsEnabled;

        private void TryToEnableStartQuiz()
        {
            if (this.QuestionNumberForQuizVerified && this.PercentToPassVerified && this.TimeVerified && (this.SelectedTest != null))
            {
                this.StartQuizIsEnabled = "True";
            }
            else
            {
                this.StartQuizIsEnabled = "False";
            }
        }
        public BindableCollection<TestModel> Tests { get; set; }
        public string DescriptionLabel { get; set; }
        public string AvailableTestsLabel { get; set; }
        public string NumberOfQuestionsLabel { get; set; }
        public string StartQuizButton { get; set; }
        public string QuestionNumberForQuizLabel { get; set; }
        public string PercentToPassLabel { get; set; }
        public string TimeLabel { get; set; }
        public bool QuestionNumberForQuizVerified { get; set; }
        public bool PercentToPassVerified { get; set; }
        public bool TimeVerified { get; set; }
        public TestModel SelectedTest
        {
            get
            {
                return this._selectedTest;
            }
            set
            {
                this._selectedTest = value;
                if (value != null)
                {
                    this.NumberOfQuestionsValue = value.Questions.Count().ToString();
                    this.QuestionNumberForQuizFieldIsEnabled = "True";
                    this.PercentToPassFieldIsEnabled = "True";
                    this.TimeFieldIsEnabled = "True";
                }
                NotifyOfPropertyChange(() => this.SelectedTest);
                if (this.SelectedTest != null && this.QuestionNumberForQuizValue != null)
                {
                    this.QuestionNumberForQuizValue = this.QuestionNumberForQuizValue;
                }
                TryToEnableStartQuiz();
            }
        }
        public string NumberOfQuestionsValue
        {
            get
            {
                return this._numberOfQuestionsValue;
            }
            set
            {
                this._numberOfQuestionsValue = value;
                NotifyOfPropertyChange(() => this.NumberOfQuestionsValue);
            }
        }
        public string QuestionNumberForQuizValue
        {
            get
            {
                return this._questionNumberForQuizValue;
            }
            set
            {
                this._questionNumberForQuizValue = value;
                NotifyOfPropertyChange(() => this.QuestionNumberForQuizValue);
                try
                {
                    int.Parse(this.QuestionNumberForQuizValue);
                    if (0 < int.Parse(this.QuestionNumberForQuizValue) && int.Parse(this.QuestionNumberForQuizValue) <= this.SelectedTest.Questions.Count)
                    {
                        this.QuestionNumberForQuizVerified = true;
                        this.QuestionNumberForQuizFieldBackground = "White";
                    }
                    else
                    {
                        this.QuestionNumberForQuizVerified = false;
                        this.QuestionNumberForQuizFieldBackground = "Red";
                    }
                }
                catch (System.FormatException)
                {
                    this.QuestionNumberForQuizVerified = false;
                    if (this.QuestionNumberForQuizValue == String.Empty)
                    {
                        this.QuestionNumberForQuizFieldBackground = "White";
                    }
                    else
                    {
                        this.QuestionNumberForQuizFieldBackground = "Red";
                    }
                }
                TryToEnableStartQuiz();
            }
        }
        public string PercentToPassValue
        {
            get
            {
                return this._percentToPassValue;
            }
            set
            {
                this._percentToPassValue = value;
                NotifyOfPropertyChange(() => this.PercentToPassValue);
                try
                {
                    int.Parse(this.PercentToPassValue);
                    if (0 < int.Parse(this.PercentToPassValue) && int.Parse(this.PercentToPassValue) <= 100)
                    {
                        this.PercentToPassVerified = true;
                        this.PercentToPassFieldBackground = "White";
                    }
                    else
                    {
                        this.PercentToPassVerified = false;
                        this.PercentToPassFieldBackground = "Red";
                    }
                }
                catch (System.FormatException)
                {
                    this.PercentToPassVerified = false;
                    if (PercentToPassValue == String.Empty)
                    {
                        this.PercentToPassFieldBackground = "White";
                    }
                    else
                    {
                        this.PercentToPassFieldBackground = "Red";
                    }
                }
                TryToEnableStartQuiz();
            }
        }
        public string TimeValue
        {
            get
            {
                return this._timeValue;
            }
            set
            {
                this._timeValue = value;
                NotifyOfPropertyChange(() => this.TimeValue);
                try
                {
                    int.Parse(this.TimeValue);
                    if (int.Parse(this.TimeValue) > 0)
                    {
                        this.TimeVerified = true;
                        this.TimeFieldBackground = "White";
                    }
                    else
                    {
                        this.TimeVerified = false;
                        this.TimeFieldBackground = "Red";
                    }
                }
                catch
                {
                    this.TimeVerified = false;
                    if (this.TimeValue == String.Empty)
                    {
                        this.TimeFieldBackground = "White";
                    }
                    else
                    {
                        this.TimeFieldBackground = "Red";
                    }
                }
                TryToEnableStartQuiz();
            }
        }
        public string QuestionNumberForQuizFieldBackground
        {
            get
            {
                return this._questionNumberForQuizFieldBackground;
            }
            set
            {
                this._questionNumberForQuizFieldBackground = value;
                NotifyOfPropertyChange(() => this.QuestionNumberForQuizFieldBackground);
            }
        }
        public string PercentToPassFieldBackground
        {
            get
            {
                return this._percentToPassFieldBackground;
            }
            set
            {
                this._percentToPassFieldBackground = value;
                NotifyOfPropertyChange(() => this.PercentToPassFieldBackground);
            }
        }
        public string TimeFieldBackground
        {
            get
            {
                return this._timeFieldBackground;
            }
            set
            {
                this._timeFieldBackground = value;
                NotifyOfPropertyChange(() => this.TimeFieldBackground);
            }
        }
        public string QuestionNumberForQuizFieldIsEnabled
        {
            get
            {
                return this._questionNumberForQuizFieldIsEnabled;
            }
            set
            {
                this._questionNumberForQuizFieldIsEnabled = value;
                NotifyOfPropertyChange(() => this.QuestionNumberForQuizFieldIsEnabled);
            }
        }
        public string PercentToPassFieldIsEnabled
        {
            get
            {
                return this._percentToPassFieldIsEnabled;
            }
            set
            {
                this._percentToPassFieldIsEnabled = value;
                NotifyOfPropertyChange(() => this.PercentToPassFieldIsEnabled);
            }
        }
        public string TimeFieldIsEnabled
        {
            get
            {
                return this._timeFieldIsEnabled;
            }
            set
            {
                this._timeFieldIsEnabled = value;
                NotifyOfPropertyChange(() => this.TimeFieldIsEnabled);
            }
        }
        public string StartQuizIsEnabled
        {
            get
            {
                return this._startQuizIsEnabled;
            }
            set
            {
                this._startQuizIsEnabled = value;
                NotifyOfPropertyChange(() => this.StartQuizIsEnabled);
            }
        }
        public void QuizModeOn()
        {
            this._windowManager.ShowDialog(new QuizPopUpViewModel(this.SelectedTest, int.Parse(this.QuestionNumberForQuizValue), int.Parse(this.PercentToPassValue), int.Parse(this.TimeValue)));
        }
        public QuizModeViewModel(IWindowManager windowManager, ConnectionToDBModel db)
        {
            this._windowManager = windowManager;
            GUIstringsModel strings = new GUIstringsModel();
            this.DescriptionLabel = strings.GetGUIstr("DescriptionLabel");
            this.AvailableTestsLabel = strings.GetGUIstr("AvailableTestsLabel");
            this.NumberOfQuestionsLabel = strings.GetGUIstr("NumberOfQuestionsLabel");
            this.StartQuizButton = strings.GetGUIstr("StartQuizButton");
            this.QuestionNumberForQuizLabel = strings.GetGUIstr("QuestionNumberForQuizLabel");
            this.PercentToPassLabel = strings.GetGUIstr("PercentToPassLabel");
            this.TimeLabel = strings.GetGUIstr("TimeLabel");

            Task.Run(() =>
            {
                this.Tests = db.GetTests();
                this.Refresh();
            });

            this.QuestionNumberForQuizFieldBackground = "White";
            this.PercentToPassFieldBackground = "White";
            this.TimeFieldBackground = "White";
            this.StartQuizIsEnabled = "False";

            this.QuestionNumberForQuizFieldIsEnabled = "False";
            this.PercentToPassFieldIsEnabled = "False";
            this.TimeFieldIsEnabled = "False";
        }
    }
}