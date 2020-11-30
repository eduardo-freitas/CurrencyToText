using System.Collections.Generic;

namespace CurrencyToText.Domain.Model
{
    public class DomainResponse<T>
    {
        public DomainResponse(T result, string domainError)
        {
            Result = result;
            DomainError = domainError;
        }

        public T Result { get; set; }
        public string DomainError { get; set; }
    }
}

