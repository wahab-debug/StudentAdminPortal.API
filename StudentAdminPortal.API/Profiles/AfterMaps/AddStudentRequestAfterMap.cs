﻿using AutoMapper;
using StudentAdminPortal.API.DomainModels;

namespace StudentAdminPortal.API.Profiles.AfterMaps
{
    public class AddStudentRequestAfterMap : IMappingAction<AddStudentRequest, DataModel.Student>
    {
        public void Process(AddStudentRequest source, DataModel.Student destination, ResolutionContext context)
        {
           destination.Id = Guid.NewGuid();
           destination.Address = new DataModel.Address() 
           { 
              Id = Guid.NewGuid(),
              PhysicalAddress = source.PhysicalAddress,
              PostalAddress = source.PostalAddress,           
           };
        }
    }
}
