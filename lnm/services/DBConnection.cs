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
