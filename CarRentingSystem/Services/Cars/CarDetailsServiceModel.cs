namespace CarRentingSystem.Services.Cars
{
    public class CarDetailsServiceModel
    {
        public int Id { get; init; }
        public string Brand { get; init; }
        public string Model { get; init; }
        public string Description { get; init; }
        public string ImageUrl { get; init; }
        public int Year { get; init; }
        public int DealerId { get; init; }
        public string UserId { get; init; }
    }
}
