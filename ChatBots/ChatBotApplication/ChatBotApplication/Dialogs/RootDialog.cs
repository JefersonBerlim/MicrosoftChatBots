using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System.Collections.Generic;

namespace ChatBotApplication.Dialogs
{
    [LuisModel("d4716100-1765-4c51-819f-53c35afc7fac", "aac0ecff427348e4a98abc674c96af9a")]
    [Serializable]
    public class RootDialog : LuisDialog<object>
    {
        public RootDialog() { }

        [LuisIntent("BaixarNfe")]
        public async Task BaixarNfe(IDialogContext context, LuisResult result)
        {

            var attachment = GetHeroCard();

            var message = context.MakeMessage();

            message.Attachments.Add(attachment);

            await context.PostAsync(message);

        }

        private static Attachment GetHeroCard()
        {
            var heroCard = new HeroCard
            {
                Title = "Download de NF-e Microvix",
                Subtitle = "Como você pode baixar o XML da NF-e para seu PC",
                Text = $" Para baixar o XML de uma NF-e, deve-se acessar o módulo NFe no menu, buscar pela nota e clicar em baixar NF-e. " +
                        " Cuidado, pois deve-se ter as permissõe necessárias para ter acesso ao Módulo.",
                Images = new List<CardImage> { new CardImage("https://sec.ch9.ms/ch9/7ff5/e07cfef0-aa3b-40bb-9baa-7c9ef8ff7ff5/buildreactionbotframework_960.jpg") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Assisir Vídeo", value: "https://www.youtube.com/watch?v=Zb0T5woTSnc&list=PLxzoU_Ud-MeJK3Du_lT6XqodzWkpnj8Ra") }
            };

            return heroCard.ToAttachment();
        }

        [LuisIntent("EntradaComprasXML")]
        public async Task EntradaComprasXML(IDialogContext context, LuisResult result)
        {
            var attachment = GetVideoCard();

            var message = context.MakeMessage();

            message.Attachments.Add(attachment);

            await context.PostAsync(message);
        }

        private static Attachment GetVideoCard()
        {
            var videoCard = new VideoCard
            {
                Title = "Linx Microvix - Entrada de Compras via XML",
                Subtitle = "#DicaLinx",
                Text = $" Olá, seja bem-vindo a mais uma Dica Linx. " +
                " Quando o fornecedor emite a Nota Fiscal Eletrônica, também são gerados o Danfe e o arquivo XML com as informações da nota."+
                " No Linx Microvix ERP é possível realizar a entrada de compras através do upload deste arquivo XML, atualizando assim, o saldo dos itens no sistema."+
                " Além disso, produtos que estão no arquivo porém não constam no Microvix ERP, poderão ser incluídos automaticamente através desta rotina.",
               Image = new ThumbnailUrl
                {
                    Url = "https://linx-files.s3.amazonaws.com/linx/static/app/logo-rs.png.png"
                },
                Media = new List<MediaUrl>
                {
                    new MediaUrl()
                    {
                        Url = "https://www.youtube.com/watch?v=rtQzxkfquCo&index=6&list=PLxzoU_Ud-MeJK3Du_lT6XqodzWkpnj8Ra"
                    }
                },
                Buttons = new List<CardAction>
                {
                    new CardAction()
                    {
                        Title = "Acesar Youtube",
                        Type = ActionTypes.OpenUrl,
                        Value = "https://www.youtube.com/watch?v=Zb0T5woTSnc&list=PLxzoU_Ud-MeJK3Du_lT6XqodzWkpnj8Ra"
                    }
                }
            };

            return videoCard.ToAttachment();
        }

        [LuisIntent("LogarMicrovix")]
        public async Task LogarMicrovix(IDialogContext context, LuisResult result)
        {
            var attachment = GetSigninCard();

            var message = context.MakeMessage();

            message.Attachments.Add(attachment);

            await context.PostAsync(message);
        }

        private static Attachment GetSigninCard()
        {
            var signinCard = new SigninCard
            {
                Text = "BotFramework Login Microvix",
                Buttons = new List<CardAction> { new CardAction(ActionTypes.Signin, "Login ERP Microvix", value: "http://erp.microvix.com.br") }
            };

            return signinCard.ToAttachment();
        }

        [LuisIntent("AtualizarPOS")]
        public async Task AtualizarPOS(IDialogContext context, LuisResult result)
        {
            var attachment = GetThumbnailCard();

            var message = context.MakeMessage();

            message.Attachments.Add(attachment);

            await context.PostAsync(message);
        }

        private static Attachment GetThumbnailCard()
        {
            var heroCard = new ThumbnailCard
            {
                Title = "Linx Microvix - Atualização POS",
                Subtitle = "#DicaLinx",
                Text = $" Um pré requisito para realizar o processo de atualização do Linx Microvix POS é ter o POS instalado no computador."+
                        " Na página inicial do Linx Microvix ERP, no Dashboard, é necessário navegar até o grupo POS, onde será apresentada uma mensagem com três links."+
                        " Ao Localizar o link do atualizador é necessário clicar para realizar o download.",
                Images = new List<CardImage> { new CardImage("https://linx-files.s3.amazonaws.com/linx/static/app/logo-rs.png.png") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Get Started", value: "https://www.youtube.com/watch?v=CSLtUY8rYYI") }
            };

            return heroCard.ToAttachment();
        }

        [LuisIntent("VendaValeProduto")]
        public async Task VendaValeProduto(IDialogContext context, LuisResult result)
        {
            var attachment = GetAudioCard();

            var message = context.MakeMessage();

            message.Attachments.Add(attachment);

            await context.PostAsync(message);
        }

        private static Attachment GetAudioCard()
        {
            var audioCard = new AudioCard
            {
                Title = "Linx POS - Venda de Vale Produto e sua utilização",
                Subtitle = "#DicaLinx",
                Text = " Vamos iremos aprender a realizar vendas com Vale Produto, enviar para validação na retaguarda e devolver para utilização no Linx POS.",
                Image = new ThumbnailUrl
                {
                    Url = "https://linx-files.s3.amazonaws.com/linx/static/app/logo-rs.png.png"
                },
                Media = new List<MediaUrl>
                {
                    new MediaUrl()
                    {
                        Url = "https://www.youtube.com/watch?v=2of1YE9cRcE"
                    }
                },
                Buttons = new List<CardAction>
                {
                    new CardAction()
                    {
                        Title = "Veja Mais",
                        Type = ActionTypes.OpenUrl,
                        Value = "https://www.youtube.com/watch?v=2of1YE9cRcE"
                    }
                }
            };

            return audioCard.ToAttachment();
        }

        [LuisIntent("BoasVindas")]
        public async Task BoasVindas(IDialogContext context, LuisResult result)
        {

            var attachment = GetAnimationCard();

            var message = context.MakeMessage();

            message.Attachments.Add(attachment);

            await context.PostAsync(message);

        }

        private static Attachment GetAnimationCard()
        {
            var animationCard = new AnimationCard
            {
                Title = "Microsoft Bot Framework",
                Subtitle = "Animation Card",
                Image = new ThumbnailUrl
                {
                    Url = "https://docs.microsoft.com/en-us/bot-framework/media/how-it-works/architecture-resize.png"
                },
                Media = new List<MediaUrl>
                {
                    new MediaUrl()
                    {
                        Url = "http://i.giphy.com/3nS8PC27Fwsqk.gif"
                    }
                }
            };

            return animationCard.ToAttachment();
        }

        [LuisIntent("LancarFaturaAvulsaMCX")]
        public async Task LancarFaturaAvulsa(IDialogContext context, LuisResult result)
        {

            var attachment = GetCardsAttachments();

            var message = context.MakeMessage();

            message.Attachments = attachment;

            message.AttachmentLayout = AttachmentLayoutTypes.Carousel;

            await context.PostAsync(message);
        }

        private static IList<Attachment> GetCardsAttachments()
        {
            return new List<Attachment>()
            {
                GetHeroCard(
                    "Linx Microvix ERP - Lançamento de faturas avulsas",
                    "#DicaLinx",
                    "Para lançar uma fatura avulsa no Linx Microvix ERP é necessário acessar 'Adm. / Financeiro - Contas a Receber - Lançamento de faturas",
                    new CardImage(url: "https://linx-files.s3.amazonaws.com/linx/static/app/logo-rs.png.png"),
                    new CardAction(ActionTypes.OpenUrl, "Learn more", value: "https://www.youtube.com/watch?v=bzIJ5rJ7l2E")),
                GetThumbnailCard(
                    "Linx Microvix ERP - Lançamento de faturas avulsas",
                    "#DicaLinx",
                    "Para lançar uma fatura avulsa no Linx Microvix ERP é necessário acessar 'Adm. / Financeiro - Contas a Receber - Lançamento de faturas",
                    new CardImage(url: "https://linx-files.s3.amazonaws.com/linx/static/app/logo-rs.png.png"),
                    new CardAction(ActionTypes.OpenUrl, "Learn more", value: "https://www.youtube.com/watch?v=bzIJ5rJ7l2E")),
                GetHeroCard(
                    "Linx Microvix ERP - Lançamento de faturas avulsas",
                    "#DicaLinx",
                    "Para lançar uma fatura avulsa no Linx Microvix ERP é necessário acessar 'Adm. / Financeiro - Contas a Receber - Lançamento de faturas",
                    new CardImage(url: "https://linx-files.s3.amazonaws.com/linx/static/app/logo-rs.png.png"),
                    new CardAction(ActionTypes.OpenUrl, "Learn more", value: "https://www.youtube.com/watch?v=bzIJ5rJ7l2E")),
                GetThumbnailCard(
                    "Linx Microvix ERP - Lançamento de faturas avulsas",
                    "#DicaLinx",
                    "Para lançar uma fatura avulsa no Linx Microvix ERP é necessário acessar 'Adm. / Financeiro - Contas a Receber - Lançamento de faturas",
                    new CardImage(url: "https://linx-files.s3.amazonaws.com/linx/static/app/logo-rs.png.png"),
                    new CardAction(ActionTypes.OpenUrl, "Learn more", value: "https://www.youtube.com/watch?v=bzIJ5rJ7l2E")),
            };
        }

        [LuisIntent("ReceiptCard")]
        public async Task ReceiptCard(IDialogContext context, LuisResult result)
        {

            var attachment = GetReceiptCard();

            var message = context.MakeMessage();

            message.Attachments.Add(attachment);

            await context.PostAsync(message);
        }

        private static Attachment GetReceiptCard()
        {
            var receiptCard = new ReceiptCard
            {
                Title = "John Doe",
                Facts = new List<Fact> { new Fact("Order Number", "1234"), new Fact("Payment Method", "VISA 5555-****") },
                Items = new List<ReceiptItem>
                {
                    new ReceiptItem("Data Transfer", price: "$ 38.45", quantity: "368", image: new CardImage(url: "https://github.com/amido/azure-vector-icons/raw/master/renders/traffic-manager.png")),
                    new ReceiptItem("App Service", price: "$ 45.00", quantity: "720", image: new CardImage(url: "https://github.com/amido/azure-vector-icons/raw/master/renders/cloud-service.png")),
                },
                Tax = "$ 7.50",
                Total = "$ 90.95",
                Buttons = new List<CardAction>
                {
                    new CardAction(
                        ActionTypes.OpenUrl,
                        "More information",
                        "https://account.windowsazure.com/content/6.10.1.38-.8225.160809-1618/aux-pre/images/offer-icon-freetrial.png",
                        "https://azure.microsoft.com/en-us/pricing/")
                }
            };

            return receiptCard.ToAttachment();
        }

        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Desculpe, Eu não entendi '{result.Query}'.";

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }

        private static Attachment GetHeroCard(string title, string subtitle, string text, CardImage cardImage, CardAction cardAction)
        {
            var heroCard = new HeroCard
            {
                Title = title,
                Subtitle = subtitle,
                Text = text,
                Images = new List<CardImage>() { cardImage },
                Buttons = new List<CardAction>() { cardAction },
            };

            return heroCard.ToAttachment();
        }

        private static Attachment GetThumbnailCard(string title, string subtitle, string text, CardImage cardImage, CardAction cardAction)
        {
            var heroCard = new ThumbnailCard
            {
                Title = title,
                Subtitle = subtitle,
                Text = text,
                Images = new List<CardImage>() { cardImage },
                Buttons = new List<CardAction>() { cardAction },
            };

            return heroCard.ToAttachment();
        }
    }
}