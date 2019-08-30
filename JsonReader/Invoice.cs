using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonReader
{
    class Invoice
    {

        public class JSONReader
        {
            [Key]
            public int Id { get; set; }
            public string gstin { get; set; }
            public string fp { get; set; }
            public List<B2b> b2b { get; set; }
        }

        public class B2b
        {
            [Key]
            public int B2BId { get; set; }
            public string ctin { get; set; }
            public string cfs { get; set; }
            public object cname { get; set; }
            public List<Inv> inv { get; set; }
        }

        public class Inv
        {
            [Key]
            public int InvId { get; set; }
            public float val { get; set; }
            public List<Itm> itms { get; set; }
            public string inv_typ { get; set; }
            public string pos { get; set; }
            public string idt { get; set; }
            public string rchrg { get; set; }
            public string inum { get; set; }
            public string chksum { get; set; }
        }

        public class Itm
        {
            [Key]
            public int ItemId { get; set; }
            public int num { get; set; }
            public Itm_Det itm_det { get; set; }
        }

        public class Itm_Det
        {
            [Key]
            public int ItemDetailId { get; set; }
            public float samt { get; set; }
            public int rt { get; set; }
            public float txval { get; set; }
            public float camt { get; set; }
            public int csamt { get; set; }
        }



    }
}
