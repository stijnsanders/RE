using RE;

namespace REBasic
{
    [REItem("struppercase", "Uppercase", "Converts a string to all uppercase characters")]
    public class REStrUpper : REBasic.REBaseStringOp
    {
        public REStrUpper() { Caption = "Uppercase"; }
        protected override string Perform(string Data) { return Data.ToUpper(); }
    }

    [REItem("strlowercase","Lowercase","Converts a string to all lowercase characters")]
    public class REStrLower : REBasic.REBaseStringOp
    {
        public REStrLower() { Caption = "Lowercase"; }
        protected override string Perform(string Data) { return Data.ToLower(); }
    }

    [REItem("strtrim", "Trim", "Trims white-space from start and end of a string")]
    public class REStrTrim : REBasic.REBaseStringOp
    {
        public REStrTrim() { Caption = "Trim"; }
        protected override string Perform(string Data) { return Data.Trim(); }
    }

    [REItem("strtrimstart", "Trim start", "Trims white-space from start of a string")]
    public class REStrTrimStart : REBasic.REBaseStringOp
    {
        public REStrTrimStart() { Caption = "Trim start"; }
        protected override string Perform(string Data) { return Data.TrimStart(); }
    }

    [REItem("strtrimend", "Trim end", "Trims white-space from end of a string")]
    public class REStrTrimEnd : REBasic.REBaseStringOp
    {
        public REStrTrimEnd() { Caption = "Trim end"; }
        protected override string Perform(string Data) { return Data.TrimEnd(); }
    }

    [REItem("strappendeol", "Append EOL", "Append an end-of-line code")]
    public class REStrAppendEOL : REBasic.REBaseStringOp
    {
        public REStrAppendEOL() { Caption = "Append EOL"; }
        protected override string Perform(string Data) { return Data + "\r\n"; }
    }

}
