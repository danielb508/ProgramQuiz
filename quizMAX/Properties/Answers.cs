//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace quizMAX.Properties
{
    using System;
    using System.Collections.Generic;
    
    public partial class Answers
    {
        public int Id { get; set; }
        public Nullable<int> Id_Quest { get; set; }
        public Nullable<int> Correct { get; set; }
        public string textAnswer { get; set; }
    
        public virtual Questions Questions { get; set; }
    }
}