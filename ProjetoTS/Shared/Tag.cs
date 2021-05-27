using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTS.Shared
{
    public class Tag //UMA TAG POSSUI VÁRIOS AutomovelS
    {
        public int TagId { get; set; }
        public string Nome { get; set; }
        public List<TagAutomovel>  TagAutomovel  { get; set; }

    }
}
