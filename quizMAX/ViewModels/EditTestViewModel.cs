using Caliburn.Micro;
using quizMAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizMAX.ViewModels
{
    public class EditTestViewModel : Screen
    {
        readonly IWindowManager _windowManager;
        readonly EventAggregator _eventAggregator;

        private TestModel _selectedTest;
        private string _editTestButtonIsEnabled;
        private string _deleteTestButtonIsEnabled;
        public BindableCollection<TestModel> Tests { get; set; }
        public ConnectionToDBModel Db { get; set; }
        public string AvailableTestsLabel { get; set; }
        public string EditTestButton { get; set; }
        public string DeleteTestButton { get; set; }
        public string CreateTestButton { get; set; }

        public string EditTestButtonIsEnabled
        {
            get
            {
                return this._editTestButtonIsEnabled;
            }
            set
            {
                this._editTestButtonIsEnabled = value;
                NotifyOfPropertyChange(() => this.EditTestButtonIsEnabled);
            }
        }
        public string DeleteTestButtonIsEnabled
        {
            get
            {
                return this._deleteTestButtonIsEnabled;
            }
            set
            {
                this._deleteTestButtonIsEnabled = value;
                NotifyOfPropertyChange(() => this.DeleteTestButtonIsEnabled);
            }
        }
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
                    this.EditTestButtonIsEnabled = "True";
                    this.DeleteTestButtonIsEnabled = "True";
                }
                else
                {
                    this.EditTestButtonIsEnabled = "False";
                    this.DeleteTestButtonIsEnabled = "False";
                }
                NotifyOfPropertyChange(() => this.SelectedTest);
            }
        }
        public void DeleteTest()
        {
            Task.Run(() =>
            {
                var taskDB = this.Db.DeleteTest(this.SelectedTest);
            });
            this.Tests.Remove(this.SelectedTest);
        }
        public void CreateTest()
        {
            TestModel newTest = new TestModel(-1, "", "");
            EditTestPopUpViewModel window = new EditTestPopUpViewModel(this.Db, this._eventAggregator, newTest);
            this._windowManager.ShowDialog(window);
            Task task = Task.Run(() =>
            {
                window.ReadyToUpdateTests();
                this.Tests = this.Db.GetTests();
                this.Refresh();
            });
        }
        public void EditTestOn()
        {
            EditTestPopUpViewModel window = new EditTestPopUpViewModel(this.Db, this._eventAggregator, this.SelectedTest);
            this._windowManager.ShowDialog(window);
            Task task = Task.Run(() =>
            {
                window.ReadyToUpdateTests();
                this.Tests = this.Db.GetTests();
                this.Refresh();
            });
        }
        public EditTestViewModel(IWindowManager windowManager, EventAggregator eventAggregator, ConnectionToDBModel db)
        {
            this._windowManager = windowManager;
            this._eventAggregator = eventAggregator;

            this.Db = db;
            Task.Run(() =>
            {
                this.Tests = this.Db.GetTests();
                this.Refresh();
            });

            GUIstringsModel strings = new GUIstringsModel();
            this.AvailableTestsLabel = strings.GetGUIstr("AvailableTestsLabel");
            this.EditTestButton = strings.GetGUIstr("EditTestButton");
            this.DeleteTestButton = strings.GetGUIstr("DeleteTestButton");
            this.CreateTestButton = strings.GetGUIstr("CreateTestButton");

            this.EditTestButtonIsEnabled = "False";
            this.DeleteTestButtonIsEnabled = "False";
        }
    }
}