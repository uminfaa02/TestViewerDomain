
//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Domain
{

using System;
    using System.Collections.Generic;
    
using System.ComponentModel;
internal partial class Choice
{
	

	partial void ObjectPropertyChanged(string propertyName);


    public Choice()
    {

        this.Answers = new HashSet<Answer>();

    }


	private System.Guid _id;
    public  System.Guid Id 
		{ 
			get
			{ 
				return _id; 
			} 
			set
			{
				_id = value;
				ObjectPropertyChanged("Id");
			}
		}

	private System.Guid _questionid;
    public  System.Guid QuestionId 
		{ 
			get
			{ 
				return _questionid; 
			} 
			set
			{
				_questionid = value;
				ObjectPropertyChanged("QuestionId");
			}
		}

	private string _text;
    public  string Text 
		{ 
			get
			{ 
				return _text; 
			} 
			set
			{
				_text = value;
				ObjectPropertyChanged("Text");
			}
		}

	private bool _iscorrect;
    public  bool IsCorrect 
		{ 
			get
			{ 
				return _iscorrect; 
			} 
			set
			{
				_iscorrect = value;
				ObjectPropertyChanged("IsCorrect");
			}
		}



    public virtual ICollection<Answer> Answers { get; set; }

    public virtual Question Question { get; set; }

}

}
