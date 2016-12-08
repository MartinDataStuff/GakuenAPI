using System.Collections.Generic;
using GakuenDLL.Entity;

namespace GakuenDLL.Interface
{
    public interface IRepository<T> where T : AbstractEntity
    {
        /// <summary>
        /// Will create an object based on the parameter.
        /// Will give an ID and return the object
        /// </summary>
        /// <param name="o"></param>
        /// <returns>The object with an ID</returns>
        T Create(T o);

        /// <summary>
        /// Returns the list with the objects
        /// </summary>
        /// <returns>List of objects</returns>
        List<T> ReadAll();

        /// <summary>
        /// Will return an object which matches the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A single object</returns>
        T Read(int id);

        /// <summary>
        /// Updates an object, by finding an object with the same id
        /// and replaces its propaties with the one in the parameter
        /// </summary>
        /// <param name="o"></param>
        /// <returns>The updated object</returns>
        T Update(T o);

        /// <summary>
        /// Removes the object from the list by comparing id
        /// </summary>
        /// <param name="o"></param>
        /// <returns>True if it was succesfull, otherwise false</returns>
        bool Delete(T o);
    }
}
