using System.Text.Json;

namespace Messages.ClientServer
{
    /// <summary>
    /// Inpired by https://github.com/jeffreypalermo/blazor-wasm-single-web-api/blob/master/src/Shared/WebServiceMessage.cs
    /// </summary>
    public class WebServiceMessage
    {
        public string Body { get; set; } = "";
        public string? TypeName { get; set; }

        public WebServiceMessage()
        {

        }

        public WebServiceMessage(object request)
        {
            Body = GetBody(request);
            TypeName = request.GetType().FullName + ", " + request.GetType().Assembly.GetName().Name;
        }

        public string GetBody(object request)
        {
            var body = JsonSerializer.Serialize(request, request.GetType());
            return body;
        }

        public string GetJson()
        {
            return JsonSerializer.Serialize(this, GetType());
        }

        public TReturn GetBodyObject<TReturn>()
        {
            Type type = typeof(TReturn);
            string value = Body;
            return (TReturn)JsonSerializer.Deserialize(value, type);
        }

        public object GetBodyObject()
        {
            Type type = Type.GetType(TypeName, true);
            string value = Body;
            return JsonSerializer.Deserialize(value, type);
        }
    }
}
