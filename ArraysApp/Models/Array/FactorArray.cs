using ArraysApp.lib;

namespace ArraysApp.Models
{
    public class FactorArray<T>: BaseArray<T>
    {
        public FactorArray(int initLength, int factor) : base(factor, initLength) {

        }
    }
}
