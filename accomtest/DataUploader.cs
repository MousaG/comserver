using accomtest.model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accomtest
{
    public class DataUploader<T>
    {
        private decimal refCode;
        private int cocode;
        private ConcurrentQueue<List<T>> formque = new ConcurrentQueue<List<T>>();
        public DataUploader(int cocode,decimal refcode)
        {
            finished = false;
            this.cocode = cocode;
            this.refCode = refcode;
            System.Threading.Thread th = new System.Threading.Thread(ListenQue);
            th.Start();
        }
        public bool forceClose { get; set; }
        public bool finished { get; set; }
        public bool progressing
        {
            get
            {
                return !formque.IsEmpty;
            }
        }
        private void ListenQue()
        {

            while (1 == 1)
            {
                List<T> mrs;
                while (formque.TryDequeue(out mrs))
                {

                    if (forceClose)
                        return;

                    if (typeof(T) == typeof(F50Record))
                    {
                        UploadData50((List<F50Record>)Convert.ChangeType(mrs, typeof(List<F50Record>)));
                    }
                    else if (typeof(T) == typeof(F30Record))
                    {
                        UploadData30((List<F30Record>)Convert.ChangeType(mrs, typeof(List<F30Record>)));
                    }
                    else if (typeof(T) == typeof(F10Record))
                    {
                        UploadData10((List<F10Record>)Convert.ChangeType(mrs, typeof(List<F10Record>)));
                    }
                }
                if (finished && formque.IsEmpty)
                    return;
            }


        }
 
        public  void UploadData( List<T> mrs)
        {
            formque.Enqueue(mrs);
            
        }

        private  void UploadData50( List<F50Record> mrs)
        {
            try
            {


                var ex = new TVNF50Model();
                ex.formcode = 50;

                ex.refcode = refCode;
                ex.cocode = cocode;
                ex.data = new List<TVNF50Record>();
                ex.r150metadata = new List<int>();
                #region metadata rcal
                ex.r150metadata.Add(501);
                ex.r150metadata.Add(502);
                ex.r150metadata.Add(503);
                ex.r150metadata.Add(504);
                ex.r150metadata.Add(505);
                ex.r150metadata.Add(506);
                ex.r150metadata.Add(507);
                ex.r150metadata.Add(508);
                ex.r150metadata.Add(509);
                ex.r150metadata.Add(510);
                ex.r150metadata.Add(511);
                ex.r150metadata.Add(512);
                ex.r150metadata.Add(513);
                ex.r150metadata.Add(514);
                ex.r150metadata.Add(515);
                ex.r150metadata.Add(516);
                ex.r150metadata.Add(517);
                ex.r150metadata.Add(518);
                ex.r150metadata.Add(519);
                ex.r150metadata.Add(520);
                ex.r150metadata.Add(521);

                #endregion


                #region data
                //for (int i = 0; i < 10000; i++)
                {
                    foreach (var m in mrs)
                    {
                        var tvnr = new TVNF50Record() { id = m.id };

                        #region rcalc
                        tvnr.r150 = new List<object>();
                        tvnr.r150.Add(m.r150.r501BILL_IDENTIFIER);
                        tvnr.r150.Add(m.r150.r502PAYMENT_ID);
                        tvnr.r150.Add(m.r150.r503PAYMENT_AMOUNT);
                        tvnr.r150.Add(m.r150.r504PAYMENT_DATE);
                        tvnr.r150.Add(m.r150.r505FILE_NAME);
                        tvnr.r150.Add(m.r150.r506FILE_DATE);
                        tvnr.r150.Add(m.r150.r507PROCESS_DATE);
                        tvnr.r150.Add(m.r150.r508PAYMENT_METHOD_FK);
                        tvnr.r150.Add(m.r150.r509CREATION_DATE);
                        tvnr.r150.Add(m.r150.r510BANK_CODE_FK);
                        tvnr.r150.Add(m.r150.r511BRANCH_CODE);
                        tvnr.r150.Add(m.r150.r512CHANNEL_TYPE_FK);
                        tvnr.r150.Add(m.r150.r513TRACKING_NUMBER);
                        tvnr.r150.Add(m.r150.r514STATUS);
                        tvnr.r150.Add(m.r150.r515BILL_SERIAL);
                        tvnr.r150.Add(m.r150.r516CANCEL_DATE);
                        tvnr.r150.Add(m.r150.r517CANCEL_REASON);
                        tvnr.r150.Add(m.r150.r518PAYMENT_TYPE);
                        tvnr.r150.Add(m.r150.r519CITY_CODE_FK);
                        tvnr.r150.Add(m.r150.r520AREA_CODE);
                        tvnr.r150.Add(m.r150.r521ZONE_CODE);

                        #endregion

                        ex.data.Add(tvnr);
                    }


                }

                #endregion


                var response = WebConnection.getWebCleint("senddata", ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        private  void UploadData30(  List<F30Record> mrs)
        {
            try
            {


                var ex = new TVNF30Model();
                ex.formcode = 30;

                ex.refcode = refCode;
                ex.cocode = Convert.ToInt32(cocode);
                ex.data = new List<TVNF30Record>();
                ex.r130metadata = new List<int>();
                #region metadata rcal
                ex.r130metadata.Add(212);
                ex.r130metadata.Add(213);
                ex.r130metadata.Add(214);
                ex.r130metadata.Add(233);
                ex.r130metadata.Add(238);
                ex.r130metadata.Add(228);
                ex.r130metadata.Add(216);
                #endregion

                #region metadata 130

                ex.r130metadata.Add(301);
                ex.r130metadata.Add(302);
                ex.r130metadata.Add(303);
                ex.r130metadata.Add(304);
                ex.r130metadata.Add(305);
                ex.r130metadata.Add(306);
                ex.r130metadata.Add(307);
                ex.r130metadata.Add(308);
                ex.r130metadata.Add(309);
                ex.r130metadata.Add(310);
                ex.r130metadata.Add(311);
                ex.r130metadata.Add(312);
                ex.r130metadata.Add(313);
                ex.r130metadata.Add(314);
                ex.r130metadata.Add(315);
                ex.r130metadata.Add(316);
                ex.r130metadata.Add(317);
                ex.r130metadata.Add(318);
                ex.r130metadata.Add(319);
                ex.r130metadata.Add(320);
                ex.r130metadata.Add(321);
                ex.r130metadata.Add(322);
                ex.r130metadata.Add(323);
                ex.r130metadata.Add(324);
                ex.r130metadata.Add(325);
                ex.r130metadata.Add(326);
                ex.r130metadata.Add(327);
                ex.r130metadata.Add(328);
                ex.r130metadata.Add(329);
                ex.r130metadata.Add(330);
                ex.r130metadata.Add(331);
                ex.r130metadata.Add(332);
                ex.r130metadata.Add(333);
                ex.r130metadata.Add(334);
                ex.r130metadata.Add(335);
                ex.r130metadata.Add(336);
                ex.r130metadata.Add(337);
                ex.r130metadata.Add(338);
                ex.r130metadata.Add(339);
                ex.r130metadata.Add(340);
                ex.r130metadata.Add(341);
                ex.r130metadata.Add(342);
                ex.r130metadata.Add(343);
                ex.r130metadata.Add(344);
                ex.r130metadata.Add(345);
                ex.r130metadata.Add(346);
                ex.r130metadata.Add(347);
                ex.r130metadata.Add(348);
                ex.r130metadata.Add(349);
                ex.r130metadata.Add(350);
                ex.r130metadata.Add(351);
                ex.r130metadata.Add(352);
                ex.r130metadata.Add(353);
                ex.r130metadata.Add(354);
                ex.r130metadata.Add(355);

                ex.r130metadata.Add(356);

                ex.r130metadata.Add(357);
                ex.r130metadata.Add(358);
                ex.r130metadata.Add(359);
                ex.r130metadata.Add(360);
                ex.r130metadata.Add(361);
                ex.r130metadata.Add(362);
                ex.r130metadata.Add(363);
                ex.r130metadata.Add(364);
                ex.r130metadata.Add(365);
                ex.r130metadata.Add(366);
                ex.r130metadata.Add(367);
                ex.r130metadata.Add(368);
                ex.r130metadata.Add(369);
                ex.r130metadata.Add(370);
                ex.r130metadata.Add(371);
                ex.r130metadata.Add(372);

                #endregion

                #region metadata 140
                ex.r140metadata = new List<int>();
                ex.r140metadata.Add(406);
                ex.r140metadata.Add(407);
                ex.r140metadata.Add(408);
                ex.r140metadata.Add(409);
                ex.r140metadata.Add(410);
                ex.r140metadata.Add(411);
                ex.r140metadata.Add(412);
                ex.r140metadata.Add(413);
                ex.r140metadata.Add(414);
                ex.r140metadata.Add(415);
                ex.r140metadata.Add(416);
                ex.r140metadata.Add(417);
                ex.r140metadata.Add(418);
                ex.r140metadata.Add(419);
                ex.r140metadata.Add(420);
                ex.r140metadata.Add(421);
                ex.r140metadata.Add(422);
                ex.r140metadata.Add(423);
                ex.r140metadata.Add(424);
                ex.r140metadata.Add(425);
                ex.r140metadata.Add(426);
                ex.r140metadata.Add(427);
                ex.r140metadata.Add(428);
                ex.r140metadata.Add(429);
                ex.r140metadata.Add(430);
                ex.r140metadata.Add(431);
                ex.r140metadata.Add(432);
                ex.r140metadata.Add(433);
                ex.r140metadata.Add(434);
                ex.r140metadata.Add(435);
                ex.r140metadata.Add(436);
                ex.r140metadata.Add(437);
                ex.r140metadata.Add(438);
                ex.r140metadata.Add(439);
                ex.r140metadata.Add(440);
                ex.r140metadata.Add(441);
                ex.r140metadata.Add(442);
                ex.r140metadata.Add(443);
                ex.r140metadata.Add(444);
                ex.r140metadata.Add(445);
                ex.r140metadata.Add(446);
                ex.r140metadata.Add(447);
                ex.r140metadata.Add(448);
                ex.r140metadata.Add(449);
                ex.r140metadata.Add(450);
                ex.r140metadata.Add(451);
                ex.r140metadata.Add(401);
                ex.r140metadata.Add(402);
                ex.r140metadata.Add(403);
                ex.r140metadata.Add(404);
                ex.r140metadata.Add(405);
                ex.r140metadata.Add(452);
                ex.r140metadata.Add(453);
                ex.r140metadata.Add(454);
                ex.r140metadata.Add(455);
                ex.r140metadata.Add(456);
                ex.r140metadata.Add(457);
                ex.r140metadata.Add(458);
                ex.r140metadata.Add(459);
                ex.r140metadata.Add(460);
                ex.r140metadata.Add(461);
                ex.r140metadata.Add(462);
                ex.r140metadata.Add(463);
                ex.r140metadata.Add(464);
                ex.r140metadata.Add(465);
                ex.r140metadata.Add(466);
                ex.r140metadata.Add(467);
                ex.r140metadata.Add(468);
                ex.r140metadata.Add(469);
                ex.r140metadata.Add(470);
                ex.r140metadata.Add(471);
                ex.r140metadata.Add(472);
                ex.r140metadata.Add(473);
                ex.r140metadata.Add(474);
                ex.r140metadata.Add(475);
                ex.r140metadata.Add(476);
                ex.r140metadata.Add(477);
                ex.r140metadata.Add(478);
                ex.r140metadata.Add(479);
                ex.r140metadata.Add(480);
                ex.r140metadata.Add(481);
                ex.r140metadata.Add(482);
                ex.r140metadata.Add(483);
                ex.r140metadata.Add(484);
                ex.r140metadata.Add(485);
                ex.r140metadata.Add(486);
                ex.r140metadata.Add(487);
                ex.r140metadata.Add(488);
                ex.r140metadata.Add(489);
                ex.r140metadata.Add(490);

                #endregion



                #region data
                //for (int i = 0; i < 10000; i++)
                {
                    foreach (var m in mrs)
                    {
                        var tvnr = new TVNF30Record() { id = m.id, srcode = m.srcode, billid = m.billid };

                        #region rcalc
                        tvnr.rcalc = new List<object>();
                        tvnr.rcalc.Add(m.rcalc.r212NO_OF_PHASE);
                        tvnr.rcalc.Add(m.rcalc.r213AMPER);
                        tvnr.rcalc.Add(m.rcalc.r214AGREEMENT_DEMAND);
                        tvnr.rcalc.Add(m.rcalc.r233POPULATION_NUMBER);
                        tvnr.rcalc.Add(m.rcalc.r238TARIFF_FK);
                        tvnr.rcalc.Add(m.rcalc.r228LICENSE_ALLOWED_POWER);
                        tvnr.rcalc.Add(m.rcalc.r216TARIFF_TYPE);

                        #endregion

                        #region r110
                        tvnr.r130 = new List<object>();
                        tvnr.r130.Add(m.r130.r301READING_Date);
                        tvnr.r130.Add(m.r130.r302ACTIVE_NORMALTIME_READING);
                        tvnr.r130.Add(m.r130.r303ACTIVE_PEAKTIME_READING);
                        tvnr.r130.Add(m.r130.r304ACTIVE_LOWTIME_READING);
                        tvnr.r130.Add(m.r130.r305ACTIVE_WEEKENDTIME_READING);
                        tvnr.r130.Add(m.r130.r306REACTIVE_NORMALTIME_READING);

                        tvnr.r130.Add(m.r130.r307MAXIMETR_READING);

                        tvnr.r130.Add(m.r130.r308PREV_NORMALTIME_READING);
                        tvnr.r130.Add(m.r130.r309PREV_PEAKTIME_READING);
                        tvnr.r130.Add(m.r130.r310PREV_LOWTIME_READING);
                        tvnr.r130.Add(m.r130.r311PREV_WEEKENDTIME_READING);
                        tvnr.r130.Add(m.r130.r312PREV_REACTIVE_NORMALTIME);
                        tvnr.r130.Add(m.r130.r313PREV_READING_Date);

                        tvnr.r130.Add(m.r130.r314AGENT_REPORT_CODE_FK);
                        tvnr.r130.Add(m.r130.r315PROCESS_STATUS);
                        tvnr.r130.Add(m.r130.r316SERVICE_COLLECTION_DAY);
                        tvnr.r130.Add(m.r130.r317SERVICE_READING_AGENT_CODE);

                        tvnr.r130.Add(m.r130.r318COLD_A1_USAGE);
                        tvnr.r130.Add(m.r130.r319COLD_A2_USAGE);
                        tvnr.r130.Add(m.r130.r320COLD_A3_USAGE);
                        tvnr.r130.Add(m.r130.r321COLD_A4_USAGE);

                        tvnr.r130.Add(m.r130.r322REACT_USAGE);

                        tvnr.r130.Add(m.r130.r323WARM1_NORMALTIME_CONSUMPTION);
                        tvnr.r130.Add(m.r130.r324WARM1_PEAKTIME_CONSUMPTION);
                        tvnr.r130.Add(m.r130.r325WARM1_LOWTIME_CONSUMPTION);
                        tvnr.r130.Add(m.r130.r326WARM1_WEEKEND_CONSUMPTION);

                        tvnr.r130.Add(m.r130.r327WARM2_NORMALTIME_CONSUMPTION);

                        tvnr.r130.Add(m.r130.r328CHARGED_COLD_NORMALTIME_CONS);
                        tvnr.r130.Add(m.r130.r329CHARGED_COLD_PEAKTIME_CONS);
                        tvnr.r130.Add(m.r130.r330CHARGED_COLD_LOWTIME_CONS);
                        tvnr.r130.Add(m.r130.r331CHARGED_COLD_WEEKEND_CONS);

                        tvnr.r130.Add(m.r130.r332CHRGD_REACTIVE_NORMAL_CONS);

                        tvnr.r130.Add(m.r130.r333CHRGD_WARM1_NORMALTIME_CONS);
                        tvnr.r130.Add(m.r130.r334CHRGD_WARM1_PEAKTIME_CONS);
                        tvnr.r130.Add(m.r130.r335CHRGD_WARM1_LOWTIME_CONS);
                        tvnr.r130.Add(m.r130.r336CHRGD_WARM1_WEEKEND_CONS);

                        tvnr.r130.Add(m.r130.r337CHRGD_WARM2_NORMAL_CONS);
                        tvnr.r130.Add(m.r130.r338MAXIMETR_KW);
                        tvnr.r130.Add(m.r130.r339MAXIMETR_CALC);
                        tvnr.r130.Add(m.r130.r340READING_DURATION);
                        tvnr.r130.Add(m.r130.r341COLD_DAYS);
                        tvnr.r130.Add(m.r130.r342WARM_DAYS);
                        tvnr.r130.Add(m.r130.r343WARM_TO_COLD_RATIO);
                        tvnr.r130.Add(m.r130.r344TOTAL_ACTIVE_USAGE);
                        tvnr.r130.Add(m.r130.r345TOTAL_CONSUMPTION_REACTIVE);
                        tvnr.r130.Add(m.r130.r346NOT_INDUSTRIAL_PERSENTAGE);
                        tvnr.r130.Add(m.r130.r347REACTIVE_PEAKTIME_READING);
                        tvnr.r130.Add(m.r130.r348REACTIVE_LOWTIME_READING);
                        tvnr.r130.Add(m.r130.r349REACTIVE_WEEKENDTIME_READING);
                        tvnr.r130.Add(m.r130.r350PREV_REACTIVE_PEAKTIME);
                        tvnr.r130.Add(m.r130.r351PREV_REACTIVE_LOWTIME);
                        tvnr.r130.Add(m.r130.r352PREV_REACTIVE_WEEKENDTIME);
                        tvnr.r130.Add(m.r130.r353REACTIVE_PEAKTIME_CONSUMPTION);
                        tvnr.r130.Add(m.r130.r354REACTIVE_LOWTIME_CONSUMPTION);
                        tvnr.r130.Add(m.r130.r355REACTIVE_WEEKEND_CONSUMPTION);
                        tvnr.r130.Add(m.r130.r356WARM2_PEAKTIME_CONSUMPTION);
                        tvnr.r130.Add(m.r130.r357WARM2_LOWTIME_CONSUMPTION);
                        tvnr.r130.Add(m.r130.r358WARM2_WEEKEND_CONSUMPTION);
                        tvnr.r130.Add(m.r130.r359CHRGD_REACTIVE_PEAK_CONS);
                        tvnr.r130.Add(m.r130.r360CHRGD_REACTIVE_LOW_CONS);
                        tvnr.r130.Add(m.r130.r361CHRGD_REACTIVE_WEEKEND_CONS);
                        tvnr.r130.Add(m.r130.r362CHRGD_WARM2_PEAKTIME_CONS);
                        tvnr.r130.Add(m.r130.r363CHRGD_WARM2_LOWTIME_CONS);
                        tvnr.r130.Add(m.r130.r364CHRGD_WARM2_WEEKEND_CONS);
                        tvnr.r130.Add(m.r130.r365WARM3_NORMALTIME_CONSUMPTION);
                        tvnr.r130.Add(m.r130.r366WARM3_PEAKTIME_CONSUMPTION);
                        tvnr.r130.Add(m.r130.r367WARM3_LOWTIME_CONSUMPTION);
                        tvnr.r130.Add(m.r130.r368WARM3_WEEKEND_CONSUMPTION);
                        tvnr.r130.Add(m.r130.r369WARM4_NORMALTIME_CONSUMPTION);
                        tvnr.r130.Add(m.r130.r370WARM4_PEAKTIME_CONSUMPTION);
                        tvnr.r130.Add(m.r130.r371WARM4_LOWTIME_CONSUMPTION);
                        tvnr.r130.Add(m.r130.r372WARM4_WEEKEND_CONSUMPTION);


                        #endregion



                        #region r140
                        tvnr.r140 = new List<object>();
                        // tvnr.r120.Add(m.r120.r200BILL_IDENTIFIER);
                        tvnr.r140.Add(m.r140.r401BILL_IDENTIFIER);
                        tvnr.r140.Add(m.r140.r402PAYMENT_ID);
                        tvnr.r140.Add(m.r140.r403BILL_SERIAL);
                        tvnr.r140.Add(m.r140.r404SALE_YEAR);
                        tvnr.r140.Add(m.r140.r405REQUEST_PERIOD);
                        tvnr.r140.Add(m.r140.r406REQUEST_CYCLE);
                        tvnr.r140.Add(m.r140.r407SERVICE_TYPE);
                        tvnr.r140.Add(m.r140.r408REQUEST_DATE);
                        tvnr.r140.Add(m.r140.r409NET_AMOUNT);
                        tvnr.r140.Add(m.r140.r410TAX_AMOUNT);
                        tvnr.r140.Add(m.r140.r411PAYTOLL_AMOUNT);
                        tvnr.r140.Add(m.r140.r412GROSS_AMOUNT);
                        tvnr.r140.Add(m.r140.r413PREVIOUS_ACCOUNT_BALANCE);
                        tvnr.r140.Add(m.r140.r414TOTAL_REQUESTED_AMOUNT);
                        tvnr.r140.Add(m.r140.r415BILL_TYPE);
                        tvnr.r140.Add(m.r140.r416POWER_AMOUNT);
                        tvnr.r140.Add(m.r140.r417SEASON_PEAK_AMOUNT);
                        tvnr.r140.Add(m.r140.r418SUBSCRIPTION_AMOUNT);
                        tvnr.r140.Add(m.r140.r419DISCOUNT_AMOUNT);
                        tvnr.r140.Add(m.r140.r420WARM1_NORMALTIME_AMOUNT);
                        tvnr.r140.Add(m.r140.r421WARM1_PEAKTIME_AMOUNT);
                        tvnr.r140.Add(m.r140.r422WARM1_LOWTIME_AMOUNT);
                        tvnr.r140.Add(m.r140.r423WARM1_WEEKENDTIME_AMOUNT);

                        tvnr.r140.Add(m.r140.r424COLD_NORMALTIME_AMOUNT);
                        tvnr.r140.Add(m.r140.r425COLD_PEAKTIME_AMOUNT);
                        tvnr.r140.Add(m.r140.r426COLD_LOWTIME_AMOUNT);
                        tvnr.r140.Add(m.r140.r427COLD_WEEKENDTIME_AMOUNT);

                        tvnr.r140.Add(m.r140.r428WARM2_NORMALTIME_AMOUNT);
                        tvnr.r140.Add(m.r140.r429NORMAL_REACTIVE_AMOUNT);
                        tvnr.r140.Add(m.r140.r430PATTERNOVERUSE_FINEAMOUNT_WARM);
                        tvnr.r140.Add(m.r140.r431PATTERNOVERUSE_FINEAMOUNT_COLD);
                        tvnr.r140.Add(m.r140.r432POPULATION_NUMBER);
                        tvnr.r140.Add(m.r140.r433CHARGED_POWER_CONSUMPTION);
                        tvnr.r140.Add(m.r140.r434POWER_FACTOR);
                        tvnr.r140.Add(m.r140.r435DAMAGE_FACTOR);
                        tvnr.r140.Add(m.r140.r436ALLOWED_POWER);
                        tvnr.r140.Add(m.r140.r437WARM_SEASON_PEAK_DAYS);
                        tvnr.r140.Add(m.r140.r438COLD_SEASON_PEAK_DAYS);
                        tvnr.r140.Add(m.r140.r439PAYMENT_DUE_DATE);
                        tvnr.r140.Add(m.r140.r440DEMAND_OVERUSE_COUNT);
                        tvnr.r140.Add(m.r140.r441ROUND_AMOUNT);
                        tvnr.r140.Add(m.r140.r442TARIFF_FK);
                        tvnr.r140.Add(m.r140.r443TARIFF_OPTION_CODE);
                        tvnr.r140.Add(m.r140.r444COMPANY_CODE_FK);
                        tvnr.r140.Add(m.r140.r445PROCESS_STATUS);
                        tvnr.r140.Add(m.r140.r446REJECT_REASON);
                        tvnr.r140.Add(m.r140.r447REJECT_DATE);
                        tvnr.r140.Add(m.r140.r448METER_FLAG);
                        tvnr.r140.Add(m.r140.r449FREE_AMOUNT);
                        tvnr.r140.Add(m.r140.r450DEMAND_OVERUSE_AMOUNT);
                        tvnr.r140.Add(m.r140.r451NON_INDUSTRIAL_AMT);
                        tvnr.r140.Add(m.r140.r452LICENSE_EXPIRE_AMOUNT);
                        tvnr.r140.Add(m.r140.r453NO_GAS_DISCOUNT_AMOUNT);
                        tvnr.r140.Add(m.r140.r454SHORA_AMT);
                        tvnr.r140.Add(m.r140.r455VOLTAGE_DISCOUNT_AMOUNT);
                        tvnr.r140.Add(m.r140.r456DAYS_BEFORE_PATTERN);
                        tvnr.r140.Add(m.r140.r457CONSUMPTION_BEFORE_PATTERN);
                        tvnr.r140.Add(m.r140.r458AMOUNT_BEFORE_PATTERN);
                        tvnr.r140.Add(m.r140.r459REVISORY_PAYMENT_REQUEST);

                        tvnr.r140.Add(m.r140.r460WARM2_PEAKTIME_AMOUNT);
                        tvnr.r140.Add(m.r140.r461WARM2_LOWTIME_AMOUNT);
                        tvnr.r140.Add(m.r140.r462WARM2_WEEKENDTIME_AMOUNT);

                        tvnr.r140.Add(m.r140.r463PEAK_REACTIVE_AMOUNT);
                        tvnr.r140.Add(m.r140.r464LOW_REACTIVE_AMOUNT);
                        tvnr.r140.Add(m.r140.r465WEEKEND_REACTIVE_AMOUNT);
                        tvnr.r140.Add(m.r140.r466BUSINESS_CODE_FK);
                        tvnr.r140.Add(m.r140.r467SCHOOLS_DISCOUNT_AMOUNT);
                        tvnr.r140.Add(m.r140.r468SPECIAL_DISEASE_DISCOUNT_AMNT);
                        tvnr.r140.Add(m.r140.r469INSURANCE_AMOUNT);

                        tvnr.r140.Add(m.r140.r470WARM3_NORMALTIME_AMOUNT);
                        tvnr.r140.Add(m.r140.r471WARM3_PEAKTIME_AMOUNT);
                        tvnr.r140.Add(m.r140.r472WARM3_LOWTIME_AMOUNT);
                        tvnr.r140.Add(m.r140.r473WARM3_WEEKENDTIME_AMOUNT);

                        tvnr.r140.Add(m.r140.r474WARM4_NORMALTIME_AMOUNT);
                        tvnr.r140.Add(m.r140.r475WARM4_PEAKTIME_AMOUNT);
                        tvnr.r140.Add(m.r140.r476WARM4_LOWTIME_AMOUNT);
                        tvnr.r140.Add(m.r140.r477WARM4_WEEKENDTIME_AMOUNT);

                        tvnr.r140.Add(m.r140.r478CITY_CODE_FK);
                        tvnr.r140.Add(m.r140.r479AREA_CODE);
                        tvnr.r140.Add(m.r140.r480ZONE_CODE);
                        tvnr.r140.Add(m.r140.r481POWER_PAYTOLL_AMOUNT);
                        tvnr.r140.Add(m.r140.r482JANBAZ_DISCOUNT_AMT);
                        tvnr.r140.Add(m.r140.r483MOSQUE_DISCOUNT_AMT);
                        tvnr.r140.Add(m.r140.r484TUNNEL_DISCOUNT_AMT);
                        tvnr.r140.Add(m.r140.r485CNG_DISCOUNT_AMT);
                        tvnr.r140.Add(m.r140.r486UNINDUSTRIAL_USAGE);
                        tvnr.r140.Add(m.r140.r487BUSSINESS_LICENSE_AMT);
                        tvnr.r140.Add(m.r140.r488MOSQUE_AREA);
                        tvnr.r140.Add(m.r140.r489MOSQUE_DISCOUNT_USAGE);
                        tvnr.r140.Add(m.r140.r490BILL_REASON);
                        #endregion             
                        ex.data.Add(tvnr);
                    }




                }

                #endregion


                var response = WebConnection.getWebCleint("senddata", ex);
                //  MessageBox.Show(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        private  void UploadData10( List<F10Record> mrs)
        {
            try
            {


                var ex = new TVNF10Model();
                ex.formcode = 10;
                ex.refcode = refCode;
                ex.cocode = cocode;
                ex.data = new List<TVNF10Record>();
                ex.r110metadata = new List<int>();
                #region metadata 110
                ex.r110metadata.Add(10);
                ex.r110metadata.Add(20);
                ex.r110metadata.Add(30);
                ex.r110metadata.Add(101);
                ex.r110metadata.Add(102);
                ex.r110metadata.Add(103);
                ex.r110metadata.Add(104);
                ex.r110metadata.Add(105);
                ex.r110metadata.Add(106);
                ex.r110metadata.Add(107);
                ex.r110metadata.Add(108);
                ex.r110metadata.Add(109);
                ex.r110metadata.Add(110);
                ex.r110metadata.Add(111);
                ex.r110metadata.Add(112);
                ex.r110metadata.Add(113);
                ex.r110metadata.Add(114);
                ex.r110metadata.Add(115);
                ex.r110metadata.Add(116);
                ex.r110metadata.Add(117);
                ex.r110metadata.Add(118);
                ex.r110metadata.Add(119);
                ex.r110metadata.Add(120);
                ex.r110metadata.Add(121);
                #endregion

                #region metadata 120
                ex.r120metadata = new List<int>();
                ex.r120metadata.Add(1000);
                ex.r120metadata.Add(201);
                ex.r120metadata.Add(202);
                ex.r120metadata.Add(204);
                ex.r120metadata.Add(205);
                ex.r120metadata.Add(206);
                ex.r120metadata.Add(207);
                ex.r120metadata.Add(208);
                ex.r120metadata.Add(209);
                ex.r120metadata.Add(210);
                ex.r120metadata.Add(211);
                ex.r120metadata.Add(212);
                ex.r120metadata.Add(213);
                ex.r120metadata.Add(214);
                ex.r120metadata.Add(215);
                ex.r120metadata.Add(216);
                ex.r120metadata.Add(217);
                ex.r120metadata.Add(219);
                ex.r120metadata.Add(220);
                ex.r120metadata.Add(221);
                ex.r120metadata.Add(222);
                ex.r120metadata.Add(223);
                ex.r120metadata.Add(224);
                ex.r120metadata.Add(225);
                ex.r120metadata.Add(226);
                ex.r120metadata.Add(227);
                ex.r120metadata.Add(228);
                ex.r120metadata.Add(229);
                ex.r120metadata.Add(230);
                ex.r120metadata.Add(231);
                ex.r120metadata.Add(232);
                ex.r120metadata.Add(233);
                ex.r120metadata.Add(234);
                ex.r120metadata.Add(235);
                ex.r120metadata.Add(236);
                ex.r120metadata.Add(237);
                ex.r120metadata.Add(238);
                ex.r120metadata.Add(239);
                ex.r120metadata.Add(240);
                ex.r120metadata.Add(241);
                ex.r120metadata.Add(242);
                ex.r120metadata.Add(243);
                ex.r120metadata.Add(244);
                ex.r120metadata.Add(245);
                ex.r120metadata.Add(246);
                ex.r120metadata.Add(247);
                ex.r120metadata.Add(248);
                ex.r120metadata.Add(249);
                ex.r120metadata.Add(250);
                ex.r120metadata.Add(251);
                ex.r120metadata.Add(252);
                ex.r120metadata.Add(254);
                ex.r120metadata.Add(255);
                ex.r120metadata.Add(256);
                ex.r120metadata.Add(257);
                ex.r120metadata.Add(258);

                #endregion

                #region metadata 125
                ex.r125metadata = new List<int>();
                ex.r125metadata.Add(280);
                ex.r125metadata.Add(281);
                ex.r125metadata.Add(282);
                ex.r125metadata.Add(283);
                ex.r125metadata.Add(284);
                ex.r125metadata.Add(285);
                ex.r125metadata.Add(286);
                ex.r125metadata.Add(287);
                ex.r125metadata.Add(288);
                ex.r125metadata.Add(289);
                ex.r125metadata.Add(290);
                ex.r125metadata.Add(291);
                #endregion

                #region data
                //for (int i = 0; i < 10000; i++)
                {
                    foreach (var m in mrs)
                    {
                        var tvnr = new TVNF10Record() { id = m.id };

                        #region r110
                        tvnr.r110 = new List<object>();
                        tvnr.r110.Add(m.r110.r10TOTAL_BILL_DEBT);
                        tvnr.r110.Add(m.r110.r20TOTAL_REGISTER_DEBT);
                        tvnr.r110.Add(m.r110.r30OTHER_ACCOUNT_BALANCE);

                        tvnr.r110.Add(m.r110.r101CUSTOMER_TYPE);
                        tvnr.r110.Add(m.r110.r102FIRST_NAME);
                        tvnr.r110.Add(m.r110.r103SURNAME);
                        tvnr.r110.Add(m.r110.r104FATHER_NAME);
                        tvnr.r110.Add(m.r110.r105BIRTH_CERTIFICATE_ID);
                        tvnr.r110.Add(m.r110.r106NATIONAL_CARD_ID);
                        tvnr.r110.Add(m.r110.r107BIRTH_DATE);
                        tvnr.r110.Add(m.r110.r108ISSUE_PLACE);
                        tvnr.r110.Add(m.r110.r109COMPANY_NAME);
                        tvnr.r110.Add(m.r110.r110COMPANY_REGISTRATION_DATE);
                        tvnr.r110.Add(m.r110.r111COMPANY_REGISTRATION_ID);
                        tvnr.r110.Add(m.r110.r112COMPANY_ISIC_FK);
                        tvnr.r110.Add(m.r110.r113COMPANY_CODE_FK);
                        tvnr.r110.Add(m.r110.r114SEX_TYPE);
                        tvnr.r110.Add(m.r110.r115PHONE_NUMBEr);
                        tvnr.r110.Add(m.r110.r116MOBILE_NUMBEr);
                        tvnr.r110.Add(m.r110.r117FAX_NUMBEr);
                        tvnr.r110.Add(m.r110.r118EMAIL_ADDRESS);
                        tvnr.r110.Add(m.r110.r119ADDRESS);
                        tvnr.r110.Add(m.r110.r120POSTAL_CODE);
                        tvnr.r110.Add(m.r110.r121BUSINESS_CODE_FK);

                        #endregion

                        #region r120
                        tvnr.r120 = new List<object>();
                        // tvnr.r120.Add(m.r120.r200BILL_IDENTIFIER);
                        tvnr.r120.Add(m.r120.r201FILE_SERIAL_NUMBER);
                        tvnr.r120.Add(m.r120.r202SUBSCRIPTION_ID);
                        tvnr.r120.Add(m.r120.r204CITY_CODE_FK);
                        tvnr.r120.Add(m.r120.r205AREA_CODE);
                        tvnr.r120.Add(m.r120.r206ZONE_CODE);
                        tvnr.r120.Add(m.r120.r207IDENTIFYING_NUMBER);
                        tvnr.r120.Add(m.r120.r208READING_COLLECTION_DAY);
                        tvnr.r120.Add(m.r120.r209READING_AGENT_CODE);
                        tvnr.r120.Add(m.r120.r210READING_SEQUENCE);
                        tvnr.r120.Add(m.r120.r211SERVICE_TYPE);
                        tvnr.r120.Add(m.r120.r212NO_OF_PHASE);
                        tvnr.r120.Add(m.r120.r213AMPER);
                        tvnr.r120.Add(m.r120.r214AGREEMENT_DEMAND);
                        tvnr.r120.Add(m.r120.r215VOLTAGE_TYPE);
                        tvnr.r120.Add(m.r120.r216TARIFF_TYPE);
                        tvnr.r120.Add(m.r120.r217TARIFF_OPTION_CODE);
                        tvnr.r120.Add(m.r120.r219PREMISE_LOCATION);
                        tvnr.r120.Add(m.r120.r220SERVICE_POINT_ADDRESS);
                        tvnr.r120.Add(m.r120.r221SERVICE_POINT_POSTCODE);
                        tvnr.r120.Add(m.r120.r222PHONE_NUMBER);
                        tvnr.r120.Add(m.r120.r223INSTALLATION_DATE);
                        tvnr.r120.Add(m.r120.r224CREATION_DATE);
                        tvnr.r120.Add(m.r120.r225AGREEMENT_DATE);
                        tvnr.r120.Add(m.r120.r226AGREEMENT_NUMBER);
                        tvnr.r120.Add(m.r120.r227SERVICE_POINT_STATUS);
                        tvnr.r120.Add(m.r120.r228LICENSE_ALLOWED_POWER);
                        tvnr.r120.Add(m.r120.r229LICENSE_EXPIRE_DATE);
                        tvnr.r120.Add(m.r120.r230LICENSE_NUMBER);
                        tvnr.r120.Add(m.r120.r231LICENSE_ISSUER);
                        tvnr.r120.Add(m.r120.r232ELECTRICITY_SUPPLY_FK);
                        tvnr.r120.Add(m.r120.r233POPULATION_NUMBER);
                        tvnr.r120.Add(m.r120.r234POPULATION_EXPIRE_DATE);
                        tvnr.r120.Add(m.r120.r235DISCOUNT_CONSUMPTION_FK);
                        tvnr.r120.Add(m.r120.r236DISCOUNT_REGISTRATION_FK);
                        tvnr.r120.Add(m.r120.r237REGISTRATION_DISCOUNT_REF);
                        tvnr.r120.Add(m.r120.r238TARIFF_FK);
                        tvnr.r120.Add(m.r120.r239SERVICE_INACTIVE_DATE);
                        tvnr.r120.Add(m.r120.r240SERVICE_DELETE_DATE);
                        tvnr.r120.Add(m.r120.r241TEMPORARY_REDUCE_EXPIRE_DATE);
                        tvnr.r120.Add(m.r120.r242LAST_POWER_REDUCTION);
                        tvnr.r120.Add(m.r120.r243TEMPORARY_REDUCE_START_DATE);
                        tvnr.r120.Add(m.r120.r244TEMPORARY_POWER_REDUCT_COUNT);
                        tvnr.r120.Add(m.r120.r245TRACKING_CODE);
                        tvnr.r120.Add(m.r120.r246TRANSFORMATOR_COUNT);
                        tvnr.r120.Add(m.r120.r247POST_NUMBER);
                        tvnr.r120.Add(m.r120.r248FEEDER_NUMBER);
                        tvnr.r120.Add(m.r120.r249BASE_NUMBER);
                        tvnr.r120.Add(m.r120.r250TRANSFORMATOR_POWER);
                        tvnr.r120.Add(m.r120.r251TRANSFORMATOR_NUMBER);
                        tvnr.r120.Add(m.r120.r252LAST_TEST_DATE);
                        tvnr.r120.Add(m.r120.r254GAS_ENERGY_STATUS);
                        tvnr.r120.Add(m.r120.r255REPEAT_CODE);
                        tvnr.r120.Add(m.r120.r256X_DEGREE);
                        tvnr.r120.Add(m.r120.r257Y_DEGREE);
                        tvnr.r120.Add(m.r120.r258Y_MOSQUE_AREA);


                        #endregion

                        #region r125
                        tvnr.r125 = new List<List<object>>();
                        foreach (var mr125 in m.r125)
                        {
                            var lo = new List<object>();

                            lo.Add(mr125.r280SERIAL_NUMBER);
                            lo.Add(mr125.r281METER_TYPE);
                            lo.Add(mr125.r282DIGIT_NUMBER);
                            lo.Add(mr125.r283ADJUSTMENT_FACTOR);
                            lo.Add(mr125.r284METER_MODEL_FK);
                            lo.Add(mr125.r285METER_MAKER_TYPE_FK);
                            lo.Add(mr125.r286INSTALLATION_DATE);
                            lo.Add(mr125.r287READING_CLOCK_CODE);
                            lo.Add(mr125.r288MAXIMETER_FACTOR);
                            lo.Add(mr125.r289METER_STATUS);
                            lo.Add(mr125.r290CREATION_DATE);
                            lo.Add(mr125.r291EXPIRATION_DATE);
                            tvnr.r125.Add(lo);
                        }
                        #endregion

                        #region r125r
                        if (m.r125r.Count != 0)
                        {
                            tvnr.r125r = new List<List<object>>();
                            foreach (var mr125 in m.r125r)
                            {
                                var lo = new List<object>();

                                lo.Add(mr125.r280SERIAL_NUMBER);
                                lo.Add(mr125.r281METER_TYPE);
                                lo.Add(mr125.r282DIGIT_NUMBER);
                                lo.Add(mr125.r283ADJUSTMENT_FACTOR);
                                lo.Add(mr125.r284METER_MODEL_FK);
                                lo.Add(mr125.r285METER_MAKER_TYPE_FK);
                                lo.Add(mr125.r286INSTALLATION_DATE);
                                lo.Add(mr125.r287READING_CLOCK_CODE);
                                lo.Add(mr125.r288MAXIMETER_FACTOR);
                                lo.Add(mr125.r289METER_STATUS);
                                lo.Add(mr125.r290CREATION_DATE);
                                lo.Add(mr125.r291EXPIRATION_DATE);
                                tvnr.r125r.Add(lo);
                            }
                        }
                        #endregion

                        ex.data.Add(tvnr);
                    }




                }

                #endregion


                var response = WebConnection.getWebCleint("senddata", ex);
                //  MessageBox.Show(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
