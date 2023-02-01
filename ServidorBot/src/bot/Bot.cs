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
        public static CargaDeEvento? _eventoMenRep { get; private set; }
        public static CargaDeUserDM? _chanelDMUser { get; private set; }



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


            _cliente.Ready += _cliente_Ready;
            _cliente.MessageReceived += _cliente_MessageReceived;

            await Task.Delay(-1);


        }


        //---------------------------------------------------------------------------------------
        //        Metodos del eventos al bot
        private Task _cliente_MessageReceived(SocketMessage arg)
        {
            var id = arg.Author.Id;
            if ( id == 971070979948290108 || arg.Author.IsBot) return Task.CompletedTask;
            //Console.WriteLine($"Mensajge: {arg.Content} User: {arg.Author.Username}"); 
            var temp = arg.Author;
            var temp2 = temp.CreateDMChannelAsync().Result;
            //Console.WriteLine($"Mensaje: {arg.Content} \n ID autor: {temp.Id} \n ID DM Chanel: {temp2.Id}");
            _chanelDMUser.agregarDMUser(temp2);

            

            return Task.CompletedTask;
        }

        private Task _cliente_Ready()
        {
            Console.WriteLine(stryleConsole.ContainerText("Bot is connected!"));
            //------------------------------------------------------------------
            CargarEventos();
            CargarMDUser();
            //bbb();
            //ccc();

            //------------------------------------------------------------------

            return Task.CompletedTask;
            
        }


        private void CargarEventos()
        {
            _eventoMenRep = new CargaDeEvento();

            var dt = new DateTime(2023, 01, 02, 12, 05, 00);
            var ch = _cliente.GetChannel(1013262734411972718);
            var gh = _cliente.GetGuild(996937109740978226);
            var uh = _cliente.GetUser(472582540134449152);
            _eventoMenRep.agregarMRepetitivo(new MensageRepetitive("Despedida", "Chao, Geovanny", new List<EmbedBuilder>(), dt, TimeSpan.FromSeconds(15), "utc", ch, gh, uh));

            _eventoMenRep.activarEventos();
        }

        private void CargarMDUser()
        {
            _chanelDMUser = new CargaDeUserDM();

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

        //---------------------------------------------------------------------------------------
        //         Metodos staticos

        /// <summary>
        /// Busca el canal de discord con el ide que le declares
        /// </summary>
        /// <param name="id">id del canal a buscar</param>
        /// <returns></returns>
        public static SocketChannel buscarCanal(ulong id)
        {
            return _cliente.GetChannel(id);
        }
        public static SocketGuild buscarGuild(ulong id)
        {
            return _cliente.GetGuild(id);
        }
        public static SocketUser buscarUser(ulong id)
        {
            return _cliente.GetUser(id);
        }

        /// <summary>
        /// Busca el usuario y crear el canal de mensaje directo para el chat.
        /// </summary>
        /// <param name="id">Id del usuario</param>
        /// <returns></returns>
        public static IDMChannel buscarDMUser(ulong id)
        {
            var temp = _cliente.GetDMChannelAsync(id);
            return temp.Result;
        }

        //---------------------------------------------------------------------------------------
    }

}