﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace model.Institution
{
    public class TblInstitutionActivity
    {
        [Key]
        public int ImSlno { get; set; }  
        public int ImInstitutionId { get; set; }
        public int ImActivityId { get; set; }
        public string? ImInstitutionType { get; set; }
        public string? ImInstitutionAddress { get; set; }
        public string? ImInstitutionName { get; set; }
        public int ImStudentStrength { get; set; }
        public string? ImActivityName { get; set; }
        public string? ImAssignConnector { get; set; }
        public int ImCreatedBy { get; set; }
        public int? ImUpdatedBy { get; set; }
        public DateTime ImCreatedDate { get; set; }
        public DateTime? ImUpdatedDate { get; set; }
        public DateOnly ImScheduleDate { get; set; }
        public int ImStudentParticipating { get; set; }
        public int NoOfDaysEvent { get; set; }
        public string? ImEventVenue { get; set; }
    }
}
