using Donor_Api_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donor_Api_Project.Repository
{
    public class DonorRepo :IDonorRepo
    {

        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(DonorRepo));

        private readonly GiveAwayFundsDBContext _context;

        public DonorRepo(GiveAwayFundsDBContext context)
        {
            _context = context;
        }

        public  async Task<Donor> DonorRegister(Donor donor)
        {
            LoginDetail log = new LoginDetail();
            log.UserName = donor.DonorUserName;
            log.Password = donor.DonorPassword;
            log.Loginas = "donor";

            _context.LoginDetails.Add(log);

            _context.Donors.Add(donor);

            _context.SaveChanges();

            return donor;
           
        }

        public IEnumerable<Donor> GetAllDonors()
        {
            return _context.Donors.ToList();
        }


        public void DonorEdit(int id, Donor don)
        {
            Donor sp = _context.Donors.Find(id);
            sp.DonorName = don.DonorName;
            sp.DonorPhoneNumber = don.DonorPhoneNumber;
            sp.DonorMailId = don.DonorMailId;
            sp.DonorPassword = don.DonorPassword;
            _context.SaveChanges();

        }

        public Donor GetDonorbyId(int bid)
        {


            return _context.Donors.Find(bid);

        }

        public void DeletebyId(int id)
        {
            Donor don = _context.Donors.Find(id);
            //var del = _context.Ngos.Find(id);
            _context.Donors.Remove(don);
            _context.SaveChanges();

        }

    }
}
