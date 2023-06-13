using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Building
{
    public interface IReadable<T>
    {
        List<T> Read(string filepath);
    }
}
