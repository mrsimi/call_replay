using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace call_replay.Models
{
    public class WishLog
    {
        public int Id { get; set; }
        public string PersonWishing {get; set;}
        public byte[] WishAudio {get; set;}

        public string AudioFileUrl {get; set;}
        
    }
}