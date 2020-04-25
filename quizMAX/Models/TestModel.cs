using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizMAX.Models
{
    public class TestModel : PropertyChangedBase
    {
        readonly Random rand;

        private string _title;
        public int IdDB { get; set; }

        public string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                this._title = value;
                NotifyOfPropertyChange(() => this.Title);
            }
        }
        public string Description { get; set; }
        public BindableCollection<QuestionModel> Questions { get; set; }
        public QuestionModel GetNextQuestion()
        {
            try
            {
                QuestionModel q = this.Questions[rand.Next(0, this.Questions.Count)];
                Questions.Remove(q);
                QuestionModel ret = new QuestionModel(q.IdDB, q.QuestionText);
                BindableCollection<AnswerModel> answers = new BindableCollection<AnswerModel>();
                foreach (AnswerModel a in q.Answers)
                {
                    answers.Add(a);
                }
                while (answers.Count > 0)
                {
                    AnswerModel a = answers[rand.Next(0, answers.Count)];
                    answers.Remove(a);
                    ret.Answers.Add(a);
                }
                return ret;
            }
            catch
            {
                return null;
            }
        }

        public TestModel(int idDB, string title, string description)
        {
            this.IdDB = idDB;
            this.rand = new Random();
            this.Title = title;
            this.Description = description;
            this.Questions = new BindableCollection<QuestionModel>();
        }
    }
}
