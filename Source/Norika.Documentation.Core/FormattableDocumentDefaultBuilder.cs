using System;
using System.Linq;
using Norika.Documentation.Core.Types;

namespace Norika.Documentation.Core
{
    /// <summary>
    /// Default formattable document builder
    /// </summary>
    public class FormattableDocumentDefaultBuilder : IFormattableDocumentBuilder
    {
        /// <summary>
        /// <inheritdoc cref="IFormattableDocumentBuilder.Build{T}"/>
        /// </summary>
        public T Build<T>() where T : IPrintableDocument
        {
            var targetType = GetAssignableClassForInterface(typeof(T));
            return (T) Activator.CreateInstance(targetType ?? throw new TypeInitializationException(typeof(T).FullName, null));
        }

        /// <summary>
        /// Returns the first class from the current app domain that implements the
        /// given interface type.
        /// </summary>
        /// <returns>Type of the class that implements the interface.</returns>
        public Type GetAssignableClassForInterface(Type interfaceType)
        { 
            if(!interfaceType.IsInterface)
                throw new TypeLoadException($"The type '{interfaceType.FullName}' is not an interface.");
            
            return AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(s => s.GetTypes()).FirstOrDefault(interfaceType.IsAssignableFrom);
        }
    }
}
