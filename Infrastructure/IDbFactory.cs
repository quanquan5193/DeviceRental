using DeviceRental.Database;
using System;

namespace DeviceRental.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        ApplicationDbContext Init();
    }
}
