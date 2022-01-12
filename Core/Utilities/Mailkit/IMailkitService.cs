using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Mailkit
{
    public interface IMailkitService
    {
        void SendPassword(string email,string attendeeName);
    }
}
