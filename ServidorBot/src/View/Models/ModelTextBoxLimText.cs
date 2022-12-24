using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ServidorBot.src.View.Models
{
    public class ModelTextBoxLimText
    {
        public string Name { get; set; }
        public int Length { get; set; }
        public string Text { get; set; }
        public Visibility VisibleCount { get; set; }
        public bool Return { get; set; }
        public int MaxHeight { get; set; } = 50;
    }
}
