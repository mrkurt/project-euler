using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests
{
    class Program
    {
static void Main(string[] args)
{
    var permissions = new List<Permissions> { Permissions.Something, Permissions.Nothing };
    var x = permissions.Find(p => (p & Permissions.Everything) == Permissions.Everything);
}
[Flags]
enum Permissions
{
    Nothing = 0,
    Something = 2,
    Everything = 4
}
    }
}
