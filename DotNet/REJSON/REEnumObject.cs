using RE;
using System.Collections;
using System.Text.Json;

namespace REJSON
{
    [REItem("jsonenumobject", "JSON enumerate object", "Enumerate JSON object elements")]
    public partial class REEnumObject : REBaseItem
    {
        public REEnumObject()
        {
            InitializeComponent();
        }

        private System.Collections.IEnumerator? list;

        public override void Start()
        {
            base.Start();
            list = null;
        }

        public override void Stop()
        {
            base.Stop();
            list = null;
        }

        private void lpInput_Signal(RELinkPoint Sender, object? Data)
        {
            if (list != null)
                throw new EReUnexpectedInputException(lpInput);
            JsonElement? e = Data as JsonElement?;
            if (e.HasValue)
            {
                list = e.Value.EnumerateObject();
                if (list != null && list.MoveNext())
                {
                    var p = list.Current as JsonProperty?;
                    if (p.HasValue)
                        if (lpOutputKeys.ConnectedTo != null)
                            lpOutputKeys.Emit(p.Value.Name, true);
                        else if (lpOutputValues.ConnectedTo != null)
                            lpOutputValues.Emit(p.Value.Value, true);
                }
                else
                    list = null;
            }
            else
                throw new EReException("[JsonObjEnum] input is not a JsonElement");
        }

        private void lpOutputKeys_Signal(RELinkPoint Sender, object Data)
        {
            if (list != null)
            {
                var p = list.Current as JsonProperty?;
                if (p.HasValue)
                    if (lpOutputValues.ConnectedTo != null)
                        lpOutputValues.Emit(p.Value.Value, true);
                    else
                    {
                        if (list.MoveNext())
                        {
                            var p1 = list.Current as JsonProperty?;
                            if (p1.HasValue)
                                if (lpOutputKeys.ConnectedTo != null)
                                    lpOutputKeys.Emit(p1.Value.Name, true);
                                else if (lpOutputValues.ConnectedTo != null)
                                    lpOutputValues.Emit(p1.Value.Value, true);
                        }
                        else
                            list = null;
                    }
            }
        }

        private void lpOutputValues_Signal(RELinkPoint Sender, object Data)
        {
            if (list != null && list.MoveNext())
            {
                var p = list.Current as JsonProperty?;
                if (p.HasValue)
                    if (lpOutputKeys.ConnectedTo != null)
                        lpOutputKeys.Emit(p.Value.Name, true);
                    else if (lpOutputValues.ConnectedTo != null)
                        lpOutputValues.Emit(p.Value.Value, true);
            }
            else 
                list = null;
        }
    }
}
