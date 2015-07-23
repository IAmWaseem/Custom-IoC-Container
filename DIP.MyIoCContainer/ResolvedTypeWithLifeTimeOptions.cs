using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.MyIoCContainer
{

    public enum LifeTimeOptions
    {
        TransientLifeTimeOption,
        ContainerControlledLifeTimeOption
    }

    public class ResolvedTypeWithLifeTimeOptions
    {
        public Type ResolvedType { get; set; }
        public LifeTimeOptions LifeTimeOption { get; set; }
        public object InstanceValue { get; set; }

        public ResolvedTypeWithLifeTimeOptions(Type resolvedType)
        {
            ResolvedType = resolvedType;
            LifeTimeOption = LifeTimeOptions.TransientLifeTimeOption;
            InstanceValue = null;
        }

        public ResolvedTypeWithLifeTimeOptions(Type resolvedType, LifeTimeOptions lifeTimeOption)
        {
            ResolvedType = resolvedType;
            LifeTimeOption = lifeTimeOption;
            InstanceValue = null;
        }
    }
}
