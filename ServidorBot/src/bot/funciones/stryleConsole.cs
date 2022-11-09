using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bot.funciones
{
    public class stryleConsole
    {

        public static String ContainerText(String text)
        {
            char tl = '┌';
            char tr = '┐';
            char bl = '└';
            char br = '┘';
            char lh = '─';
            char lv = '│';
            char space = ' ';

            int x = 2;
            int y = 1;

            int lengText = 0;

            string[] arraText = text.Split("\n");
            List<string> arraTextTemp = new List<string>();

            foreach (string element in arraText)
            {
                string textTemp = element;
                if (textTemp.ToCharArray()[0] == space)
                {
                    textTemp = textTemp.Substring(1, textTemp.Length -1);
                }

                if (textTemp.ToCharArray()[textTemp.Length - 1] == space)
                {
                    textTemp = textTemp.Substring(0, textTemp.Length - 2);
                }

                if (textTemp.Length > lengText) lengText = textTemp.Length;
            }

            string struc = tl + new String(lh, x + lengText + x) + tr + "\n";

            for (int i = 0; i < y; i++)
            {
                struc += lv + new String(space, x + lengText + x) + lv + "\n";
            }

            foreach (string element in arraText)
            {
                int lengthTextTemp = lengText - element.Length;
                 string textTemp = element;
                if (lengthTextTemp > 0)
                {
                    textTemp += new String(space, lengthTextTemp);

                }

                struc += lv + new String(space, x) + textTemp + new String(space, x) + lv + "\n";

            }

            for (int i = 0; i < y; i++)
            {
                struc += lv + new String(space, x + lengText + x) + lv + "\n";
            }

            struc += bl + new String(lh, x + lengText + x) + br + "\n";

            return struc;
        }

    }
}
