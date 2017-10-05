using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accomtest.model
{
    public class R120Model 
    {
        public string r200BILL_IDENTIFIER { get; set; }
        public decimal r201FILE_SERIAL_NUMBER { get; set; }
        public decimal r202SUBSCRIPTION_ID { get; set; }
        public decimal r204CITY_CODE_FK { get; set; }
        public decimal r205AREA_CODE { get; set; }
        public decimal r206ZONE_CODE { get; set; }
        public string r207IDENTIFYING_NUMBER { get; set; }
        public decimal r208READING_COLLECTION_DAY { get; set; }
        public decimal r209READING_AGENT_CODE { get; set; }
        public decimal r210READING_SEQUENCE { get; set; }
        public decimal r211SERVICE_TYPE { get; set; }
        public decimal r212NO_OF_PHASE { get; set; }
        public decimal r213AMPER { get; set; }
        public decimal r214AGREEMENT_DEMAND { get; set; }
        public decimal r215VOLTAGE_TYPE { get; set; }
        public string r216TARIFF_TYPE { get; set; }
        public decimal r217TARIFF_OPTION_CODE { get; set; }
        public decimal r219PREMISE_LOCATION { get; set; }
        public string r220SERVICE_POINT_ADDRESS { get; set; }
        public string r221SERVICE_POINT_POSTCODE { get; set; }
        public string r222PHONE_NUMBER { get; set; }
        public DateTime? r223INSTALLATION_DATE { get; set; }
        public DateTime? r224CREATION_DATE { get; set; }
        public DateTime? r225AGREEMENT_DATE { get; set; }
        public string r226AGREEMENT_NUMBER { get; set; }
        public int r227SERVICE_POINT_STATUS { get; set; }
        public double r228LICENSE_ALLOWED_POWER { get; set; }
        public DateTime? r229LICENSE_EXPIRE_DATE { get; set; }
        public string r230LICENSE_NUMBER { get; set; }
        public string r231LICENSE_ISSUER { get; set; }
        public int r232ELECTRICITY_SUPPLY_FK { get; set; }
        public int r233POPULATION_NUMBER { get; set; }
        public DateTime? r234POPULATION_EXPIRE_DATE { get; set; }
        public int r235DISCOUNT_CONSUMPTION_FK { get; set; }
        public int r236DISCOUNT_REGISTRATION_FK { get; set; }
        
        public string r237REGISTRATION_DISCOUNT_REF { get; set; }
        public decimal r238TARIFF_FK { get; set; }
        public DateTime? r239SERVICE_INACTIVE_DATE { get; set; }
        public DateTime? r240SERVICE_DELETE_DATE { get; set; }
        public DateTime? r241TEMPORARY_REDUCE_EXPIRE_DATE { get; set; }
        public decimal r242LAST_POWER_REDUCTION { get; set; }
        public DateTime? r243TEMPORARY_REDUCE_START_DATE { get; set; }
        public int r244TEMPORARY_POWER_REDUCT_COUNT { get; set; }
        public int r245TRACKING_CODE { get; set; }
        public int r246TRANSFORMATOR_COUNT { get; set; }
        public string r247POST_NUMBER { get; set; }
        public string r248FEEDER_NUMBER { get; set; }
        public string r249BASE_NUMBER { get; set; }
        public int r250TRANSFORMATOR_POWER { get; set; }
        public int r251TRANSFORMATOR_NUMBER { get; set; }
        public DateTime? r252LAST_TEST_DATE { get; set; }
        public int r254GAS_ENERGY_STATUS { get; set; }
        public int r255REPEAT_CODE { get; set; }
        public double r256X_DEGREE { get; set; }
        public double r257Y_DEGREE { get; set; }
        public int r258Y_MOSQUE_AREA { get; set; }

    }
    public class TvnTarrifData
    {
        public int TrfHcode { get; set; }
        public int TarrifCode { get; set; }
        public int DiscountCode { get; set; }
        public decimal pwrCnt { get; set; }
        public decimal SelCode { get; set; }
        public bool IsCng { get; set; }
    }
}
