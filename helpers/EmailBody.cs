using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Infra.helpers
{
    public static class EmailBody
    {
        public static string EmailStringBody(string email)
        {
            return $@"<html>
                <head>
                </head>
                <body>
                    <div style="" border: 2px solid #004CF0;width: fit-content;"">
                        <h1 style="" margin-left: 4.5em;"">You Invoice</h1>
                        <h3 style="" padding-left: 1em;padding-right: 1em;"">This emial to ensure that your payment is success</h3>
                        <h3 style="" margin-left: 1em;"">Total Amount: 5 $</h3>
                        <h3 style="" margin-left: 1em;"">Payment Date: {DateTime.Now.ToShortDateString()}</h3>
                        <br>
                        <a href="" http://localhost:4200/user/userInvoice"" target="" _blank"" style="" padding:
                            20px;border: 4px solid #296DFF;background-color: #004CF0;color: #fff; font-weight: bold; text-decoration:
                            none; font-size: larger; margin-left: 8em;"">View</a>
                        <h4 style="" margin-left: 1em;"">With Regards</h4>
                    </div>
                </body>
             </html>";
        }
    }
}
