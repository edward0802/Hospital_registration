using InternetHospital.BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetHospital.BusinessLogic.Interfaces
{
    public interface IRegistrationService
    {
        Task<ActionResult> RegistrateDoctor(UserRegistrationModel vm);
        Task<ActionResult> RegistratePatient(UserRegistrationModel vm);

    }
}
