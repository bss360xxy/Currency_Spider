using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBaseTaskRuner
{
  public  interface IMatcher
    {
        object GetResult(String sourcestr);
    }
}
