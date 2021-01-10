using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace backendProject.Models
{
    public class WritingText
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public String text { set; get; }
        public String source { set; get; }
        public double topSpeed { set; get; }
        public double averageSpeed { set; get; }

        public void updateTopSpeed(double newTopSpeed)
        {
            topSpeed = newTopSpeed;
        }

        public void updateAverageSpeed(double newAverageSpeed)
        {
            averageSpeed = newAverageSpeed;
        }
    }
}