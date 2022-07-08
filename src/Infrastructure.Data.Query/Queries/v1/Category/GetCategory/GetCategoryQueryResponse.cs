using System.Collections.Generic;

namespace MargunStore.Infrastructure.Data.Query.Queries.v1.Category.GetCategory
{
    public class GetCategoryQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
