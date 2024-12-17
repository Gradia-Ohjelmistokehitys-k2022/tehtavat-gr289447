using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Bitcoin.model;

namespace Bitcoin.model
{
    public class CoinGeckoService
    {
        // Perus URL, joka käytetään CoinGecko API:n kutsuihin
        private const string BaseUrl = "https://api.coingecko.com/api/v3/";

        // Metodi, joka hakee Bitcoinin markkinadataa tietyltä aikaväliltä
        public async Task<List<BitcoinData>> GetBitcoinDataAsync(DateTime startDate, DateTime endDate)
        {
            // Rakennetaan API:n URL, joka hakee Bitcoinin hinnan ja volyymin tietyltä aikaväliltä
            string url = $"{BaseUrl}coins/bitcoin/market_chart/range?vs_currency=eur&from={ToUnixTime(startDate)}&to={ToUnixTime(endDate)}";

            // Luodaan HttpClient, joka tekee pyynnön API:lle
            using HttpClient client = new HttpClient();

            // Odotetaan API:sta saatu vastaus
            var response = await client.GetStringAsync(url);

            // Deserialisoidaan API:n vastaus JSON-muodosta dynaamiseksi objektiksi
            dynamic data = JsonConvert.DeserializeObject(response);

            // Luodaan lista, johon tallennetaan Bitcoin-data
            var result = new List<BitcoinData>();

            // Alustetaan muuttujat seuraavia hintoja ja volyymeja varten
            DateTime? lastDate = null;  // Aiempi päivä
            decimal? dailyOpenPrice = null;  // Päivän avauskurssi
            decimal? dailyVolume = null;  // Päivän volyymi

            // Käydään läpi API:n hinnat ja käsitellään ne
            foreach (var entry in data.prices)
            {
                // Hinnan aikaleima ja itse hinta
                var priceTimestamp = (long)entry[0];
                var price = (decimal)entry[1];

                // Haetaan volyymi data.total_volumes taulukosta
                var volume = (decimal)data.total_volumes[result.Count][1];

                // Muunnetaan aikaleima päivämääräksi
                DateTime currentDate = UnixTimeStampToDateTime(priceTimestamp).Date;

                // Jos aiempi päivä on olemassa ja nykyinen päivä eroaa siitä, tallennetaan edellinen päivä
                if (lastDate != null && currentDate != lastDate)
                {
                    // Lisätään uusi BitcoinData-objekti listaan
                    result.Add(new BitcoinData
                    {
                        Date = lastDate.Value.AddDays(1),  // Asetetaan päivämääräksi edellinen päivä + 1
                        Price = dailyOpenPrice ?? 0,  // Jos hinnat eivät ole määritettyjä, käytetään nollaa
                        Volume = dailyVolume ?? 0  // Jos volyymit eivät ole määritettyjä, käytetään nollaa
                    });
                }

                // Päivitetään muuttujat seuraavaa silmukkaa varten
                lastDate = currentDate;
                dailyOpenPrice = price;
                dailyVolume = volume;
            }

            // Lisätään viimeinen päivä, jos se ei ole vielä lisätty
            if (lastDate != null)
            {
                result.Add(new BitcoinData
                {
                    Date = lastDate.Value,  // Asetetaan päivämääräksi viimeinen päivä
                    Price = dailyOpenPrice ?? 0,  // Jos hinta on null, käytetään nollaa
                    Volume = dailyVolume ?? 0  // Jos volyymi on null, käytetään nollaa
                });
            }

            // Palautetaan kerätty data
            return result;
        }

        // Muuntaa DateTime-objektin Unix-aikaleimaksi (sekunteina)
        private long ToUnixTime(DateTime date) => ((DateTimeOffset)date).ToUnixTimeSeconds();

        // Muuntaa Unix-aikaleiman DateTime-objektiksi
        private DateTime UnixTimeStampToDateTime(long unixTimeStamp) => DateTimeOffset.FromUnixTimeMilliseconds(unixTimeStamp).DateTime;
    }
}
