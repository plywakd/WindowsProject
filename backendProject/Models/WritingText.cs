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
        public string text { set; get; }
        public string source { set; get; }
        public int wordCount { set; get; }
        public double topSpeed { set; get; }
        public double averageSpeed { set; get; }

        public WritingText() { }
        public WritingText(string t, string s)
        {
            text = t;
            source = s;
            wordCount = countWords();
            topSpeed = 0;
            averageSpeed = 0;
        }

        public int countWords()
        {
            return text.Count(c => c == ' ') + 1;
        }

    }
}