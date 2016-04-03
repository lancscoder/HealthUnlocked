using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Castle.Windsor;

namespace HealthUnlocked.Infrastrucure
{
    public sealed class WindsorDependencyResolver : IDependencyResolver
    {
        private bool _disposed;
        private IWindsorContainer _container;

        public WindsorDependencyResolver(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            _container = container;
        }

        ~WindsorDependencyResolver()
        {
            Dispose(false);
        }

        public object GetService(Type type)
        {
            return _container.Kernel.HasComponent(type) ? _container.Resolve(type) : null;
        }

        public IEnumerable<object> GetServices(Type type)
        {
            return _container.ResolveAll(type).Cast<object>().ToArray();
        }

        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(_container);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                if (_container != null)
                {
                    _container.Dispose();
                    _container = null;
                }
            }

            _disposed = true;
        }
    }
}