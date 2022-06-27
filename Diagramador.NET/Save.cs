using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Diagramador.NET
{
    internal class Save
    {
        [JsonInclude]
        public List<int[]> figuras = new List<int[]>();
        [JsonInclude]
        public List<int> colores = new List<int>();

        public void Clear()
        {
            figuras.Clear();
            colores.Clear();
        }
    }
}
