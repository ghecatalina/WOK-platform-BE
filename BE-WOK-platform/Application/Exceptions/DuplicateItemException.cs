using System.Security.Cryptography;
using System.Text;

namespace Application.Exceptions
{
    public class DuplicateItemException : ApplicationException
    {
        public DuplicateItemException(string itemType, string itemKey, object itemValue)
            : base($"Object of type {itemType} with {itemKey}:{itemValue} already exists.")
        {
        }

        public DuplicateItemException(
            string itemType,
            Dictionary<string, object> itemFields)
            : base($"Object of type {itemType} with " + ConvertDictionaryToString(itemFields) + " already exists.")
        {
        }

        private static string ConvertDictionaryToString(Dictionary<string, object> dict)
        {
            StringBuilder sb = new();

            foreach (KeyValuePair<string, object> kvp in dict)
            {
                sb.Append(kvp.Key);
                sb.Append(':');
                sb.Append(kvp.Value);
                sb.Append(',');
            }

            return sb.ToString().TrimEnd(',');
        }
    }
}
