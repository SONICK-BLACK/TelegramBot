using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types.ReplyMarkups;
//using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBOT
{
    class Program
    {
        private const string token = "5458773887:AAEzl_r6PkeCvBnomvCimQn5lax09y8J5hg";
        private bool set;
        private  static readonly TelegramBotClient client = new TelegramBotClient(token);

        static async Task Main(string[] args)
        {
              ReceiverOptions receiverOptions = new ReceiverOptions();
           // receiverOptions.Limit = 1;
           // receiverOptions.AllowedUpdates = Array.Empty<UpdateType>();
                using var cts = new CancellationTokenSource();
          
            var me = await client.GetMeAsync();
            Console.WriteLine(me.Username);
            Thread.Sleep(1000);
                client.StartReceiving(updateHandler: HandleUpdateAsync, HandlePollingErrorAsync,
        receiverOptions: receiverOptions,
        cancellationToken: cts.Token);
            // Thread.Sleep(1000);
            //cts.Cancel();
            while (true) ;
    }

        static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            bool sett = true;
            // KeyboardButton button = new KeyboardButton("hi");
            //KeyboardButton button1 = new KeyboardButton("Hey");
            string[,] buttons = new string[1, 2]
            {
               { "one", "two" }
            };


            //{ "Hi","To" }

            // string[,] array2Db = new string[3, 2] { { "one", "two" }, { "three", "four" },
            //   { "five", "six" } };
            //   ReplyKeyboardMarkup[,] board = new ReplyKeyboardMarkup[1,2];
          



            // ReplyKeyboardMarkup board = new ReplyKeyboardMarkup(button, button1);
            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
    {
        new KeyboardButton[] { "Покажи мне прекрассное", "Ты плохой" },
        new KeyboardButton[] { "Я тебя не навижу", "Я тебя люблю" },
    });
            //  {
            //   ResizeKeyboard = true
            //};
            // ReplyKeyboardMarkup board1 = new ReplyKeyboardMarkup("two");



            var msg = update.Message.Text;
            if (msg == "Покажи мне прекрассное")
            {
                
                client.SendPhotoAsync(update.Message.Chat.Id, "https://yandex.ru/images/search?from=tabbar&text=%D0%B0%D0%BD%D0%B6%D0%B5%D0%BB%D0%B8%D0%BD%D0%B0%20%D0%B4%D0%B6%D0%BE%D0%BB%D0%B8%20%D0%B2%20%D0%BC%D0%B0%D0%BB%D0%B5%D1%84%D0%B8%D1%81%D0%B5%D0%BD%D1%82%D0%B5%202&pos=14&img_url=https%3A%2F%2Fpbs.twimg.com%2Fmedia%2FEJDbwJ3WwAENE9l.jpg&rpt=simage&lr=10747", parseMode: ParseMode.Html);
                client.SendPhotoAsync(update.Message.Chat.Id, "https://yandex.ru/images/search?from=tabbar&text=%D0%B0%D0%BD%D0%B6%D0%B5%D0%BB%D0%B8%D0%BD%D0%B0%20%D0%B4%D0%B6%D0%BE%D0%BB%D0%B8%20%D0%B2%20%D0%BC%D0%B0%D0%BB%D0%B5%D1%84%D0%B8%D1%81%D0%B5%D0%BD%D1%82%D0%B5%202&pos=25&img_url=https%3A%2F%2Fpbs.twimg.com%2Fmedia%2FEOua00UWoAcO3Dv.jpg&rpt=simage&lr=10747", parseMode: ParseMode.Html);
                sett = false;
            }
            if (msg == "Ты плохой")
            {
                client.SendTextMessageAsync(update.Message.Chat.Id, "Почему?(((");
                sett = false;
            }
            if (msg == "Я тебя не навижу")
            {
                client.SendTextMessageAsync(update.Message.Chat.Id, "Да пошёл ты");
                sett = false;
            }
            if (msg == "Я тебя люблю")
            {
                client.SendTextMessageAsync(update.Message.Chat.Id, "И я тебя мой друг)))");
                sett = false;
             //   client.SendStickerAsync(update.Message.Chat.Id, "https://yandex.ru/images/search?pos=11&img_url=https%3A%2F%2Fstatic.wixstatic.com%2Fmedia%2F270c64_d0f0c7e3fe644abcb1d22652c224474d~mv2.gif%2Fv1%2Ffit%2Fw_1000%252Ch_1000%252Cal_c%252Cq_80%2Ffile.gif&text=%D1%81%D1%82%D0%B8%D0%BA%D0%B5%D1%80%20%D0%BB%D1%8E%D0%B1%D0%BE%D0%B2%D1%8C&lr=10747&rpt=simage&source=serp");
                //Bird of Paradise
            }
            if (sett)
            client.SendTextMessageAsync(update.Message.Chat.Id, "хай", replyMarkup: replyKeyboardMarkup);
            Console.WriteLine(msg);

            //    client.SendTextMessageAsync(update.Message.Chat.Id, "хай", replyMarkup: board);
           
            
          //  Thread.Sleep(1000);
            // await throw new NotImplementedException();

        }
        private static async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {

        }
    }
}
