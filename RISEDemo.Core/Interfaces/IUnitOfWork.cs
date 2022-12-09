namespace RISEDemo.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUrunRepository Urunler { get; }

        int Save();
    }
}
