using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace bottelega.classes
{
    class start
    {
        private static ITelegramBotClient botClient;
        public static void Start()
        {

            botClient = new TelegramBotClient("1425957030:AAG6MkJTg_CTFGNnrV685ao38KctbH8dkhQ") { Timeout = TimeSpan.FromSeconds(10) };
            var bot = botClient.GetMeAsync().Result;
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();

            Console.ReadKey();
            botClient.StopReceiving();
        }
        private async static void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            var text = e?.Message?.Text;
            if (text == null)
                return;
            try
            {
                var weatherText = weather.Show_Api(text);
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: $"Сейчас в городе {text}: \n{weatherText}\n\n" +
                          $"Введите другой город"
                    ).ConfigureAwait(false);
            }
            catch (Exception)
            {
                await botClient.SendTextMessageAsync(
            chatId: e.Message.Chat,
            text: "Напишите город"
            ).ConfigureAwait(false);
            }
        }
    }
}
