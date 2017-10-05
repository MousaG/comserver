using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accomtest.model
{
    public class TVNF10Model
    {
        public int cocode { get; set; } //کد شرکت توزیع
        public int formcode { get; set; } //یکی از کدهای پنج گانه فرم
        public decimal refcode { get; set; } //کد پیگیری 
        public List<TVNF10Record> data { get; set; } //محتویات داده ها
        public List<int> r110metadata { get; set; } //ساختار ارسال اطلاعات برای رکورد 110
        public List<int> r120metadata { get; set; } //ساختار ارسال اطلاعات برای رکورد 120
        public List<int> r125metadata { get; set; }//ساختار ارسال اطلاعات برای رکوورد 125

    }
    public class F10Record : TVNRECORD
    {


        public R110Model r110 { get; set; }
        public R120Model r120 { get; set; }
        public List<R125Model> r125 { get; set; }
        public List<R125Model> r125r { get; set; }
    }
    public  class TVNF10Record
    {
        public string id { get; set; }
        
        public List<object> r110 { get; set; }
        public List<object> r120 { get; set; }
        public List<List<object>> r125 { get; set; }
        public List<List<object>> r125r { get; set; }
    }

    public class R110Model 
    {
        public decimal r10TOTAL_BILL_DEBT { get; set; }
        public decimal r20TOTAL_REGISTER_DEBT { get; set; }
        public decimal r30OTHER_ACCOUNT_BALANCE { get; set; }
        public int r101CUSTOMER_TYPE { get; set; }
        public String r102FIRST_NAME { get; set; }
        public String r103SURNAME { get; set; }
        public String r104FATHER_NAME { get; set; }
        public int? r105BIRTH_CERTIFICATE_ID { get; set; }
        public String r106NATIONAL_CARD_ID { get; set; }
        public DateTime r107BIRTH_DATE { get; set; }
        public String r108ISSUE_PLACE { get; set; }
        public string r109COMPANY_NAME { get; set; }
        public DateTime? r110COMPANY_REGISTRATION_DATE { get; set; }
        public String r111COMPANY_REGISTRATION_ID { get; set; }
        public decimal? r112COMPANY_ISIC_FK { get; set; }
        public int r113COMPANY_CODE_FK { get; set; }
        public int? r114SEX_TYPE { get; set; }
        public string r115PHONE_NUMBEr { get; set; }
        public string r116MOBILE_NUMBEr { get; set; }
        public string r117FAX_NUMBEr { get; set; }
        public string r118EMAIL_ADDRESS { get; set; }
        public string r119ADDRESS { get; set; }
        public string r120POSTAL_CODE { get; set; }
        public decimal? r121BUSINESS_CODE_FK { get; set; }
    }

    public class TVNF30Model
    {
     
         public int cocode { get; set; }
        public int formcode { get; set; }
        public decimal refcode { get; set; }
        public List<TVNF30Record> data { get; set; }
        public List<int> r130metadata { get; set; }
        public List<int> r140metadata { get; set; }
        public List<int> rcalcmetadata { get; set; }

    }
    public class TVNF30Record:TVNRECORD
    {
        public long srcode { get; set; }
        public string billid { get; set; }
        public List<object> r130 { get; set; }
        public List<object> r140 { get; set; }
        public List<object> rcalc { get; set; }

    }
    public class F30Record
    {

        public string id { get; set; }
        public string refcode { get; set; }
        public long srcode { get; set; }
        public string billid { get; set; }
        public R130Model r130 { get; set; }
        public R140Model r140 { get; set; }
        public CALCDATAMODEL rcalc { get; set; }

    }
    public class TVNRECORD
    {
        public string id { get; set; }
        public string refcode { get; set; }

    }
}
