namespace ABDM.Helpers
{
    using System.ServiceModel;
    using System.ServiceModel.Channels;

    public static class WcfHeaderHelper
    {
        public static OperationContextScope AddUnitHeader(
            IClientChannel channel,
            string unitCode
        )
        {
            var scope = new OperationContextScope(channel);

            var httpRequestProperty =
                new HttpRequestMessageProperty();

            httpRequestProperty.Headers.Add(
                "appUnitSelection",
                unitCode
            );

            OperationContext.Current
                .OutgoingMessageProperties[
                    HttpRequestMessageProperty.Name
                ] = httpRequestProperty;

            return scope;
        }
    }
}
