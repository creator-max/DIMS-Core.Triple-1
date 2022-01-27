using System;
using DIMS_Core.DataAccessLayer.Context;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    internal class SampleRepositoryFixture : IDisposable
    {
        public SampleRepositoryFixture()
        {
            Context = CreateContext();
            Repository = new SampleRepository(Context);

            InitDatabase();
        }

        public DimsContext Context { get; }

        public IRepository<Sample> Repository { get; }

        public int SampleId { get; private set; }

        public void Dispose()
        {
            Context.Dispose();
        }

        private void InitDatabase()
        {
            var entry = Context.Samples.Add(new Sample()
                                               {
                                                   Name = "Test Direction",
                                                   Description = "Test Description"
                                               });
            SampleId = entry.Entity.SampleId;

            Context.SaveChanges();
            entry.State = EntityState.Detached;
        }

        private static DimsContext CreateContext()
        {
            var options = GetOptions();

            return new DimsContext(options);
        }

        private static DbContextOptions<DimsContext> GetOptions()
        {
            var builder = new DbContextOptionsBuilder<DimsContext>().UseInMemoryDatabase(GetInMemoryDbName());

            return builder.Options;
        }

        private static string GetInMemoryDbName()
        {
            return $"InMemory_{Guid.NewGuid()}";
        }
    }
}