using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accomtest.model
{
  public  class F50Record:TVNRECORD
    {
        public R150Model r150 { get; set; }

    }
    public class R150Model
    {
        
        public string r501BILL_IDENTIFIER { get; set; }
        public string r502PAYMENT_ID { get; set; }
        public decimal r503PAYMENT_AMOUNT { get; set; }
        public DateTime r504PAYMENT_DATE { get; set; }
        public string r505FILE_NAME { get; set; }
        public DateTime r506FILE_DATE { get; set; }
        public DateTime r507PROCESS_DATE { get; set; }
        public decimal r508PAYMENT_METHOD_FK { get; set; }
        public DateTime r509CREATION_DATE { get; set; }
        public decimal r510BANK_CODE_FK { get; set; }
        public decimal r511BRANCH_CODE { get; set; }
        public decimal r513TRACKING_NUMBER { get; set; }
        public decimal r512CHANNEL_TYPE_FK { get; set; }
        public decimal r514STATUS { get; set; }
        public decimal r515BILL_SERIAL { get; set; }
        public DateTime? r516CANCEL_DATE { get; set; }
        public decimal r517CANCEL_REASON { get; set; }
        public decimal r518PAYMENT_TYPE { get; set; }
        public decimal r519CITY_CODE_FK { get; set; }
        public decimal r520AREA_CODE { get; set; }
        public decimal r521ZONE_CODE { get; set; }
    }
    public class TVNF50Record
    {
        public string id { get; set; }
        public long srcode { get; set; }
        public List<object> r150 { get; set; }
    }
    public class TVNF50Model
    {

        public int cocode { get; set; }
        public int formcode { get; set; }
        public decimal refcode { get; set; }
        public List<TVNF50Record> data { get; set; }
        public List<int> r150metadata { get; set; }
    }
}
