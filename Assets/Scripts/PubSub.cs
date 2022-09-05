using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match.PubSub
{
    public class PubSUb { }
    
    public struct TimeOver { }
    public struct MatchGotClick
    {
        public int index;
        public MatchGotClick(int index)
        {
            this.index = index;
        }
    }
    public struct AddCoinMessage { }
    public struct TilesCleared { }
}