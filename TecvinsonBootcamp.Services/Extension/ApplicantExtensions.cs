using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecvinsonBootcamp.Domain.Entities;
using TecvinsonBootcamp.Services.Contracts;

namespace TecvinsonBootcamp.Services.Extension
{
    public static class ApplicantExtensions
    {
        public static Applicant AsEntity(this ApplicantCreateReq req) 
        {
            return new Applicant
            {

                FirstName = req.FirstName,
                LastName = req.LastName,
                //Createdby = "Admin",
                Email = req.Email,
                Phone = req.Phone,
                Gender = req.Gender,
                Nationality = req.Nationality,
                DateOfBirth = req.DateOfBirth,
                ExistingDevSkill = req.ExsitingDevSkill,
                MyDevSkills = req.MyDevSkills,
                DateCreated = DateTime.Now
            };
        }

    public static Applicant AsEntity(this ApplicantUpdateReq req) 
    {
            return new Applicant
            {
                //Id = req.GroupID,
                FirstName = req.FirstName,
                LastName = req.LastName,
                //Createdby = "Admin"
                Email = req.Email,
                Phone = req.Phone,
                Gender = req.Gender,
                Nationality = req.Nationality,
                DateOfBirth = req.DateOfBirth,
                ExistingDevSkill = req.ExistingDevSkill,
                MyDevSkills = req.MyDevSkills,
                DateModified = DateTime.Now

            };
    }
        
    }
}