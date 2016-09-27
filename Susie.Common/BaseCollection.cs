using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace Susie.Common
{
    public abstract class BaseCollection<T> : Collection<T>, IList<T>
    {
       ///<summary>
       /// Initializes a new instance of the <see cref=" cref="CollectionBase" /> class.
       ///</summary>
       ///
       protected BaseCollection() : base(new List<T>()) { }
    }
}
