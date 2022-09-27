using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace call_replay.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string WishingPerson { get; set; }
        public IFormFile Audio {get; set;}
    }

    public class AudioFile
    {
        public int Id {get; set;}
        public string WishingPerson {get; set;}
        public string FileUrl {get;set;}
    }
}