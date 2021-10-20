using System.Text;
using Vostok.Logging.Abstractions;

namespace API.Utils
{
    public static class LogExtensions
    {
        public static void RequestInfo(this ILog log, string controllerName, string methodName, object info = null)
        {
            log.Info($"Request in {controllerName}: {methodName}.\nWith info: {info}");
        }
        public static void ResponseInfo(this ILog log, string controllerName, string methodName, object info = null)
        {
            log.Info($"Response in {controllerName}: {methodName}.\nWith info: {info}");
        }

        public static void StartMethodExecution(this ILog log, string serviceName, string methodName,
            params (string Name,object Obj)[] parameters)
        {
            var infoBuilder = new StringBuilder();
            infoBuilder.AppendLine($"Start Method: {methodName} in service: {serviceName}");
            if (parameters.Length > 0)
                infoBuilder.AppendLine("With parameters:");
            foreach (var (name, obj) in parameters)
                infoBuilder.AppendLine($"{name}: {obj}");
            log.Info(infoBuilder.ToString());
        }

        public static void EndMethodExecution(this ILog log, string serviceName, string methodName, object result = null)
        {
            log.Info($"End Method: {methodName} in {serviceName}.\nWith result: {result}");
        }
    }
}