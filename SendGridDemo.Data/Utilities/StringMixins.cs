namespace SendGridDemo.Data.Utilities
{
    public static class StringMixins
    {
        public static string GetEventName(this string eventName)
        {
            if (eventName == "open")
            {
                return "Opened";
            }
            if (eventName == "click")
            {
                return "Clicked";
            }
            return eventName.ToUpperFirstCharacter();
        }
        public static string OrDefault(this string value, string defaultValue)
        {
            if (string.IsNullOrEmpty(value)) return defaultValue;
            else return value;
        }
        public static string ToUpperFirstCharacter(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            // convert to char array of the string
            char[] letters = str.ToCharArray();
            // upper case the first char
            letters[0] = char.ToUpper(letters[0]);
            // return the array made of the new char array
            return new string(letters);
        }
    }
}
