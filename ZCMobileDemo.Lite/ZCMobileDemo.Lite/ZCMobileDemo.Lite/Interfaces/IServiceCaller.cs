using System;
using System.Threading.Tasks;

namespace ZCMobileDemo.Lite.Interfaces
{
    /// <summary>
    /// Interface to define all methods which communicates with host services
    /// </summary>
    public interface IServiceCaller 
    {
        /// <summary>
        /// Calls host service
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="request"></param>
        /// <param name="methodName"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        Task CallHostService<TRequest, TResponse>(TRequest request, string methodName, Action<TResponse> callback);
    }
}
