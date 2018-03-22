using System;
using System.ComponentModel.DataAnnotations;
using EM.Util.DataAccess.Repository;

namespace EM.Transfer.DAL.Common.Entities
{
    public class Transaction : EntityBase<long>
    {
        [Required, MaxLength(26)]
        public string SourceAccountNumber { get; set; }
        [Required, MaxLength(26)]
        public string TargetAccountNumber { get; set; }
        [Required]
        public int MoneyAmount { get; set; }
        [Required]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [Required]
        public bool Consolidated { get; set; } = false;
    }
}
