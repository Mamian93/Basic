using Basic.Core.Interfaces;
using Basic.Data;
using Basic.Data.Enums;
using Basic.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basic.Core.Services
{
    public class VehicleService<T> : BaseService<T>
    {
        public void PowerGroupCalculation(int kindOfVehicle)
        {
            using (var ctx = new BasicContext())
            {
                var vehicleList = ctx.Vehicles.Where(a => a.VehicleType == (VehicleType)kindOfVehicle).ToList();
                var avg = vehicleList.Average(a => a.Power);
                var min = vehicleList.Min(a => a.Power);
                var max = vehicleList.Max(a => a.Power);

                Console.WriteLine($"Vehicle type: {kindOfVehicle}. Average: {avg}\nMin: {min}\nMax: {max}");
            }
        }

        public override List<T> MembersCount(List<T> list)
        {
            return base.MembersCount(list);
        }

        public string Hello()
        {
            return "Hello from VehicleService ;O";
        }
    }
}
