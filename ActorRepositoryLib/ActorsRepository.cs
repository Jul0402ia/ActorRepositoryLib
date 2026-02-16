namespace ActorRepositoryLib
{
    public class ActorsRepository
    {
        private List<Actor> actors = new List<Actor>();
        private int nextId = 1;

        public IEnumerable<Actor> Get(int? birthYearBefore = null, int? birthYearAfter = null, string? nameStartsWith = null)
        {
            IEnumerable<Actor> result = new List<Actor>(actors);
            if (birthYearBefore != null)
            {
                result = result.Where(result => result.BirthYear < birthYearBefore.Value);
            }
            if (birthYearAfter != null)
            {
                result = result.Where(result => result.BirthYear > birthYearAfter.Value);
            }
            if (nameStartsWith != null)
            {
                result = result.Where(result => result.Name != null && result.Name.StartsWith(nameStartsWith));
            }
            return result;
        }
        
        public Actor? GetByID(int id)
        {
            return actors.FirstOrDefault(a => a.ID == id);
        }
        public Actor Add(Actor actor)
        {
            actor.ID = nextId++;
            actors.Add(actor);
            return actor;
        }
        public Actor Delete(int id)
        {
            var actor = GetByID(id);
            if (actor != null)
            {
                actors.Remove(actor);
                return actor;
            }
            return null;
        }

        public Actor? Update(int id, Actor updatedActorData)
        {
            Actor? existingActorData = GetByID(id);
            if (existingActorData != null)
            {
                existingActorData.Name = updatedActorData.Name;
                existingActorData.BirthYear = updatedActorData.BirthYear;
                return existingActorData;
            }
            return null;
        
        }
    }
}
