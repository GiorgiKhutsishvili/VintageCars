﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VintageCars.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VintageCarsDBEntities : DbContext
    {
        public VintageCarsDBEntities()
            : base("name=VintageCarsDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdminTbl> AdminTbl { get; set; }
        public virtual DbSet<ImageTbl> ImageTbl { get; set; }
        public virtual DbSet<ServiceTbl> ServiceTbl { get; set; }
        public virtual DbSet<SocialLinksTbl> SocialLinksTbl { get; set; }
        public virtual DbSet<SubscriberTbl> SubscriberTbl { get; set; }
    }
}
