using System;
using System.Collections.Generic;

namespace Infrastructure
{
    public interface IServices
    {
        T Get<T>() where T : class;
        void Set<T>(T service) where T : class;
    }
    
    public class Services
    {
        public static IServices Implementation { get; set; } = new DefaultServices();
        
        public static T Get<T>() where T : class
        {
            return Implementation.Get<T>();
        }

        public static void Set<T>(T service) where T : class
        {
            Implementation.Set(service);
        }
    }
    
    public class DefaultServices : IServices
    {
        private readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();
            
        public T Get<T>() where T : class
        {
            return (T) _services[typeof(T)];
        }

        public void Set<T>(T service) where T : class
        {
            _services[typeof(T)] = service;
        }
    }
}