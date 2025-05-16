using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.MOUs
{
    public class InstitutionMou
    {
        [Key]
        public int ImoMouNo { get; set; }
        public float? ImoMouId { get; set; }
        public int? ImoInstitutionId { get; set; }
        public int? ImoCreatedBy { get; set; }
        public int? ImoUpdatedBy { get; set; }
        public DateTime? ImoCreatedDate { get; set; }
        public DateTime? ImoUpdatedDate { get; set; }
        public float ImoMouVerionNo { get; set; }
        public string? ImoMouPath { get; set; }
        public string? ImoMouDescription { get; set; }
        public string? ImoUploadedMou { get; set; }
        public string? ImoDownloadedMou { get; set; }
    }
}
