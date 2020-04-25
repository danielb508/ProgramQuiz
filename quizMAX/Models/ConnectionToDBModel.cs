using Caliburn.Micro;
using quizMAX.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizMAX.Models
{
    public class ConnectionToDBModel : PropertyChangedBase
    {
        private readonly EventAggregator _eventAggregator;
        private bool isUpdated;

        public BindableCollection<TestModel> GetTests()
        {
            this._eventAggregator.PublishOnUIThread(new CursorMessageModel(System.Windows.Input.Cursors.Wait, (int)Task.CurrentId));
            while (this.isUpdated) { }
            BindableCollection<TestModel> retTests = new BindableCollection<TestModel>();
            using (var context = new quizEntities())
            {
                var testsDB = context.Tests.Select(t => t).ToList();
                foreach (Tests t in testsDB)
                {
                    TestModel retT = new TestModel(t.Id, t.Title, t.Description);
                    foreach (QuestionModel q in this.GetQuestionsForTest(retT.IdDB))
                    {
                        retT.Questions.Add(q);
                    }
                    retTests.Add(retT);
                }
            }
            this._eventAggregator.PublishOnUIThread(new CursorMessageModel(System.Windows.Input.Cursors.Arrow, (int)Task.CurrentId));
            return retTests;
        }
        public BindableCollection<QuestionModel> GetQuestionsForTest(int id)
        {
            BindableCollection<QuestionModel> retQuestions = new BindableCollection<QuestionModel>();
            using (var context = new quizEntities())
            {
                var linksDB = context.Table2.Where(l => l.IdTest == id).Select(l => l).ToList();
                foreach (Table2 l in linksDB)
                {
                    var questionDB = context.Questions.Where(q => q.Id == l.IdQuest).Select(q => q).First();
                    QuestionModel retQ = new QuestionModel(questionDB.Id, questionDB.QuestionText);
                    foreach (AnswerModel a in this.GetAnswers(retQ.IdDB))
                    {
                        retQ.Answers.Add(a);
                    }
                    retQuestions.Add(retQ);
                }
            }
            return retQuestions;
        }

        public BindableCollection<QuestionModel> GetQuestions()
        {
            this._eventAggregator.PublishOnUIThread(new CursorMessageModel(System.Windows.Input.Cursors.Wait, (int)Task.CurrentId));
            while (this.isUpdated) { }
            BindableCollection<QuestionModel> retQuestions = new BindableCollection<QuestionModel>();
            using (var context = new quizEntities())
            {
                var questionsDB = context.Questions.Select(q => q).ToList();
                foreach (Questions q in questionsDB)
                {
                    QuestionModel retQ = new QuestionModel(q.Id, q.QuestionText);
                    foreach (AnswerModel a in this.GetAnswers(retQ.IdDB))
                    {
                        retQ.Answers.Add(a);
                    }
                    retQuestions.Add(retQ);
                }
            }
            this._eventAggregator.PublishOnUIThread(new CursorMessageModel(System.Windows.Input.Cursors.Arrow, (int)Task.CurrentId));
            return retQuestions;
        }

        public BindableCollection<AnswerModel> GetAnswers(int id)
        {
            BindableCollection<AnswerModel> retAnswers = new BindableCollection<AnswerModel>();
            using (var context = new quizEntities())
            {
                var answersDB = context.Answers.Where(a => a.Id_Quest == id).Select(a => a).ToList();
                foreach (Answers a in answersDB)
                {
                    AnswerModel ans = new AnswerModel(a.Id, a.textAnswer);
                    if (a.Correct == 1)
                    {
                        ans.Correct = true;
                    }
                    else
                    {
                        ans.Correct = false;
                    }
                    retAnswers.Add(ans);
                }
            }
            return retAnswers;
        }

        public int DeleteTest(TestModel test)
        {
            this.isUpdated = true;
            using (var context = new quizEntities())
            {
                var testToRemove = context.Tests.SingleOrDefault(t => t.Id == test.IdDB);
                context.Tests.Remove(testToRemove);
                var linksToRemove = context.Table2.Where(l => l.IdTest == test.IdDB).Select(l => l).ToList();
                foreach (Table2 l in linksToRemove)
                {
                    context.Table2.Remove(l);
                }
                context.SaveChanges();
            }
            this.isUpdated = false;
            return 0;
        }

        public int UpdateTest(TestModel t)
        {
            while (this.isUpdated == true) { }
            this.isUpdated = true;
            int max_t;
            int max_l;
            if (t.IdDB == -1)
            {
                using (var context = new quizEntities())
                {
                    try
                    {
                        max_t = context.Tests.Max(ts => ts.Id);
                        max_t++;
                    }
                    catch (System.InvalidOperationException)
                    {
                        max_t = 1;
                    }
                    var test = new Tests()
                    {
                        Id = max_t,
                        Title = t.Title.Trim(),
                        Description = t.Description.Trim()
                    };
                    context.Tests.Add(test);
                    context.SaveChanges();
                    foreach (QuestionModel q in t.Questions)
                    {
                        try
                        {
                            max_l = context.Table2.Max(l => l.Id);
                            max_l++;
                        }
                        catch (System.InvalidOperationException)
                        {
                            max_l = 1;
                        }
                        var table = new Table2()
                        {
                            Id = max_l,
                            IdQuest = q.IdDB,
                            IdTest = test.Id,
                        };
                        context.Table2.Add(table);
                        context.SaveChanges();
                    }
                }
            }
            else
            {
                using (var context = new quizEntities())
                {
                    this.DeleteTest(t);

                    var test = new Tests()
                    {
                        Id = t.IdDB,
                        Title = t.Title.Trim(),
                        Description = t.Description.Trim()
                    };

                    context.Tests.Add(test);
                    context.SaveChanges();
                    foreach (QuestionModel q in t.Questions)
                    {
                        try
                        {
                            max_l = context.Table2.Max(l => l.Id);
                            max_l++;
                        }
                        catch (System.InvalidOperationException)
                        {
                            max_l = 1;
                        }
                        var table = new Table2()
                        {
                            Id = max_l,
                            IdQuest = q.IdDB,
                            IdTest = test.Id,
                        };
                        context.Table2.Add(table);
                        context.SaveChanges();
                    }
                }
            }
            this.isUpdated = false;
            return 0;
        }

        public int UpdateQuestions(QuestionModel question)
        {
            while (this.isUpdated) { }
            this.isUpdated = true;
            int max_a;
            int max_q;
            if (question.IdDB == -1)
            {
                using (var context = new quizEntities())
                {
                    try
                    {
                        max_q = context.Questions.Max(l => l.Id);
                        max_q++;
                    }
                    catch (System.InvalidOperationException)
                    {
                        max_q = 1;
                    }
                    var questionRow = new Questions()
                    {
                        Id = max_q,
                        QuestionText = question.QuestionText.Trim()
                    };
                    context.Questions.Add(questionRow);
                    context.SaveChanges();
                    foreach (AnswerModel a in question.Answers)
                    {
                        try
                        {
                            max_a = context.Answers.Max(l => l.Id);
                            max_a++;
                        }
                        catch (System.InvalidOperationException)
                        {
                            max_a = 1;
                        }
                        int correct;
                        if (a.Correct == true)
                        {
                            correct = 1;
                        }
                        else
                        {
                            correct = 0;
                        }
                        var answerRow = new Answers()
                        {
                            Id = max_a,
                            Id_Quest = questionRow.Id,
                            Correct = correct,
                            textAnswer = a.Answer,
                        };
                        context.Answers.Add(answerRow);
                        context.SaveChanges();
                    }

                }
            }
            else
            {
                using (var context = new quizEntities())
                {
                    var existingQuestion = context.Questions.SingleOrDefault(q => q.Id == question.IdDB);
                    existingQuestion.QuestionText = question.QuestionText.Trim();
                    context.SaveChanges();

                    var answersToRemove = context.Answers.Where(a => a.Id_Quest == question.IdDB).Select(a => a).ToList();
                    foreach (Answers a in answersToRemove)
                    {
                        context.Answers.Remove(a);
                    }
                    context.SaveChanges();

                    foreach (AnswerModel a in question.Answers)
                    {
                        try
                        {
                            max_a = context.Answers.Max(l => l.Id);
                            max_a++;
                        }
                        catch (System.InvalidOperationException)
                        {
                            max_a = 1;
                        }
                        int correct;
                        if (a.Correct == true)
                        {
                            correct = 1;
                        }
                        else
                        {
                            correct = 0;
                        }
                        var answerRow = new Answers()
                        {
                            Id = max_a,
                            Id_Quest = question.IdDB,
                            Correct = correct,
                            textAnswer = a.Answer,
                        };
                        context.Answers.Add(answerRow);
                        context.SaveChanges();
                    }
                }
            }
            this.isUpdated = false;
            return 0;
        }

        public int DeleteQuestions(QuestionModel question)
        {
            while (this.isUpdated) { }
            this.isUpdated = true;
            using (var context = new quizEntities())
            {
                var questionToRemove = context.Questions.SingleOrDefault(q => q.Id == question.IdDB);
                context.Questions.Remove(questionToRemove);
                var answersToRemove = context.Answers.Where(a => a.Id_Quest == question.IdDB).Select(a => a).ToList();
                foreach (Answers a in answersToRemove)
                {
                    context.Answers.Remove(a);
                }
                var linksToRemove = context.Table2.Where(l => l.IdQuest == question.IdDB).Select(l => l).ToList();
                foreach (Table2 l in linksToRemove)
                {
                    context.Table2.Remove(l);
                }
                context.SaveChanges();
            }
            this.isUpdated = false;
            return 0;
        }

        public ConnectionToDBModel(EventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            this.isUpdated = false;
        }
    }
}
