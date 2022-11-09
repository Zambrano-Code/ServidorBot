using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using bot.funciones;

namespace bot.events
{
    public class CommandHandler
    {

        private readonly DiscordSocketClient _client;
        private readonly CommandService _commands;

        private configJson config = new configJson();


        public CommandHandler(DiscordSocketClient client, CommandService commands)
        {
            _client = client;
            _commands = commands;

        }

        public async Task InstallCommandsAsync()
        {
            _client.MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(assembly: Assembly.GetEntryAssembly(), services: null);
        }
        private async Task HandleCommandAsync(SocketMessage messageParam)
        {
            var message = messageParam as SocketUserMessage;
            if (message == null) return;

            // Create a number to track where the prefix ends and the command begins
            int argPos = 0;

            // Determine if the message is a command based on the prefix and make sure no bots trigger commands
            if (!message.HasStringPrefix(config.bot.Prefix, ref argPos) || message.HasMentionPrefix(_client.CurrentUser, ref argPos) || message.Author.IsBot)
            {
                return;
            }
            var context = new SocketCommandContext(_client, message);

            await _commands.ExecuteAsync(context: context, argPos: argPos, services: null);
        }
    }

}
