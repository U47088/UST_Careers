using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using UST_Careers.Domain.Abstract;
using Moq;
using UST_Careers.Domain.Entities;
using UST_Careers.Domain.Concrete;

namespace UST_Careers.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            // put bindings here
            kernel.Bind<ILocationRepository>().To<EFLocationRepository>();
            kernel.Bind<IJobOfferRepository>().To<EFJobOfferRepository>();
        }
    }
}