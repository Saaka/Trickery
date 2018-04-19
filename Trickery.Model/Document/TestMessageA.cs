namespace Trickery.Model.Document
{
    public class TestMessageA : TestMessage
    {
        public TestMessageA()
        {
            MessageType = Common.Enums.TestMessageType.TypeA;
        }
        public string MessageA { get; set; }
    }
}
