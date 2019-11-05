using Documentation.Core.Types;

namespace Documentation.Core
{
    /// <summary>
    /// Builder for creating formattable documents
    /// </summary>
    public interface IFormattableDocumentBuilder
    {
        /// <summary>
        /// Creates a new instance of the generic type that implements the
        /// <see cref="IPrintableDocument"/> interface.
        /// </summary>
        /// <typeparam name="T">Target type that should be created. Must implement <see cref="IPrintableDocument"/>.</typeparam>
        /// <returns>Activated instance of the generic type.</returns>
        T Build<T>() where T : IPrintableDocument;
    }
}