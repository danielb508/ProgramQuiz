using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizMAX.Models
{
    public class AnswerModel : PropertyChangedBase
    {
        private string _answer;
        private bool _isSelected;
        public int IdDB { get; set; }
        public bool Correct { get; set; }
        public AnswerModel(int idDB, string answer, bool correct)
        {
            this.IdDB = idDB;
            this.Answer = answer;
            this.Correct = correct;
            this.IsSelected = false;
        }
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
        public string Answer
        {
            get
            {
                return this._answer;
            }
            set
            {
                this._answer = value;
                NotifyOfPropertyChange();
            }
        }

        public AnswerModel(int idDB, string answer)
        {
            this.IdDB = idDB;
            this.Answer = answer;
            this.Correct = false;
            this.IsSelected = false;
        }
    }
}