using Caliburn.Micro;
using quizMAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace quizMAX.ViewModels
{
    public class LearnPopUpViewModel : Screen
    {
        private string _feedbackColor;
        private string _answersIsEnabled;
        private string _confirmButtonIsEnabled;
        private string _nextQuestionButtonIsEnabled;
        public string LearnWindowTitle { get; set; }
        public string ResultLabel { get; set; }
        public string QuestionLabel { get; set; }
        public string ConfirmButton { get; set; }
        public string NextQuestionButton { get; set; }
        public string MessageBoxResult { get; set; }
        public string MessageBoxYourResultIs { get; set; }
        public TestForLearnModel LearnMechanism { get; set; }

        public string FeedbackColor
        {
            get
            {
                return this._feedbackColor;
            }
            set
            {
                this._feedbackColor = value;
                NotifyOfPropertyChange(() => this.FeedbackColor);
            }
        }
        public string AnswersIsEnabled
        {
            get
            {
                return this._answersIsEnabled;
            }
            set
            {
                this._answersIsEnabled = value;
                NotifyOfPropertyChange(() => this.AnswersIsEnabled);
            }
        }
        public string ConfirmButtonIsEnabled
        {
            get
            {
                return this._confirmButtonIsEnabled;
            }
            set
            {
                this._confirmButtonIsEnabled = value;
                NotifyOfPropertyChange(() => this.ConfirmButtonIsEnabled);
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
        public void Confirm()
        {
            this.AnswersIsEnabled = "False";
            this.ConfirmButtonIsEnabled = "False";
            this.NextQuestionButtonIsEnabled = "True";
            if (this.LearnMechanism.CurrentQuestion.CheckAnswers())
            {
                this.FeedbackColor = "Green";
            }
            else
            {
                this.FeedbackColor = "Red";
            }
            if (!this.LearnMechanism.Confirm())
            {
                MessageBox.Show(this.MessageBoxYourResultIs + this.LearnMechanism.ResultValue + "/" +
                    this.LearnMechanism.AllQuestionNumber, this.MessageBoxResult, MessageBoxButton.OK, MessageBoxImage.Information);
                this.TryClose();
            }
        }
        public void NextQuestion()
        {
            this.AnswersIsEnabled = "True";
            this.ConfirmButtonIsEnabled = "True";
            this.NextQuestionButtonIsEnabled = "False";
            this.FeedbackColor = "White";
            this.LearnMechanism.NextQuestion();
        }

        public LearnPopUpViewModel(TestModel selectedTest)
        {
            GUIstringsModel strings = new GUIstringsModel();
            this.LearnWindowTitle = strings.GetGUIstr("LearnWindowTitle");
            this.QuestionLabel = strings.GetGUIstr("QuestionLabel");
            this.ResultLabel = strings.GetGUIstr("ResultLabel");
            this.ConfirmButton = strings.GetGUIstr("ConfirmButton");
            this.NextQuestionButton = strings.GetGUIstr("NextQuestionButton");
            this.MessageBoxResult = strings.GetGUIstr("MessageBoxResult");
            this.MessageBoxYourResultIs = strings.GetGUIstr("MessageBoxYourResultIs");

            this.LearnMechanism = new TestForLearnModel(selectedTest);

            this.FeedbackColor = "White";
            this.AnswersIsEnabled = "True";
            this.ConfirmButtonIsEnabled = "True";
            this.NextQuestionButtonIsEnabled = "False";
        }
    }
}