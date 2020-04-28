using Caliburn.Micro;
using quizMAX.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace quizMAX.ViewModels
{
    public class QuizPopUpViewModel : Screen
    {
        private string _endQuizButtonIsEnabled;
        private string _nextQuestionButtonIsEnabled;
        private string _previousQuestionButtonIsEnabled;
        private string _timeLeftValue;
        protected override void OnDeactivate(bool close)
        {
            this.Timer.Stop();
        }
        public string QuizWindowTitle { get; set; }
        public string QuestionLabel { get; set; }
        public string PreviousQuestionButton { get; set; }
        public string NextQuestionButton { get; set; }
        public string EndQuizButton { get; set; }
        public string TimeLeftLabel { get; set; }
        public string MessageBoxResult { get; set; }
        public string MessageBoxYourResultIs { get; set; }
        public string MessageBoxQuizPassed { get; set; }
        public string MessageBoxQuizFailed { get; set; }
        public TestForQuizModel QuizMechanism { get; set; }
        public int AllQuestionNumber { get; set; }
        public int Time { get; set; }
        public float PercentToPass { get; set; }
        public DispatcherTimer Timer { get; set; }

        public string EndQuizButtonIsEnabled
        {
            get
            {
                return this._endQuizButtonIsEnabled;
            }
            set
            {
                this._endQuizButtonIsEnabled = value;
                NotifyOfPropertyChange(() => this.EndQuizButtonIsEnabled);
            }
        }
        public string NextQuestionButtonIsEnabled
        {
            get
            {
                return this._nextQuestionButtonIsEnabled;
            }
            set
            {
                this._nextQuestionButtonIsEnabled = value;
                NotifyOfPropertyChange(() => this.NextQuestionButtonIsEnabled);
            }
        }
        public string PreviousQuestionButtonIsEnabled
        {
            get
            {
                return this._previousQuestionButtonIsEnabled;
            }
            set
            {
                this._previousQuestionButtonIsEnabled = value;
                NotifyOfPropertyChange(() => this.PreviousQuestionButtonIsEnabled);
            }
        }
        public string TimeLeftValue
        {
            get
            {
                return this._timeLeftValue;
            }
            set
            {
                TimeSpan time = TimeSpan.FromSeconds(double.Parse(value));
                this._timeLeftValue = time.ToString(@"mm\:ss");
                NotifyOfPropertyChange(() => this.TimeLeftValue);
            }
        }
        public void TimerTick(object sender, EventArgs e)
        {
            this.Time--;
            this.TimeLeftValue = this.Time.ToString();
            if (this.Time == 0)
            {
                EndQuiz();
            }
        }
        public void NextQuestion()
        {
            this.QuizMechanism.NextQuestion();
            this.PreviousQuestionButtonIsEnabled = "True";
            if (this.QuizMechanism.CurrentQuestionNumber < this.QuizMechanism.AllQuestionNumber)
            {
                this.NextQuestionButtonIsEnabled = "True";
            }
            else
            {
                this.NextQuestionButtonIsEnabled = "False";
            }
        }
        public void PreviousQuestion()
        {
            this.QuizMechanism.PreviousQuestion();
            this.NextQuestionButtonIsEnabled = "True";
            if (this.QuizMechanism.CurrentQuestionNumber == 1)
            {
                this.PreviousQuestionButtonIsEnabled = "False";
            }
        }
        public void EndQuiz()
        {
            this.Timer.Stop();
            float result = this.QuizMechanism.EndQuiz();
            if (result >= this.PercentToPass / 100)
            {
                MessageBox.Show(this.MessageBoxQuizPassed + "\n" + this.MessageBoxYourResultIs +
                    result.ToString("P", CultureInfo.CreateSpecificCulture("hr-HR")), this.MessageBoxResult, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(this.MessageBoxQuizFailed + "\n" + this.MessageBoxYourResultIs +
                    result.ToString("P", CultureInfo.CreateSpecificCulture("hr-HR")), this.MessageBoxResult, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            this.TryClose();
        }

        public QuizPopUpViewModel(TestModel selectedTest, int allQuestionNumber, float percentToPass, int time)
        {
            GUIstringsModel strings = new GUIstringsModel();
            this.QuizWindowTitle = strings.GetGUIstr("QuizWindowTitle");
            this.QuestionLabel = strings.GetGUIstr("QuestionLabel");
            this.PreviousQuestionButton = strings.GetGUIstr("PreviousQuestionButton");
            this.NextQuestionButton = strings.GetGUIstr("NextQuestionButton");
            this.EndQuizButton = strings.GetGUIstr("EndQuizButton");
            this.TimeLeftLabel = strings.GetGUIstr("TimeLeftLabel");
            this.MessageBoxResult = strings.GetGUIstr("MessageBoxResult");
            this.MessageBoxYourResultIs = strings.GetGUIstr("MessageBoxYourResultIs");
            this.MessageBoxQuizPassed = strings.GetGUIstr("MessageBoxQuizPassed");
            this.MessageBoxQuizFailed = strings.GetGUIstr("MessageBoxQuizFailed");

            this.Time = time;
            this.PercentToPass = percentToPass;
            this.QuizMechanism = new TestForQuizModel(selectedTest, allQuestionNumber);
            this.PreviousQuestionButtonIsEnabled = "False";
            if (this.QuizMechanism.CurrentQuestionNumber < this.QuizMechanism.AllQuestionNumber)
            {
                this.NextQuestionButtonIsEnabled = "True";
            }
            else
            {
                this.NextQuestionButtonIsEnabled = "False";
            }
            this.EndQuizButtonIsEnabled = "True";

            this.Timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            Timer.Tick += new EventHandler(TimerTick);
            this.TimeLeftValue = this.Time.ToString();
            this.Timer.Start();
        }
    }
}