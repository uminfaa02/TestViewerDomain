
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
internal abstract partial class Person
{
	

	partial void ObjectPropertyChanged(string propertyName);


    public Person()
    {

        this.Active = true;

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

	private bool _active;
    public  bool Active 
		{ 
			get
			{ 
				return _active; 
			} 
			set
			{
				_active = value;
				ObjectPropertyChanged("Active");
			}
		}



    public virtual TestViewer TestViewer { get; set; }

}

}
