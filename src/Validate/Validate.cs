using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Validate
{
    public class Validate
    {
        private const string DefaultIsTrueExceptionMessage = "The expression is false";
        private const string DefaultNotNullExceptionMessage = "The object is null";
        private const string DefaultNotEmptyArrayExceptionMessage = "The array is null or empty";
        private const string DefaultNotEmptyCollectionExceptionMessage = "The collection is null or empty";
        private const string DefaultNotBlankExceptionMessage = "The string is null or empty";
        private const string DefaultNoNullElementsArrayExceptionMessage = "The array is null or contains a null element";
        private const string DefaultNoNullElementsCollectionExceptionMessage = "The collection is null or contains a null element";
        private const string DefaultValidIndexArrayExceptionMessage = "The array is null or the array index, {0}, is invalid";
        private const string DefaultValidIndexCollectionExceptionMessage = "The collection is null or the collection index, {0}, is invalid";
        private const string DefaultValidStateExceptionMessage = "The state is invalid";
        private const string DefaultMatchesPatternExceptionMessage = "The input does not match the pattern";
        private const string DefaultInclusiveBetweenExceptionMessage = "The value does not fall within the specified boundaries";
        private const string DefaultExclusiveBetweenExceptionMessage = "The value does not fall within the specified boundaries";
        private const string DefaultIsAssignableFromExceptionMessage = "The superType, {0}, is not assignable from type, {1}";
        private const string DefaultIsInstanceOfExceptionMessage = "The object is not an instance of type, {0}";

        /// <summary>
        /// Checks if the expression is true
        /// </summary>
        /// <param name="expression"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void IsTrue(bool expression)
        {
            IsTrue(expression, DefaultIsTrueExceptionMessage);
        }

        /// <summary>
        ///  Checks if the expression is true
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void IsTrue(bool expression, string message, params object[] args)
        {
            if (!expression)
            {
                throw new ArgumentException(string.Format(message, args));
            }
        }

        /// <summary>
        /// Checks if the object is null
        /// </summary>
        /// <param name="o"></param>
        /// <exception cref="NullReferenceException"></exception>
        public static void NotNull(object o)
        {
            NotNull(o, DefaultNotNullExceptionMessage);
        }


        /// <summary>
        /// Checks if the object is null
        /// </summary>
        /// <param name="o"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        /// <exception cref="NullReferenceException"></exception>
        public static void NotNull(object o, string message, params object[] args)
        {
            if (o == null)
            {
                throw new NullReferenceException(string.Format(message, args));
            }
        }

        /// <summary>
        ///  Checks if the array is null or empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="NullReferenceException"></exception>
        public static void NotEmpty<T>(T[] array)
        {
            NotEmpty(array, DefaultNotEmptyArrayExceptionMessage);
        }

        /// <summary>
        ///  Checks if the array is null or empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="NullReferenceException"></exception>
        public static void NotEmpty<T>(T[] array, string message, params object[] args)
        {
            NotNull(array, string.Format(message, args));

            if (array.Length == 0)
            {
                throw new ArgumentException(string.Format(message, args));
            }
        }

        /// <summary>
        ///  Checks if the collection is null or empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="NullReferenceException"></exception>
        public static void NotEmpty<T>(ICollection<T> collection)
        {
            NotEmpty(collection, DefaultNotEmptyCollectionExceptionMessage);
        }

        /// <summary>
        ///  Checks if the collection is null or empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="NullReferenceException"></exception>
        public static void NotEmpty<T>(ICollection<T> collection, string message, params object[] args)
        {
            NotNull(collection, string.Format(message, args));

            if (collection.Count == 0)
            {
                throw new ArgumentException(string.Format(message, args));
            }
        }

        /// <summary>
        /// Checks if string is null or empty
        /// </summary>
        /// <param name="input"></param>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void NotBlank(string input)
        {
            NotBlank(input, DefaultNotBlankExceptionMessage);
        }

        /// <summary>
        /// Checks if string is null or empty
        /// </summary>
        /// <param name="input"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void NotBlank(string input, string message, params object[] args)
        {
            NotNull(input, string.Format(message, args));

            if (input.Length == 0)
            {
                throw new ArgumentException(string.Format(message, args));
            }
        }

        /// <summary>
        /// Checks if the array is null or contains null elements
        /// </summary>
        /// <param name="array"></param>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void NoNullElements<T>(T[] array)
        {
            NoNullElements(array, DefaultNoNullElementsArrayExceptionMessage);
        }

        /// <summary>
        /// Checks if the array is null or contains null elements
        /// </summary>
        /// <param name="array"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void NoNullElements<T>(T[] array, string message, params object[] args)
        {
            NotNull(array, string.Format(message, args));

            if (array.Any(e => e == null))
            {
                throw new ArgumentException(string.Format(message, args));
            }
        }

        /// <summary>
        /// Checks if the array is null or contains null elements
        /// </summary>
        /// <param name="collection"></param>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void NoNullElements<T>(ICollection<T> collection)
        {
            NoNullElements(collection, DefaultNoNullElementsCollectionExceptionMessage);
        }

        /// <summary>
        /// Checks if the collection is null or contains null elements
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void NoNullElements<T>(ICollection<T> collection, string message, params object[] args)
        {
            NotNull(collection, string.Format(message, args));

            if (collection.Any(e => e == null))
            {
                throw new ArgumentException(string.Format(message, args));
            }
        }

        /// <summary>
        /// Checks if the array is null or the index is invalid
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public static void ValidIndex<T>(T[] array, int index)
        {
            ValidIndex(array, index, DefaultValidIndexArrayExceptionMessage, index);
        }

        /// <summary>
        /// Checks if the array is null or the index is invalid
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public static void ValidIndex<T>(T[] array, int index, string message, params object[] args)
        {
            NotNull(array, string.Format(message, args));

            if (index < 0 || index >= array.Length)
            {
                throw new IndexOutOfRangeException(string.Format(message, args));
            }
        }

        /// <summary>
        /// Checks if the collection is null or the index is invalid
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="index"></param>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public static void ValidIndex<T>(ICollection<T> collection, int index)
        {
            ValidIndex(collection, index, DefaultValidIndexCollectionExceptionMessage, index);
        }

        /// <summary>
        /// Checks if the collection is null or the index is invalid
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="index"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public static void ValidIndex<T>(ICollection<T> collection, int index, string message, params object[] args)
        {
            NotNull(collection, string.Format(message, args));

            if (index < 0 || index >= collection.Count)
            {
                throw new IndexOutOfRangeException(string.Format(message, args));
            }
        }

        /// <summary>
        /// Checks if the state is valid
        /// </summary>
        /// <param name="expression"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void ValidState(bool expression)
        {
            ValidState(expression, DefaultValidStateExceptionMessage);
        }

        /// <summary>
        /// Checks if the state is valid
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void ValidState(bool expression, string message, params object[] args)
        {
            if (!expression)
            {
                throw new InvalidOperationException(string.Format(message, args));
            }
        }

        /// <summary>
        /// Checks if the input matches the pattern
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void MatchesPattern(string input, string pattern)
        {
            MatchesPattern(input, pattern, DefaultMatchesPatternExceptionMessage);
        }

        /// <summary>
        /// Checks if the input matches the pattern
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void MatchesPattern(string input, string pattern, string message, params object[] args)
        {
            if (!Regex.IsMatch(input, pattern))
            {
                throw new ArgumentException(string.Format(message, args));
            }
        }

        /// <summary>
        /// Checks if the input is between or equal to the bounds
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void InclusiveBetween<T>(T start, T end, IComparable<T> value)
        {
            InclusiveBetween(start, end, value, DefaultInclusiveBetweenExceptionMessage);
        }

        /// <summary>
        /// Checks if the input is between or equal to the bounds
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="value"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void InclusiveBetween<T>(T start, T end, IComparable<T> value, string message, params object[] args)
        {
            if (value.CompareTo(start) < 0 || value.CompareTo(end) > 0)
            {
                throw new ArgumentException(string.Format(message, args));
            }
        }

        /// <summary>
        /// Checks if the input is between the bounds
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void ExclusiveBetween<T>(T start, T end, IComparable<T> value)
        {
            ExclusiveBetween(start, end, value, DefaultExclusiveBetweenExceptionMessage);
        }

        /// <summary>
        /// Checks if the input is between the bounds
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="value"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void ExclusiveBetween<T>(T start, T end, IComparable<T> value, string message, params object[] args)
        {
            if (value.CompareTo(start) <= 0 || value.CompareTo(end) >= 0) {
                throw new ArgumentException(string.Format(message, args));
            }
        }

        /// <summary>
        /// Checks if the object is an instance of the type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="o"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void IsInstanceOf(Type type, object o)
        {
            IsInstanceOf(type, o, DefaultIsInstanceOfExceptionMessage, type.Name);
        }

        /// <summary>
        /// Checks if the object is an instance of the type 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="o"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void IsInstanceOf(Type type, object o, string message, params object[] args) 
        {
            if (!type.IsInstanceOfType(o))
            {
                throw new ArgumentException(string.Format(message, args));
            }
        }
        
        /// <summary>
        /// Checks if the supertype is assignable from the type
        /// </summary>
        /// <param name="superType"></param>
        /// <param name="type"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void IsAssignableFrom(Type superType, Type type)
        {
            IsAssignableFrom(superType, type, DefaultIsAssignableFromExceptionMessage, superType.Name, type.Name);
        }

        /// <summary>
        /// Checks if the supertype is assignable from the type
        /// </summary>
        /// <param name="superType"></param>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void IsAssignableFrom(Type superType, Type type, string message, params object[] args) 
        {
            if (!superType.IsAssignableFrom(type))
            {
                throw new ArgumentException(string.Format(message, args));
            }
        }
    }
}