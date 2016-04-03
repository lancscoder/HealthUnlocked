using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;

namespace HealthUnlocked.Infrastrucure
{
    public sealed class WindsorDependencyScope : IDependencyScope
    {
        private bool _disposed;

        private readonly IWindsorContainer _container;
        private IDisposable _scope;
        private object _component;

        public WindsorDependencyScope(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            _container = container;
            _scope = container.BeginScope();
        }

        ~WindsorDependencyScope()
        {
            Dispose(false);
        }

        public object GetService(Type type)
        {
            if (_disposed) throw new ObjectDisposedException("Scope");

            _component = _container.Kernel.HasComponent(type) ? _container.Resolve(type) : null;

            return _component;
        }

        public IEnumerable<object> GetServices(Type type)
        {
            if (_disposed) throw new ObjectDisposedException("Scope");

            return _container.ResolveAll(type).Cast<object>().ToArray();
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
                if (_scope != null)
                {
                    _scope.Dispose();
                    _scope = null;
                }
            }

            _disposed = true;
        }
    }
}