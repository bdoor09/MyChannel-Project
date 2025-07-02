using System;
using System.Collections.Generic;

namespace MyChannel.Core.Data
{
    public partial class User
    {
        public User()
        {
            Channels = new HashSet<Channel>();
            Channelsubs = new HashSet<Channelsub>();
            Comments = new HashSet<Comment>();
            Feedbacks = new HashSet<Feedback>();
            Logins = new HashSet<Login>();
            Payments = new HashSet<Payment>();
            Respons = new HashSet<Respon>();
        }

        public decimal Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public decimal? Age { get; set; }
        public string? Emaile { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public DateTime? Registerdate { get; set; }
        public string? Phonenumber { get; set; }
        public string? Image { get; set; }

        public virtual ICollection<Channel> Channels { get; set; }
        public virtual ICollection<Channelsub> Channelsubs { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Respon> Respons { get; set; }
    }
}
