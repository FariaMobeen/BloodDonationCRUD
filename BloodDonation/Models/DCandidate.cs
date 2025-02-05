// provide properties of each ccolumn in table (basically setting up the table)
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonation.Models
{
    public class DCandidate
    {   
        [Key] //id is the key for the table
        public int id {get; set;}

        [Column(TypeName ="nvarchar(100)")]  //need to only specify this (the type and length of strin in the table ) for strings
        public string fullName  {get; set;}
        
        [Column(TypeName ="nvarchar(16)")]
        public string mobile  {get; set;}

        [Column(TypeName ="nvarchar(100)")]
        public string email {get; set;}

        public int age {get; set;}

        [Column(TypeName ="nvarchar(3)")]
        public string bloodGroup {get; set;}

        [Column(TypeName ="nvarchar(100)")]
        public string address {get; set;}

    }
}
