﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DoXM_Library.Models
{
    public class CommandContext
    {
        [Key]
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public string CommandMode { get; set; }
        public string CommandText { get; set; }
        public string SenderUserID { get; set; }
        public string SenderConnectionID { get; set; }
        public string[] TargetMachineIDs { get; set; }
        public List<PSCoreCommandResult> PSCoreResults { get; set; } = new List<PSCoreCommandResult>();
        public List<GenericCommandResult> CommandResults { get; set; } = new List<GenericCommandResult>();
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        [IgnoreDataMember]
        public Organization Organization { get; set; }
        public string OrganizationID { get; set; }
    }
}
