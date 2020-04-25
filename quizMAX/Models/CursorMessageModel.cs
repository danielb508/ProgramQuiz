using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace quizMAX.Models
{
    public class CursorMessageModel
    {
        public Cursor State { get; set; }
        public int TaskID { get; set; }
        public CursorMessageModel(Cursor cursor, int taskId)
        {
            this.State = cursor;
            this.TaskID = taskId;
        }
    }
}
