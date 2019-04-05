using System;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;

namespace Teste
{
    //SINGLE -> INSTANCIA UNICA e Sigle-Thread
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single,
        InstanceContextMode = InstanceContextMode.Single,
        ReleaseServiceInstanceOnTransactionComplete = false)]
    public class InboundMessageHandlerService : IInboundMessageHandlerService
    {
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void ProcessIncomingMessage(MsmqMessage<string> incomingOrderMessage)
        {
            Console.WriteLine("------------------------------------ mensagem recebida ---------------------------------------");

            var orderRequest = incomingOrderMessage.Body;

            WCFListner.WcfBD.Service1Client bd = new WCFListner.WcfBD.Service1Client();

            bd.SaveData(orderRequest);

            Console.WriteLine(orderRequest);
            Console.WriteLine();
        }
    }
}
