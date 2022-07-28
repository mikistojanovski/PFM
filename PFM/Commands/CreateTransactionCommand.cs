using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PFM.Commands
{
     public class CreateTransactionCommand
     {
        [Required]
         public int id {get; set;}

        [Required]
         public string beneficiaryname { get; set; }
         public DateTime date { get; set; }
         public string direction { get;set; }
         public double amount {get; set;}
         public string description { get; set; }
         public string currency {get; set;}
         public int? mcc {get;set;}
         public string kind {get;set;}
     }
}