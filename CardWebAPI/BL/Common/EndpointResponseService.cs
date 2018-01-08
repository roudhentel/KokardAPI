using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CardWebAPI.BL.Common
{
    public class EndpointResponseService
    {
        public static EndpointResponse ErrorResponse(Exception ex)
        {
            var res = new EndpointResponse();
            res.StatusCode = HttpStatusCode.InternalServerError;
            res.ErrorDetails = ex.ToString();
            res.TableResult = null;

            return res;
        }

        public static EndpointResponse SuccessResponse(DataTable dt)
        {
            var res = new EndpointResponse();
            res.StatusCode = HttpStatusCode.OK;
            res.ErrorDetails = null;
            res.TableResult = dt;

            return res;
        }
    }
}
