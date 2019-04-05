using System;
using System.Messaging;
using System.ServiceModel.Activation;

namespace WcfRest
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "Service1" no arquivo de código, svc e configuração ao mesmo tempo.
    // OBSERVAÇÃO: Para iniciar o cliente de teste do WCF para testar esse serviço, selecione Service1.svc ou Service1.svc.cs no Gerenciador de Soluções e inicie a depuração.
    public class Service1 : IService1
    {
        public string messagePath = @".\Private$\TextQueue";
        private MessageQueue messageQueue;

        public string QueueMessage(Message body)
        {
            if (!MessageQueue.Exists(messagePath))
            {
                MessageQueue.Create(messagePath);
            }

            messageQueue = new MessageQueue(messagePath);
            messageQueue.Label = "Mesage";
            messageQueue.Send(body.message);

            return "message sent";
        }

        public Message test()
        {
            return new Message
            {
                message = "worked"
            };
        }
    }
}
