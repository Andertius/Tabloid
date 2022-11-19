using System;
using System.Collections.Generic;

using Tabloid.Application.Interfaces.Repositories;

using Xunit;

namespace Tabloid.Tests.UnitOfWork;

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
        var repo4 = unitOfWorkFixture.UnitOfWork.GetRepository<ITuningRepository>();
        var repo5 = unitOfWorkFixture.UnitOfWork.GetRepository<ISongRepository>();
        var repo6 = unitOfWorkFixture.UnitOfWork.GetRepository<ITabRepository>();

        Assert.NotNull(repo1);
        Assert.NotNull(repo2);
        Assert.NotNull(repo3);
        Assert.NotNull(repo4);
        Assert.NotNull(repo5);
        Assert.NotNull(repo6);
    }

    [Fact]
    public void GetRepository_IncorrectParameter_ThrowsNotSupportedException()
    {
        Assert.Throws<NotSupportedException>(unitOfWorkFixture.UnitOfWork.GetRepository<string>);
        Assert.Throws<NotSupportedException>(unitOfWorkFixture.UnitOfWork.GetRepository<List<int>>);
    }
}
