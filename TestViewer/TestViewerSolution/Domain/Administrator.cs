
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
internal partial class Administrator : Person
{
	

	partial void ObjectPropertyChanged(string propertyName);


    public Administrator()
    {

        this.TestInstances = new HashSet<TestInstance>();

    }


	private string _lastname;
    public  string LastName 
		{ 
			get
			{ 
				return _lastname; 
			} 
			set
			{
				_lastname = value;
				ObjectPropertyChanged("LastName");
			}
		}

	private string _givenname;
    public  string GivenName 
		{ 
			get
			{ 
				return _givenname; 
			} 
			set
			{
				_givenname = value;
				ObjectPropertyChanged("GivenName");
			}
		}



    public virtual ICollection<TestInstance> TestInstances { get; set; }

    public virtual User User { get; set; }

}

}
