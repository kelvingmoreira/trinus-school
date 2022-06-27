﻿using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School.Repository
{
    /// <summary>
    /// Defines methods for consulting an entity's backend database.
    /// </summary>
    /// <typeparam name="T">A class that represents a database entity of type <see cref="DbObject"/>.</typeparam>
    public interface IReadOnlyRepository<T> where T : class
    {

        /// <summary>
        /// Returns all entities of <typeparamref name="T"/>. 
        /// </summary>
        IEnumerable<T> GetAsync();

        /// <summary>
        /// Returns all entities of <typeparamref name="T"/> that satisfy a given predicate.
        /// </summary>
        /// /// <param name="predicate">The predicate expression.</param>
        IEnumerable<T> GetWhereAsync(Func<T, bool> predicate);

        /// <summary>
        /// Returns the first entity that satisfies a given predicate, or <see langword="null"/> if none is found.
        /// </summary>
        /// <param name="predicate">The predicate expression.</param>
        /// <returns>The first entity where the given predicate is <see langword="true"/>, or <see langword="null"/>.</returns>
        T GetAsync(Func<T, bool> predicate);
    }

    /// <summary>
    /// Defines methods for interacting with an entity's backend database.
    /// </summary>
    /// <typeparam name="T">A class that represents a database entity of type <see cref="DbObject"/>.</typeparam>
    public interface IRepository<T> : IReadOnlyRepository<T> where T : DbObject
    {
        /// <summary>
        /// Creates a new entity of type <typeparamref name="T"/> on database.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <returns>
        /// The created entry. 
        /// </returns>
        /// /// <exception cref="ArgumentNullException" />
        T InsertAsync(T entity);

        /// <summary>
        /// Updates the entity of type <typeparamref name="T"/> on database.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>
        /// The updated entry. 
        /// </returns>
        /// /// <exception cref="ArgumentNullException" />
        T UpdateAsync(T entity);

        /// <summary>
        /// Removes <typeparamref name="T"/> entity with a given ID from database.
        /// </summary>
        /// <param name="id">The entity ID.</param>
        /// /// <returns>
        /// <see langword="true"/> if the given entity ID exists and is removed, <see langword="false"/> otherwise. 
        /// </returns>
        bool DeleteAsync(int id);
    }
}
