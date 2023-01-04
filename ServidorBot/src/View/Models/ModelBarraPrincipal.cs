using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ServidorBot.src.View.Models
{
    public class ModelBarraPrincipal
    {
        public string Title { get; set; } = "New windows";
        public Window ViewWindow { get; set; }
        public Visibility Maximize { get; set; } = Visibility.Visible;
        public Visibility Minimize { get; set; } = Visibility.Visible;
    }
}
