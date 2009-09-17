using System;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Builder;
using NathanPalmer.com.Core.Domain;
using NathanPalmer.com.Infrastructure.DataAccess.Impl;
using NathanPalmer.com.Infrastructure.DataAccess.ORMapper;
using Tarantino.Infrastructure.Commons.DataAccess.ORMapper;

namespace NathanPalmer.com
{
    public class AutofacControllerFactory : DefaultControllerFactory
    {
        private IContainer container;

        public AutofacControllerFactory()
        {
            var builder = new ContainerBuilder();
            builder.Register<FluentSessionBuilder>().As<ISessionBuilder>();
            builder.Register<FluentNHibernatePostRepository>().As<IPostRepository>();
            builder.Register<FluentNHibernateTagRepository>().As<ITagRepository>();

            foreach (Type t in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (typeof(IController).IsAssignableFrom(t))
                    builder.Register(t).FactoryScoped();
            }

            container = builder.Build();
        }

        protected override IController GetControllerInstance(Type ControllerType)
        {
            if (ControllerType != null)
            {
                return (IController)container.Resolve(ControllerType);
            }
            return null;
        }

    }
}