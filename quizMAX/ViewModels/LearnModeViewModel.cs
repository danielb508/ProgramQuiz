using Caliburn.Micro;
using quizMAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizMAX.ViewModels
{
    public class LearnModeViewModel : Screen
    {
        readonly IWindowManager _windowManager;

        private TestModel _selectedTest;
        private string _numberOfQuestionsValue;
        private string _startLearnButtonIsEnabled;

        public BindableCollection<TestModel> Tests { get; set; }
        public string DescriptionLabel { get; set; }
        public string AvailableTestsLabel { get; set; }
        public string NumberOfQuestionsLabel { get; set; }
        public string StartLearningButton { get; set; }


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
                    this.StartLearnButtonIsEnabled = "True";
                    this.NumberOfQuestionsValue = value.Questions.Count().ToString();
                }
                NotifyOfPropertyChange(() => this.SelectedTest);
                NotifyOfPropertyChange(() => this.NumberOfQuestionsValue);
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
        public string StartLearnButtonIsEnabled
        {
            get
            {
                return this._startLearnButtonIsEnabled;
            }
            set
            {
                this._startLearnButtonIsEnabled = value;
                NotifyOfPropertyChange(() => this.StartLearnButtonIsEnabled);
            }
        }
        public void LearnModeOn()
        {
            this._windowManager.ShowDialog(new LearnPopUpViewModel(this.SelectedTest));
        }

        public LearnModeViewModel(IWindowManager windowManager, ConnectionToDBModel db)
        {
            this._windowManager = windowManager;
            GUIstringsModel strings = new GUIstringsModel();
            this.DescriptionLabel = strings.GetGUIstr("DescriptionLabel");
            this.AvailableTestsLabel = strings.GetGUIstr("AvailableTestsLabel");
            this.NumberOfQuestionsLabel = strings.GetGUIstr("NumberOfQuestionsLabel");
            this.StartLearningButton = strings.GetGUIstr("StartLearningButton");

            Task.Run(() =>
            {
                this.Tests = db.GetTests();
                this.Refresh();
            });

            this.StartLearnButtonIsEnabled = "False";
        }
    }
}