﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SERVIES.Helper
{
    public static class EmailSettings

    {
        public static void SendEmail (Email email)

        {
            var client = new SmtpClient("smtp.gmail.com" , 587);
            client.EnableSsl = true;

            client.Credentials = new NetworkCredential("bassantkhaled084@gmail.com", "stbijnnkrhrxmolp");

            client.Send("bassantkhaled084@gmail.com", email.To, email.Subject, email.body);

		}


    }
}
