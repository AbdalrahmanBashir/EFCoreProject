using EFCoreProject.DAL.Repositories;
using EFCoreProject.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreProject.ConsoleApp
{
    public class Doctor
    {
        private readonly IDoctorRepository _doctorRepository;

        public Doctor()
        {

        }
        public Doctor(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public void doctor()
        {
            var result = _doctorRepository.GetDoctorByIdAsync("999-00-1111");


            if (result != null)
            {
                Console.WriteLine(result);
                //Console.WriteLine($"{result.}, {result.LastName}, {result.Patients.Count}");

            }
        }
        
    }
}
