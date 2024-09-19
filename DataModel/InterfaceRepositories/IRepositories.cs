using DataModel.Entities;

namespace DataModel.InterfaceRepositories
{
    public interface ICity : IRepositoryBase<City> { }
    public interface IPoint : IRepositoryBase<Point> { }
    public interface IConcentration : IRepositoryBase<Concentration> { }
}
