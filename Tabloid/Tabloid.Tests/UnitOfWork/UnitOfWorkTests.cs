using System;
using System.Collections.Generic;

using Tabloid.Domain.Interfaces.Repositories;
using Tabloid.Infrastructure.Repositories;

using Xunit;

namespace Tabloid.Tests.UnitOfWork
{
    public class UnitOfWorkTests : IClassFixture<UnitOfWorkFixture>
    {
        private readonly UnitOfWorkFixture unitOfWorkFixture;

        public UnitOfWorkTests(UnitOfWorkFixture fixture)
        {
            unitOfWorkFixture = fixture;
        }

        [Fact]
        public void GenerateRepositories_Generates()
        {
            var repo1 = unitOfWorkFixture.UnitOfWork.GetRepository<IAlbumRepository>();
            var repo2 = unitOfWorkFixture.UnitOfWork.GetRepository<IGenreRepository>();
            var repo3 = unitOfWorkFixture.UnitOfWork.GetRepository<IArtistRepository>();
            var repo4 = unitOfWorkFixture.UnitOfWork.GetRepository<IGuitarTuningRepository>();
            var repo5 = unitOfWorkFixture.UnitOfWork.GetRepository<ISongRepository>();
            var repo6 = unitOfWorkFixture.UnitOfWork.GetRepository<ITabRepository>();

#pragma warning disable IDE0150 // Prefer 'null' check over type check
            Assert.True(repo1 is IAlbumRepository);
            Assert.True(repo2 is IGenreRepository);
            Assert.True(repo3 is IArtistRepository);
            Assert.True(repo4 is IGuitarTuningRepository);
            Assert.True(repo5 is ISongRepository);
            Assert.True(repo6 is ITabRepository);
#pragma warning restore IDE0150 // Prefer 'null' check over type check
        }

        [Fact]
        public void GetRepository_IncorrectParameter_ThrowsNotSupportedException()
        {
            Assert.Throws<NotSupportedException>(unitOfWorkFixture.UnitOfWork.GetRepository<string>);
            Assert.Throws<NotSupportedException>(unitOfWorkFixture.UnitOfWork.GetRepository<List<int>>);
        }
    }
}