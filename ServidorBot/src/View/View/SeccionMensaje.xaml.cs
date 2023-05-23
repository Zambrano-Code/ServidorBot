using System.Windows.Controls;

namespace ServidorBot.src.View.View
{
    /// <summary>
    /// Lógica de interacción para SeccionMensaje.xaml
    /// </summary>
    public partial class SeccionMensaje : UserControl
    {
        

        public SeccionMensaje()
        {

            //App.Bot._cliente.MessageReceived += _cliente_MessageReceived;

            InitializeComponent();
        }



        //}
        //--------------------- ACCIONES -----------------------
        //private Task _cliente_MessageReceived(Discord.WebSocket.SocketMessage arg)
        //{
        //    this.Dispatcher.Invoke(async () =>
        //    {
        //        if (userCheck == null) return;
        //        if (arg.Author.Id == userCheck._iDMChannel.Recipient.Id)
        //        {
        //            var i = userCheck._iDMChannel.GetMessageAsync(arg.Id).Result;
        //            //Console.WriteLine($"Nombre: {i.Author.Username} \n\tconten: {i.Content}\n\tcomponent: {i.Components.Count}\n\tsourse: {i.Source}\n\tflags: {i.Flags}\n\tAttachments: {i.Attachments.Count}");
        //            ModeloMensaje ms = new ModeloMensaje(i);
        //            _MUC.Add(ms);
        //            scrview.ScrollToEnd();
        //        }
        //        //Console.WriteLine(arg.Author.Id + " " + userCheck._iDMChannel.Recipient.Id);
        //    });
        //    return Task.CompletedTask;

        //}


        //private void _chanelDMUser_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        //{
        //    foreach (IDMChannel item in e.NewItems)
        //    {
        //        Console.WriteLine(item.Name);
        //        this.Dispatcher.Invoke(async () =>
        //        {
        //            agregarUser(item);
        //        });
        //    }


        //}

        //private void accionForOptions(object sender, RoutedEventArgs e)
        //{

        //    CheckBoxDMChannel boxChecke = sender as CheckBoxDMChannel;

        //    if (boxChecke == userCheck) return;
        //    if (!ButtonCreateEmbed.IsEnabled) ButtonCreateEmbed.IsEnabled = true;

        //    userCheck = boxChecke;

        //    _MUC.Clear();
        //    txtBody.IsEnabled = true;
        //    txtBody.Text = "";
        //    cargarMensajes(100);
        //    scrview.ScrollToEnd();
        //}

        //private void ScrollViewer_Initialized(object sender, EventArgs e)
        //{
        //    scrview.ScrollToEnd();
        //}

        //private void evento_messageSend(object sender, KeyEventArgs e)
        //{
        //    if ((Keyboard.Modifiers == ModifierKeys.Shift) && (e.Key == Key.Enter))
        //    {
        //        var a = txtBody.Text.Length;
        //        txtBody.SelectionStart = a;
        //        return;
        //    }

        //    if (e.Key == Key.Enter)
        //    {
        //        e.Handled = true;

        //        string temp = txtBody.Text.Replace("\n", "").Replace("\r", "");

        //        if (String.IsNullOrEmpty(temp) && _EmbedsForEnviar.Count == 0) return;

        //        //Console.WriteLine($"value: '{temp2}' leng: {temp2.Length}");

        //        List<Embed> list = new List<Embed>();
        //        foreach (var i in _EmbedsForEnviar)
        //        {
        //            list.Add(i.embedBuilder.Build());
        //        }

        //        try
        //        {
        //            var i2 = userCheck._iDMChannel.SendMessageAsync(txtBody.Text, embeds: list.ToArray()).Result;
        //            _MUC.Add(new ModeloMensaje(i2));
        //            txtBody.Text = "";

        //            if (ConfiguracionView.RemoveEmbedAfterSendMessage) _EmbedsForEnviar.Clear();

        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //    }

        //}

        //private void button_CrearEmbed(object sender, RoutedEventArgs e)
        //{
        //    //CrearEmbed _cE = new CrearEmbed(new ModeloViewCreateEmbed(new EmbedBuilder()));
        //    //_cE.embedCreate += _cE_embedCreate;

        //    //_cE.ShowDialog();

        //}

        //private void _cE_embedCreate(EmbedBuilder Msg)
        //{
        //    _EmbedsForEnviar.Add(new NumerEmbed()
        //    {
        //        embedBuilder = Msg,
        //        numer = NumerEmbed.cont,
        //    });

        //    NumerEmbed.cont++;
        //}

        //private void ButtonDeleteEmbed_Click(object sender, RoutedEventArgs e)
        //{
        //    var button = sender as Button;
        //    NumerEmbed temp = button.DataContext as NumerEmbed;
        //    _EmbedsForEnviar.Remove(temp);

        //    NumerEmbed.cont = 1;
        //    foreach (var i in _EmbedsForEnviar)
        //    {
        //        i.numer = NumerEmbed.cont;
        //        NumerEmbed.cont++;
        //    }

        //}

        //private void Edited_embed(object sender, RoutedEventArgs e)
        //{
        //    //var butt = (Button)sender;
        //    //var dt = butt.DataContext as NumerEmbed;
        //    //CrearEmbed _cE = new CrearEmbed(new ModeloViewCreateEmbed(dt.embedBuilder));

        //    //_cE.embedCreate += (EmbedBuilder Msg) =>
        //    //{
        //    //    dt.embedBuilder = Msg;

        //    //};

        //    //_cE.ShowDialog();
        //}


        //public class NumerEmbed : ViewModelBase
        //{
        //    public static int cont = 1;
        //    public EmbedBuilder embedBuilder { get; set; }

        //    private int _numer;
        //    public int numer
        //    {
        //        get
        //        {
        //            return _numer;
        //        }
        //        set
        //        {
        //            _numer = value;
        //            OnPropertyChanged(nameof(numer));
        //        }
        //    }
        //}

    }
}
