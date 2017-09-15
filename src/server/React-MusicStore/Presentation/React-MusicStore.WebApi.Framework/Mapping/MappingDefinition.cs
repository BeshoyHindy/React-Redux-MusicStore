using System;
using System.Globalization;
using System.Linq;
using AutoMapper;
using ReactMusicStore.Core.Domain.Interfaces.Foundation;
using ReactMusicStore.Core.IoC;

namespace ReactMusicStore.WebApi.Framework.Mapping
{
    public class MappingDefinitions
    {
        public void Initialise()
        {
            _autoRegistrations();
        }

        private void _autoRegistrations()
        {
            var dataEntities =  ReferencedAssemblies.Domain.GetTypes().Where(a => typeof(IBaseEntity).IsAssignableFrom(a)).ToList();
          
            var dataVieModels =ReferencedAssemblies.Domain. GetTypes().Where(a => a.Name.EndsWith("Vm", true, CultureInfo.InvariantCulture)).ToList();

            foreach (var entity in dataEntities)
            {
                if (Mapper.GetAllTypeMaps().FirstOrDefault(m => m.DestinationType == entity || m.SourceType == entity) == null)
                {
                    var matchingVm = dataVieModels.FirstOrDefault(x => x.Name.Replace("Vm", string.Empty).Equals(entity.Name, StringComparison.InvariantCultureIgnoreCase));

                    if (matchingVm != null)
                    {
                        Mapper.CreateMap(entity, matchingVm);
                        Mapper.CreateMap(matchingVm, entity);
                    }
                }
            }

        }

    }
}