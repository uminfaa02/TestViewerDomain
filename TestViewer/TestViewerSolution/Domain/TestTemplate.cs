
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
internal partial class TestTemplate
{
	

	partial void ObjectPropertyChanged(string propertyName);


    public TestTemplate()
    {

        this.TestInstances = new HashSet<TestInstance>();

        this.Questions = new HashSet<Question>();

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

	private System.Guid _testviewerid;
    public  System.Guid TestViewerId 
		{ 
			get
			{ 
				return _testviewerid; 
			} 
			set
			{
				_testviewerid = value;
				ObjectPropertyChanged("TestViewerId");
			}
		}

	private string _name;
    public  string Name 
		{ 
			get
			{ 
				return _name; 
			} 
			set
			{
				_name = value;
				ObjectPropertyChanged("Name");
			}
		}



    public virtual ICollection<TestInstance> TestInstances { get; set; }

    public virtual TestViewer TestViewer { get; set; }

    public virtual ICollection<Question> Questions { get; set; }

}

}
