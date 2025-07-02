using Dapper;
using MyChannel.Core.Commen;
using MyChannel.Core.Data;
using MyChannel.Core.DTO;
using MyChannel.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Infra.Repository
{
    public class PaymentRepository: IPaymentRepository
    {

        private readonly IDbContext dbContext;
        public PaymentRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public List<Payment> GetAllPayment()
        {

            IEnumerable<Payment> result = dbContext.Connection.Query<Payment>("Payment_Package.GET_ALL", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Payment GetPaymentById(int id)
        {
            var p = new DynamicParameters();
            p.Add("pid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Payment>("Payment_Package.GET_PAYMENT_BY_ID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreatePayment(Payment payment)
        {
            var p = new DynamicParameters();
            p.Add("Card_Name", payment.Cardholdername, DbType.String, direction: ParameterDirection.Input);
            p.Add("CARD_NUMBER", payment.Cardnumber, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("cvv", payment.Cvv, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("EXPIRY_DATE", payment.Expirydate, DbType.Date, direction: ParameterDirection.Input);
            p.Add("PAYMENT_DATE", payment.Paymentdate, DbType.Date, direction: ParameterDirection.Input);
            p.Add("TOTAL_AMOUNT", payment.Totalamount, DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("USER_ID", payment.Userid, DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.Connection.Execute("Payment_Package.CREAT_NEW_PAYMENT", p, commandType: CommandType.StoredProcedure);

            //name of 
            //wit it change 
            // Ok

        }
        public void UpdatePayment(Payment payment)
        {
            var p = new DynamicParameters();
            p.Add("pid", payment.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Card_Name", payment.Cardholdername, DbType.String, direction: ParameterDirection.Input);
            p.Add("CARD_NUMBER", payment.Cardholdername, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("cvv", payment.Cvv, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("EXPIRY_DATE", payment.Expirydate, DbType.Date, direction: ParameterDirection.Input);
            p.Add("PAYMENT_DATE", payment.Paymentdate, DbType.Date, direction: ParameterDirection.Input);
            p.Add("TOTAL_AMOUNT", payment.Totalamount, DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("USER_ID", payment.Userid, DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Payment_Package.UPDATE_of_PAYMENT", p, commandType: CommandType.StoredProcedure);

        }

        public Payment DeletePayment(int id)
        {
            var p = new DynamicParameters();
            p.Add("pid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Payment>("Payment_Package.DELETE_PAYMENT", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }


        public Payment GetPaymentByUserid(int userid)
        {
            var p = new DynamicParameters();
            p.Add("p_userid", userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Payment>("Payment_Package.Get_Paument_ByUserId", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }


        public List<InfoUserPayment> GetPaymentUserInfo()
        {

            IEnumerable<InfoUserPayment> result = dbContext.Connection.Query<InfoUserPayment>("Payment_Package.Get_Paument_user", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
        

        public bool checkPayment(int userid)

        {

            var p = new DynamicParameters();
            p.Add("p_userid", userid, DbType.Int32, direction: ParameterDirection.Input);



            var result = dbContext.Connection.Query<Payment>("Payment_Package.checkPayment", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault() != null ? true : false;

        }

    }
}
