using WebApplication1.Entidades.Pets;

namespace WebApplication1.Repositories.Pets
{
    public interface IPetRepository
    {
        void Create(Pet pet);
    }
}
