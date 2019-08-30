using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static JsonReader.Invoice;
using JsonReader.DataContext;
using System.Web;

namespace JsonReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void btnReadJson_Click(object sender, EventArgs e)
        {
            List<Invoice> invoices = new List<Invoice>();

            JsonSerializer jsonSerializer = new JsonSerializer();

            using (StreamReader r = new StreamReader(@"D:\DotNet\Forms\JsonReader\JsonReader\Json\Data.json"))
            {
                var json = r.ReadToEnd();

               var items = JsonConvert.DeserializeObject<JSONReader>(json);
                JSONReader jSONReader = new JSONReader()
                {
                    b2b = items.b2b,
                    gstin = items.gstin,
                    fp = items.fp
                };
                Itm itmm = new Itm();
                using (RootDataContext dbContext = new RootDataContext())
                {
                    var b2bList = jSONReader.b2b; //b2b
                   foreach(var data in b2bList)
                    {
                        B2b b2 = new B2b()
                        {
                            cfs= data.cfs,
                            cname= data.cname,
                            ctin= data.ctin,
                            inv= data.inv//
                        };

                        var invList = data.inv;
                        foreach (var invItem in invList)// inv
                        {
                            var invItems = invItem.itms;
                            List<Inv> InvList = new List<Inv>();
                            // Itm Done Here
                            foreach (var Items in invItems)
                            {
                                var Itm_DetItem = Items.itm_det;
                                var ItemDetObj = new Itm_Det()
                                {
                                    camt = Itm_DetItem.camt,
                                    csamt = Itm_DetItem.csamt,
                                    rt = Itm_DetItem.rt,
                                    samt = Itm_DetItem.samt,
                                    txval = Itm_DetItem.txval
                                };

                                var itm = new Itm()
                                {
                                    num = Items.num,
                                    itm_det = ItemDetObj
                                };

                                List<Itm> ItemList = new List<Itm>()  // inv List Done Here
                            {
                               new Itm()
                               {
                                   num= itm.num,
                                   itm_det=itm.itm_det
                               }
                            };
                                Inv inv = new Inv()
                                {
                                    chksum = invItem.chksum,
                                    idt = invItem.idt,
                                    inum = invItem.inum,
                                    inv_typ = invItem.inv_typ,
                                    pos = invItem.pos,
                                    rchrg = invItem.rchrg,
                                    val = invItem.val,
                                    itms= ItemList,
                                };

                               
                                InvList.Add(inv);
                                

                            }

                           
                        }
                    }

                }
            }
        }
    }
}
