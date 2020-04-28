using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizMAX.Models
{
    public class TestForQuizModel : PropertyChangedBase
    {
        private int _currentQuestionNumber;
        private int _currentQuestionNumberForArray;
        private QuestionModel _currentQuestion;
        public BindableCollection<QuestionModel> Questions { get; set; }
        public int AllQuestionNumber { get; set; }
        public int ResultValue { get; set; }

        public int CurrentQuestionNumberForArray
        {
            get
            {
                return this._currentQuestionNumberForArray;
            }
            set
            {
                this._currentQuestionNumberForArray = value;
                this.CurrentQuestionNumber = value + 1;
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
        public void NextQuestion()
        {
            this.CurrentQuestionNumberForArray++;
            this.CurrentQuestion = this.Questions[this.CurrentQuestionNumberForArray];
        }
        public void PreviousQuestion()
        {
            this.CurrentQuestionNumberForArray--;
            this.CurrentQuestion = this.Questions[this.CurrentQuestionNumberForArray];
        }
        public float EndQuiz()
        {
            foreach (QuestionModel q in this.Questions)
            {
                if (q.CheckAnswers())
                {
                    this.ResultValue++;
                }
                foreach (AnswerModel a in q.Answers)
                {
                    a.IsSelected = false;
                }
            }
            return (float)this.ResultValue / (float)this.AllQuestionNumber;
        }

        public TestForQuizModel(TestModel selectedTest, int allQuestionNumber)
        {
            TestModel testTemp = new TestModel(selectedTest.IdDB, selectedTest.Title, selectedTest.Description);
            foreach (QuestionModel q in selectedTest.Questions)
            {
                testTemp.Questions.Add(q);
            }
            this.Questions = new BindableCollection<QuestionModel>();
            for (int i = 0; i < allQuestionNumber; i++)
            {
                this.Questions.Add(testTemp.GetNextQuestion());
            }

            this.AllQuestionNumber = allQuestionNumber;
            this.CurrentQuestionNumberForArray = 0;
            this.CurrentQuestion = this.Questions[this.CurrentQuestionNumberForArray];

            this.ResultValue = 0;
        }
    }
}
