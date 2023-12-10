﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mgmt.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class mgmtEntities : DbContext
    {
        public mgmtEntities()
            : base("name=mgmtEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<wh_list> wh_list { get; set; }
        public virtual DbSet<wh_dep> wh_dep { get; set; }
        public virtual DbSet<wh_dep_locations> wh_dep_locations { get; set; }
    
        public virtual ObjectResult<get_wh_list_byUser_Result> get_wh_list_byUser(string userID)
        {
            var userIDParameter = userID != null ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_wh_list_byUser_Result>("get_wh_list_byUser", userIDParameter);
        }
    
        public virtual ObjectResult<get_dep_list_by_wh_Result> get_dep_list_by_wh(Nullable<int> id_wh)
        {
            var id_whParameter = id_wh.HasValue ?
                new ObjectParameter("id_wh", id_wh) :
                new ObjectParameter("id_wh", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_dep_list_by_wh_Result>("get_dep_list_by_wh", id_whParameter);
        }
    }
}