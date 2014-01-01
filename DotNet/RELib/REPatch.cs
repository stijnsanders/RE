using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RE
{
    public class RELinkPointPatch
    {
        private RELinkPoint lp1;
        private RELinkPoint lp2;

        public RELinkPointPatch(RELinkPoint LinkPoint1, RELinkPoint LinkPoint2)
        {
            lp1 = LinkPoint1;
            lp2 = LinkPoint2;
            lp1.Connecting += new RELinkPointConnecting(lp1_Connecting);
            lp2.Connecting += new RELinkPointConnecting(lp2_Connecting);
        }

        public void Disconnect()
        {
            //call Disconnect() from REBaseItem.DisconnectAll()!
            if (lp1.IsConnected && lp2.IsConnected)
            {
                lp1.ConnectedTo.ConnectedTo = lp2.ConnectedTo;
            }
            else
            {
                lp1.ConnectedTo = null;
                lp2.ConnectedTo = null;
            }
        }

        private void lp1_Connecting(RELinkPoint Sender, RELinkPoint ConnectingTo)
        {
            if (
                ConnectingTo != null &&
                ConnectingTo.ConnectedTo != null &&
                lp2.ConnectedTo == null &&
                lp2.BaseItem != ConnectingTo.BaseItem
            )
                lp2.ConnectedTo = ConnectingTo.ConnectedTo;
        }

        private void lp2_Connecting(RELinkPoint Sender, RELinkPoint ConnectingTo)
        {
            if (
                ConnectingTo != null &&
                ConnectingTo.ConnectedTo != null &&
                lp1.ConnectedTo == null &&
                lp1.BaseItem != ConnectingTo.BaseItem
            )
                lp1.ConnectedTo = ConnectingTo.ConnectedTo;
        }

    }
}
