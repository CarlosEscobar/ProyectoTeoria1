using System;
using AcklenAvenue.Data;
using FacturacionLaMejor.domain.Entities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;

namespace FacturacionLaMejor.data
{
    public class MappingScheme : IDatabaseMappingScheme<MappingConfiguration>
    {
        public Action<MappingConfiguration> Mappings
        {
            get
            {
                var autoPersistenceModel = AutoMap.Assemblies(typeof(IEntity).Assembly)
                    .Where(t => typeof(IEntity).IsAssignableFrom(t))
                    //.UseOverridesFromAssemblyOf<CompanyAutoMappingOverride>()
                    //.IncludeBase<LessonActionBase>()
                    .Conventions.Add(DefaultCascade.All());

                return x => x.AutoMappings.Add(autoPersistenceModel);
            }
        }
    }
}
