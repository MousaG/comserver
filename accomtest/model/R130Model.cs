using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accomtest.model
{
    //Masraf
    public class R130Model
    {
        internal int r351PREV_REACTIVE_LOWTIME;
        internal int r352PREV_REACTIVE_WEEKENDTIME;
        internal int r353REACTIVE_PEAKTIME_CONSUMPTION;
        internal int r354REACTIVE_LOWTIME_CONSUMPTION;
        internal int r355REACTIVE_WEEKEND_CONSUMPTION;
        internal decimal r356WARM2_PEAKTIME_CONSUMPTION;
        internal decimal r357WARM2_LOWTIME_CONSUMPTION;
        internal decimal r358WARM2_WEEKEND_CONSUMPTION;
        internal int r359CHRGD_REACTIVE_PEAK_CONS;
        internal int r360CHRGD_REACTIVE_LOW_CONS;
        internal int r361CHRGD_REACTIVE_WEEKEND_CONS;
        internal decimal r362CHRGD_WARM2_PEAKTIME_CONS;
        internal decimal r363CHRGD_WARM2_LOWTIME_CONS;
        internal decimal r364CHRGD_WARM2_WEEKEND_CONS;
        internal decimal r365WARM3_NORMALTIME_CONSUMPTION;
        internal decimal r366WARM3_PEAKTIME_CONSUMPTION;
        internal decimal r367WARM3_LOWTIME_CONSUMPTION;
        internal decimal r368WARM3_WEEKEND_CONSUMPTION;
        internal decimal r369WARM4_NORMALTIME_CONSUMPTION;
        internal decimal r370WARM4_PEAKTIME_CONSUMPTION;
        internal decimal r371WARM4_LOWTIME_CONSUMPTION;
        internal decimal r372WARM4_WEEKEND_CONSUMPTION;

        public DateTime r301READING_Date { get; set; }
        public decimal r302ACTIVE_NORMALTIME_READING { get; set; }
        public decimal r303ACTIVE_PEAKTIME_READING { get; set; }
        public decimal r304ACTIVE_LOWTIME_READING { get; set; }
        public decimal r305ACTIVE_WEEKENDTIME_READING { get; set; }
        public decimal r306REACTIVE_NORMALTIME_READING { get; set; }
        public decimal r307MAXIMETR_READING { get; set; }
        public decimal r308PREV_NORMALTIME_READING { get; set; }
        public decimal r309PREV_PEAKTIME_READING { get; set; }
        public decimal r310PREV_LOWTIME_READING { get; set; }
        public decimal r311PREV_WEEKENDTIME_READING { get; set; }
        public decimal r312PREV_REACTIVE_NORMALTIME { get; set; }
        public DateTime r313PREV_READING_Date { get; set; }
        public int r314AGENT_REPORT_CODE_FK { get; set; }
        public int r315PROCESS_STATUS { get; set; }
        public int r316SERVICE_COLLECTION_DAY { get; set; }
        public int r317SERVICE_READING_AGENT_CODE { get; set; }
        public decimal r318COLD_A1_USAGE { get; set; }
        public decimal r319COLD_A2_USAGE { get; set; }
        public decimal r320COLD_A3_USAGE { get; set; }
        public decimal r321COLD_A4_USAGE { get; set; }
        public decimal r322REACT_USAGE { get; set; }
        public decimal r323WARM1_NORMALTIME_CONSUMPTION { get; set; }
        public decimal r324WARM1_PEAKTIME_CONSUMPTION { get; set; }
        public decimal r325WARM1_LOWTIME_CONSUMPTION { get; set; }
        public decimal r326WARM1_WEEKEND_CONSUMPTION { get; set; }
        public decimal r327WARM2_NORMALTIME_CONSUMPTION { get; set; }
        public decimal r328CHARGED_COLD_NORMALTIME_CONS { get; set; }
        public decimal r329CHARGED_COLD_PEAKTIME_CONS { get; set; }
        public decimal r330CHARGED_COLD_LOWTIME_CONS { get; set; }
        public decimal r331CHARGED_COLD_WEEKEND_CONS { get; set; }
        public decimal r332CHRGD_REACTIVE_NORMAL_CONS { get; set; }
        public decimal r333CHRGD_WARM1_NORMALTIME_CONS { get; set; }
        public decimal r334CHRGD_WARM1_PEAKTIME_CONS { get; set; }
        public decimal r335CHRGD_WARM1_LOWTIME_CONS { get; set; }
        public decimal r336CHRGD_WARM1_WEEKEND_CONS { get; set; }
        public decimal r337CHRGD_WARM2_NORMAL_CONS { get; set; }
        public decimal r338MAXIMETR_KW { get; set; }
        public decimal r339MAXIMETR_CALC { get; set; }
        public int r340READING_DURATION { get; set; }
        public int r341COLD_DAYS { get; set; }
        public int r342WARM_DAYS { get; set; }
        public decimal r343WARM_TO_COLD_RATIO { get; set; }
        public decimal r344TOTAL_ACTIVE_USAGE { get; set; }
        public decimal r345TOTAL_CONSUMPTION_REACTIVE { get; set; }
        public decimal r346NOT_INDUSTRIAL_PERSENTAGE { get; set; }
        public decimal r347REACTIVE_PEAKTIME_READING { get; set; }
        public decimal r348REACTIVE_LOWTIME_READING { get; set; }
        public decimal r349REACTIVE_WEEKENDTIME_READING { get; set; }
        public decimal r350PREV_REACTIVE_PEAKTIME { get; set; }

    }
}
