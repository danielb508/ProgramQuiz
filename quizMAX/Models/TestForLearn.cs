using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizMAX.Models
{
    public class TestForLearnModel : PropertyChangedBase
    {
        private int _resultValue;
        private int _currentQuestionNumber;
        private QuestionModel _currentQuestion;
        public TestModel Test { get; set; }
        public int AllQuestionNumber { get; set; }

        public int ResultValue
        {
            get
            {
                return this._resultValue;
            }
            set
            {
                this._resultValue = value;
                NotifyOfPropertyChange();
            }
        }
        public int CurrentQuestionNumber
        {
            get
            {
                return this._currentQuestionNumber;
            }
            set
            {
                this._currentQuestionNumber = value;
                NotifyOfPropertyChange();
            }
        }
        public QuestionModel CurrentQuestion
        {
            get
            {
                return this._currentQuestion;
            }
            set
            {
                this._currentQuestion = value;
                NotifyOfPropertyChange();
            }
        }
        public bool Confirm()
        {
            if (this.CurrentQuestion.CheckAnswers())
            {
                this.ResultValue++;
            }
            foreach (AnswerModel a in CurrentQuestion.Answers)
            {
                a.IsSelected = false;
            }
            if (this.CurrentQuestionNumber == this.AllQuestionNumber)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void NextQuestion()
        {
            this.CurrentQuestionNumber++;
            this.CurrentQuestion = this.Test.GetNextQuestion();
        }
        public TestForLearnModel(TestModel selectedTest)
        {
            this.Test = new TestModel(selectedTest.IdDB, selectedTest.Title, selectedTest.Description);
            foreach (QuestionModel q in selectedTest.Questions)
            {
                this.Test.Questions.Add(q);
            }

            this.AllQuestionNumber = this.Test.Questions.Count;
            this.CurrentQuestion = Test.GetNextQuestion();
            this.CurrentQuestionNumber = 1;

            this.ResultValue = 0;
        }
    }
}