using accomtest.model;
using Newtonsoft.Json;
using System;
using System.Linq;


using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Threading;

namespace accomtest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void endsend(decimal refcode)
        {
            var rq = new RequestSendResponse() { refcode = refcode };

            var result = WebConnection.getWebCleint("endsend", rq);
            //   var r = (RequestSendResponse)JsonConvert.DeserializeObject(result, typeof(RequestSendResponse));
            MessageBox.Show(result);

        }
        private decimal getRefCode(long count, int formcode, DateTime datefrom, DateTime dateto)
        {
            var rq = new requestsend() { cocode = Convert.ToInt32(txCoCode.Text), formcode = formcode, recordCount = count, fromdate = datefrom, todate = dateto };
            var result = WebConnection.getWebCleint("startsend", rq);
            var r = (RequestSendResponse)JsonConvert.DeserializeObject(result, typeof(RequestSendResponse));
            return r.refcode;

        }
        private int getblockCount()
        {
            int count = 0;
            this.Invoke((MethodInvoker)delegate
            {
                count = Convert.ToInt32(txBlockCount.Text);

            });
            return count;
        }



        private void EnableForm(bool cancel = true)
        {
            this.Invoke((MethodInvoker)delegate
            {
                cancelation = cancel;
                button1.Enabled = cancel;
                button2.Enabled = cancel;
                button6.Enabled = cancel;
                button5.Enabled = !cancel;

            });

        }
        private void DoCancel()
        {

            EnableForm(true);
        }




        private void GetFdata<T, TSource>(int formCode, DateTime fromDate, DateTime toDate, Expression<Func<TSource, bool>> predicate)
        {
            int totalcount = 0;
            try
            {
                decimal refcode = 0;
                int blockcount = getblockCount();
                int progress = 0;
                long ct = new DataCounter().Count<TSource>(formCode, predicate);
                EventManager.Inst.WriteInfo(string.Format("start sending date formcode={0} , count={1}", formCode, ct), formCode);
                refcode = getRefCode(ct, formCode, fromDate, DateTime.Now);
                this.Invoke((MethodInvoker)delegate
                {
                    lblRefCode.Text = refcode.ToString();

                });
                var du = new DataUploader<T>(Convert.ToInt32(txCoCode.Text), refcode);
                var dl = new DataLoader();
                du.finished = false;
                du.forceClose = false;
                foreach (var item in dl.FData<T, TSource>(formCode, blockcount, fromDate, toDate, predicate))
                {
                    try
                    {
                        if (cancelation)
                        {
                            dl.cancelation = cancelation;
                            du.forceClose = true;
                        }
                        totalcount += item.Count;
                        progress += item.Count;

                        this.Invoke((MethodInvoker)delegate
                        {
                            label1.Text = totalcount.ToString();
                            label4.Text = new TimeSpan(DateTime.Now.Ticks - startticks).ToString();
                        });
                        du.UploadData(item);
                    }
                    catch
                    {
                        du.forceClose = true;
                    }
                   
                }
                while (du.progressing)
                    continue;
                endsend(refcode);
                EventManager.Inst.WriteInfo(string.Format("end sending date formcode={0} , count={1}", formCode, ct), formCode);
                du.finished = true;

            }
            catch (Exception e)
            {
              

                this.Invoke((MethodInvoker)delegate
                {
                    txException.Text = e.Message;

                });
                DoCancel();
            }
            //   return result110;
        }
        long startticks = 0;
        delegate void CreateFormDataHandler<T, TSource>(int formCode, DateTime fromDate, DateTime toDate, Expression<Func<TSource, bool>> predicate);
        private void MakeForms<T, TSource>(int formCode, DateTime fromDate, DateTime toDate, Expression<Func<TSource, bool>> predicate)
        {
            try
            {
                EnableForm(false);
                txException.Clear();
                label1.Text = "0";
                label4.Text = "0";
                lblRefCode.Text = "0";
                startticks = DateTime.Now.Ticks;
                button1.Enabled = false;

                ThreadStart ts = delegate () { GetFdata<T, TSource>(formCode, fromDate, toDate, predicate); };

                System.Threading.Thread th = new System.Threading.Thread(ts);
                th.Start();
                while (th.IsAlive)
                {
                    if (cancelation)
                    {
                        th.Abort();
                    }
                    Application.DoEvents();
                }
                EnableForm(true);
            }
            finally
            {
                button1.Enabled = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //GetF10data<F10Record, TVNBranchDataView>(10, new DateTime(1900, 1, 1), DateTime.Now, (p => 1 == 1));
            MakeForms<F10Record, TVNBranchDataView>(10, new DateTime(1900, 1, 1), DateTime.Now, (p => 1 == 1));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MakeForms<F30Record, TVNNEWForm30View>(30, new DateTime(1900, 1, 1), DateTime.Now, (p => p.CurrRdgDate > new DateTime(2016, 03, 21)));

            //MakeForms(GetF30data);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var dbContext = new GolestanDBEntities())
            {
                if (dbContext.Database.Exists())
                    MessageBox.Show("Successfully connected!");
                else
                    MessageBox.Show("Connection faled", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(WebConnection.getWebCleint("hello", new object()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private bool cancelation = false;
        private void button5_Click(object sender, EventArgs e)
        {
            DoCancel();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WebConnection.remoteAddr = txtRemote.Text;
        }
     

        private void button6_Click(object sender, EventArgs e)
        {

            MakeForms<F50Record, TVNF50FormView>(50, new DateTime(1900, 1, 1), DateTime.Now, (p => p.RcptDateTime > new DateTime(2016, 03, 21)));
        }

        private void txCoCode_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void txtRemote_TextChanged(object sender, EventArgs e)
        {
            WebConnection.remoteAddr = txtRemote.Text;
        }
    }
}
