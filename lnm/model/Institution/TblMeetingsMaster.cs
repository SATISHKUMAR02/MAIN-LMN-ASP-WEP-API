﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.Institution
{
    public class TblMeetingsMaster
    {
        [Key]
        public int MmMeetingId { get; set; }

        public int MmInstitutionId { get; set; }

        public string? MmMeetingDescritpion { get; set; }

        public int MmCreatedBy { get; set; }

        public DateTime? MmCreatedDate { get; set; }

        public DateOnly? MmMeetingScheduleDate {  get; set; }

        public int? MmUpdatedBy { get; set; }

        public string? MmInstitutionResponded { get; set; }

        public DateTime MmUpdatedDate { get; set; }

        public string? MmInstitutionAddress { get; set; }

        public TimeOnly? MmMeetingTime { get; set; }
        // creating only one table for both meeting and callback , and it is differentiated by the meeting type (Meeting/Callback)
        public string? MmMeetingType { get; set; }
        //==================================================================================================================
        public string? MmMeetingStatus { get; set; }

        public bool MmMeetingConducted { get; set; }

        public string MmmeetingOutcome {get;set;}

        public bool MmIsDeleted { get; set; }


    }
}
