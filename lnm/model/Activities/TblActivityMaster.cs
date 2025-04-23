using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.Activities
{
    public class TblActivityMaster
    {
        [Key]
        public int AmActivityId { get; set; }

        public string? AmActivityName { get; set; }
    }
}
