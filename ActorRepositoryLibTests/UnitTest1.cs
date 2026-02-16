using System.Linq;
using ActorRepositoryLib;
using Xunit;

namespace ActorRepositoryLibTests
{
    public class UnitTest1
    {

        [Fact]
        public void Add_AssignsIdAndReturnsActor()
        {
            var repo = new ActorsRepository();
            var actor = new Actor { Name = "Alice", BirthYear = 1980 };

            var added = repo.Add(actor);

            Assert.Equal(1, added.ID);
            Assert.Equal("Alice", added.Name);
            Assert.Equal(1980, added.BirthYear);
        }

        [Fact]
        public void GetAll_ReturnsAllAddedActors()
        {
            var repo = new ActorsRepository();
            repo.Add(new Actor { Name = "A", BirthYear = 1970 });
            repo.Add(new Actor { Name = "B", BirthYear = 1980 });

            var all = repo.Get().ToList();

            Assert.Equal(2, all.Count);
            Assert.Contains(all, a => a.Name == "A");
            Assert.Contains(all, a => a.Name == "B");
        }

        [Fact]
        public void GetByID_ReturnsCorrectActorOrNull()
        {
            var repo = new ActorsRepository();
            repo.Add(new Actor { Name = "Alice", BirthYear = 1980 });

            var found = repo.GetByID(1);
            var notFound = repo.GetByID(999);

            Assert.NotNull(found);
            Assert.Equal("Alice", found!.Name);
            Assert.Null(notFound);
        }

        [Fact]
        public void Delete_RemovesAndReturnsActor()
        {
            var repo = new ActorsRepository();
            repo.Add(new Actor { Name = "ToDelete", BirthYear = 1960 });

            var deleted = repo.Delete(1);

            Assert.NotNull(deleted);
            Assert.Equal(1, deleted!.ID);
            Assert.Null(repo.GetByID(1));
        }

        [Fact]
        public void Update_UpdatesExistingAndReturnsUpdated()
        {
            var repo = new ActorsRepository();
            repo.Add(new Actor { Name = "OldName", BirthYear = 1950 });

            var updated = repo.Update(1, new Actor { Name = "NewName", BirthYear = 1990 });

            Assert.NotNull(updated);
            Assert.Equal("NewName", updated!.Name);
            Assert.Equal(1990, updated.BirthYear);
        }

        [Fact]
        public void Update_NonExisting_ReturnsNull()
        {
            var repo = new ActorsRepository();

            var updated = repo.Update(999, new Actor { Name = "NoOne", BirthYear = 2000 });

            Assert.Null(updated);
        }

        [Fact]
        public void Actor_ToString_ReturnsExpectedFormat()
        {
            var actor = new Actor { ID = 5, Name = "Bob", BirthYear = 1975 };

            var s = actor.ToString();

            Assert.Equal("ID: 5, Name: Bob, Birth Year: 1975", s);
        }
    }
}
