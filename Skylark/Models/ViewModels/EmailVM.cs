using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skylark.Models.ViewModels
{
    public class EmailVM
    {
        public string EmailAddress { get; set; }
        public string CCEmailAddress { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
