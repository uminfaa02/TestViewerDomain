
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
internal partial class Answer
{
	

	partial void ObjectPropertyChanged(string propertyName);


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

	private System.Guid _choiceid;
    public  System.Guid ChoiceId 
		{ 
			get
			{ 
				return _choiceid; 
			} 
			set
			{
				_choiceid = value;
				ObjectPropertyChanged("ChoiceId");
			}
		}

	private System.Guid _candidatetestid;
    public  System.Guid CandidateTestId 
		{ 
			get
			{ 
				return _candidatetestid; 
			} 
			set
			{
				_candidatetestid = value;
				ObjectPropertyChanged("CandidateTestId");
			}
		}

	private System.DateTime _datetime;
    public  System.DateTime DateTime 
		{ 
			get
			{ 
				return _datetime; 
			} 
			set
			{
				_datetime = value;
				ObjectPropertyChanged("DateTime");
			}
		}



    public virtual CandidateTest CandidateTest { get; set; }

    public virtual Choice Choice { get; set; }

}

}
