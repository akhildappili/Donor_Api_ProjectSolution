using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Donor_Api_Project.Controllers;
using Donor_Api_Project.Models;

namespace Donor_Api_Project.Repository
{
    public interface IDonorRepo
    {
        IEnumerable<Donor> GetAllDonors();

        Task<Donor> DonorRegister(Donor donor);        

        void DonorEdit(int id, Donor don);

        Donor GetDonorbyId(int tid);

        void DeletebyId(int id);


    }
}
