//Sensor datapoints average
namespace SensorAvg
{
    class DataPoint
    {
        public string Id { get; set; }
        public decimal Temperature { get; set; }
        public long TimeStamp { get; set; }

    }

    class Solution
    {
        public int solution(string[] datapoints, string[] sensors)
        {
            var result = 0;
            var resultList = new List<decimal>();
            var dataPointList = datapoints.Distinct()
                .Select(dp => new DataPoint
                {
                    Id = dp.Split("_")[0],
                    Temperature = int.Parse(dp.Split("_")[1]),
                    TimeStamp = long.Parse(dp.Split("_")[2])
                });

            foreach (string s in sensors)
            {
                var avg = dataPointList
                    .Where(dp => dp.Id == s)
                    .Average(dp => dp.Temperature);
                resultList.Add(avg);
            }
            result = Decimal.ToInt32(Math.Round(resultList.Average()));
            return result;

        }


    }

}
