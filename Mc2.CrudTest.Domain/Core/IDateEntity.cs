using System;
using System.Collections.Generic;
using System.Text;

namespace Mc2.CrudTest.Core
{
    public interface IDateEntity
    {
         DateTime CreateOn { get; set; }
         DateTime UpdateOn { get; set; }
    }
}
