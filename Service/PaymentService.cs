using MyChannel.Core.Data;
using MyChannel.Core.DTO;
using MyChannel.Core.Repository;
using MyChannel.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Infra.Service
{
    public class PaymentService: IPaymentService
    {
        private readonly IPaymentRepository paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            this.paymentRepository = paymentRepository;
        }

        public List<Payment> GetAllPayment()
        {
            return paymentRepository.GetAllPayment();

        }

        public Payment GetPaymentById(int id)
        {
            return paymentRepository.GetPaymentById(id);
        }

        public void CreatePayment(Payment payment)
        {
            paymentRepository.CreatePayment(payment);
        }

        public void UpdatePayment(Payment payment)
        {
            paymentRepository.UpdatePayment(payment);
        }
        public Payment DeletePayment(int id)
        {
            return paymentRepository.DeletePayment(id);
        }


        public Payment GetPaymentByUserid(int userid)
        {
            return paymentRepository.GetPaymentByUserid(userid);
        }


        public List<InfoUserPayment> GetPaymentUserInfo()
        {
            return paymentRepository.GetPaymentUserInfo();  
        }


        public bool checkPayment(int userid)
        {
            return paymentRepository.checkPayment(userid);
        }
    }
}
