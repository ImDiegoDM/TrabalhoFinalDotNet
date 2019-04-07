# TRABALHO PRÁTICO DE .NET

## Requisitos de tecnologia

* O Trabalho consiste em fazer comunicação entre camadas no .NET
* As portas de entradas são Web.Api e o Web Services. Os métodos recebem uma string como parâmetro e “passa para as outras camadas”. 
* Utilizando Httpclient ou RestSharp será realizado uma chamada (post ou get) para o WCF (rest). 
* O WCF vai colocar uma mensagem no MSMQ. 

Vai ter outro WCF que vai ficar lendo a fila e gravando em algum BD (pode ser qualquer BD).



![alt text](https://github.com/weto/TrabalhoFinalDotNet/blob/master/trabalho_dotnet.png)


