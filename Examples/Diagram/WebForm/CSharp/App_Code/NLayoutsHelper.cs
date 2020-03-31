using System;
using System.Collections;
using System.Globalization;
using System.Reflection;

using Nevron.Diagram.Layout;

namespace Nevron.Examples.Diagram.Webform
{
    /// <summary>
    /// Provides methods that are used by the Layout examples.
    /// </summary>
    public static class NLayoutsHelper
    {
        #region Public Methods

        /// <summary>
        /// Configures the layout using the property/value pairs in the specified hash table.
        /// </summary>
        /// <param name="layout"></param>
        /// <param name="args"></param>
        public static void ConfigureLayout(NLayout layout, Hashtable args)
        {
            // Configure the layout
            if (args == null)
                return;

            Type type = layout.GetType();
            IDictionaryEnumerator enumerator = args.GetEnumerator();
            while (enumerator.MoveNext())
            {
                PropertyInfo p = type.GetProperty(enumerator.Key.ToString());
                if (p == null)
                {
                    throw new Exception(string.Format("The property {0} is not defined for the class {1}", enumerator.Key, layout.GetType().Name));
                }

                try
                {
                    object value = enumerator.Value;
                    if (p.PropertyType.Equals(FLOAT_TYPE))
                    {   // The decimal separator problem fix
                        value = ParseFloat(value);                        
                    }

                    value = p.PropertyType.IsEnum ?
                        Enum.Parse(p.PropertyType, enumerator.Value.ToString()) :
                        Convert.ChangeType(value, p.PropertyType);

                    p.SetValue(layout, value, null);
                }
                catch
                {
                    throw new Exception(string.Format("The value '{0}' is not valid for the {1} property",
                        enumerator.Value, enumerator.Key));
                }
            }
        }
        /// <summary>
        /// Parses the given object to float using the proper decimal separator.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float ParseFloat(object value)
        {
            string s = value.ToString();
            if (s.Contains("."))
                s = s.Replace(".", DECIMAL_SEPARATOR);
            else if (s.Contains(","))
                s = s.Replace(",", DECIMAL_SEPARATOR);

            return float.Parse(s);
        }

        #endregion

        #region Static

        private static readonly Type FLOAT_TYPE = typeof(float);
        private static readonly string DECIMAL_SEPARATOR = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

        #endregion
    }
}