using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accomtest.model
{
    public class R125Model 
    {
        public string r280SERIAL_NUMBER { get; set; }
        public int r281METER_TYPE { get; set; }
        public int r282DIGIT_NUMBER { get; set; }
        public double r283ADJUSTMENT_FACTOR { get; set; }
        public int r284METER_MODEL_FK { get; set; }
        public int r285METER_MAKER_TYPE_FK { get; set; }
        public DateTime r286INSTALLATION_DATE { get; set; }
        public int r287READING_CLOCK_CODE { get; set; }
        public double r288MAXIMETER_FACTOR { get; set; }
        public int r289METER_STATUS { get; set; }
        public DateTime r290CREATION_DATE { get; set; }
        public DateTime? r291EXPIRATION_DATE { get; set; }
    }
}
