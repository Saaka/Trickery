using System;

namespace Trickery.Infrastructure
{
    public interface IGuidProvider
    {
        string CreateGuid();
    }

    public class GuidProvider : IGuidProvider
    {
        public string CreateGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
