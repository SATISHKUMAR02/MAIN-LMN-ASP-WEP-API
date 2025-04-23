using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.MOUs
{
    public class ConnectorMou
    {
        [Key]
        public int CmouMouNo { get; set; }

        public int? CmouMouId { get; set; }

        public int? CmouRoleId { get; set; }

        public int CmouCreatedBy { get; set; }

        public int? CmouUpdatedBy { get; set; }

        public DateTime CmouCreatedDate { get; set; }

        public DateTime? CmouUpdatedDate { get; set; }

        public string? CmouMouVerionNo { get; set; }

        public string? CmouMouPath { get; set; }

        public string? CmouMouDescription { get; set; }
    }
}
