using System.Collections.Generic;
using Nest;

namespace SmartDataApp.Helpers
{
    public static class QueryExtension
    {
        public static QueryContainer MatchAny<T>(this QueryContainerDescriptor<T> descriptor, Field field, List<string> values)
            where T : class
        {
            QueryContainer q = new QueryContainer();

            foreach (var value in values)
            {
                q |= descriptor.Term(t => t.Field(field).Value(value));
            }

            return q;
        }
    }
}