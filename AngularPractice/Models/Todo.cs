using System;
using System.ComponentModel.DataAnnotations;

namespace AngularPractice.Models
{
    public class Todo
    {
        [Key]
        public Guid? Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public bool? Active { get; set; }
    }
}
