using Bitcoin.model;
using Bitcoin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitcoin.controller
{
    public class BitcoinController
    {
        private readonly CoinGeckoService _service;

        // Alustaa conrtollerin CoinGeckoService:llä
        public BitcoinController(CoinGeckoService service)
        {
            _service = service;
        }

        // Metodi Bitcoin-datan analysoimiseksi ja näkymän päivittämiseksi
        public async Task AnalyzeDataAsync(DateTime startDate, DateTime endDate, MainForm view)
        {
            // Hakee Bitcoin-datan palvelusta valitulta aikaväliltä
            var data = await _service.GetBitcoinDataAsync(startDate, endDate);

            // Analysoi hinnan ja volyymin erikseen
            var priceAnalysisResult = AnalyzePriceData(data);
            var volumeAnalysisResult = AnalyzeVolumeData(data);

            // Päivittää näkymän analysoiduilla tuloksilla
            view.UpdatePriceAnalysis(priceAnalysisResult);
            view.UpdateVolumeAnalysis(volumeAnalysisResult);

            // Luodaan TrendAnalyzer ja etsitään pisimmät lasku- ja nousutrendit
            var trendAnalyzer = new TrendAnalyzer();
            var (longestDowntrend, longestUptrend) = trendAnalyzer.FindLongestTrends(data, startDate, endDate);

            // Valmistellaan trenditiedot näytettäväksi
            var trendDetails = new StringBuilder();
            if (longestDowntrend != null && longestDowntrend.Length > 0)
            {
                trendDetails.AppendLine(longestDowntrend.ToString());
            }
            else
            {
                trendDetails.AppendLine("Ei laskutrendejä valitulta aikaväliltä.");
            }
            if (longestUptrend != null)
            {
                trendDetails.AppendLine(longestUptrend.ToString());
            }
            else
            {
                trendDetails.AppendLine("Ei nousutrendejä valitulta aikaväliltä.");
            }

            // Päivitetään näkymä trenditiedoilla
            view.UpdateTrendDetails(trendDetails.ToString());

            // Päivitetään kaaviot analysoiduilla tiedoilla (hinta, volyymi, trendit)
            view.UpdateCharts(data, longestDowntrend, longestUptrend, priceAnalysisResult);
        }

        // Analysoi hinnan dataa: löytää alhaisimman ja korkeimman hinnan sekä niiden päivämäärät
        private PriceAnalysisResult AnalyzePriceData(List<BitcoinData> data)
        {
            var minPrice = data.MinBy(d => d.Price);
            var maxPrice = data.MaxBy(d => d.Price);

            return new PriceAnalysisResult
            {
                MinPrice = minPrice.Price,
                MinPriceDate = minPrice.Date,
                MaxPrice = maxPrice.Price,
                MaxPriceDate = maxPrice.Date
            };
        }

        // Analysoi volyymin dataa: löytää alhaisimman ja korkeimman volyymin sekä niiden päivämäärät
        private VolumeAnalysisResult AnalyzeVolumeData(List<BitcoinData> data)
        {
            var minVolume = data.MinBy(d => d.Volume);
            var maxVolume = data.MaxBy(d => d.Volume);

            return new VolumeAnalysisResult
            {
                MinVolume = minVolume.Volume,
                MinVolumeDate = minVolume.Date,
                MaxVolume = maxVolume.Volume,
                MaxVolumeDate = maxVolume.Date
            };
        }
    }
}
