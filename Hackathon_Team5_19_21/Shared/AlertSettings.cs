using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon_Team5_19_21.Shared
{
    public class AlertSettings
    {
        public bool IsVisible { get; set; }
        public Color TypeMessage { get; set; } = Color.Danger;
        public string Message { get; set; } = "";

        public void Chiudi() { IsVisible = false; }
    }
}
