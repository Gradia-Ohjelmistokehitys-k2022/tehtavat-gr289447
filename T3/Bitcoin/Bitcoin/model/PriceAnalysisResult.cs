using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitcoin.model
{
    // Tämä luokka tallentaa hinnan analyysin tulokset, kuten minimi- ja maksimihinnan sekä niiden päivämäärät
    public class PriceAnalysisResult
    {
        public decimal MinPrice { get; set; }
        public DateTime MinPriceDate { get; set; }
        public decimal MaxPrice { get; set; }
        public DateTime MaxPriceDate { get; set; }
    }
}
