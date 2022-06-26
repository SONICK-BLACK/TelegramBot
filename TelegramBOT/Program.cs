using System;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System.Linq;

using System.Drawing;
//sing System.Windows.Controls;
//using System.Drawing.Common;
using System.Data;

using System.Net.Http.Headers;
using System.ComponentModel;
using System.Net.Http;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBOT
{

   struct Pogoda
    {
        public string temp1;
        public string wind_speed1;
        public string pressure_mm1;
        public string Condition;
        public string icon;

    }

    class Program
    {
        static string tem1;
        //static string wind_speed1;

        private static Pogoda Mosc;
        private static Pogoda Ufa;
        private static int schet = new int();
        private static int schet1 = new int();
        private static Pogoda Magnit;
        private const string token = "5458773887:AAEzl_r6PkeCvBnomvCimQn5lax09y8J5hg";
        private bool set;
        private static readonly TelegramBotClient client = new TelegramBotClient(token);

        static async Task Main(string[] args)
        {
            Dictionary<String, String> lang = new Dictionary<String, String>()
            {
                { "clear", "ясно." },
                { "partly-cloudy", "малооблачно." },
{ "cloudy",  "облачно с прояснениями." },
{ "overcast",  "пасмурно."},
{"drizzle", "морось."},
{"light-rain",  "небольшой дождь."},
{"rain",  "дождь."},
{"moderate-rain",  "умеренно сильный дождь."},
{"heavy-rain", "сильный дождь."},
{"continuous-heavy-rain", "длительный сильный дождь."},
{"showers", "ливень."},
{"wet-snow", "дождь со снегом."},
{"light-snow", "небольшой снег."},
{"snow", "снег."},
{"snow-showers", "снегопад."},
{"hail", "град."},
{"thunderstorm", "гроза."},
{"thunderstorm-with-rain",  "дождь с грозой."},
{ "thunderstorm-with-hail",  "гроза с градом." }
            };
               ReceiverOptions receiverOptions = new ReceiverOptions();

            using var cts = new CancellationTokenSource();
           HttpClient cl = new HttpClient();
              cl.DefaultRequestHeaders.Add("X-Yandex-API-Key", "1462b43a-e2e2-44ca-a6b1-4a3b153afbbe");
            var repons = cl.GetAsync("https://api.weather.yandex.ru/v2/forecast?lat=53.407164&lon=58.9802858&extra=true&lang=ru_RU").Result;
           dynamic js = JObject.Parse(repons.Content.ReadAsStringAsync().Result);
            Magnit.temp1 = js.fact.temp;
            Magnit.wind_speed1 = js.fact.wind_speed;
           Magnit.pressure_mm1= js.fact.pressure_mm;
            string h = js.fact.condition;
            Magnit.Condition = lang[h];

             var repons2 = cl.GetAsync("https://api.weather.yandex.ru/v2/forecast?lat=54.735152&lon=55.958736&extra=true&lang=ru_RU").Result;

             dynamic js2 = JObject.Parse(repons2.Content.ReadAsStringAsync().Result);
             Ufa.temp1 = js2.fact.temp;
            Ufa.wind_speed1 = js2.fact.wind_speed;
            Ufa.pressure_mm1 = js2.fact.pressure_mm;
            string h2 = js2.fact.condition;
            Ufa.Condition = lang[h2];
           // Ufa.Condition = js.fact.condition;

            var repons3 = cl.GetAsync("https://api.weather.yandex.ru/v2/forecast?lat=55.755819&lon=37.617644&extra=true&lang=ru_RU&limit=2").Result;

            dynamic js3 = JObject.Parse(repons3.Content.ReadAsStringAsync().Result);
        //    dynamic js33 = JObject.Parse(js3.Last.First);

             Mosc.temp1 = js3.fact.temp;
         Mosc.icon=   js3.fact.icon;
        //    Console.WriteLine(Mosc.temp1 = js3.fact.temp);
             Mosc.wind_speed1 = js3.fact.wind_speed;
           Mosc.pressure_mm1 = js3.fact.pressure_mm;
            string h1 = js3.fact.condition;
            Mosc.Condition = lang[h1];
            //Mosc.Condition = js.fact.condition;
          
            



            client.StartReceiving(updateHandler: HandleUpdateAsync, HandlePollingErrorAsync,
        receiverOptions: receiverOptions,
        cancellationToken: cts.Token);
            
            while (true) ;
        }

        static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            bool sett = true;

          







            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
    {
        new KeyboardButton[] { "Покажи мне прекрассное", "Леонарда Телеграм искать голубку😍" },
        new KeyboardButton[] { "Леонарда Телеграм💌❤️ Создать Аккаунт", "Я тебя люблю","погода" },
        new KeyboardButton[] {"V 1.0.5"}

    });
            ReplyKeyboardMarkup markup2 = new ReplyKeyboardMarkup(new[]
            {
                new KeyboardButton[]{"Магнитогорск", "Уфа" , "Москва" }
            });


           // update.Message.Photo

           var msg = update.Message.Text;
            Console.WriteLine(msg);
            Console.WriteLine(update.Message.Photo);
           // Console.WriteLine(update.Message.Photo[update.Message.Photo.Count() - 1].FileId);
            if (msg == "Покажи мне прекрассное")
            {

                client.SendPhotoAsync(update.Message.Chat.Id, "https://yandex.ru/images/search?from=tabbar&text=%D0%B0%D0%BD%D0%B6%D0%B5%D0%BB%D0%B8%D0%BD%D0%B0%20%D0%B4%D0%B6%D0%BE%D0%BB%D0%B8%20%D0%B2%20%D0%BC%D0%B0%D0%BB%D0%B5%D1%84%D0%B8%D1%81%D0%B5%D0%BD%D1%82%D0%B5%202&pos=14&img_url=https%3A%2F%2Fpbs.twimg.com%2Fmedia%2FEJDbwJ3WwAENE9l.jpg&rpt=simage&lr=10747", parseMode: ParseMode.Html);
                client.SendPhotoAsync(update.Message.Chat.Id, "https://yandex.ru/images/search?from=tabbar&text=%D0%B0%D0%BD%D0%B6%D0%B5%D0%BB%D0%B8%D0%BD%D0%B0%20%D0%B4%D0%B6%D0%BE%D0%BB%D0%B8%20%D0%B2%20%D0%BC%D0%B0%D0%BB%D0%B5%D1%84%D0%B8%D1%81%D0%B5%D0%BD%D1%82%D0%B5%202&pos=25&img_url=https%3A%2F%2Fpbs.twimg.com%2Fmedia%2FEOua00UWoAcO3Dv.jpg&rpt=simage&lr=10747", parseMode: ParseMode.Html);
                client.SendPhotoAsync(update.Message.Chat.Id, "https://vk.com/frost_the_dog?z=photo529341252_457242042%2Fphotos529341252", parseMode: ParseMode.Html);
            
                sett = false;
            }
            if(msg== "Леонарда Телеграм💌❤️ Создать Аккаунт" && !(schet1 == 0))
            {
                client.SendPhotoAsync(update.Message.Chat.Id, "https://vk.com/frost_the_dog?z=photo529341252_457242042%2Fphotos529341252",  "Привет. Хочешь найти свою голубку?"+"\n"+"Начнем тогда заполнять форму:"+ "\n"+ "Сколько Вам лет(возраст должен заканчиваться словом лет):");
               // client.SendTextMessageAsync(update.Message.Chat.Id, "Сколько Вам лет(возраст должен заканчиваться словом лет):");
                schet += 1;
                sett = false;
               // string msgLeo;
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
            if(msg== "Леонарда Телеграм искать голубку😍" && schet != 0)
            {
                client.SendTextMessageAsync(update.Message.Chat.Id, "Введите номер профиля заканчивая /n(Сейчас в боте профилей:"+ schet+"):");
                sett = false;
                //   using(StreamReader red = new StreamReader("B:\\Teleg_bot_Leo/" + schet.ToString() + ".txt"))
            }
            if (msg == "Я тебя люблю")
            {
                client.SendTextMessageAsync(update.Message.Chat.Id, "И я тебя мой друг)))");
                string image = Path.Combine(Environment.CurrentDirectory, "B:\\Teleg_bot_Leo/1.jpg");
                using(var str= System.IO.File.OpenWrite("B:\\Teleg_bot_Leo/1.jpg"))
                {
                   // client.Se(update.Message.Chat.Id, str);
                }
               client.SendPhotoAsync(update.Message.Chat.Id, "AgACAgIAAxkBAAIEA2KrO7FDQdaeoT4Ox1qxv-LKTYZzAAIcuzEbuGdYSR5PtQoXxlq6AQADAgADeAADJAQ");
                sett = false;
                //   client.SendStickerAsync(update.Message.Chat.Id, "https://yandex.ru/images/search?pos=11&img_url=https%3A%2F%2Fstatic.wixstatic.com%2Fmedia%2F270c64_d0f0c7e3fe644abcb1d22652c224474d~mv2.gif%2Fv1%2Ffit%2Fw_1000%252Ch_1000%252Cal_c%252Cq_80%2Ffile.gif&text=%D1%81%D1%82%D0%B8%D0%BA%D0%B5%D1%80%20%D0%BB%D1%8E%D0%B1%D0%BE%D0%B2%D1%8C&lr=10747&rpt=simage&source=serp");
                //Bird of Paradise
            }
            if (msg == "погода")
            {
              
                client.SendTextMessageAsync(update.Message.Chat.Id, "Введите город", replyMarkup: markup2);

                sett = false;



            }
        if(msg == "Москва")
        {
             //   Console.WriteLine("москва");
                
            client.SendTextMessageAsync(update.Message.Chat.Id, "Температура:"+ Mosc.temp1 + " "+"Градусов"+ "🌡"+ "\n" + "Давление:"  + Mosc.pressure_mm1+ "мм.рт.стл"+ "\n" + "Скорость ветра:" + Mosc.wind_speed1 + "м/c" + "\n" + "Обещается:" + " " + Mosc.Condition, replyMarkup: replyKeyboardMarkup);
               // client.SendPhotoAsync(update.Message.Chat.Id, "https://yastatic.net/weather/i/icons/funky/dark/" + Mosc.icon + ".svg", parseMode: ParseMode.Html);
                //  client.SendTextMessageAsync(update.Message.Chat.Id, "Введите город"
              //  Console.WriteLine("москва123");
               
                sett = false;
           }
            if (msg == "Магнитогорск")
            {


                client.SendTextMessageAsync(update.Message.Chat.Id, "Температура:" + Magnit.temp1 + " " + "Градусов"+ "🌡" + "\n" + "Давление:" + Magnit.pressure_mm1+"мм.рт.стл"+ "\n" + "Скорость ветра:" + Magnit.wind_speed1+ "м/c"+ "\n"+"Обещается:"+" "+Magnit.Condition, replyMarkup: replyKeyboardMarkup);
                //  client.SendTextMessageAsync(update.Message.Chat.Id, "Введите город"
                sett = false;
            }
            if (msg == "Уфа")
            {
                
              
              client.SendTextMessageAsync(update.Message.Chat.Id, "Температура:" + Ufa.temp1+ " "+ "Градусов" + "🌡" + "\n" + "Давление:" + Ufa.pressure_mm1 + "мм.рт.стл"+ "\n" + "Скорость ветра:" + Ufa.wind_speed1 + "м/c" + "\n" + "Обещается:" + " " + Ufa.Condition, replyMarkup: replyKeyboardMarkup);
                //  client.SendTextMessageAsync(update.Message.Chat.Id, "Введите город"
             sett = false;
          }
          // if (update.Message.Photo.Length != null)

        // {
                //var test = await client.GetFileAsync(update.Message.Photo[update.Message.Photo.Count() - 1].FileId);

               // var image = Bitmap.FromStream(test.FileStream);

             //   image.Save(@"C:\\Users\xxx\Desktop\test.png");
             //   var ph = await client.GetFileAsync(update.Message.Photo[update.Message.Photo.Count() - 1].FileId);
              //  Console.WriteLine(update.Message.Photo[update.Message.Photo.Count() - 1].FileId);
           //    using (var fileStream = System.IO.File.OpenWrite("B:\\TelegramPhoto/3.jpg"))
              // {
               //    var Fileinfo = await client.GetInfoAndDownloadFileAsync(update.Message.Photo[update.Message.Photo.Count() - 1].FileId, fileStream);
              //  }
                    //var filestream = ph.Create("B:\\TelegramPhoto");
                    //  using(MemoryStream str = new MemoryStream(ph))
                    //  {
                    //  using (var img = FileStream(ph,FileMode.Create)
                    // {
                    //  img.Save("B:\\TelegramPhoto");
                    //  }
                    //  }
                 //   Console.WriteLine(update.Message.Photo);
          // }
            if (sett)
                client.SendTextMessageAsync(update.Message.Chat.Id, "хай", replyMarkup: replyKeyboardMarkup);
            if (update.Message.Photo==null)
            {

                if (msg.Contains("/n") && !(schet1 == 0) && !(schet == 0))
                {
                    int hh  =msg.IndexOf("/n");
                    string msg11 =msg.Remove(hh);
                    dynamic mef;
                    string mm;
                    string mm1= null;
                    string me = null;
                    string me1;
                    using (StreamReader red = new StreamReader("B:\\Teleg_bot_Leo/" + msg11 + ".txt"))
                    {
                        while((mm=await red.ReadLineAsync()) != null)
                        {
                            mm1 += mm + "\n";
                        }
                  
                       // mef = JObject.Parse(mm);
                    }
                    using(var red1 = new StreamReader("B:\\Teleg_bot_Leo/" + msg11 + "p" + ".txt"))
                    {
                        while ((me1 = await red1.ReadLineAsync()) != null)
                        {
                            me +=me1 ;
                        }
                    }
                    // string Ye = mef.Person.Years;
                    // string Name = mef.Person.NameFull;
                    //  string inf = mef.Person.inf;
                    // client.SendTextMessageAsync(update.Message.Chat.Id, Ye + "\n"+ Name + "\n" + inf, replyMarkup: replyKeyboardMarkup);
                //  client.SendTextMessageAsync(update.Message.Chat.Id, mm1, replyMarkup: replyKeyboardMarkup);
                    client.SendPhotoAsync(update.Message.Chat.Id, me, mm1, replyMarkup: replyKeyboardMarkup);
                    Console.WriteLine(me);
                }
                    if (msg.Contains("лет") && !(schet1 == 0))
                {
                    //  string msgLeo = "{Person:{ NameFull:{" + msg + "}" + "}}";

                    client.SendTextMessageAsync(update.Message.Chat.Id, "Как вас зовут, Имя Фамилия(Вконце должно быть слово имя):");
                    using (StreamWriter stream = new StreamWriter("B:\\Teleg_bot_Leo/" + schet.ToString() + ".txt", false))
                    {
                        //stream.WriteAsync("{Person:{ Years:{" + msg + "}");
                        int ger = msg.IndexOf("лет");
                        string msg12 = msg.Remove(ger);
                        stream.WriteLineAsync(msg12);
                    }
                    sett = false;
                    //  msgLeo = "{Person:{ NameFull:{" + msg + "}" + "}}";
                }
                if (msg.Contains("имя") && !(schet1 == 0))
                {
                    //string msgLeo1 = "info:{"+msg+"}";
                    client.SendTextMessageAsync(update.Message.Chat.Id, "Расскажите дополнительную инфу(Вконце должно быть слово /info):");
                    using (StreamWriter stream = new StreamWriter("B:\\Teleg_bot_Leo/" + schet + ".txt", true))
                        
                    {
                        int ger = msg.IndexOf("имя");
                        string msg12 = msg.Remove(ger);
                        //stream.WriteAsync("NameFull:{" + msg + "}");
                        stream.WriteLineAsync(msg12);
                    }
                    sett = false;
                }
                if (msg.Contains("/info") && !(schet1 == 0))
                {
                    client.SendTextMessageAsync(update.Message.Chat.Id, "А теперь фото профиля:");
                    using (StreamWriter stream = new StreamWriter("B:\\Teleg_bot_Leo/" + schet + ".txt", true))
                    {
                       // stream.WriteLineAsync("inf:{" + msg + "}" + "}}");
                        int ger = msg.IndexOf("/info");
                        string msg12 = msg.Remove(ger);
                        stream.WriteLineAsync(msg12);
                    }
                    sett = false;
                }
            }
            if (update.Message.Photo != null && !(schet1 == 0))

                {
                while (update.Message.Photo.Length == null) ;
                // using (var fileStream = System.IO.File.OpenWrite("B:\\Teleg_bot_Leo/"+ schet +".jpg"))
                // {
                //  var Fileinfo = await client.GetInfoAndDownloadFileAsync(update.Message.Photo[update.Message.Photo.Count() - 1].FileId, fileStream);
                // }
                using (StreamWriter stream = new StreamWriter("B:\\Teleg_bot_Leo/" + schet + "p"+".txt", true))
                {
                    stream.WriteLineAsync(update.Message.Photo[update.Message.Photo.Count() - 1].FileId);
                }
                    Console.WriteLine(update.Message.Photo[update.Message.Photo.Count() - 1].FileId);
              //  using (var filestream = System.IO.File.OpenWrite("B:\\Teleg_bot_Leo/1.jpg"))
             //       {
                   //     var f =client.GetInfoAndDownloadFileAsync(update.Message.Photo[update.Message.Photo.Count() - 1].FileId, filestream);
                 //   }
                }

            schet1 += 1;

        }
        private static async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {

        }
    }
}

