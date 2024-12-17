using Bitcoin.controller;
using Bitcoin.model;
using System.Windows.Forms.DataVisualization.Charting;

namespace Bitcoin
{
    // P‰‰ikkuna Bitcoin-analyysi‰ varten
    public partial class MainForm : Form
    {
        private readonly BitcoinController _controller;

        private Chart chartPrice;
        private Chart chartVolume;

        // MainForm:n konstruktori
        public MainForm()
        {
            InitializeComponent(); // Alustaa lomakkeen komponentit
            _controller = new BitcoinController(new CoinGeckoService()); // Luodaan BitcoinController, joka k‰ytt‰‰ CoinGeckoServicea
        }

        // P‰ivitt‰‰ kaaviot uusilla tiedoilla
        public void UpdateCharts(List<BitcoinData> data, TrendResult longestDowntrend, TrendResult longestUptrend, PriceAnalysisResult priceAnalysis)
        {
            // Tyhjennet‰‰n vanhat kaaviot
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            // Asetetaan kaavion alueet ja akselit
            var chartArea = new ChartArea("MainArea");
            chartArea.AxisX.Title = "P‰iv‰m‰‰r‰"; // X-akselin nimi
            chartArea.AxisY.Title = "Hinta (Ä)"; // Y-akselin nimi (hinta)
            chartArea.AxisY2.Title = "Volyymi"; // Toinen Y-akseli (volyymi)
            chartArea.AxisY2.Enabled = AxisEnabled.True;
            chart1.ChartAreas.Add(chartArea);

            // Volyymisarjan lis‰‰minen
            var volumeSeries = new Series("Volyymi");
            volumeSeries.ChartType = SeriesChartType.Column;
            volumeSeries.XValueType = ChartValueType.DateTime;
            volumeSeries.YValueType = ChartValueType.Double;
            volumeSeries.Color = Color.Orange;
            volumeSeries.YAxisType = AxisType.Secondary;

            foreach (var point in data)
            {
                volumeSeries.Points.AddXY(point.Date, point.Volume);
            }
            chart1.Series.Add(volumeSeries); // Lis‰‰ volyymisarja kaavioon

            // Hintasarjan lis‰‰minen
            var priceSeries = new Series("Hinnat");
            priceSeries.ChartType = SeriesChartType.Line;
            priceSeries.XValueType = ChartValueType.DateTime;
            priceSeries.YValueType = ChartValueType.Double;
            priceSeries.Color = Color.Blue;

            foreach (var point in data)
            {
                priceSeries.Points.AddXY(point.Date, point.Price);
            }
            chart1.Series.Add(priceSeries); // Lis‰‰ hintasarja kaavioon

            // Laskutrendin lis‰‰minen, jos lˆytyy
            if (longestDowntrend != null)
            {
                var downtrendSeries = new Series("Laskutrendi");
                downtrendSeries.ChartType = SeriesChartType.Line;
                downtrendSeries.Color = Color.Red;
                downtrendSeries.BorderWidth = 2;

                foreach (var point in data.Where(d => d.Date >= longestDowntrend.StartDate && d.Date <= longestDowntrend.EndDate))
                {
                    downtrendSeries.Points.AddXY(point.Date, point.Price);
                }
                chart1.Series.Add(downtrendSeries); // Lis‰‰ laskutrendi kaavioon
            }

            // Nousutrendin lis‰‰minen, jos lˆytyy
            if (longestUptrend != null)
            {
                var uptrendSeries = new Series("Nousutrendi");
                uptrendSeries.ChartType = SeriesChartType.Line;
                uptrendSeries.Color = Color.Green;
                uptrendSeries.BorderWidth = 2;

                foreach (var point in data.Where(d => d.Date >= longestUptrend.StartDate && d.Date <= longestUptrend.EndDate))
                {
                    uptrendSeries.Points.AddXY(point.Date, point.Price);
                }
                chart1.Series.Add(uptrendSeries); // Lis‰‰ nousutrendi kaavioon
            }

            // Ostop‰iv‰n merkint‰
            var buySeries = new Series("Ostop‰iv‰");
            buySeries.ChartType = SeriesChartType.Point;
            buySeries.Color = Color.Green;
            buySeries.MarkerSize = 10;
            buySeries.MarkerStyle = MarkerStyle.Circle;

            buySeries.Points.AddXY(priceAnalysis.MinPriceDate, priceAnalysis.MinPrice);

            // Myyntip‰iv‰n merkint‰
            var sellSeries = new Series("Myyntip‰iv‰");
            sellSeries.ChartType = SeriesChartType.Point;
            sellSeries.Color = Color.Red;
            sellSeries.MarkerSize = 10;
            sellSeries.MarkerStyle = MarkerStyle.Circle;

            sellSeries.Points.AddXY(priceAnalysis.MaxPriceDate, priceAnalysis.MaxPrice);

            chart1.Series.Add(buySeries);
            chart1.Series.Add(sellSeries);

            chart1.Invalidate(); // P‰ivitt‰‰ kaavion
        }

        // Analyysin k‰ynnistys
        private async void BtnAnalyze_Click(object sender, EventArgs e)
        {
            DateTime startDate = datePickerStart.Value; // K‰ytt‰j‰n valitsema aloitusp‰iv‰m‰‰r‰
            DateTime endDate = datePickerEnd.Value; // K‰ytt‰j‰n valitsema lopetusp‰iv‰m‰‰r‰
            DateTime currentDate = DateTime.Now; // Nykyhetki

            // Tarkistetaan, ett‰ aikav‰li on v‰hint‰‰n kaksi p‰iv‰‰
            if ((endDate - startDate).Days < 1)
            {
                MessageBox.Show("Aikav‰lin t‰ytyy olla v‰hint‰‰n kaksi p‰iv‰‰.");
                return; // Lopetetaan analyysi, jos aikav‰li on liian lyhyt
            }

            // Tarkistetaan, ett‰ p‰iv‰m‰‰r‰t eiv‰t ole tulevaisuudessa
            if (startDate > currentDate || endDate > currentDate)
            {
                MessageBox.Show("Valitut p‰iv‰m‰‰r‰t eiv‰t voi olla tulevaisuudessa. Valitse aikav‰li menneen ja nykyhetken sis‰ll‰.");
                return; // Lopetetaan analyysi, jos p‰iv‰m‰‰r‰t ovat tulevaisuudessa
            }

            // K‰ynnist‰‰ analyysin, ja odottaa sen valmistumista
            await _controller.AnalyzeDataAsync(startDate, endDate, this);
        }

        // P‰ivitt‰‰ hintatiedot TextBoxeihin
        public void UpdatePriceAnalysis(PriceAnalysisResult result)
        {
            tbMinPrice.Text = $"{result.MinPrice:F2}Ä"; // N‰ytt‰‰ minimi hinnan
            tbMinPriceDate.Text = result.MinPriceDate.ToShortDateString(); // N‰ytt‰‰ minimi hinnan p‰iv‰m‰‰r‰n
            tbMaxPrice.Text = $"{result.MaxPrice:F2}Ä"; // N‰ytt‰‰ maksimi hinnan
            tbMaxPriceDate.Text = result.MaxPriceDate.ToShortDateString(); // N‰ytt‰‰ maksimi hinnan p‰iv‰m‰‰r‰n
        }

        // P‰ivitt‰‰ volyymitiedot TextBoxeihin
        public void UpdateVolumeAnalysis(VolumeAnalysisResult result)
        {
            tbVolumeMin.Text = $"{result.MinVolume:F2}Ä"; // N‰ytt‰‰ minimi volyymin
            tbVolumeMinDate.Text = result.MinVolumeDate.ToShortDateString(); // N‰ytt‰‰ minimi volyymin p‰iv‰m‰‰r‰n
            tbVolumeMax.Text = $"{result.MaxVolume:F2}Ä"; // N‰ytt‰‰ maksimi volyymin
            tbVolumeMaxDate.Text = result.MaxVolumeDate.ToShortDateString(); // N‰ytt‰‰ maksimi volyymin p‰iv‰m‰‰r‰n
        }

        // P‰ivitt‰‰ trenditiedot
        public void UpdateTrendDetails(string trendDetails)
        {
            tbTrend.Text = trendDetails; // N‰ytt‰‰ trenditiedot
        }

        // Sovelluksen sulkeminen
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
