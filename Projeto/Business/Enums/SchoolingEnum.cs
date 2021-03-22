using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Enums
{
    public enum SchoolingEnum
    {
        [DescriptionEnum("Infantil")]
        Infantil = 1,

        [DescriptionEnum("Fundamental")]
        Fundamental = 2,

        [DescriptionEnum("Médio")]
        Médio = 3,

        [DescriptionEnum("Superior")]
        Superior = 4
    }
}
