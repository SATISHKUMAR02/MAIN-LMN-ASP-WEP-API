using Microsoft.EntityFrameworkCore;
using model.Activities;
using model.Institution;
using model.MOUs;
using model.User;


namespace services
{
    public class DBConnection : DbContext
    {
        public DBConnection(DbContextOptions<DBConnection> options) : base(options)
        {
            

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //        modelBuilder.Entity<Child>()               // Student
            //.HasOne(p => p.ParentNavigation)       // c => c.Department
            //.WithMany(c => c.ChildCollection)      // p => p.Students
            //.HasForeignKey<Child>(c => c.ForeignKeyProp)  // c => c.DepartmentId
            //.OnDelete(DeleteBehavior.Restrict);


            // between connector mou and mou



            // institution activity and activitymaster on activity ID ====/
            modelBuilder.Entity<TblInstitutionActivity>()
                .HasOne(c => c.ActivityMaster)
                .WithMany(p => p.TblActivities)
                .HasForeignKey(c => c.ImActivityId)
                .HasConstraintName("FK_InstitutionActivity_Activitymaster")
                .OnDelete(DeleteBehavior.Cascade);
                




            // relation between Meeting and institution master === 
            modelBuilder.Entity<TblMeetingsMaster>()
                .HasOne(c => c.institutionMaster)
                .WithOne(p => p.Meeting)
                .HasForeignKey<TblMeetingsMaster>(c => c.MmInstitutionId)
                .HasConstraintName("FK_MeetingMaster_Institutionmaster")
                .OnDelete(DeleteBehavior.Cascade);

            // institution master and institution Activity 
            modelBuilder.Entity<TblInstitutionActivity>()
                .HasOne(c => c.InstitutionMaster)
                
                .WithMany(p=>p.Activities)
                .HasForeignKey(c=>c.ImInstitutionId)
                .OnDelete(DeleteBehavior.Cascade);

            // one employee having only one role , multiple users can have different but  only one role id
            modelBuilder.Entity<tbl_employee_master>()
                  .HasOne(s => s.Role_Master)
                  .WithMany(d => d.Employees)
                  .HasForeignKey(s => s.em_role_id)
                  .HasConstraintName("FK_employeemaster_Roles")
                  .OnDelete(DeleteBehavior.Cascade);
            // one to one between user login and employee master
            modelBuilder.Entity<tbl_user_login_details>()
                  .HasOne(c => c.Employee)
                  .WithOne(p => p.Login_Details)
                  .HasForeignKey<tbl_user_login_details>(c => c.uld_employee_id)
                  .HasConstraintName("FK_tbluserlogindetails_EmployeeMaster")
                  .OnDelete(DeleteBehavior.Cascade);







        }

        #region User

        public DbSet<tbl_employee_master> tbl_employee_master { get; set; }
        public DbSet<tbl_role_master> tbl_role_master  { get; set; }
        public DbSet<tbl_user_login_details> tbl_user_login_details { get; set; }

        #endregion


        #region MOUs
        public DbSet<ConnectorMou> connectorMou { get; set; }
        public DbSet<InstitutionMou> institutionMou { get; set; }
        public DbSet<MouMaster> mouMaster { get; set; }
        #endregion

        #region Institution
        public DbSet<TblInstitutionActivity> institutionActivity { get; set; }
        public DbSet<TblInstitutionMaster> institutionMaster { get; set; }
        public DbSet<TblMeetingsMaster> meetingsMaster { get; set; }
        #endregion

        #region ActivityMaster
        public DbSet<TblActivityMaster> activityMaster { get; set; }

        #endregion

    }
}
