using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Susie.Common
{
    #region BROKEN RULE CLASS
    public class BrokenRule
    {
        /// <summary>
        /// Constructor to intilize new instance of Broken Rule class.
        /// </summary>
        /// <param name="propertyName"> The name of the property that caused the rule to be broken.</param>
        /// <param name="message">Error message that should be associated with the broken rule.</param>

    public BrokenRule(string propertyName, string message)
        {
            this.PropertyName = propertyName;
            this.Message = message;
        }

    #endregion

    public string PropertyName { get; set; }
    public string Message { get; set; }

    #region BROKEN RULE COLLECTION
    
    public class BrokenRuleCollection : Collection<BrokenRule>
        {
            public void Add(string message)
            {
                Add(new BrokenRule(string.Empty, message));
            }

        /// <summary>
        /// Creates a new BrokenRule instance and adds it to the inner list
        /// </summary>
        /// <param name="propertyName"> The name of the property that caused the rule to be broken. Can be left empty</param>
        /// <param name="message"> The validation message asscoiated with the broken rule.</param>

        public void Add(string propertyName, string message)
            {
                Add(new BrokenRule(propertyName, message));
            }

        }
    
    #endregion
    }
}