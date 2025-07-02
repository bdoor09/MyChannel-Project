using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.DTO
{
    public class EmailModel
    {
        public string TO { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public EmailModel(string to, string subject, string content)
        {
            TO = to;
            Subject = subject;
            Content = content;
        }
    }
}
