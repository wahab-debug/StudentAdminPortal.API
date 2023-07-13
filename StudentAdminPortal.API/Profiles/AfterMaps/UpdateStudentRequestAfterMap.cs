using AutoMapper;
using AutoMapper.Features;
using StudentAdminPortal.API.DomainModels;
using DataModels=StudentAdminPortal.API.DataModel;

namespace StudentAdminPortal.API.Profiles.AfterMaps
{
    public class UpdateStudentRequestAfterMap : IMappingAction<UpdateStudentRequest, DataModels.Student>
    {
        public void Process(UpdateStudentRequest source, DataModels.Student destination, ResolutionContext context)
        {
          destination.Address= new DataModels.Address() 
          { 
            PhysicalAddress = source.PhysicalAddress,
            PostalAddress = source.PostalAddress,
          };
        }
    }
}
