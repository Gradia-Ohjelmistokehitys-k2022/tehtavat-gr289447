using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitcoin.model
{
    // Tämä luokka analysoi trendit Bitcoinin hintatiedoista
    public class TrendAnalyzer
    {
        // Etsii pisimmät lasku- ja nousutrendit annetulta aikaväliltä
        public (TrendResult longestDowntrend, TrendResult longestUptrend) FindLongestTrends(List<BitcoinData> bitcoinData, DateTime startDate, DateTime endDate)
        {
            // Jos data on tyhjä tai siinä on vähemmän kuin kaksi tietuetta, ei voida analysoida trendejä
            if (bitcoinData == null || bitcoinData.Count < 2)
            {
                return (null, null);
            }

            // Suodatetaan data halutulle aikavälille
            var filteredData = bitcoinData.Where(d => d.Date >= startDate && d.Date <= endDate).ToList();
            if (filteredData.Count < 2)
            {
                return (null, null);
            }

            // Muuttujat, jotka seuraavat nykyistä trendiä
            int currentDowntrendLength = 0;
            int currentUptrendLength = 0;

            // Muuttujat, jotka pitävät kirjaa pisimmistä trendeistä
            TrendResult longestDowntrend = null;
            TrendResult longestUptrend = null;

            // Muuttujat, jotka pitävät kirjaa trendin aloituspäivistä
            DateTime? downtrendStart = null;
            DateTime? uptrendStart = null;

            // Käydään data läpi ja etsitään trendit
            for (int i = 1; i < filteredData.Count; i++)
            {
                // Jos hinta on laskenut edellisestä päivästä, on kyseessä laskutrendi
                if (filteredData[i].Price < filteredData[i - 1].Price)
                {
                    // Jos trendi on juuri alkanut, asetetaan aloituspäivämäärä
                    if (currentDowntrendLength == 0)
                    {
                        downtrendStart = filteredData[i - 1].Date;
                    }

                    currentDowntrendLength++;

                    // Päivitetään pisin laskutrendi, jos nykyinen on pidempi
                    if (longestDowntrend == null || currentDowntrendLength > longestDowntrend.Length)
                    {
                        longestDowntrend = new TrendResult
                        {
                            Length = currentDowntrendLength,
                            StartDate = downtrendStart.Value,
                            EndDate = filteredData[i].Date,
                            Type = "Laskutrendi"
                        };
                    }

                    // Nollataan nousutrendi
                    currentUptrendLength = 0;
                    uptrendStart = null;
                }
                // Jos hinta on noussut edellisestä päivästä, on kyseessä nousutrendi
                else if (filteredData[i].Price > filteredData[i - 1].Price)
                {
                    // Jos trendi on juuri alkanut, asetetaan aloituspäivämäärä
                    if (currentUptrendLength == 0)
                    {
                        uptrendStart = filteredData[i - 1].Date;
                    }

                    currentUptrendLength++;

                    // Päivitetään pisin nousutrendi, jos nykyinen on pidempi
                    if (longestUptrend == null || currentUptrendLength > longestUptrend.Length)
                    {
                        longestUptrend = new TrendResult
                        {
                            Length = currentUptrendLength,
                            StartDate = uptrendStart.Value,
                            EndDate = filteredData[i].Date,
                            Type = "Nousutrendi"
                        };
                    }

                    // Nollataan laskutrendi
                    currentDowntrendLength = 0;
                    downtrendStart = null;
                }
                // Jos hinta on pysynyt samana, nollataan molemmat trendit
                else
                {
                    currentDowntrendLength = 0;
                    currentUptrendLength = 0;
                    downtrendStart = null;
                    uptrendStart = null;
                }
            }

            // Lasketaan trendien pituudet päivinä ja lisätään ne trenditulokseen
            if (longestDowntrend != null)
            {
                longestDowntrend.Length = (longestDowntrend.EndDate - longestDowntrend.StartDate).Days + 1;
            }

            if (longestUptrend != null)
            {
                longestUptrend.Length = (longestUptrend.EndDate - longestUptrend.StartDate).Days + 1;
            }

            return (longestDowntrend, longestUptrend);  // Palautetaan pisimmät trendit
        }
    }

    // Tämä luokka tallentaa yksittäisen trendin tulokset
    public class TrendResult
    {
        public int Length { get; set; }     // Trendin pituus päivinä
        public DateTime StartDate { get; set; }  // Trendin aloituspäivämäärä
        public DateTime EndDate { get; set; }    // Trendin lopetuspäivämäärä
        public string Type { get; set; }        // Trendin tyyppi (Laskutrendi / Nousutrendi)

        // Ylikirjoitetaan ToString-metodi, joka tulostaa trendin tiedot
        public override string ToString()
        {
            return $"{Type} {Length} päivän ajan välillä {StartDate:yyyy-MM-dd} ja {EndDate:yyyy-MM-dd}";
        }
    }
}
