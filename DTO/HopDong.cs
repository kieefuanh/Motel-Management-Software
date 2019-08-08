using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HopDong
    {
        public string MaHopDong { get; set; }
        public DateTime NgayThue { get; set; }
        public DateTime NgayTra { get; set; }
        public string MaPhong { get; set; }
        public string CMND { get; set; }
        public float Coc { get; set; }
        public string ChuThich { get; set; }
    }
}
