using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CardWebAPI.BL.Common
{
    public class EndpointResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ErrorDetails { get; set; }
        public DataTable TableResult { get; set; }
        public string AdditionalInfo { get; set; }

        public EndpointResponse()
        {

        }

        public EndpointResponse(
            HttpStatusCode scode,
            string err,
            DataTable dtData,
            string addinfo)
        {
            StatusCode = scode;
            ErrorDetails = err;
            TableResult = dtData;
            AdditionalInfo = addinfo;
        }
    }
}
