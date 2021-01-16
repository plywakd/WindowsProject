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
            topSpeed = 0.0d;
            averageSpeed = 0.0d;
        }

        public int countWords()
        {
            return text.Count(c => c == ' ') + 1;
        }

    }

    public class WritingTextJSON
    {
        public string text { get; set; }
        public string source { get; set; }

        public WritingText getWritingText()
        {
            return new WritingText(text, source);
        }
    }
}