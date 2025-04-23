using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.MOUs
{
    public class MouMaster
    {
        [Key]
        public int MoumMouId { get; set; }

        public string? MoumMouName { get; set; }

        public string? MoumMouDescription { get; set; }

        public string? MoumMouPath { get; set; }

        public int MoumCreatedBy { get; set; }

        public DateTime MoumCreatedDate { get; set; }

        public int? MoumUpdatedBy { get; set; }

        public DateTime? MoumUpdatedDate { get; set; }
    }
}
