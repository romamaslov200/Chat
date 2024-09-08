using System.ServiceModel;

namespace Wcf_chat
{
    public class ServerUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public OperationContext operationcontext { get; set; }
    }
}
