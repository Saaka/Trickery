namespace Trickery.Model.Document
{
    public class TestMessageB : TestMessage
    {
        public TestMessageB()
        {
            MessageType = Common.Enums.TestMessageType.TypeB;
        }
        public string MessageB { get; set; }
    }
}
