using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ConductoresEntity: EN
    {
        public int? ConductorId { get; set; }
        public string CedulaConductor { get; set; }
        public string NombreConductor { get; set; }
        public string TelefonoConductor { get; set; }


    }
}
