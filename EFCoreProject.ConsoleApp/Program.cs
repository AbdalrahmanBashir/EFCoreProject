using EFCoreProject.DAL;
using EFCoreProject.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EFCoreProject.ConsoleApp
{
    class Program
    {

        public static void Main(string[] args)
        {
            Doctor doctor = new Doctor();

            doctor.doctor();

        }
    }
}