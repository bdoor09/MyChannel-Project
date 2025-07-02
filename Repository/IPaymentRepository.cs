using MyChannel.Core.Data;
using MyChannel.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.Repository
{
    public interface IPaymentRepository
    {
        List<Payment> GetAllPayment();

        Payment GetPaymentById(int id);

        void CreatePayment(Payment payment);

        void UpdatePayment(Payment payment);

        Payment DeletePayment(int id);
        Payment GetPaymentByUserid(int userid);

        List<InfoUserPayment> GetPaymentUserInfo();

       bool checkPayment(int userid);
    }
}
