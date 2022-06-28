using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace Diagramador.NET
{
    internal class Save
    {
        [JsonInclude]
        public List<int[]> figuras = new List<int[]>();
        [JsonInclude]
        public List<int> colores = new List<int>();
        [JsonInclude]
        public List<int[]> labels = new List<int[]>();
        [JsonInclude]
        public List<string> labelsTexto = new List<string>();
        

        public void Clear()
        {
            figuras.Clear();
            colores.Clear();
        }
    }
}
