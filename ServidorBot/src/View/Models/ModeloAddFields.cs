using Discord;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorBot.src.View.Models
{
    public class ModeloAddFields : ViewModelBase
    {
        private ObservableCollection<ModeloItemField> _embedFieldBuilders = new ObservableCollection<ModeloItemField>();
        public int ListMax { get; set; }
        public ObservableCollection<ModeloItemField> EmbedFieldBuilders
        {
            get { return _embedFieldBuilders; }
            set
            {
                _embedFieldBuilders = value;
            }
        }

        public ModeloAddFields()
        {
        }

        public void addElemten(ModeloItemField e)
        {
            if (!(EmbedFieldBuilders.Count < ListMax)) { return; }
            EmbedFieldBuilders.Add(e);
            OnPropertyChanged(nameof(EmbedFieldBuilders));
        }

        public List<EmbedFieldBuilder> getList()
        {
            List<EmbedFieldBuilder> list = new List<EmbedFieldBuilder>();
            foreach (var item in EmbedFieldBuilders)
            {
                list.Add(
                    new EmbedFieldBuilder()
                    {
                        Name = item.ModelTextBoxLimName.Text,
                        Value= item.ModelTextBoxLimValue.Text,
                        IsInline = item.ModelTextBoxLimInlineChecked,
                    }
                    );
            }
            return list;
        }

    }

    public class ModeloItemField
    {
        public ModelTextBoxLimText ModelTextBoxLimName { get; set; }
        public ModelTextBoxLimText ModelTextBoxLimValue { get; set; }
        public string ModelTextBoxLimInline { get; set; }
        public bool ModelTextBoxLimInlineChecked { get; set; }
        public int Index { get; set; }

    }


}
