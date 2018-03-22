using System.ComponentModel.DataAnnotations;

namespace EM.Transfer.BL.Common.Models
{
    public class TransactionRequest
    {
        [Required, MaxLength(26)]
        public string SourceAccountNumber { get; set; }
        [Required, MaxLength(26)]
        public string TargetAccountNumber { get; set; }
        [Required]
        public int MoneyAmount { get; set; }
    }
}
