using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAssessment
{
    public class PlayGameRequestDTO
    {
        public int packetType { get; set; }
        public string payload { get; set; }
        public bool useFilter { get; set; }
        public bool isBase64Encoded { get; set; }
    }
}
