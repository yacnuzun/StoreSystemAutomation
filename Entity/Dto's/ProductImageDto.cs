using Core.Entities.Dto;

namespace Entity.Dto_s
{
    public class ProductImageDto : IDto
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
