using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DIP.MyIoCContainer
{

    

    public class Container
    {
        private Dictionary<Type, ResolvedTypeWithLifeTimeOptions> iocMap = new Dictionary<Type, ResolvedTypeWithLifeTimeOptions>();

        public void Register<T1, T2>()
        {
            Register<T1, T2>(LifeTimeOptions.TransientLifeTimeOption);
        }

        public void Register<T1, T2>(LifeTimeOptions lifeTimeOption)
        {
            if (iocMap.ContainsKey(typeof(T1)))
            {
                throw new Exception(string.Format("Type {0} already Registered.", typeof(T1).FullName));
            }
            ResolvedTypeWithLifeTimeOptions targetType = new ResolvedTypeWithLifeTimeOptions(typeof(T2), lifeTimeOption);
            iocMap.Add(typeof(T1), targetType);
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private object Resolve(Type typeToResolve)
        {
            if (!iocMap.ContainsKey(typeToResolve))
            {
                throw new Exception(string.Format("Can't Resolve {0}. Type is not Registered.", typeToResolve.FullName));
            }
            ResolvedTypeWithLifeTimeOptions resolvedType = iocMap[typeToResolve];

            if (resolvedType.LifeTimeOption == LifeTimeOptions.ContainerControlledLifeTimeOption && resolvedType.InstanceValue != null)
            {
                return resolvedType.InstanceValue;
            }

            ConstructorInfo ctorInfo = resolvedType.ResolvedType.GetConstructors().First();
            
            List<ParameterInfo> paramsInfo = ctorInfo.GetParameters().ToList();
            List<object> resolvedParams = new List<object>();
            foreach (ParameterInfo param in paramsInfo)
            {
                Type t = param.ParameterType;
                object res = Resolve(t);
                resolvedParams.Add(res);
            }

            object retObject = ctorInfo.Invoke(resolvedParams.ToArray());

            resolvedType.InstanceValue = retObject;
            
            return retObject;
        }
    }
}
