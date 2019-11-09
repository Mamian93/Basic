using Basic.Data;
using Basic.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basic.Core.Repository
{
    public class VehicleRepository
    {
        /// <summary>
        /// Read - One vehicle
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        public Vehicle GetVehicle(int vehicleId)
        {
            using (var ctx = new BasicContext())
            {
                var vehicle = FindById(vehicleId);
                if (vehicle != null)
                {
                    return vehicle;
                }
                else
                {
                    return ctx.Vehicles.FirstOrDefault();
                }
            }
        }

        /// <summary>
        /// Read - Vehicles List
        /// </summary>
        /// <returns></returns>
        public List<Vehicle> GetVehicles()
        {
            using (var ctx = new BasicContext())
            {
                return ctx.Vehicles.ToList();
            }
        }

        /// <summary>
        /// Put - Update vehicle
        /// </summary>
        /// <param name="vehicleUpdate"></param>
        /// <returns></returns>
        public Vehicle PutVehicle(Vehicle vehicleUpdate)
        {
            using (var ctx = new BasicContext())
            {
                var vehicle = FindById(vehicleUpdate.Id);
                if (vehicle != null)
                {
                    vehicle.Name = vehicleUpdate.Name;
                    vehicle.NumberPlate = vehicleUpdate.NumberPlate;
                    vehicle.Power = vehicleUpdate.Power;
                    vehicle.VehicleType = vehicleUpdate.VehicleType;
                }
                else
                {
                    return vehicleUpdate;
                }
                SaveChanges(ctx);
                return vehicle;
            }
        }

        /// <summary>
        /// Create = Create vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public Vehicle CreateVehicle(Vehicle vehicle)
        {
            using (var ctx = new BasicContext())
            {
                ctx.Add(vehicle);
                SaveChanges(ctx);
                return vehicle;
            }
        }

        /// <summary>
        /// Delete = Delete vehicle
        /// </summary>
        /// <param name="vehicleId"></param>
        public void DeleteVehicle(int vehicleId)
        {
            using (var ctx = new BasicContext())
            {
                var vehicle = FindById(vehicleId);
                ctx.Remove(vehicle);
                SaveChanges(ctx);
            }
        }

        /// <summary>
        /// Find vehicle by Id
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        private Vehicle FindById(int vehicleId)
        {
            using (var ctx = new BasicContext())
            {
                return ctx.Vehicles.Find(vehicleId);
            }
        }

        /// <summary>
        /// Save changes
        /// </summary>
        /// <param name="ctx"></param>
        private void SaveChanges(BasicContext ctx)
        {
            ctx.SaveChanges();
        }

    }
}
