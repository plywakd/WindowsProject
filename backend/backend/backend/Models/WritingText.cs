using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend.Models
{
    public class WritingText
    {
        private int writinTextId { get; set; }
        private String text { set; get; }
        private String source { set; get; }
        private double topSpeed { set; get; }
        private double averageSpeed { set; get; }

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