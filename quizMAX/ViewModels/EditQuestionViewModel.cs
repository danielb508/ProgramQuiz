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
    public class EditQuestionViewModel : Screen
    {
        readonly IWindowManager _windowManager;
        readonly EventAggregator _eventAggregator;

        private QuestionModel _selectedQuestion;
        private string _editQuestionButtonIsEnabled;
        private string _deleteQuestionButtonIsEnabled;
        private QuestionModel editQuestionDuringDeleting;
        public ConnectionToDBModel Db { get; set; }
        public string AvailableQuestionsLabel { get; set; }
        public string EditQuestionButton { get; set; }
        public string CreateQuestionButton { get; set; }
        public string DeleteQuestionButton { get; set; }
        public string QuestionCantBeDeleted { get; set; }
        public string OnlyQuestion { get; set; }
        public BindableCollection<QuestionModel> Questions { get; set; }

        public string EditQuestionButtonIsEnabled
        {
            get
            {
                return this._editQuestionButtonIsEnabled;
            }
            set
            {
                this._editQuestionButtonIsEnabled = value;
                NotifyOfPropertyChange(() => this.EditQuestionButtonIsEnabled);
            }
        }
        public string DeleteQuestionButtonIsEnabled
        {
            get
            {
                return this._deleteQuestionButtonIsEnabled;
            }
            set
            {
                this._deleteQuestionButtonIsEnabled = value;
                NotifyOfPropertyChange(() => this.DeleteQuestionButtonIsEnabled);
            }
        }
        public QuestionModel SelectedQuestion
        {
            get
            {
                return this._selectedQuestion;
            }
            set
            {
                this._selectedQuestion = value;
                if (value != null)
                {
                    if (this.editQuestionDuringDeleting != value)
                    {
                        this.EditQuestionButtonIsEnabled = "True";
                        this.DeleteQuestionButtonIsEnabled = "True";
                    }
                    else
                    {
                        this.EditQuestionButtonIsEnabled = "False";
                        this.DeleteQuestionButtonIsEnabled = "False";
                    }
                }
                else
                {
                    this.EditQuestionButtonIsEnabled = "False";
                    this.DeleteQuestionButtonIsEnabled = "False";
                }
                NotifyOfPropertyChange(() => this.SelectedQuestion);
            }
        }
        public void DeleteQuestion()
        {
            Task.Run(() =>
            {
                QuestionModel questionTemp = new QuestionModel(this.SelectedQuestion.IdDB, "");
                this.editQuestionDuringDeleting = this.SelectedQuestion;
                this.EditQuestionButtonIsEnabled = "False";
                this.DeleteQuestionButtonIsEnabled = "False";
                BindableCollection<TestModel> tests = this.Db.GetTests();
                this._eventAggregator.PublishOnUIThread(new CursorMessageModel(System.Windows.Input.Cursors.Wait, (int)Task.CurrentId));
                String testsString = String.Empty;
                foreach (TestModel t in tests)
                {
                    bool ret = false;
                    foreach (QuestionModel q in t.Questions)
                    {
                        if (q.IdDB == questionTemp.IdDB)
                        {
                            ret = true;
                        }
                    }
                    if (ret && (t.Questions.Count == 1))
                    {
                        testsString = testsString + "\n" + t.Title;
                    }
                }
                if (testsString != string.Empty)
                {
                    this.editQuestionDuringDeleting = null;
                    this.EditQuestionButtonIsEnabled = "True";
                    this.DeleteQuestionButtonIsEnabled = "True";
                    MessageBox.Show(this.OnlyQuestion +
                        testsString, QuestionCantBeDeleted, MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    this.Db.DeleteQuestions(this.SelectedQuestion);
                    this.Questions.Remove(this.SelectedQuestion);
                }
                this._eventAggregator.PublishOnUIThread(new CursorMessageModel(System.Windows.Input.Cursors.Arrow, (int)Task.CurrentId));
                this.Refresh();
            });
        }
        public void EditQuestionOn()
        {
            EditQuestionPopUpViewModel window = new EditQuestionPopUpViewModel(this.Db, this._eventAggregator, this.SelectedQuestion);
            this._windowManager.ShowDialog(window);
            Task.Run(() =>
            {
                window.ReadyToUpdateQuestions();
                this.Questions = this.Db.GetQuestions();
                this.Refresh();
            });
        }

        public void CreateQuestion()
        {
            EditQuestionPopUpViewModel window = new EditQuestionPopUpViewModel(this.Db, this._eventAggregator, new QuestionModel(-1, ""));
            this._windowManager.ShowDialog(window);
            Task.Run(() =>
            {
                window.ReadyToUpdateQuestions();
                this.Questions = this.Db.GetQuestions();
                this.Refresh();
            });
        }

        public EditQuestionViewModel(IWindowManager windowManager, EventAggregator eventAggregator, ConnectionToDBModel db)
        {
            this._windowManager = windowManager;
            this._eventAggregator = eventAggregator;
            this.Db = db;

            this.editQuestionDuringDeleting = null;

            GUIstringsModel strings = new GUIstringsModel();
            this.AvailableQuestionsLabel = strings.GetGUIstr("AvailableQuestionsLabel");
            this.EditQuestionButton = strings.GetGUIstr("EditQuestionButton");
            this.CreateQuestionButton = strings.GetGUIstr("CreateQuestionButton");
            this.DeleteQuestionButton = strings.GetGUIstr("DeleteQuestionButton");
            this.QuestionCantBeDeleted = strings.GetGUIstr("QuestionCantBeDeleted");
            this.OnlyQuestion = strings.GetGUIstr("OnlyQuestion");

            Task.Run(() =>
            {
                this.Questions = this.Db.GetQuestions();
                this.Refresh();
            });
            this.EditQuestionButtonIsEnabled = "False";
            this.DeleteQuestionButtonIsEnabled = "False";
        }
    }
}