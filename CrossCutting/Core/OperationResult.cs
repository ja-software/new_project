using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrossCutting.Core
{
    /// <summary>
    /// Encapsulates an error from an operation.
    /// </summary>
    public class OperationError
    {
        /// <summary>
        /// Gets or sets the code for this error.
        /// </summary>
        /// <value>
        /// The code for this error.
        /// </value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description for this error.
        /// </summary>
        /// <value>
        /// The description for this error.
        /// </value>
        public string Description { get; set; }
    }

    /// <summary>
    /// Represents the result of an operation.
    /// </summary>
    public class OperationResult
    {
        #region Fields
        private List<OperationError> _errors = new List<OperationError>();
        #endregion

        #region Properties
        /// <summary>
        /// Flag indicating whether if the operation succeeded or not.
        /// </summary>
        /// <value>True if the operation succeeded, otherwise false.</value>
        public bool Succeeded { get; set; }

        /// <summary>
        /// An <see cref="IEnumerable{IOperationError}"/> of <see cref="OperationError"/>s containing an errors
        /// that occurred during the operation.
        /// </summary>
        /// <value>An <see cref="IEnumerable{IOperationError}"/> of <see cref="OperationError"/>s.</value>
        public IEnumerable<OperationError> Errors => _errors;
        #endregion

        #region Static Success/Failed
        /// <summary>
        /// Returns an <see cref="OperationResult"/> indicating a successful operation.
        /// </summary>
        /// <returns>An <see cref="OperationResult"/> indicating a successful operation.</returns>
        public static OperationResult Success => new OperationResult { Succeeded = true };

        /// <summary>
        /// Creates an <see cref="OperationResult"/> indicating a failed operation, with a list of <paramref name="errors"/> if applicable.
        /// </summary>
        /// <param name="errors">An optional array of <see cref="IOperationError"/> which caused the operation to fail.</param>
        /// <returns>An <see cref="OperationResult"/> indicating a failed operation, with a list of <paramref name="errors"/> if applicable.</returns>
        public static OperationResult Failed(params OperationError[] errors)
        {
            var result = new OperationResult { Succeeded = false };
            result.AddErrors(errors);
            return result;
        }
        #endregion

        #region ToString
        /// <summary>
        /// Converts the value of the current <see cref="OperationResult"/> object to its equivalent string representation.
        /// </summary>
        /// <returns>A string representation of the current <see cref="OperationResult"/> object.</returns>
        /// <remarks>
        /// If the operation was successful the ToString() will return "Succeeded" otherwise it returned 
        /// "Failed : " followed by a comma delimited list of error codes from its <see cref="Errors"/> collection, if any.
        /// </remarks>
        public override string ToString()
        {
            return Succeeded ?
                "Succeeded" :
                string.Format("Failed : {0}", string.Join(", ", Errors.Select(x => x.Code).ToList()));
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds the errors to the operation result.
        /// </summary>
        /// <param name="errors">Array of <see cref="IOperationError"/> to add.
        protected void AddErrors(params OperationError[] errors)
        {
            if (errors != null)
            {
                _errors.AddRange(errors);
            }
        }
        #endregion
    }

    /// <summary>
    /// Represents the result of an operation with a specific return type.
    /// </summary>
    /// <typeparam name="T">Type of the result returned from the operation.</typeparam>
    public class OperationResult<T> : OperationResult
    {
        #region Properties
        /// <summary>
        /// Gets the operation return value.
        /// </summary>
        public T ReturnValue { get; protected set; }
        #endregion

        #region Static Success
        /// <summary>
        /// Returns an <see cref="OperationResult{T}"/> indicating a successful operation with a return value.
        /// </summary>
        /// <param name="returnValue">Result return value.</param>
        /// <returns>An <see cref="OperationResult{T}"/> indicating a successful operation.</returns>
        public static new OperationResult<T> Success(T returnValue)
        {
            var result = new OperationResult<T>()
            {
                Succeeded = true,
                ReturnValue = returnValue
            };
            return result;
        }

        /// <summary>
        /// Creates an <see cref="OperationResult"/> indicating a failed operation, with a list of <paramref name="errors"/> if applicable.
        /// </summary>
        /// <param name="errors">An optional array of <see cref="OperationError"/>s which caused the operation to fail.</param>
        /// <returns>An <see cref="OperationResult"/> indicating a failed operation, with a list of <paramref name="errors"/> if applicable.</returns>
        public static new OperationResult<T> Failed(params OperationError[] errors)
        {
            var result = new OperationResult<T> { Succeeded = false };
            result.AddErrors(errors);
            return result;
        }
        #endregion
    }

    /// <summary>
    /// Represents the result of an operation with a specific return type.
    /// </summary>
    /// <typeparam name="T">Type of the result returned from the operation.</typeparam>
    public class OperationPagedResult<T> : OperationResult<T>
    {
        #region Properties
        /// <summary>
        /// Gets the total number of records found.
        /// </summary>
        public int TotalRecords { get; protected set; }

        /// <summary>
        /// Gets or sets the current page number.
        /// </summary>
        public int Page { get; protected set; }

        /// <summary>
        /// Gets or sets the page size (number of items per page).
        /// </summary>
        public int PageSize { get; protected set; }
        #endregion

        #region Static Success
        /// <summary>
        /// Returns an <see cref="OperationPagedResult{T}"/> indicating a successful operation with a return value.
        /// </summary>
        /// <param name="returnValue">Result return value.</param>
        /// <param name="totalRecords">Total number of records.</param>
        /// <param name="page">Current page number.</param>
        /// <param name="pageSize">Number of records per page.</param>
        /// <returns>An <see cref="OperationPagedResult{T}"/> indicating a successful operation.</returns>
        public static new OperationPagedResult<T> Success(T returnValue, int totalRecords, int page, int pageSize)
        {
            var result = new OperationPagedResult<T>()
            {
                Succeeded = true,
                ReturnValue = returnValue,
                TotalRecords = totalRecords,
                Page = page,
                PageSize = pageSize
            };
            return result;
        }

        /// <summary>
        /// Creates an <see cref="OperationPagedResult"/> indicating a failed operation, with a list of <paramref name="errors"/> if applicable.
        /// </summary>
        /// <param name="errors">An optional array of <see cref="OperationError"/>s which caused the operation to fail.</param>
        /// <returns>An <see cref="OperationPagedResult"/> indicating a failed operation, with a list of <paramref name="errors"/> if applicable.</returns>
        public static new OperationPagedResult<T> Failed(params OperationError[] errors)
        {
            var result = new OperationPagedResult<T> { Succeeded = false };
            result.AddErrors(errors);
            return result;
        }
        #endregion
    }
}
