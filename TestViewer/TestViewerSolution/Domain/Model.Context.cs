﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    internal partial class TestViewerEntities : DbContext
    {
        public TestViewerEntities()
            : base("name=TestViewerEntities")
        {
    		Answers = Set<Answer>();	
    		CandidateTests = Set<CandidateTest>();	
    		Choices = Set<Choice>();	
    		People = Set<Person>();	
    		Questions = Set<Question>();	
    		QuestionBanks = Set<QuestionBank>();	
    		TestInstances = Set<TestInstance>();	
    		TestTemplates = Set<TestTemplate>();	
    		TestViewers = Set<TestViewer>();	
    
    
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        internal DbSet<Answer> Answers { get; set; }
        internal DbSet<CandidateTest> CandidateTests { get; set; }
        internal DbSet<Choice> Choices { get; set; }
        internal DbSet<Person> People { get; set; }
        internal DbSet<Question> Questions { get; set; }
        internal DbSet<QuestionBank> QuestionBanks { get; set; }
        internal DbSet<TestInstance> TestInstances { get; set; }
        internal DbSet<TestTemplate> TestTemplates { get; set; }
        internal DbSet<TestViewer> TestViewers { get; set; }
    }
}