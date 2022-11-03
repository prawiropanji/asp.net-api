namespace WebApi.Repositories.Interfaces
{
    public interface IRepository<Entity, Key> where Entity : class
    {
        public IEnumerable<Entity> Get();

        public Entity Get(Key id);

        public int Create(Entity entity);
        public int Update(Entity entity);
        public int Delete(Key id);
    }
}
