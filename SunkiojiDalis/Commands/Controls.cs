using Newtonsoft.Json;

namespace SignalRWebPack
{
    [JsonObject(MemberSerialization.Fields)]
    public class Controls
    {
        public int id;

        public bool up;
        public bool left;
        public bool down;
        public bool right;

        public bool undo;
    }
}