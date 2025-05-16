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
        public float MoumMouId { get; set; }
        public string MouMouType { get; set; } // this will be either institution or connector
        public string? MoumMouName { get; set; }
        public string? MoumMouDescription { get; set; }
        public string? MoumMouPath { get; set; }
        public int MoumCreatedBy { get; set; }
        public DateTime MoumCreatedDate { get; set; }
        public int? MoumUpdatedBy { get; set; }
        public DateTime? MoumUpdatedDate { get; set; }
        public ConnectorMou connectorMous { get; set; } //only one mouid in float format representing each mou respect to connectors
        public InstitutionMou institutionMous { get; set; }

    }
}
