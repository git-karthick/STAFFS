using System.ComponentModel;

namespace STAFFS.Models
{
    public class Staffs
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("STAFF ID")]
        public int sId { get; set; }
        [DisplayName("STAFF NAME")]
        public string sName { get; set; }
        [DisplayName("QUALIFICATION")]
        public string sQly { get; set; }
        [DisplayName("DESIGNATION")]
        public string sDesg { get; set; }
        [DisplayName("SALARY")]
        public decimal sSal { get; set; }

    }
}
