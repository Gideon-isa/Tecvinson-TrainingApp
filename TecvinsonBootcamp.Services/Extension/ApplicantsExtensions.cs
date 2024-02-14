using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecvinsonBootcamp.Domain.Entities;
using TecvinsonBootcamp.Services.Contracts;

namespace TecvinsonBootcamp.Services.Extension
{
    public class ApplicantsExtensions
    {
        public static Applicants AsEntity(this ApplicantCreateReq req) 
        {
            return new Applicants
            {
                
                FirstName = req.FirstName,
                LastName = req.LastName,
                Createdby = "Admin"
                Email = req.Email,
                Phone = req.Phone,
                Gender = req.Gender,
                Nationality = req.Nationality,
                DateOfBirth = req.DateOfBirth,
                ExistingDevSkills = req.ExistingDevSkills,
                MyDevSkills =req.MyDevSkills,
                DateCreated = DateTime.utcNow
            }
        }

    public static Applicants AsEntity(this ApplicantUpdateReq req) 
    {
        return new Applicants 
        {
            id = req.GroupID,
            FirstName = req.FirstName,
                LastName = req.LastName,
                Createdby = "Admin"
                Email = req.Email,
                Phone = req.Phone,
                Gender = req.Gender,
                Nationality = req.Nationality,
                DateOfBirth = req.DateOfBirth,
                ExistingDevSkills = req.ExistingDevSkills,
                MyDevSkills =req.MyDevSkills,
                DateModified = DateTime.utcNow

        }
    }
        
    }
}