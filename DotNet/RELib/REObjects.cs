using System;

namespace RE
{
    [AttributeUsage(AttributeTargets.Class)]
    public class REItemAttribute : Attribute
    {
        public string SystemName;
        public string DisplayName;
        public string Description;
        public REItemAttribute(string SystemName, string DisplayName, string Description)
        {
            this.SystemName = SystemName;
            this.DisplayName = DisplayName;
            this.Description = Description;
        }
    }

    public class REItemType
    {
        public REItemAttribute ItemInfo;
        public Type ItemType;
        public string Module;
        public REItemType(REItemAttribute ItemInfo, Type ItemType, string Module)
        {
            this.ItemInfo = ItemInfo;
            this.ItemType = ItemType;
            this.Module = Module;
        }
        public REBaseItem? CreateOne()
        {
            var c = ItemType.GetConstructor(Type.EmptyTypes);
            return c?.Invoke(Array.Empty<object>()) as REBaseItem;
        }
    }

    public enum RELinkPointSignalType
    {
        Sending,
        Suspending,
        Resuming
    }

    //implemented by main application
    public interface IRELinkPanel
    {
        void ReportLinkConnect(RELinkPoint LinkPoint1, RELinkPoint LinkPoint2);
        void ReportLinkDisconnect(RELinkPoint LinkPoint);
        void ReportLinkSignal(RELinkPoint Linkpoint, RELinkPointSignalType State, object? Data, bool MoreComing);
        void AddItem(REBaseItem Item, bool FindNextPosition);
    }

    public class EReException : Exception
    {
        public EReException(string Message)
            : base(Message)
        {
        }
    }

    public class EReUnexpectedInputException : EReException
    {
        private RELinkPoint _InputLinkPoint;

        public EReUnexpectedInputException(RELinkPoint InputLinkPoint)
            : base(string.Format("Unexpected input signal ({0})", InputLinkPoint.Caption))
        {
            _InputLinkPoint = InputLinkPoint;
        }
    }

}
