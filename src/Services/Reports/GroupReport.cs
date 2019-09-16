using System.Text;
using System.Reflection;

namespace Services.Reports
{
    public class GroupReport : IReport
    {
        public int MatchNumber { get; set; }

        public int NumPlayers { get; set; }

        public double MinSkillIndex { get; set; }

        public double MaxSkillIndex { get; set; }

        public double AvgSkillIndex { get; set; }

        public double MinRemoteIndex { get; set; }

        public double MaxRemoteIndex { get; set; }
    
        public double AvgRemoteIndex { get; set; }

        public double MinWaitingTime { get; set; }

        public double MaxWaitingTime { get; set; }

        public double AvgWaitingTime { get; set; }

        private PropertyInfo[] _PropertyInfos = null;

        /// <summary>
        /// Convert Group Report to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            if (_PropertyInfos == null)
            {
                _PropertyInfos = this.GetType().GetProperties();
            }
            
            foreach (var info in _PropertyInfos)
            {
                var value = info.GetValue(this, null) ?? "(null)";
                sb.AppendLine(info.Name + ": " + value.ToString());
            }

            return sb.ToString();
        }
    }
}
