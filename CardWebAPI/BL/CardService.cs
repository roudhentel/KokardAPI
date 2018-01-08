using CardWebAPI.BL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardWebAPI.BL
{
    public class CardService
    {
        DatabaseService dbSvc;

        public CardService()
        {
            dbSvc = new DatabaseService();
        }

        public EndpointResponse ActivateCard(
            string cardNumber)
        {
            // code for card activation
            var response = new EndpointResponse();

            try
            {
                var parameters = new List<SqlParams>();
                parameters.Add(new SqlParams("@pCardNumber", cardNumber, System.Data.SqlDbType.NVarChar));
                parameters.Add(new SqlParams("@pStatus", "1", System.Data.SqlDbType.NVarChar));

                var dt = dbSvc.executeStoreProcedure("uspChangeCardStatus", parameters);
                response = EndpointResponseService.SuccessResponse(dt);
            }
            catch (Exception ex)
            {
                response = EndpointResponseService.ErrorResponse(ex);
            }

            return response;
        }


        public EndpointResponse GetCardStatus (
            string cardNumber)
        {
            var response = new EndpointResponse();

            try
            {
                var parameters = new List<SqlParams>();
                parameters.Add(new SqlParams("@pCardNumber", cardNumber, System.Data.SqlDbType.NVarChar));

                var dt = dbSvc.executeStoreProcedure("uspGetCardStatus", parameters);
                response = EndpointResponseService.SuccessResponse(dt);

            }
            catch (Exception ex)
            {
                response = EndpointResponseService.ErrorResponse(ex);
            }

            return response;
        }
    }
}
