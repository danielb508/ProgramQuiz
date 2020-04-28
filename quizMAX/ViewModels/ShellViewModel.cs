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
    class ShellViewModel : Conductor<object>, IHandle<CursorMessageModel>
    {
        readonly IWindowManager _windowManager;
        readonly EventAggregator _eventAggregator;
        readonly ConnectionToDBModel _db;

        private int _cursorID { get; set; }
        private Cursor _cursor;

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
        public string MainWindowTitle { get; set; }
        public string MenuButtonTests { get; set; }
        public string MenuButtonTests_Learn { get; set; }
        public string MenuButtonTests_Quiz { get; set; }
        public string MenuButtonEdit { get; set; }
        public string MenuButtonEdit_Question { get; set; }
        public string MenuButtonEdit_Test { get; set; }
        public string MenuButtonOther { get; set; }
        public string MenuButtonAbout { get; set; }

        public void LoadAbout()
        {
            ActivateItem(new AboutViewModel());
        }
        public void LoadEditQuestion()
        {
            ActivateItem(new EditQuestionViewModel(this._windowManager, this._eventAggregator, this._db));
        }
        public void LoadEditTest()
        {
            ActivateItem(new EditTestViewModel(this._windowManager, this._eventAggregator, this._db));
        }
        public void LoadLearnMode()
        {
            ActivateItem(new LearnModeViewModel(this._windowManager, this._db));
        }
        public void LoadQuizMode()
        {
            ActivateItem(new QuizModeViewModel(this._windowManager, this._db));
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

        public ShellViewModel()
        {
            this._eventAggregator = new EventAggregator();
            this._windowManager = new WindowManager();
            this._db = new ConnectionToDBModel(_eventAggregator);
            GUIstringsModel strings = new GUIstringsModel();

            this._eventAggregator.Subscribe(this);

            this.MainWindowTitle = strings.GetGUIstr("MainWindowTitle");
            this.MenuButtonTests = strings.GetGUIstr("MenuButtonTests");
            this.MenuButtonTests_Learn = strings.GetGUIstr("MenuButtonTests_Learn");
            this.MenuButtonTests_Quiz = strings.GetGUIstr("MenuButtonTests_Quiz");
            this.MenuButtonEdit = strings.GetGUIstr("MenuButtonEdit");
            this.MenuButtonEdit_Question = strings.GetGUIstr("MenuButtonEdit_Question");
            this.MenuButtonEdit_Test = strings.GetGUIstr("MenuButtonEdit_Test");
            this.MenuButtonOther = strings.GetGUIstr("MenuButtonOther");
            this.MenuButtonAbout = strings.GetGUIstr("MenuButtonAbout");

            ActivateItem(new AboutViewModel());
        }
    }
}