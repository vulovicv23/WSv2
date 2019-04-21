using WSV2.Program.Model;

namespace WSV2.Program.Processor
{
    /// <summary>
    /// 
    /// </summary>
    public interface IInputObjectProcessor
    {
        /// <summary>
        /// Sorts Input Object Entities by ID
        /// </summary>
        /// <param name="inputObject">Input Object gotten from json file</param>
        void SortEntities(InputObject inputObject);
    }
}