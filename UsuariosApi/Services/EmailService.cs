using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class EmailService
    {
        private IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void EnviarEmail(string[] destinatario, string assunto, int usuarioId, string codigoAtivacao)
        {
            Mensagem mensagem = new Mensagem(destinatario, assunto, usuarioId, codigoAtivacao);
            var mensagemDeEmail = CriaCorpoDoEmail(mensagem);
            EnviarEmail(mensagemDeEmail);
        }

        private void EnviarEmail(MimeMessage mensagemDeEmail)
        {
            using (var cliente = new SmtpClient())
            {
                try
                {
                    cliente.Connect(_configuration.GetValue<string>("EmailSettings:StmpServer"), 
                        _configuration.GetValue<int>("EmailSettings:Port"), true);
                    cliente.AuthenticationMechanisms.Remove("XOUATH2");
                    cliente.Authenticate(_configuration.GetValue<string>("EmailSettings:From"),
                        _configuration.GetValue<string>("EmailSettings:Password"));
                    cliente.Send(mensagemDeEmail);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    cliente.Disconnect(true);
                    cliente.Dispose();
                }
            }
        }

        private MimeMessage CriaCorpoDoEmail(Mensagem mensagem)
        {
            var emailMsg = new MimeMessage();
            emailMsg.From.Add(new MailboxAddress(_configuration.GetValue<string>("EmailSettings:From")));
            emailMsg.To.AddRange(mensagem.Destinatario);
            emailMsg.Subject = mensagem.Assunto;
            emailMsg.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mensagem.Conteudo
            };

            return emailMsg;
        }
    }
}
