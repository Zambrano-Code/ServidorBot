using Discord.WebSocket;
using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Newtonsoft.Json;

using bot.events;
using bot.funciones;
using bot.acciones;
using bot.actividad;
using bot.mysql;

namespace bot
{
    public class Bot
    {
        public static DiscordSocketClient? _cliente { get; private set; }
        private DiscordSocketConfig? _discordConfig { get; set; }
        private CommandService _commandService { get; set; }
        private CommandHandler? _handler { get; set; }


        private configJson config = new configJson();

        public Bot()
        {

        }

        public async Task MainAsyn()
        {

            new ConectMysql();

            _discordConfig = new DiscordSocketConfig
            {
                AlwaysDownloadUsers = true,
                MessageCacheSize = 100,
                GatewayIntents = GatewayIntents.All
            };

            _cliente = new DiscordSocketClient(_discordConfig);

            await _cliente.LoginAsync(TokenType.Bot, config.bot.Token);
            await _cliente.StartAsync();

            _commandService = new CommandService();

            _handler = new CommandHandler(_cliente, _commandService);
            await _handler.InstallCommandsAsync();


            _cliente.Ready += () =>
            {
                Console.WriteLine(stryleConsole.ContainerText("Bot is connected!"));
                //------------------------------------------------------------------
                aaa();
                //bbb();
                //ccc();

                //------------------------------------------------------------------
                return Task.CompletedTask;
            };


            await Task.Delay(-1);


        }

        public static SocketChannel buscarCanal(ulong id)
        {
            return _cliente.GetChannel(id);
        }

        private void aaa()
        {
            var cde = new CargaDeEvento();

            //var embed = new EmbedBuilder();
            //embed.Description = "Jajaja!";
            //embed.Title = "Dos";

            //DateTime t1 = new DateTime(2022, 10, 12, 08, 40, 0);
            //TimeSpan t2 = new TimeSpan(0, 0, 0, 10);

            //SocketChannel sc = buscarCanal(1013262734411972718);

            //MensageRepetitive temp = new MensageRepetitive("mensaje5", "Hola!", embed, t1, t2, "local", sc);

            //var a = cde.agregarMRepetitivo(temp);

            cde.activarEventos();
        }

        private async void bbb()
        {

            SocketChannel aa = _cliente.GetChannel(996937110730838107);
            var temp = await CopyUser.getListUserChannelVoice(aa);

            foreach (var item in temp)
            {
                Console.WriteLine($"{item.DisplayName}");
            }

        }

        private void ccc()
        {
            List<string> list = new List<string>();
            list.Add("Geovanny");
            list.Add("angel");
            list.Add("Ghost");
            list.Add("Alex");

            Sorteo st = new Sorteo(list, 1, 2);

            var  a= st.obtMemberRandom();

            Console.WriteLine(a);

        }

    }

}