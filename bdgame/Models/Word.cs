using System;
using System.Collections.Generic;

namespace bdgame.Models;

public partial class Word
{
    public int WordsId { get; set; }

    public string En { get; set; }

    public string Hu { get; set; }

    public string SentenceEn { get; set; }

    public string SentenceHu { get; set; }

    public string LessionGroup { get; set; }
}
