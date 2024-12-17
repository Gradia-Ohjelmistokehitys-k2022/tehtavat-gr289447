using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitcoin.model
{
    // Tämä luokka tallentaa Bitcoinin kaupankäynnin volyymin analyysin tulokset
    public class VolumeAnalysisResult
    {
        public decimal MinVolume { get; set; }
        public DateTime MinVolumeDate { get; set; }
        public decimal MaxVolume { get; set; }
        public DateTime MaxVolumeDate { get; set; }
    }
}
