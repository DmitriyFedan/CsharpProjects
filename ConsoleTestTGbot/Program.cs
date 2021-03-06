using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

/*
Provides extension - обеспечивает расширение
that allow - что позволяет
Recive -  получать



*/




string tokenpath = Path.Combine(@"G:\WORKED\C# projects", "Token TGBOT.txt");
string token = System.IO.File.ReadAllText(tokenpath);
var Bot = new TelegramBotClient(token);

using var cts = new CancellationTokenSource();

// StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.



Bot.StartReceiving(
    HandleUpdateAsync,
    HandleErrorAsync,
    cancellationToken: cts.Token);

var me = await Bot.GetMeAsync();

Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();

// Send cancellation request to stop bot
cts.Cancel();

async Task HandleUpdateAsync(ITelegramBotClient Bot, Update update, CancellationToken cancellationToken)
{
    // Only process Message updates: https://core.telegram.org/bots/api#message
    if (update.Type != UpdateType.Message)
        return;
    // Only process text messages
    if (update.Message!.Type != MessageType.Text)
        return;
    if (update.Message.Text == "/start")
        //NewUser();

    switch (update.Message.Text)
    {
        case "Привет":
            {
                GoNext(Bot,update.Message.Chat.Id);
                break;
            }
        case "Как дела":
            GoNext(Bot, update.Message.Chat.Id);
            Console.WriteLine("1");
            break;
    }
    if (update.Message.Text == "Клавиатура")
        GoNext(Bot,update.Message.Chat.Id);
    
    

    var chatId = update.Message.Chat.Id;
    var messageText = update.Message.Text;

    Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

    // Echo received message text
    Message sentMessage = await Bot.SendTextMessageAsync(
        chatId: chatId,
        text: "You said:\n" + messageText,
        cancellationToken: cancellationToken);
}

Task HandleErrorAsync(ITelegramBotClient Bot, Exception exception, CancellationToken cancellationToken)
{
    var ErrorMessage = exception switch
    {
        ApiRequestException apiRequestException
            => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
        _ => exception.ToString()
    };

    Console.WriteLine(ErrorMessage);
    return Task.CompletedTask;
}

async void GoNext(ITelegramBotClient Bot, ChatId chatId)
{
    ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
    {
    new KeyboardButton[] { "One", "Two" },
    new KeyboardButton[] { "Three", "Four" },
    })
    {
        ResizeKeyboard = true
    };
    Message sentMessage = await Bot.SendTextMessageAsync(
        chatId: chatId,
        text: "Choose a response",
        replyMarkup: replyKeyboardMarkup);
        //cancellationToken: cancellationToken);
}
/*
ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
{
        new KeyboardButton[] { "One", "Two" },
        new KeyboardButton[] { "Three", "Four" },
    })
{
    ResizeKeyboard = true
};
/*
Message sentMessage = await Bot.SendTextMessageAsync(
    chatId: chatId,
    text: "Choose a response",
    replyMarkup: replyKeyboardMarkup,
    cancellationToken: cancellationToken);
*/
