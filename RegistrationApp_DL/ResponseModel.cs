using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationApp_DL
{
    public class ResponseModel<TResult> where TResult : class
    {
        public int Status { get; set; }
        public int PrimaryKey { get; set; }
        public string Message { get; set; }
        public IEnumerable<TResult> ListResult { get; set; }
        public string Result { get; set; }
    }
}
