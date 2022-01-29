using System;

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
            var repo1 = unitOfWorkFixture.UnitOfWork.GetRepository<AlbumRepository>();
            var repo2 = unitOfWorkFixture.UnitOfWork.GetRepository<GenreRepository>();
            var repo3 = unitOfWorkFixture.UnitOfWork.GetRepository<ArtistRepository>();
            var repo4 = unitOfWorkFixture.UnitOfWork.GetRepository<GuitarTuningRepository>();
            var repo5 = unitOfWorkFixture.UnitOfWork.GetRepository<SongRepository>();
            var repo6 = unitOfWorkFixture.UnitOfWork.GetRepository<TabRepository>();

            Assert.IsType<AlbumRepository>(repo1);
            Assert.IsType<GenreRepository>(repo2);
            Assert.IsType<ArtistRepository>(repo3);
            Assert.IsType<GuitarTuningRepository>(repo4);
            Assert.IsType<SongRepository>(repo5);
            Assert.IsType<TabRepository>(repo6);
        }

        [Fact]
        public void GetRepository_IncorrectParameter_ThrowsNotSupportedException()
        {
            Assert.Throws<NotSupportedException>(unitOfWorkFixture.UnitOfWork.GetRepository<string>);
        }
    }
}