using System;
using System.ComponentModel.DataAnnotations;

namespace NextStepMVC.Models
{
    public class Opportunity
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Organization { get; set; }

        [Required]
        public string Type { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime Deadline { get; set; }

        [Required]
        public string ApplicationLink { get; set; }
    }
}
