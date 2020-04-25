using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizMAX.Models
{
    public class QuestionModel : PropertyChangedBase
    {
        private string _questionText;
        public int IdDB { get; set; }
        public BindableCollection<AnswerModel> Answers { get; set; }
        public string QuestionText
        {
            get
            {
                return this._questionText;
            }
            set
            {
                this._questionText = value;
                NotifyOfPropertyChange();
            }
        }
        public BindableCollection<AnswerModel> CorrectAnswers()
        {
            BindableCollection<AnswerModel> correctAnswers = new BindableCollection<AnswerModel>();
            foreach (AnswerModel a in this.Answers)
            {
                if (a.Correct)
                {
                    correctAnswers.Add(a);
                }
            }
            return correctAnswers;
        }
        public bool CheckAnswers()
        {
            BindableCollection<AnswerModel> selectedAnswers = new BindableCollection<AnswerModel>();
            BindableCollection<AnswerModel> correctAnswers = this.CorrectAnswers();
            foreach (AnswerModel answer in this.Answers)
            {
                if (answer.IsSelected)
                {
                    selectedAnswers.Add(answer);
                }
            }
            foreach (AnswerModel answer in selectedAnswers)
            {
                if (correctAnswers.Contains(answer))
                {
                    correctAnswers.Remove(answer);
                }
                else
                {
                    return false;
                }
            }
            if (correctAnswers.Any())
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get
            {
                return this._isSelected;
            }
            set
            {
                this._isSelected = value;
                NotifyOfPropertyChange();
            }
        }
        public QuestionModel(int idDB, string questionText)
        {
            this.IdDB = idDB;
            this.QuestionText = questionText;
            this.Answers = new BindableCollection<AnswerModel>();
            this.IsSelected = false;
        }
    }
}