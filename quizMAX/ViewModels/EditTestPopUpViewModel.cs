using Caliburn.Micro;
using quizMAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace quizMAX.ViewModels
{
    public class EditTestPopUpViewModel : Screen, IHandle<CursorMessageModel>
    {
        readonly ConnectionToDBModel _db;
        readonly TestModel _selectedTest;
        readonly EventAggregator _eventAggregator;

        private Cursor _cursor;
        private int _cursorID;
        public Cursor Cursor
        {
            get
            {
                return this._cursor;
            }
            set
            {
                this._cursor = value;
                NotifyOfPropertyChange(() => this.Cursor);
            }
        }

        private bool _readyToRead;
        private string _titleValue;
        private string _descriptionValue;
        private string _confirmEditionButtonIsEnabled;
        private void ConfirmButtonTryToEnable()
        {
            bool isAnySelected = false;
            foreach (QuestionModel q in this.Questions)
            {
                if (q.IsSelected)
                {
                    isAnySelected = true;
                    break;
                }
            }
            if (this.TitleValue != String.Empty && this.DescriptionValue != string.Empty && isAnySelected)
            {
                this.ConfirmEditionButtonIsEnabled = "True";
            }
            else
            {
                this.ConfirmEditionButtonIsEnabled = "False";
            }
        }
        protected override void OnDeactivate(bool close)
        {
            foreach (QuestionModel q in this.Questions)
            {
                q.IsSelected = false;
            }
        }
        public BindableCollection<QuestionModel> Questions { get; set; }
        public string EditTestTitle { get; set; }
        public string QuestionsInTestLabel { get; set; }
        public string TitleLabel { get; set; }
        public string DescriptionLabel { get; set; }
        public string ConfirmEditionButton { get; set; }
        public string TitleValue
        {
            get
            {
                return this._titleValue;
            }
            set
            {
                this._titleValue = value;
                NotifyOfPropertyChange(() => this.TitleValue);
                ConfirmButtonTryToEnable();
            }
        }
        public string DescriptionValue
        {
            get
            {
                return this._descriptionValue;
            }
            set
            {
                this._descriptionValue = value;
                NotifyOfPropertyChange(() => this.DescriptionValue);
                ConfirmButtonTryToEnable();
            }
        }
        public string ConfirmEditionButtonIsEnabled
        {
            get
            {
                return this._confirmEditionButtonIsEnabled;
            }
            set
            {
                this._confirmEditionButtonIsEnabled = value;
                NotifyOfPropertyChange(() => this.ConfirmEditionButtonIsEnabled);
            }
        }
        public void Confirm()
        {
            this._selectedTest.Title = this.TitleValue;
            this._selectedTest.Description = this.DescriptionValue;
            this._selectedTest.Questions.Clear();
            foreach (QuestionModel q in this.Questions)
            {
                if (q.IsSelected)
                {
                    this._selectedTest.Questions.Add(q);
                }
                q.IsSelected = false;
            }
            Task.Run(() =>
            {
                this._eventAggregator.PublishOnUIThread(new CursorMessageModel(System.Windows.Input.Cursors.Wait, (int)Task.CurrentId));
                this._db.UpdateTest(this._selectedTest);
                this._readyToRead = true;
                this._eventAggregator.PublishOnUIThread(new CursorMessageModel(System.Windows.Input.Cursors.Arrow, (int)Task.CurrentId));
            });
            this.TryClose();
        }
        public void SelectionChanged()
        {
            ConfirmButtonTryToEnable();
        }

        public int ReadyToUpdateTests()
        {
            while (!this._readyToRead)
            { }
            return 0;
        }

        public void Handle(CursorMessageModel message)
        {
            if (message.State == System.Windows.Input.Cursors.Wait)
            {
                this.Cursor = message.State;
                this._cursorID = message.TaskID;
            }
            else
            {
                if (message.TaskID == this._cursorID)
                {
                    this.Cursor = message.State;
                }
            }
        }

        public EditTestPopUpViewModel(ConnectionToDBModel db, EventAggregator eventAggregator, TestModel selectedTest)
        {
            this._db = db;
            this._selectedTest = selectedTest;
            this._eventAggregator = eventAggregator;

            this._eventAggregator.Subscribe(this);

            this.Questions = new BindableCollection<QuestionModel>();
            Task.Run(() =>
            {
                var taskDB = db.GetQuestions();
                this.Questions = taskDB;
                foreach (QuestionModel q in this.Questions)
                {
                    foreach (QuestionModel qTest in this._selectedTest.Questions)
                    {
                        if (q.IdDB == qTest.IdDB)
                        {
                            q.IsSelected = true;
                        }
                    }
                }
                this.Refresh();
            });

            this._readyToRead = false;

            GUIstringsModel strings = new GUIstringsModel();
            this.EditTestTitle = strings.GetGUIstr("EditTestTitle");
            this.QuestionsInTestLabel = strings.GetGUIstr("QuestionsInTestLabel");
            this.ConfirmEditionButton = strings.GetGUIstr("ConfirmEditionButton");
            this.TitleLabel = strings.GetGUIstr("TitleLabel");
            this.DescriptionLabel = strings.GetGUIstr("DescriptionLabel");

            this.TitleValue = this._selectedTest.Title;
            this.DescriptionValue = this._selectedTest.Description;

            ConfirmButtonTryToEnable();
        }
    }
}