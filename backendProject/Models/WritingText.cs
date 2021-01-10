using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backendProject.Models
{
    public class WritingText
    {
        public int WritingTextID { get; set; }
        public String text { set; get; }
        public String source { set; get; }
        public double topSpeed { set; get; }
        public double averageSpeed { set; get; }

        public void updateTopSpeed()
        {
            // to implement
        }

        public void updateAverageSpeed()
        {
            // to implement
        }
    }
}