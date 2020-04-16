using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARSH
{
    public struct Route : IComparable<Route>
    {
        public int NumberOfRoute { get; }

        public string StrartName { get; }

        public string EndName { get; }

        public Route(int numberOfRoute, string startName, string endName)
        {
            StrartName = startName;
            EndName = endName;
            NumberOfRoute = numberOfRoute;
        }

        public int CompareTo(Route other) => NumberOfRoute.CompareTo(other.NumberOfRoute);

        public override string ToString() => $"{NumberOfRoute} {StrartName} {EndName}";
    }
}
