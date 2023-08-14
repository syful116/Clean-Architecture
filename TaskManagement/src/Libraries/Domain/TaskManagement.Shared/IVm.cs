

namespace TaskManagement.Shared
{
   public interface IVm<T> where T : IEquatable<T>
    {

        T id { get; set; }

    }
    public interface IVm : IVm<int>
    {

    }
}
