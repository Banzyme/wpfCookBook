using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Markup;

namespace WPFCookBook.Shared.Converters
{
    [ValueConversion(typeof(string), typeof(FlowDocument))]
    public class DocumentToStringConverter : IValueConverter
    {
        /* Associate a value converter with a binding
         * Hence need to implement the IValueConverter 
         * interface 
         */


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Returns flowdocument from string
            FlowDocument flowDoc = new FlowDocument();
            if (value == null) return flowDoc;

            flowDoc = (FlowDocument)XamlReader.Parse((string)value);

            return flowDoc;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Returns string from flowdocument
            if (value == null) return string.Empty;

            return XamlWriter.Save((FlowDocument)value);
        }
    }
}
