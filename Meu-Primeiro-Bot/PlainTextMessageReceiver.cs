using System;
using System.Threading;
using System.Threading.Tasks;
using Lime.Protocol;
using Takenet.MessagingHub.Client;
using Takenet.MessagingHub.Client.Listener;
using Takenet.MessagingHub.Client.Sender;
using System.Diagnostics;

namespace MeuPrimeiroBot
{
    public class PlainTextMessageReceiver : IMessageReceiver
    {
        private readonly IMessagingHubSender _sender;

        public PlainTextMessageReceiver(IMessagingHubSender sender)
        {
            _sender = sender;
        }

        public async Task ReceiveAsync(Message message, CancellationToken cancellationToken)
        {
            Trace.TraceInformation($"From: {message.From} \tContent: {message.Content}");
            if (message.Content.ToString().ToUpper().Contains("COMEÇAR") || message.Content.ToString().ToUpper().Contains("GET STARTED"))
            {
                await _sender.SendMessageAsync("Olá! Eu sou um bot chamado Bot!", message.From, cancellationToken);
            }
            else if (message.Content.ToString().ToUpper().Contains("PIADA"))
            {
                string[] jokes =
                {
                    "Por que o cachorro atravessou a rua? Pra chegar do outro lado!",
                    "O que a galinha foi fazer na igreja? Assistir a missa do galo!",
                    "Porque o pombo não bate nos outros animais? Porque ele tem pena!",
                    "Por que na Argentina as Vacas vivem olhando pro céu? Porque tem 'Boi nos Ares'!",
                    "O que disse um pato a outro pato? Estamos empatados!",
                    "Que disse uma pulga a outra pulga? Vamos a pé, ou esperamos um cachorro?",
                    "Por que os elefantes têm medo dos computadores? Por causa do mouse.",
                    "Qual o animal que anda com uma pata? Ora, o pato!",
                    "O que é que dá a vaca depois de um terramoto? Milkshake.",
                    "Por que o cachorro entrou na igreja? Por que a porta estava aberta!"
                };

                Random rnd = new Random();
                int i = rnd.Next(0, jokes.Length);
                await _sender.SendMessageAsync(jokes[i], message.From, cancellationToken);
            }
            else if (message.Content.ToString().ToUpper().Contains("OLÁ") || message.Content.ToString().ToUpper().Contains("OI"))
            {
                await _sender.SendMessageAsync("Olá!", message.From, cancellationToken);
            }
            else if (message.Content.ToString().ToUpper().Contains("BOM DIA"))
            {
                await _sender.SendMessageAsync("Bom dia!", message.From, cancellationToken);
            }
            else if (message.Content.ToString().ToUpper().Contains("BOA TARDE"))
            {
                await _sender.SendMessageAsync("Boa tarde!", message.From, cancellationToken);
            }
            else if (message.Content.ToString().ToUpper().Contains("BOA NOITE"))
            {
                await _sender.SendMessageAsync("Boa noite!", message.From, cancellationToken);
            }
            else if (message.Content.ToString().ToUpper().Contains("KK") || message.Content.ToString().ToUpper().Contains("HAHA"))
            {
                await _sender.SendMessageAsync("Hahahahahaha!", message.From, cancellationToken);
            }
            else
            {
                await _sender.SendMessageAsync("Desculpe! Não entendi.", message.From, cancellationToken);

            }
        }
    }
}
