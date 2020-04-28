using Caliburn.Micro;
using quizMAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizMAX.ViewModels
{
    public class EditQuestionPopUpViewModel : Screen
    {
        readonly EventAggregator _eventAggregator;
        readonly ConnectionToDBModel _db;
        readonly QuestionModel _selectedQuestion;
        private BindableCollection<AnswerModel> _answers;
        private AnswerModel _selectedAnswer;
        private string _answerTextValue;
        private bool _isCorrectValue;
        private bool _readyToRead;
        private string _questionTextValue;
        private string _isCorrectValueEnabled;
        private string _confirmButtonIsEnabled;
        private string _isDeleteButtonEnabled;
        private string _isAnswerTextValueEnabled;
        public string EditQuestionOnView { get; set; }
        public string AnswersLabel { get; set; }
        public string AnswerTextLabel { get; set; }
        public string IsCorrectLabel { get; set; }
        public string ConfirmEditionButton { get; set; }
        public string QuestionTextLabel { get; set; }
        public string DeleteAnswerButton { get; set; }
        public string NewAnswerButton { get; set; }
        public string NewAnswerValueString { get; set; }

        public BindableCollection<AnswerModel> Answers
        {
            get
            {
                return this._answers;
            }
            set
            {
                this._answers = value;
                NotifyOfPropertyChange(() => this.Answers);
            }
        }
        public AnswerModel SelectedAnswer
        {
            get
            {
                return this._selectedAnswer;
            }
            set
            {
                this._selectedAnswer = value;
                if (value != null)
                {
                    this.AnswerTextValue = value.Answer;
                    this.IsCorrectValue = value.Correct;
                    this.IsCorrectValueEnabled = "True";
                    this.IsDeleteButtonEnabled = "True";
                    this.IsAnswerTextValueEnabled = "True";
                }
                else
                {
                    this.IsCorrectValueEnabled = "False";
                    this.IsDeleteButtonEnabled = "False";
                    this.IsAnswerTextValueEnabled = "False";
                }
                NotifyOfPropertyChange(() => this.SelectedAnswer);
            }
        }
        public string AnswerTextValue
        {
            get
            {
                return this._answerTextValue;
            }
            set
            {
                this._answerTextValue = value;
                if (this.SelectedAnswer != null)
                {
                    this.SelectedAnswer.Answer = value;
                }
                NotifyOfPropertyChange(() => this.AnswerTextValue);
                ConfirmButtonTryToEnable();
            }
        }
        public bool IsCorrectValue
        {
            get
            {
                return this._isCorrectValue;
            }
            set
            {
                this._isCorrectValue = value;
                if (this.SelectedAnswer != null)
                {
                    this.SelectedAnswer.Correct = value;
                }
                NotifyOfPropertyChange(() => this.IsCorrectValue);
                ConfirmButtonTryToEnable();
            }
        }
        public string QuestionTextValue
        {
            get
            {
                return this._questionTextValue;
            }
            set
            {
                this._questionTextValue = value;
                NotifyOfPropertyChange(() => this.QuestionTextValue);
                ConfirmButtonTryToEnable();
            }
        }
        public string IsCorrectValueEnabled
        {
            get
            {
                return this._isCorrectValueEnabled;
            }
            set
            {
                this._isCorrectValueEnabled = value;
                NotifyOfPropertyChange(() => this.IsCorrectValueEnabled);
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
        public string IsDeleteButtonEnabled
        {
            get
            {
                return this._isDeleteButtonEnabled;
            }
            set
            {
                this._isDeleteButtonEnabled = value;
                NotifyOfPropertyChange(() => this.IsDeleteButtonEnabled);
            }
        }
        public string IsAnswerTextValueEnabled
        {
            get
            {
                return this._isAnswerTextValueEnabled;
            }
            set
            {
                this._isAnswerTextValueEnabled = value;
                NotifyOfPropertyChange(() => this.IsAnswerTextValueEnabled);
            }
        }
        public void Confirm()
        {
            this._selectedQuestion.QuestionText = this.QuestionTextValue;
            this._selectedQuestion.Answers.Clear();
            foreach (AnswerModel a in this.Answers)
            {
                this._selectedQuestion.Answers.Add(a);
            }
            Task.Run(() =>
            {
                this._eventAggregator.PublishOnUIThread(new CursorMessageModel(System.Windows.Input.Cursors.Wait, (int)Task.CurrentId));
                this._db.UpdateQuestions(this._selectedQuestion);
                this._readyToRead = true;
                this._eventAggregator.PublishOnUIThread(new CursorMessageModel(System.Windows.Input.Cursors.Arrow, (int)Task.CurrentId));
            });
            this.TryClose();
        }
        public void DeleteAnswer()
        {
            this.Answers.Remove(this.SelectedAnswer);
            ConfirmButtonTryToEnable();
            this.AnswerTextValue = "";
            this.IsCorrectValue = false;
        }
        public void NewAnswer()
        {
            this.SelectedAnswer = new AnswerModel(-1, this.NewAnswerValueString, false);
            this.Answers.Add(this.SelectedAnswer);
            ConfirmButtonTryToEnable();

        }
        public void ConfirmButtonTryToEnable()
        {
            bool correctAnswerCheck = false;
            bool blankAnswersCheck = true;
            foreach (AnswerModel a in this.Answers)
            {
                if (a.Correct)
                {
                    correctAnswerCheck = true;
                }
                if (a.Answer == string.Empty)
                {
                    blankAnswersCheck = false;
                }
            }
            if (this.Answers.Count >= 2 && this.QuestionTextValue != string.Empty && correctAnswerCheck && blankAnswersCheck)
            {
                this.ConfirmButtonIsEnabled = "True";
            }
            else
            {
                this.ConfirmButtonIsEnabled = "False";
            }
        }
        public int ReadyToUpdateQuestions()
        {
            while (!this._readyToRead)
            { }
            return 0;
        }
        public EditQuestionPopUpViewModel(ConnectionToDBModel db, EventAggregator eventAggregator, QuestionModel selectedQuestion)
        {
            this._selectedQuestion = selectedQuestion;
            this._db = db;
            this._eventAggregator = eventAggregator;

            this.Answers = new BindableCollection<AnswerModel>();
            foreach (AnswerModel a in selectedQuestion.Answers)
            {
                this.Answers.Add(new AnswerModel(a.IdDB, a.Answer, a.Correct));
            }
            this.QuestionTextValue = selectedQuestion.QuestionText;

            this._readyToRead = false;

            GUIstringsModel strings = new GUIstringsModel();
            this.EditQuestionOnView = strings.GetGUIstr("EditQuestionOnView");
            this.AnswersLabel = strings.GetGUIstr("AnswersLabel");
            this.AnswerTextLabel = strings.GetGUIstr("AnswerTextLabel");
            this.IsCorrectLabel = strings.GetGUIstr("IsCorrectLabel");
            this.ConfirmEditionButton = strings.GetGUIstr("ConfirmEditionButton");
            this.QuestionTextLabel = strings.GetGUIstr("QuestionTextLabel");
            this.DeleteAnswerButton = strings.GetGUIstr("DeleteAnswerButton");
            this.NewAnswerButton = strings.GetGUIstr("NewAnswerButton");
            this.NewAnswerValueString = strings.GetGUIstr("NewAnswerValueString");
        }
    }
}
