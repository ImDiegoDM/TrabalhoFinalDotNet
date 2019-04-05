using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    [ServiceKnownType(typeof(string))]
    [ServiceContract]
    public interface IInboundMessageHandlerService
    {
        [OperationContract(IsOneWay = true, Action = "*")]
        void ProcessIncomingMessage(MsmqMessage<string> incomingOrderMessage);
    }
}
